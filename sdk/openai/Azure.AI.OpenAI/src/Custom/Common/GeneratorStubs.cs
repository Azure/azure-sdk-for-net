// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")][CodeGenType("AzureContentFilterDetectionResult")] public partial class ContentFilterDetectionResult { }
[Experimental("AOAI001")][CodeGenType("AzureContentFilterResultForChoiceProtectedMaterialCode")] public partial class ContentFilterProtectedMaterialResult { }
[Experimental("AOAI001")][CodeGenType("AzureContentFilterSeverityResultSeverity")] public readonly partial struct ContentFilterSeverity { }
#if !AZURE_OPENAI_GA
[Experimental("AOAI001")][CodeGenType("AzureContentFilterCompletionTextSpan")] public partial class ContentFilterTextSpan { }
#endif