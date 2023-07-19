// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;

namespace Azure.DigitalTwins.Core.Samples
{
    public static class FileHelper
    {
        /// <summary>
        /// Loads all json file contents in a path
        /// </summary>
        /// <param name="path">Path to the target directory</param>
        /// <returns>List of all file names and their content in dictionary format</returns>
        public static Dictionary<string, string> LoadAllFilesInPath(string path)
        {
            string[] allFilesPath = Directory.GetFiles(path, "*.json");
            var fileContents = new Dictionary<string, string>();
            try
            {
                // Read all the DTDL files in the directory into memory
                foreach (string filePath in allFilesPath)
                {
                    fileContents[GetFileNameFromPath(filePath)] = File.ReadAllText(filePath);
                }

                return fileContents;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading twin types from disk due to: {ex.Message}", ConsoleColor.Red);
                Environment.Exit(0);
            }

            return null;
        }

        public static string LoadFileContentsFromFilePath(string path)
        {
            return File.ReadAllText(path);
        }

        public static string GetFileNameFromPath(string path)
        {
            string fileNameWithExtension = Path.GetFileName(path);
            return fileNameWithExtension.Substring(0, fileNameWithExtension.Length - ".json".Length);
        }
    }
}
