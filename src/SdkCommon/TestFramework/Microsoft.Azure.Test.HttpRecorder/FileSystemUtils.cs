// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Diagnostics;
using System.IO;

namespace Microsoft.Azure.Test.HttpRecorder
{
    public class FileSystemUtils
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void DeleteDirectory(string dir)
        {
            Directory.Delete(dir);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }
        
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public string[] GetDirectories(string sourceDirName, string pattern, bool recursive)
        {
            return Directory.GetDirectories(sourceDirName, 
                                            pattern, 
                                            recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        public string GetEnvironmentVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable);
        }

        public string[] GetFiles(string sourceDirName, string pattern, bool recursive)
        {
            return Directory.GetFiles(sourceDirName, 
                                      pattern, 
                                      recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        public string ReadFileAsText(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteFile(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }
}
