// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias OpenAI;
using OpenAI::System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")][CodeGenModel("AzureContentFilterImagePromptResults")] public partial class RequestImageContentFilterResult { }
[Experimental("AOAI001")][CodeGenModel("AzureContentFilterImageResponseResults")] public partial class ResponseImageContentFilterResult { }
