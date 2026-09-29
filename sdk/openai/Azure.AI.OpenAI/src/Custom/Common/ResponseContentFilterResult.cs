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
    /// <summary> Gets the content filter result for ungrounded material detected in the response. </summary>
    public ContentFilterTextSpanResult UngroundedMaterial { get; }
#else
    internal ContentFilterTextSpanResult UngroundedMaterial { get; }
#endif
}
