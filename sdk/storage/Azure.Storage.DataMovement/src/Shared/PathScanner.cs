// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Azure.Storage.DataMovement
{
    internal class PathScanner
    {
        /// <summary>
        /// The fully qualified path to be scanned.
        /// </summary>
        private readonly string _basePath;

        public PathScanner(string path)
        {
            // Resolve the given path to an absolute path in case it isn't one already
            _basePath = Path.GetFullPath(path);

            // If there's no file/directory at the given path, throw an exception.
            //
            // TODO: Logging for bad path
            if (!(Directory.Exists(_basePath) || File.Exists(_basePath)))
            {
                throw new ArgumentException($"No item(s) located at the path '{_basePath}'.");
            }
        }

        public IEnumerable<FileSystemInfo> Scan(bool continueOnError = true)
        {
            // If the given path is a single file, return only the given path
            if (!((File.GetAttributes(_basePath) & FileAttributes.Directory) == FileAttributes.Directory))
            {
                yield return new DirectoryInfo(_basePath);
                yield break;
            }

            // Create a queue of folders to enumerate files from, starting with provided path
            Queue<string> folders = new();
            folders.Enqueue(_basePath);

            while (folders.Count > 0)
            {
                // Grab a folder from the queue
                string dir = folders.Dequeue();

                // Send the current directory to the scan results
                yield return new DirectoryInfo(dir);

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
                    // If we lack permissions to enumerate, throw if the caller specifies
                    // that we shouldn't continue on error.
                    //
                    // TODO: Logging for missing permissions to enumerate folder
                    //
                    // Afterthought: once logging is implemented, we can just log any problems
                    // (whether with given dir or subdir), and skip if told to/throw if not. No need for
                    // the `dir == _basePath` check (which right now is just a filler signal
                    // for something going wrong, as opposed to an "success" with an empty list).
                    if ((dir == _basePath) || !continueOnError)
                    {
                        throw;
                    }

                    // Otherwise, just log the failed subdirectory and continue to list as many
                    // files as accessible.
                    continue;
                }

                // Send all files in the directory to the scan results
                foreach (string file in EnumerateFiles(dir))
                {
                    yield return new FileInfo(file);
                }
            }
        }

        /// <summary>
        /// Gets a file Uri that is fully encoded even if the path contains already
        /// encoded characters (double encoded in this case). <see cref="Uri.LocalPath"/>
        /// can be used to get decoded version for use with File IO.
        /// </summary>
        public static Uri GetEncodedUriFromPath(string path)
        {
            // The Uri class will normalize slashes but for Windows, do it
            // ahead of time to make the remainning logic common. Only do
            // this for Windows as \ can be a valid character for Linux/Mac.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                path = path.Replace("\\", "/");
            }

            // Encode each part of the path (except the first one) separately
            // and then reassemble into a Uri. This is done as Uri can be inconsistent
            // whether it encodes or not and we want to be sure to preserve any encoding
            // on disk.
            string[] pathParts = path.Split('/');
            List<string> encodedParts = [pathParts.First()];
            encodedParts.AddRange(pathParts.Skip(1).Select(Uri.EscapeDataString));
            string encodedPath = string.Join("/", encodedParts);

            UriBuilder uriBuilder = new()
            {
                Scheme = Uri.UriSchemeFile,
                Host = "",
                Path = encodedPath,
            };
            return uriBuilder.Uri;
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
