// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.Common.DataMovement
{
    internal class FileSystemScanner
    {
        /// <summary>
        /// The fully qualified path to be scanned.
        /// </summary>
        public string _basePath;

        private DirectoryScannerFactory _dirFactory;
        private DirectoryScanner _currentDirectory;

        private Queue<string> _directories;
        private Queue<string> _files = new Queue<string>();

        public FileSystemScanner(string path, bool isDir, DirectoryScannerFactory dirFactory = null)
        {
            _basePath = path;

            if (isDir)
            {
                try
                {
                    // Set up DirectoryScanner and initialize path queues
                    _dirFactory = dirFactory;
                    _currentDirectory = dirFactory.BuildDirectoryScanner(path);
                    _directories = new Queue<string>();
                    Populate();
                }
                catch
                {
                    // If we lack permissions to enumerate the caller-provided folder,
                    // throw the error
                    //
                    // TODO: Logging for missing permissions to enumerate main folder
                    throw;
                }
            }
            else
            {
                // Add the single file to file queue, will be the only output
                _files.Enqueue(path);
            }
        }

        // Constuctor for mocking
        public FileSystemScanner() { }

        public IEnumerable<string> Scan()
        {
            while (_files.Count > 0)
            {
                // Return files from queue, using Refresh() afer each yield to continue the iteration
                // until all recursively accessible files are exhausted
                yield return _files.Dequeue();
                Refresh();
            }
        }

        private void Refresh()
        {
            // No need to do anything if files are still in queue
            if (_files.Count > 0)
            {
                return;
            }

            if (_directories?.Count > 0)
            {
                // While we have directories in queue, and the files queue is still empty...
                while (_files.Count == 0 && _directories.Count > 0)
                {
                    try
                    {
                        // Swap to a directory from queue, and attempt to populate the queues with its contents
                        _currentDirectory = _dirFactory.BuildDirectoryScanner(_directories.Dequeue());
                        Populate();
                    }
                    catch
                    {
                        // If we lack permissions to enumerate some subfolder, continue checking
                        // through the rest of the directories in queue
                        //
                        // TODO: Logging for missing permissions to enumerate subfolder, options
                        // object(?) to let user decide whether or not to continue
                        continue;
                    }
                }
            }
        }

        private void Populate()
        {
            // Queue all directories in the current directory
            foreach (string subdir in _currentDirectory.EnumerateDirectories())
            {
                _directories.Enqueue(subdir);
            }

            // Queue all files in the current directory
            foreach (string file in _currentDirectory.EnumerateFiles())
            {
                _files.Enqueue(file);
            }
        }
    }
}
