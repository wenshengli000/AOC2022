namespace AdventOfCode
{
    internal class Day7
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("InputData/input7.txt");
            
            DirectoryAndSize? rootDirectoryAndSize = BuildAllDirectories(lines);

            long sumTotalSizeAtMost1000 = 0;
            CalculateSumTotalSize(rootDirectoryAndSize, 100000, ref sumTotalSizeAtMost1000);
            if (sumTotalSizeAtMost1000 != 1141028) throw new Exception();
          
            var spaceToFreeUp = 30000000 - (70000000 - rootDirectoryAndSize.TotalFileSize);
            var sizeOfSmallestDirectoryToDelete = FindSizeOfSmallestDirectoryToDelete(rootDirectoryAndSize, spaceToFreeUp);
            if (sizeOfSmallestDirectoryToDelete != 8278005) throw new Exception();

            Console.ReadLine();
        }

        private static DirectoryAndSize? BuildAllDirectories(string[] lines)
        {
            DirectoryAndSize? root = null;
            DirectoryAndSize? current = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("$"))
                {
                    if (line.StartsWith("$ cd"))
                    {
                        var currentDirName = line.Split(new[] { ' ' })[2];
                        if (currentDirName.Equals(".."))
                        {
                            current = current.ParentDirectoryAndSize;
                            continue;
                        }

                        if (root == null)
                        {
                            root = new DirectoryAndSize(currentDirName, 0, new List<DirectoryAndSize>(), null);
                            current = root;
                        }
                        else
                        {
                            current = current.SubDirectoryAndSizes.FirstOrDefault(x =>
                                x.DirectoryName.Equals(currentDirName));
                        }
                    }

                    if (line.StartsWith("$ ls"))
                    {
                    }
                }
                else if (line.StartsWith("dir "))
                {
                    var subDirectoryName = line.Split(new char[] { ' ' })[1];
                    current.SubDirectoryAndSizes.Add(new DirectoryAndSize(subDirectoryName, 0,
                        new List<DirectoryAndSize>(), current));
                }
                else if (char.IsDigit(line[0]))
                {
                    var size = Convert.ToInt32(line.Split(new[] { ' ' })[0]);
                    current.TotalFileSize += size;
                    UpdateParentTotalFileSize(current, size);
                }
            }

            return root;
        }

        private static long FindSizeOfSmallestDirectoryToDelete(DirectoryAndSize rootDirectoryAndSize, long spaceToFreeUp)
        {
            var listOfDirectoryAndSizes = new List<DirectoryAndSize>();
            GetAllDirectories(rootDirectoryAndSize, listOfDirectoryAndSizes);

            long sizeOfSmallestDirectoryToDelete = 0;
            foreach (var dir in listOfDirectoryAndSizes.OrderBy(x => x.TotalFileSize).ToList())
            {
                if (dir.TotalFileSize >= spaceToFreeUp)
                {
                    sizeOfSmallestDirectoryToDelete = dir.TotalFileSize;
                    break;
                }
            }

            return sizeOfSmallestDirectoryToDelete;
        }

        private static void GetAllDirectories(DirectoryAndSize? currentDir, List<DirectoryAndSize>  listOfDirectoryAndSizes)
        {
            listOfDirectoryAndSizes.Add(currentDir);
            foreach (var subDir in currentDir.SubDirectoryAndSizes)
            {
                GetAllDirectories(subDir, listOfDirectoryAndSizes);
            }
        }

        private static void CalculateSumTotalSize(DirectoryAndSize? currentDir, int mostSize, ref long sum)
        {
            if (currentDir.TotalFileSize <= mostSize)
            {
                sum += currentDir.TotalFileSize;
            }

            foreach (var subDir in currentDir.SubDirectoryAndSizes)
            {
                CalculateSumTotalSize(subDir, mostSize, ref sum);
            }
        }

        private static void UpdateParentTotalFileSize(DirectoryAndSize currentDirectoryAndSize, int size)
        {
            var parentDir = currentDirectoryAndSize.ParentDirectoryAndSize;
            while (parentDir!=null)
            {
                parentDir.TotalFileSize += size;
                parentDir = parentDir.ParentDirectoryAndSize;
            }
        }
    }

    internal class DirectoryAndSize
    {
        public DirectoryAndSize(string directoryName, long totalFileSize, List<DirectoryAndSize> subDirectoryAndSizes, DirectoryAndSize parentDirectoryAndSize)
        {
            TotalFileSize = totalFileSize;
            SubDirectoryAndSizes = subDirectoryAndSizes;
            ParentDirectoryAndSize = parentDirectoryAndSize;
            DirectoryName = directoryName;
        }

        public string DirectoryName { get; set; }
        public long TotalFileSize { get; set; }
        public DirectoryAndSize ParentDirectoryAndSize { get; set; }
        public List<DirectoryAndSize> SubDirectoryAndSizes { get; set;}
    }
}
