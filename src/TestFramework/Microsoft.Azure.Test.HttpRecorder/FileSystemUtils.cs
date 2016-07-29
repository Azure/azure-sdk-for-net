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
