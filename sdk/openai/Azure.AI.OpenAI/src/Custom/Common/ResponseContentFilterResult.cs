// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")]
[CodeGenModel("AzureContentFilterResultForChoice")]
public partial class ResponseContentFilterResult
{
    internal InternalAzureContentFilterResultForPromptContentFilterResultsError Error { get; }
}
