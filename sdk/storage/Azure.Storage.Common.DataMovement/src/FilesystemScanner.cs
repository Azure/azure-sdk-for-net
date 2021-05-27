// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Azure.Storage.Common.DataMovement
{
    /// <summary>
    /// FilesystemScanner class
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

            // Make sure we're dealing with absolute path
            path = Path.GetFullPath(path);

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
                // If there's an error (from calling File.GetAttributes()), there aren't any valid entries to scan at the
                // given path; either the path is invalid/nonexistant, or it isn't accessible by the user. In this case,
                // don't return anything.
                yield break;
            }

            // If we're given a directory, parse its children recursively
            if (isDirectory)
            {
                // Create a queue of folders to enumerate files from, starting with provided path
                Queue<string> folders = new Queue<string>();
                folders.Enqueue(path);

                while (folders.Count > 0)
                {
                    // Grab a folder from the queue
                    string dir = folders.Dequeue();

                    // Check if we have permissions to read subdirectories, and add them to queue
                    foreach (string subdir in Directory.EnumerateDirectories(dir))
                    {
                        if (Directory.Exists(dir))
                        {
                            folders.Enqueue(subdir);
                        }
                    }

                    // Check if we have permissions to read files, and add to list if so
                    foreach (string file in Directory.EnumerateFiles(dir))
                    {
                        if (File.Exists(file))
                        {
                            yield return file;
                        }
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
