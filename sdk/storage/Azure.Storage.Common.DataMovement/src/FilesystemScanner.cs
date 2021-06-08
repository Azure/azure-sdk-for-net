// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Azure.Storage.Common.DataMovement
{
    /// <summary>
    /// FilesystemScanner class.
    /// </summary>
    public class FilesystemScanner
    {
        /// <summary>
        /// Fully qualified path(s) equivalent to user-supplied path(s).
        /// </summary>
        public IEnumerable<string> FullPaths
        {
            get;
            private set;
        }

        /// <summary>
        /// Single path constructor for FilesystemScanner.
        /// </summary>
        /// <param name="path"></param>
        public FilesystemScanner(string path)
        {
            try
            {
                // Ensure we're dealing with an absolute, well-formatted path
                FullPaths = new string[] { Path.GetFullPath(path) };
            }
            catch
            {
                // TODO: Logging for bad path passed to constructor
                throw;
            }
        }

        /// <summary>
        /// Multi-path constructor for FilesystemScanner.
        /// </summary>
        /// <param name="paths"></param>
        public FilesystemScanner(IEnumerable<string> paths)
        {
            try
            {
                // Ensure we're dealing with absolute, well-formatted paths
                FullPaths = paths.Select(path => Path.GetFullPath(path));
            }
            catch
            {
                // TODO: Logging for bad path passed to constructor
                throw;
            }
        }

        /// <summary>
        /// Enumerates files pointed to by path(s) passed to constructor.
        /// </summary>
        /// <returns>Enumerable list of absolute paths to all relevant files the user has permission to see.</returns>
        /// <param name="skipErrors">Indicates whether to throw if enumeration fails on a user-supplied path; defaults to true.</param>
        /// <param name="skipSubdirectories">Indicates whether to throw if enumeration fails on a subdirectory; defaults to false.</param>
        public IEnumerable<string> Scan(bool skipErrors = false, bool skipSubdirectories = true)
        {
            foreach (string path in FullPaths)
            {
                // Path type is ambiguous at start
                bool isDirectory = false;

                try
                {
                    // Check if path points to a directory
                    if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        isDirectory = true;
                    }
                }
                catch
                {
                    // If there's an error here, there aren't any valid entries to scan at the given path;
                    // the path is either invalid or nonexistant. In this case, throw the resulting exception
                    // unless the user instructs not to.
                    //
                    // TODO: Logging for invalid path exceptions
                    if (!skipErrors)
                    {
                        throw;
                    }
                }

                // If we're given a directory, parse its children recursively
                if (isDirectory)
                {
                    // Create a queue of folders to enumerate files from, starting with provided path
                    Queue<string> folders = new();
                    folders.Enqueue(path);

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
                        // If we lack permissions to enumerate, skip the folder and continue processing
                        // the rest of the queue
                        catch
                        {
                            // TODO: Logging for missing permissions to enumerate folder
                            if (!skipSubdirectories || (dir == path && !skipErrors))
                            {
                                // Throw if the user instructs us to do so on failing to enumerate
                                // a sub- and/or user-supplied directory (if the exception trigger is one).
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
                    yield return path;
                }
            }
        }
    }
}
