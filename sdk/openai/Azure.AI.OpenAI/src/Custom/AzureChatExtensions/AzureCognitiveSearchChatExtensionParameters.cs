// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("AzureCognitiveSearchChatExtensionParameters", typeof(Uri), typeof(string))]
internal partial class AzureCognitiveSearchChatExtensionParameters
{
    internal AzureCognitiveSearchChatExtensionParameters()
    { }

    /// <summary> The absolute endpoint path for the Azure Cognitive Search resource to use. </summary>
    internal Uri SearchEndpoint { get; set; }
    /// <summary> The name of the index to use as available in the referenced Azure Cognitive Search resource. </summary>
    internal string IndexName { get; set; }
}
