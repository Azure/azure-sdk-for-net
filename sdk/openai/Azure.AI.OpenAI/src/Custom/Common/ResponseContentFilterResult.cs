// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")]
[CodeGenType("AzureContentFilterResultForChoice")]
public partial class ResponseContentFilterResult
{
#if !AZURE_OPENAI_GA
    public ContentFilterTextSpanResult UngroundedMaterial { get; }
#else
    internal ContentFilterTextSpanResult UngroundedMaterial { get; }
#endif
}
