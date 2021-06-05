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
    public static class FilesystemScanner
    {
        /// <summary>
        /// Enumerates all files pointed to by the provided path, including those in subdirectories (if path is a directory).
        /// </summary>
        /// <param name="path">Filesystem location.</param>
        /// <returns>Enumerable list of absolute paths containing all relevant files the user has permission to access.</returns>
        public static IEnumerable<string> ScanLocation(string path)
        {
            // Path type is ambiguous at start
            bool isDirectory = false;

            try
            {
                // Make sure we're dealing with absolute, well-formatted path
                path = Path.GetFullPath(path);

                // Check if path points to a directory
                if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    isDirectory = true;
                }
            }
            catch (Exception)
            {
                // If there's an error here, there aren't any valid entries to scan at the given path;
                // the path is either invalid or nonexistant. In this case, throw the resulting exception.
                //
                // TODO: Logging for invalid path exceptions
                throw;
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
                    catch (Exception)
                    {
                        // TODO: Logging for missing permissions to enumerate folder
                        if (dir == path)
                        {
                            // If we can't even enumerate the path supplied by the user, throw
                            // the error
                            throw;
                        }

                        // Otherwise, just log the failed subdirectory and continue to list as many
                        // files as accessible. Maybe let users decide whether to always throw here?
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

        /// <summary>
        /// Enumerates files pointed to by several paths.
        /// </summary>
        /// <param name="paths">Filesystem locations.</param>
        /// <returns>Enumerable list of absolute paths containing all relevant files the user has permission to access.</returns>
        public static IEnumerable<string> ScanLocations(string[] paths)
        {
            // Redirect all paths provided to ScanLocation(), and collect all results together
            foreach (string path in paths)
            {
                foreach (string file in ScanLocation(path))
                {
                    yield return file;
                }
            }
        }
    }
}
