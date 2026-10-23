// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Test.Extensions.Plugin.Common
{
    /// <summary>
    /// Helper methods for validating generated code against expected files stored under
    /// <c>TestData/&lt;TestClass&gt;/&lt;TestMethod&gt;.cs</c>, mirroring the pattern used by the
    /// Azure.Generator test infrastructure.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Reads the expected generated content from the file that matches the calling test's
        /// class and method name.
        /// </summary>
        /// <param name="parameters">Optional parameter suffix used to distinguish parameterized cases.</param>
        /// <param name="method">The calling test method name (supplied automatically).</param>
        /// <param name="filePath">The calling test file path (supplied automatically).</param>
        /// <returns>The expected file content with normalized line endings.</returns>
        public static string GetExpectedFromFile(
            string? parameters = null,
            [CallerMemberName] string method = "",
            [CallerFilePath] string filePath = "")
        {
            return File.ReadAllText(GetAssetFilePath(parameters, method, filePath)).Replace("\r\n", "\n");
        }

        private static string GetAssetFilePath(
            string? parameters,
            string method,
            string filePath)
        {
            var callingClass = Path.GetFileName(filePath).Split('.').First();
            var paramString = parameters is null ? string.Empty : $"({parameters})";

            return Path.Combine(Path.GetDirectoryName(filePath)!, "TestData", callingClass, $"{method}{paramString}.cs");
        }
    }
}
