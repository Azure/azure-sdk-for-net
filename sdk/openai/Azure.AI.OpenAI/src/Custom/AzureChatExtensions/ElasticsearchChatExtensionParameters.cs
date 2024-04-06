// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("ElasticsearchChatExtensionParameters", typeof(Uri), typeof(string))]
internal partial class ElasticsearchChatExtensionParameters
{
    // CUSTOM CODE NOTE:
    //    These changes facilitate the direct use of the extension "configuration" classes for access to their
    //    constituent "parameter" values. These serialize into a subordinate payload within the wire format
    //    REST structure but don't convey additional semantic meaning, so internalizing parameter types and then
    //    plumbing the configuration through substantially simplifies the experience.

    internal ElasticsearchChatExtensionParameters()
    { }

    /// <summary> The endpoint of Elasticsearch®. </summary>
    public Uri Endpoint { get; set; }
    /// <summary> The index name of Elasticsearch®. </summary>
    public string IndexName { get; set; }
}
