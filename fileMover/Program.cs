
using System;
using System.IO;

namespace fileMover
{
    class Program
    {
        static void Main(string[] args)
        {

            MonitorDirectory();

            Console.ReadLine();
        }

        public static void MonitorDirectory()
        {
            string path = @"C:\Users\Cameron\Documents\Test File Mover\";

            FileSystemWatcher watcher = new FileSystemWatcher();
            
                watcher.Path = path;
                watcher.EnableRaisingEvents = true;

                watcher.NotifyFilter = NotifyFilters.FileName 
                                    | NotifyFilters.LastAccess 
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.DirectoryName;

               watcher.Filter = "employee.txt";

                watcher.Created += OnCreated;
                //watcher.Deleted += OnCreated;

                watcher.EnableRaisingEvents = true;

         

        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string destinationPath = @"C:\Users\Cameron\Documents\Test 2";
              
            string existingFileName = System.IO.Path.GetFileNameWithoutExtension(Path.Combine(destinationPath, @"\employee*"));
            string newFilename = existingFileName + "1 test"; 

            if(File.Exists(Path.Combine(destinationPath, e.Name)))
            {
                //string
            }
            
            Console.WriteLine("File name: {0}, - File Full Path: {1}", newFilename, e.FullPath);
            System.IO.File.Copy(e.FullPath, Path.Combine(destinationPath, e.Name));
                
        }
    }
}
