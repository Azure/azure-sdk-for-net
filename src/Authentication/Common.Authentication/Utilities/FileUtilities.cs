// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Azure.Common.Authentication
{
    public static class FileUtilities
    {
        static FileUtilities()
        {
            DataStore = new DiskDataStore();
        }
        
        public static IDataStore DataStore { get; set; }

        public static string GetAssemblyDirectory()
        {
            var assemblyPath = Uri.UnescapeDataString(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            return Path.GetDirectoryName(assemblyPath);
        }

        public static string GetContentFilePath(string fileName)
        {
            return GetContentFilePath(GetAssemblyDirectory(), fileName);
        }

        public static string GetContentFilePath(string startDirectory, string fileName)
        {
            string path = Path.Combine(startDirectory, fileName);

            // Try search in the subdirectories in case that the file path does not exist in root path
            if (!DataStore.FileExists(path) && !DataStore.DirectoryExists(path))
            {
                try
                {
                    path = DataStore.GetDirectories(startDirectory, fileName, SearchOption.AllDirectories).FirstOrDefault();

                    if (string.IsNullOrEmpty(path))
                    {
                        path = DataStore.GetFiles(startDirectory, fileName, SearchOption.AllDirectories).First();
                    }
                }
                catch
                {
                    throw new FileNotFoundException(Path.Combine(startDirectory, fileName));
                }
            }

            return path;
        }

        public static string GetWithProgramFilesPath(string directoryName, bool throwIfNotFound)
        {
            string programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if (DataStore.DirectoryExists(Path.Combine(programFilesPath, directoryName)))
            {
                return Path.Combine(programFilesPath, directoryName);
            }
            else
            {
                if (programFilesPath.IndexOf(Resources.x86InProgramFiles, StringComparison.InvariantCultureIgnoreCase) == -1)
                {
                    programFilesPath += Resources.x86InProgramFiles;
                    if (throwIfNotFound)
                    {
                        Validate.ValidateDirectoryExists(Path.Combine(programFilesPath, directoryName));
                    }
                    return Path.Combine(programFilesPath, directoryName);
                }
                else
                {
                    programFilesPath = programFilesPath.Replace(Resources.x86InProgramFiles, String.Empty);
                    if (throwIfNotFound)
                    {
                        Validate.ValidateDirectoryExists(Path.Combine(programFilesPath, directoryName));
                    }
                    return Path.Combine(programFilesPath, directoryName);
                }
            }
        }

        /// <summary>
        /// Copies a directory.
        /// </summary>
        /// <param name="sourceDirName">The source directory name</param>
        /// <param name="destDirName">The destination directory name</param>
        /// <param name="copySubDirs">Should the copy be recursive</param>
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dirs = DataStore.GetDirectories(sourceDirName);

            if (!DataStore.DirectoryExists(sourceDirName))
            {
                throw new DirectoryNotFoundException(String.Format(Resources.PathDoesNotExist, sourceDirName));
            }

            DataStore.CreateDirectory(destDirName);

            var files = DataStore.GetFiles(sourceDirName);
            foreach (var file in files)
            {
                string tempPath = Path.Combine(destDirName, Path.GetFileName(file));
                DataStore.CopyFile(file, tempPath);
            }

            if (copySubDirs)
            {
                foreach (var subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, Path.GetDirectoryName(subdir));
                    DirectoryCopy(subdir, temppath, copySubDirs);
                }
            }
        }

        /// <summary>
        /// Ensures that a directory exists beofre attempting to write a file
        /// </summary>
        /// <param name="pathName">The path to the file that will be created</param>
        public static void EnsureDirectoryExists(string pathName)
        {
            Validate.ValidateStringIsNullOrEmpty(pathName, "Settings directory");
            string directoryPath = Path.GetDirectoryName(pathName);
            if (!DataStore.DirectoryExists(directoryPath))
            {
                DataStore.CreateDirectory(directoryPath);
            }
        }

        /// <summary>
        /// Create a unique temp directory.
        /// </summary>
        /// <returns>Path to the temp directory.</returns>
        public static string CreateTempDirectory()
        {
            string tempPath;
            do
            {
                tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            }
            while (DataStore.DirectoryExists(tempPath) || DataStore.FileExists(tempPath));

            DataStore.CreateDirectory(tempPath);
            return tempPath;
        }

        /// <summary>
        /// Copy a directory from one path to another.
        /// </summary>
        /// <param name="sourceDirectory">Source directory.</param>
        /// <param name="destinationDirectory">Destination directory.</param>
        public static void CopyDirectory(string sourceDirectory, string destinationDirectory)
        {
            Debug.Assert(!String.IsNullOrEmpty(sourceDirectory), "sourceDictory cannot be null or empty!");
            Debug.Assert(Directory.Exists(sourceDirectory), "sourceDirectory must exist!");
            Debug.Assert(!String.IsNullOrEmpty(destinationDirectory), "destinationDirectory cannot be null or empty!");
            Debug.Assert(!Directory.Exists(destinationDirectory), "destinationDirectory must not exist!");

            foreach (string file in DataStore.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories))
            {
                string relativePath = file.Substring(
                    sourceDirectory.Length + 1,
                    file.Length - sourceDirectory.Length - 1);
                string destinationPath = Path.Combine(destinationDirectory, relativePath);

                string destinationDir = Path.GetDirectoryName(destinationPath);
                if (!DataStore.DirectoryExists(destinationDir))
                {
                    DataStore.CreateDirectory(destinationDir);
                }

                DataStore.CopyFile(file, destinationPath);
            }
        }

        public static Encoding GetFileEncoding(string path)
        {
            Encoding encoding;


            if (DataStore.FileExists(path))
            {
                using (StreamReader r = new StreamReader(DataStore.ReadFileAsStream(path)))
                {
                    encoding = r.CurrentEncoding;
                }
            }
            else
            {
                encoding = Encoding.Default;
            }

            return encoding;
        }

        public static string CombinePath(params string[] paths)
        {
            return Path.Combine(paths);
        }

        /// <summary>
        /// Returns true if path is a valid directory.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsValidDirectoryPath(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return false;
            }

            try
            {
                FileAttributes attributes = DataStore.GetFileAttributes(path);

                if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void RecreateDirectory(string dir)
        {
            if (DataStore.DirectoryExists(dir))
            {
                DataStore.DeleteDirectory(dir);
            }

            DataStore.CreateDirectory(dir);
        }

        /// <summary>
        /// Gets the root installation path for the given Azure module.
        /// </summary>
        /// <param name="module" >The module name</param>
        /// <returns>The module full path</returns>
        public static string GetPSModulePathForModule(AzureModule module)
        {
            return GetContentFilePath(GetInstallPath(), GetModuleFolderName(module));
        }

        /// <summary>
        /// Gets the root directory for all modules installation.
        /// </summary>
        /// <returns>The install path</returns>
        public static string GetInstallPath()
        {
            string currentPath = GetAssemblyDirectory();
            while (!currentPath.EndsWith(GetModuleFolderName(AzureModule.AzureProfile)) &&
                   !currentPath.EndsWith(GetModuleFolderName(AzureModule.AzureResourceManager)) &&
                   !currentPath.EndsWith(GetModuleFolderName(AzureModule.AzureServiceManagement)))
            {
                currentPath = Directory.GetParent(currentPath).FullName;
            }

            // The assemption is that the install directory looks like that:
            // ServiceManagement
            //  AzureServiceManagement
            //      <Service Commands Folders>
            // ResourceManager
            //  AzureResourceManager
            //      <Service Commands Folders>
            // Profile
            //  AzureSMProfile
            //      <Service Commands Folders>
            return Directory.GetParent(currentPath).FullName;
        }

        public static string GetModuleName(AzureModule module)
        {
            switch (module)
            {
                case AzureModule.AzureServiceManagement:
                    return "Azure";

                case AzureModule.AzureResourceManager:
                    return "AzureResourceManager";

                case AzureModule.AzureProfile:
                    return "AzureProfile";

                default:
                    throw new ArgumentOutOfRangeException(module.ToString());
            }
        }

        public static string GetModuleFolderName(AzureModule module)
        {
            return module.ToString().Replace("Azure", "");
        }
    }
}
