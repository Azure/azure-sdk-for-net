// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    internal static class Check
    {
        #region const
        //const string Default_Culture = "en-US";
        #endregion

        #region fields

        #endregion

        #region Properties
        static CultureInfo DefaultCultureInfo { get; set; }
        #endregion

        #region Constructor
        static Check()
        {
            DefaultCultureInfo = CultureInfo.CurrentCulture;
        }
        #endregion

        #region internal Functions

        /// <summary>
        /// Checks if the argument passed in is NotNull
        /// Throws NullReferenceException if the arugment is Null
        /// </summary>
        /// <param name="argument">arument info for logging purpose</param>
        /// <param name="argumentName">argument info for logging</param>
        internal static void NotNull(object argument, string argumentName = "argument")
        {
            if (argument == null)
            {
                throw new ArgumentNullException(string.Format(DefaultCultureInfo, "{0} provided is null", argumentName));
            }
        }

        /// <summary>
        /// Checks if the string argument passed in is NonEmpty and NotNull
        /// Throws NullReferenceException if the arugment is Null or Empty
        /// </summary>
        /// <param name="argument">arument info for logging purpose</param>
        /// <param name="argumentName">argument info for logging</param>
        internal static void NotEmptyNotNull(string argument, string argumentName = "argument")
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullException(string.Format(DefaultCultureInfo, "{0} provided is either Null or Empty string", argumentName));
            }
        }

        /// <summary>
        /// Checks if the FilePath exists
        /// Throws FileNotFoundException if the filePath does not exists
        /// </summary>
        /// <param name="filePath">file path info for logging purpose</param>
        internal static void FileExists(string filePath)
        {
            NotNull(filePath, "File Path");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(DefaultCultureInfo, "'{0}' does not exists. Please check the validity of the path", filePath));
            }
        }

        /// <summary>
        /// Checks if the DirectoryPath exists
        /// Throws DirectoryNotFoundException if the DirectoryPath does not exists
        /// </summary>
        /// <param name="dirPath">Directory Path</param>
        internal static void DirectoryExists(string dirPath)
        {
            NotNull(dirPath, "Directory Path");
            if (!Directory.Exists(dirPath))
            {
                throw new DirectoryNotFoundException(string.Format(DefaultCultureInfo, "'{0}' does not exists. Please check the validity of the directory path", dirPath));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dirPaths"></param>
        /// <param name="argumentName"></param>
        internal static void DirectoryExists(List<string> dirPaths, string argumentName = "argument")
        {
            foreach (string dp in dirPaths)
            {
                NotNull(dp, argumentName);
                DirectoryExists(dp);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="expectedResult"></param>
        /// <param name="exceptionMessage"></param>
        internal static void Empty<T>(IEnumerable<T> collection, bool expectedResult, string exceptionMessage = "Collection items do not match with expectedResult")
        {
            if (collection == null) throw new ArgumentNullException(exceptionMessage);

            if (collection.Any<T>() == expectedResult)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        #endregion
    }
}
