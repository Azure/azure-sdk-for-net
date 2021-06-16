// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Azure.Storage
{
    internal class DirectoryScanner
    {
        private string _path;

        public DirectoryScanner(string path)
        {
            _path = path;
        }

        // Constuctor for mocking
        public DirectoryScanner() { }

        public IEnumerable<string> EnumerateDirectories()
        {
            return Directory.EnumerateDirectories(_path);
        }
        public IEnumerable<string> EnumerateFiles()
        {
            return Directory.EnumerateFiles(_path);
        }
    }
}
