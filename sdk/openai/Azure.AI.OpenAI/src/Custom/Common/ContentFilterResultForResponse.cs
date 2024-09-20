// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI;

[CodeGenModel("AzureContentFilterResultForChoice")]
public partial class ContentFilterResultForResponse
{
    internal InternalAzureContentFilterResultForPromptContentFilterResultsError Error { get; }
}
