// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.Common.DataMovement
{
    internal class PathScanner
    {
        /// <summary>
        /// The fully qualified path to be scanned.
        /// </summary>
        private readonly string _basePath;
        private readonly bool _isDir;

        public PathScanner(string path, bool isDir)
        {
            _basePath = path;
            _isDir = isDir;
        }

        public IEnumerable<string> Scan(bool skipSubdirectories = true)
        {
            // If we're given a directory, parse its children recursively
            if (_isDir)
            {
                // Create a queue of folders to enumerate files from, starting with provided path
                Queue<string> folders = new();
                folders.Enqueue(_basePath);

                while (folders.Count > 0)
                {
                    // Grab a folder from the queue
                    string dir = folders.Dequeue();

                    // Try to enumerate and queue all subdirectories of the current folder
                    try
                    {
                        foreach (string subdir in EnumerateDirectories(dir))
                        {
                            folders.Enqueue(subdir);
                        }
                    }
                    catch
                    {
                        // If we lack permissions to enumerate, throw if we fail on the main directory or
                        // if the user instructs us to do so on failing to enumerate a subdirectory.
                        //
                        // TODO: Logging for missing permissions to enumerate folder
                        if ((dir == _basePath) || !skipSubdirectories)
                        {
                            throw;
                        }

                        // Otherwise, just log the failed subdirectory and continue to list as many
                        // files as accessible.
                        continue;
                    }

                    // Add all files in the directory to be returned
                    foreach (string file in EnumerateFiles(dir))
                    {
                        yield return file;
                    }
                }
            }
            // Otherwise we can just return the original path
            else
            {
                yield return _basePath;
            }
        }

        private static IEnumerable<string> EnumerateDirectories(string path)
        {
            return Directory.EnumerateDirectories(path);
        }

        private static IEnumerable<string> EnumerateFiles(string path)
        {
            return Directory.EnumerateFiles(path);
        }
    }
}
