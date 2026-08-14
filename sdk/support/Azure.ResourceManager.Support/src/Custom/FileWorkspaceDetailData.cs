// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Support
{
    // Suppress the generated internal parameterless constructor, replace with public
    [CodeGenSuppress("FileWorkspaceDetailData")]
    public partial class FileWorkspaceDetailData
    {
        /// <summary> Initializes a new instance of <see cref="FileWorkspaceDetailData"/>. </summary>
        public FileWorkspaceDetailData()
        {
        }
    }
}
