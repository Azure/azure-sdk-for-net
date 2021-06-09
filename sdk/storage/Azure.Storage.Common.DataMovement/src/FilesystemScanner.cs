// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Azure.Storage.Common.DataMovement
{
    /// <summary>
    /// FilesystemScanner class.
    /// </summary>
    internal class FilesystemScanner
    {
        /// <summary>
        /// The fully qualified path to be scanned.
        /// </summary>
        private string _fullPath;

        /// <summary>
        /// Indicates whether the scan target is a directory.
        /// </summary>
        private bool _isDirectory;

        /// <summary>
        /// Constructor for FilesystemScanner.
        /// </summary>
        /// <param name="path"></param>
        public FilesystemScanner(string path)
        {
            try
            {
                // Ensure we're dealing with an absolute, well-formatted path
                _fullPath = Path.GetFullPath(path);

                // Check if path exists and whether it points to a directory
                if ((File.GetAttributes(_fullPath) & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    _isDirectory = true;
                }
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

        /// <summary>
        /// Enumerates files pointed to by path(s) passed to constructor.
        /// </summary>
        /// <returns>Enumerable list of absolute paths to all relevant files the user has permission to see.</returns>
        /// <param name="skipSubdirectories">Indicates whether to continue processing if enumeration fails on a subdirectory; defaults to true.</param>
        public IEnumerable<string> Scan(bool skipSubdirectories = true)
        {
            // If we're given a directory, parse its children recursively
            if (_isDirectory)
            {
                // Create a queue of folders to enumerate files from, starting with provided path
                Queue<string> folders = new();
                folders.Enqueue(_fullPath);

                while (folders.Count > 0)
                {
                    // Grab a folder from the queue
                    string dir = folders.Dequeue();

                    // Try to enumerate and queue all subdirectories of the current folder
                    try
                    {
                        foreach (string subdir in Directory.EnumerateDirectories(dir))
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
                        if ((dir == _fullPath) || !skipSubdirectories)
                        {
                            throw;
                        }

                        // Otherwise, just log the failed subdirectory and continue to list as many
                        // files as accessible.
                        continue;
                    }

                    // Add all files in the directory to be returned
                    foreach (string file in Directory.EnumerateFiles(dir))
                    {
                        yield return file;
                    }
                }
            }
            // Otherwise we can just return the original path
            else
            {
                yield return _fullPath;
            }
        }
    }
}
