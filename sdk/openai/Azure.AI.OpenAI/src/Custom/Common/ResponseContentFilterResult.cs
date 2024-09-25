// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI;

[CodeGenModel("AzureContentFilterResultForChoice")]
public partial class ResponseContentFilterResult
{
    internal InternalAzureContentFilterResultForPromptContentFilterResultsError Error { get; }
}
