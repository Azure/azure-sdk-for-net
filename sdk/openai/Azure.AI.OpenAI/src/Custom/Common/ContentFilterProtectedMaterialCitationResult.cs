// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias OpenAI;
using System;
using OpenAI::System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")]
[CodeGenModel("AzureContentFilterResultForChoiceProtectedMaterialCodeCitation")]
public partial class ContentFilterProtectedMaterialCitationResult
{
    // CUSTOM: Renamed for Uri type.
    [CodeGenMember("URL")]
    public Uri Uri { get; }
}
