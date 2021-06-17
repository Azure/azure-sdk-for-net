// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.Common.DataMovement
{
    internal class PathScannerFactory
    {
        private string _path;

        public PathScannerFactory(string path)
        {
            _path = path;
        }

        public PathScanner BuildPathScanner()
        {
            try
            {
                // Ensure we're dealing with an absolute, well-formatted path
                string fullPath = Path.GetFullPath(_path);

                // Check if path exists and whether it points to a directory
                bool isDir = (File.GetAttributes(fullPath) & FileAttributes.Directory) == FileAttributes.Directory;

                return new PathScanner(fullPath, isDir);
            }
            catch
            {
                // If there's an error here, there aren't any valid entries to scan at the given path;
                // the path is either invalid or nonexistant. In this case, throw the exception.
                //
                // TODO: Logging for bad path exceptions
                throw;
            }
        }
    }
}
