// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")]
[CodeGenType("AzureContentFilterResultForChoiceProtectedMaterialCodeCitation")]
public partial class ContentFilterProtectedMaterialCitationResult
{
    // CUSTOM: Renamed for Uri type.
    [CodeGenMember("URL")]
    public Uri Uri { get; }
}