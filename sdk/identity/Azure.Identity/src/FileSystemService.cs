// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Identity
{
    internal class FileSystemService : IFileSystemService
    {
        public static IFileSystemService Default { get; } = new FileSystemService();

        private FileSystemService() { }

        public bool FileExists(string path) => File.Exists(path);
        public string ReadAllText(string path) => File.ReadAllText(path);
        public FileStream GetFileStream(string path) => new FileStream(path, FileMode.Open, FileAccess.Read);
    }
}
