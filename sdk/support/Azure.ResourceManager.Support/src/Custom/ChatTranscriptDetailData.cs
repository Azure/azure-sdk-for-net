// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Support
{
    // Suppress the generated internal parameterless constructor, replace with public
    [CodeGenSuppress("ChatTranscriptDetailData")]
    public partial class ChatTranscriptDetailData
    {
        /// <summary> Initializes a new instance of <see cref="ChatTranscriptDetailData"/>. </summary>
        public ChatTranscriptDetailData()
        { }
    }
}
