namespace modules_8._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string catalog = @"C:\newPapka";
            DeleteAllFileInCatalog(catalog);

        }

        static void DeleteAllFileInCatalog(string path)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                string[] subDirectories = Directory.GetDirectories(path);

                DateTime dateTime = DateTime.Now;
                TimeSpan timeSpan = TimeSpan.FromMinutes(30);
                

                    foreach (string file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        TimeSpan accessTime = dateTime - fileInfo.LastAccessTime;
                        if (accessTime > timeSpan)
                        {
                            File.Delete(file);
                            Console.WriteLine($"Удалён файл {file}");
                        }
                    }
                
                foreach (string subDirectory in subDirectories)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(subDirectory);
                    TimeSpan accessTimeCatalog = dateTime - directoryInfo.LastAccessTime;
                    if (accessTimeCatalog > timeSpan)
                    {
                        directoryInfo.Delete(true);
                        Console.WriteLine($"Удалён каталог {subDirectory}\n");
                    }
                    
                }


            }
            else Console.WriteLine("Папка не существует");
        }
    }
}
