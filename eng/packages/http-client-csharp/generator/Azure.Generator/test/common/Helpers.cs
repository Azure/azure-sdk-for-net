// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Azure.Generator.Tests.Common
{
    /// <summary>
    /// Helper methods for Auzre plugin tests
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Get expected content from file with naming convention
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="method"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetExpectedFromFile(
            string? parameters = null,
            [CallerMemberName] string method = "",
            [CallerFilePath] string filePath = "")
        {
            return File.ReadAllText(GetAssetFileOrDirectoryPath(true, parameters, method, filePath)).Replace("\r\n", "\n");
        }

        private static string GetAssetFileOrDirectoryPath(
            bool isFile,
            string? parameters = null,
            [CallerMemberName] string method = "",
            [CallerFilePath] string filePath = "")
        {
            var callingClass = Path.GetFileName(filePath).Split('.').First();
            var paramString = parameters is null ? string.Empty : $"({parameters})";
            var extName = isFile ? ".cs" : string.Empty;

            return Path.Combine(Path.GetDirectoryName(filePath)!, "TestData", callingClass, $"{method}{paramString}{extName}");
        }
    }
}
