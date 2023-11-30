// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("ElasticsearchChatExtensionParameters", typeof(Uri), typeof(string))]
internal partial class ElasticsearchChatExtensionParameters
{
    internal ElasticsearchChatExtensionParameters()
    { }

    /// <summary> The endpoint of Elasticsearch. </summary>
    public Uri Endpoint { get; set; }
    /// <summary> The index name of Elasticsearch. </summary>
    public string IndexName { get; set; }
}
