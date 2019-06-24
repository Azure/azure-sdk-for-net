// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.Authentication.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Utility to check Null/Empty and throw appropriate exceptions
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Checks if the argument passed in is NotNull
        /// Throws NullReferenceException if the arugment is Null
        /// </summary>
        /// <param name="argument">arument info for logging purpose</param>
        /// <param name="argumentName">argument info for logging</param>
        public static void NotNull(object argument, string argumentName = "argument")
        {
            if (argument == null)
            {
                throw new NullReferenceException(string.Format("{0} provided is null", argumentName));
            }
        }

        /// <summary>
        /// Checks if the string argument passed in is NonEmpty and NotNull
        /// Throws NullReferenceException if the arugment is Null or Empty
        /// </summary>
        /// <param name="argument">arument info for logging purpose</param>
        /// <param name="argumentName">argument info for logging</param>
        public static void NotEmptyNotNull(string argument, string argumentName = "argument")
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new NullReferenceException(string.Format("{0} provided is either Null or Empty string", argumentName));
            }
        }

        /// <summary>
        /// Checks if the FilePath exists
        /// Throws FileNotFoundException if the filePath does not exists
        /// </summary>
        /// <param name="filePath">file path info for logging purpose</param>
        public static void FileExists(string filePath)
        {
            NotNull(filePath, "File Path");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format("'{0}' does not exists. Please check the validity of the path", filePath));
            }
        }

        /// <summary>
        /// Checks if the DirectoryPath exists
        /// Throws DirectoryNotFoundException if the DirectoryPath does not exists
        /// </summary>
        /// <param name="dirPath">Directory Path</param>
        public static void DirectoryExists(string dirPath)
        {
            NotNull(dirPath, "Directory Path");
            if (!Directory.Exists(dirPath))
            {
                throw new DirectoryNotFoundException(string.Format("'{0}' does not exists. Please check the validity of the directory path", dirPath));
            }
        }

        public static void Empty<T>(IEnumerable<T> collection, bool expectedResult, string exceptionMessage = "Collection items do not match with expectedResult" )
        {
            if (collection == null) throw new ArgumentNullException(exceptionMessage);

            if(collection.Any<T>() == expectedResult)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

    }
}
