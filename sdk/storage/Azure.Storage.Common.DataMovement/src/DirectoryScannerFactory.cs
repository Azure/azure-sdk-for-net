// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage
{
    internal class DirectoryScannerFactory
    {
#pragma warning disable CA1822 // Mark members as static
        public DirectoryScanner BuildDirectoryScanner(string path)
#pragma warning restore CA1822 // Mark members as static
        {
            return new DirectoryScanner(path);
        }

        // Constuctor for mocking
        public DirectoryScannerFactory() { }
    }
}
