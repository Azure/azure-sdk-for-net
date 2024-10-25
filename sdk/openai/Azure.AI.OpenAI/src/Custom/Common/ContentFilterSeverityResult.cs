// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias OpenAI;
using OpenAI::System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")]
[CodeGenModel("AzureContentFilterSeverityResult")]
public partial class ContentFilterSeverityResult
{
    [CodeGenMember("Severity")]
    public ContentFilterSeverity Severity { get; }
}
