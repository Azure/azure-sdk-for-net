// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.SdkAnalyzers
{
    internal static class GeneratedFolderHelper
    {
        public static GeneratedFolderInfo GetGeneratedFolderInfo(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return default;
            }

            // Check for Windows-style path
            var generatedIndex = filePath.LastIndexOf("\\Generated\\", StringComparison.OrdinalIgnoreCase);
            if (generatedIndex != -1)
            {
                return new GeneratedFolderInfo(
                    isInGeneratedFolder: true,
                    generatedIndex: generatedIndex,
                    pathSeparator: "\\",
                    generatedLength: "\\Generated\\".Length);
            }

            // Check for Unix-style path
            generatedIndex = filePath.LastIndexOf("/Generated/", StringComparison.OrdinalIgnoreCase);
            if (generatedIndex != -1)
            {
                return new GeneratedFolderInfo(
                    isInGeneratedFolder: true,
                    generatedIndex: generatedIndex,
                    pathSeparator: "/",
                    generatedLength: "/Generated/".Length);
            }

            return default;
        }
    }

    internal readonly struct GeneratedFolderInfo
    {
        public GeneratedFolderInfo(bool isInGeneratedFolder, int generatedIndex, string pathSeparator, int generatedLength)
        {
            IsInGeneratedFolder = isInGeneratedFolder;
            GeneratedIndex = generatedIndex;
            PathSeparator = pathSeparator;
            GeneratedLength = generatedLength;
        }

        public bool IsInGeneratedFolder { get; }
        public int GeneratedIndex { get; }
        public string PathSeparator { get; }
        public int GeneratedLength { get; }
    }
}
