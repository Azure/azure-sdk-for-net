// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("PineconeChatExtensionParameters", typeof(string), typeof(string), typeof(PineconeFieldMappingOptions))]
internal partial class PineconeChatExtensionParameters
{
    // CUSTOM CODE NOTE:
    //    These changes facilitate the direct use of the extension "configuration" classes for access to their
    //    constituent "parameter" values. These serialize into a subordinate payload within the wire format
    //    REST structure but don't convey additional semantic meaning, so internalizing parameter types and then
    //    plumbing the configuration through substantially simplifies the experience.

    internal PineconeChatExtensionParameters()
    { }

    /// <summary> The environment name of Pinecone. </summary>
    public string Environment { get; set; }
    /// <summary> The name of the Pinecone database index. </summary>
    public string IndexName { get; set; }
    /// <summary> Customized field mapping behavior to use when interacting with the search index. </summary>
    public PineconeFieldMappingOptions FieldMappingOptions { get; set; }
}
