// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.Common.DataMovement
{
    internal class FileSystemScannerFactory
    {
        private string _path;
        private DirectoryScannerFactory _dirFactory;

        public FileSystemScannerFactory(string path)
        {
            _path = path;
            _dirFactory = new DirectoryScannerFactory();
        }

        public FileSystemScannerFactory(string path, DirectoryScannerFactory dirFactory)
        {
            _path = path;
            _dirFactory = dirFactory;
        }

        public FileSystemScanner BuildFilesystemScanner()
        {
            try
            {
                // Ensure we're dealing with an absolute, well-formatted path
                string fullPath = Path.GetFullPath(_path);

                // Check if path exists and whether it points to a directory
                if ((File.GetAttributes(fullPath) & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    return new FileSystemScanner(fullPath, true, _dirFactory);
                }

                return new FileSystemScanner(fullPath, false);
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
