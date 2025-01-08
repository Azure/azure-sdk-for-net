// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")][CodeGenModel("AzureContentFilterBlocklistIdResult")] internal partial class InternalAzureContentFilterBlocklistIdResult { }
[Experimental("AOAI001")][CodeGenModel("AzureContentFilterBlocklistResultDetail")] internal partial class InternalAzureContentFilterBlocklistResultDetail { }
[Experimental("AOAI001")][CodeGenModel("AzureContentFilterResultForPromptContentFilterResults")] internal partial class InternalAzureContentFilterResultForPromptContentFilterResults { }
[Experimental("AOAI001")][CodeGenModel("AzureContentFilterResultForPromptContentFilterResultsError")] internal partial class InternalAzureContentFilterResultForPromptContentFilterResultsError { }
#if AZURE_OPENAI_GA
[Experimental("AOAI001")][CodeGenModel("AzureContentFilterCompletionTextSpan")] internal partial class ContentFilterTextSpan { }
#endif