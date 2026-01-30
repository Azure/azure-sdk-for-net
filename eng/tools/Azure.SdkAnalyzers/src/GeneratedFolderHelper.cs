// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.SdkAnalyzers
{
    public static class GeneratedFolderHelper
    {
        // Cache common folder arrays to avoid allocations
        private static readonly string[] CustomOnly = ["Custom"];
        private const int GeneratedLength = 10;

        public static GeneratedFolderInfo GetGeneratedFolderInfo(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return default;
            }

            int generatedIndex = filePath.IndexOf("Generated", StringComparison.Ordinal);
            bool isInGeneratedFolder = generatedIndex >= 0;

            if (!isInGeneratedFolder)
            {
                return default;
            }

            // Detect path separator from the entire path
            char pathSeparator = filePath.IndexOf('/') >= 0 ? '/' : '\\';

            // Extract relative path after "Generated" (excluding filename)
            int afterGeneratedIndex = generatedIndex + GeneratedLength;
            int fileStartIndex = filePath.LastIndexOf(pathSeparator) + 1;
            int afterLength = fileStartIndex - afterGeneratedIndex - 1;

            IEnumerable<string> customFolders = afterLength <= 0
                ? CustomOnly
                : ["Custom", .. filePath.Substring(afterGeneratedIndex, afterLength).Split(pathSeparator)];

            return new GeneratedFolderInfo(isInGeneratedFolder, customFolders);
        }
    }

    public readonly struct GeneratedFolderInfo
    {
        public GeneratedFolderInfo(bool isInGeneratedFolder, IEnumerable<string> customFolders)
        {
            IsInGeneratedFolder = isInGeneratedFolder;
            CustomFolders = customFolders;
        }

        public bool IsInGeneratedFolder { get; }
        public IEnumerable<string> CustomFolders { get; }
    }
}
