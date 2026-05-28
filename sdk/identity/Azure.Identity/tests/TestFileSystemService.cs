// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Identity.Tests
{
    internal sealed class TestFileSystemService : IFileSystemService
    {
        public Func<string, string> ReadAllHandler;
        public Func<string, bool> FileExistsHandler;
        public Func<string, FileStream> GetFileStreamHandler = null;

        public bool FileExists(string path) => FileExistsHandler?.Invoke(path) ?? false;
        public string ReadAllText(string path) => ReadAllHandler?.Invoke(path) ?? throw new FileNotFoundException();
        public FileStream GetFileStream(string path) => GetFileStreamHandler?.Invoke(path) ?? throw new FileNotFoundException();
    }
}
