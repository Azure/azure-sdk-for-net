// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.SdkAnalyzers
{
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
