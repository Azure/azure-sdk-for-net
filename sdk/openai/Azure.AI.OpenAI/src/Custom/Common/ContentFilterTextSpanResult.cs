// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")]
[CodeGenType("AzureContentFilterCompletionTextSpanDetectionResult")]
#if !AZURE_OPENAI_GA
public partial class ContentFilterTextSpanResult
#else
internal partial class ContentFilterTextSpanResult
#endif
{ }