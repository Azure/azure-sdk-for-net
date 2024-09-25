// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI;

[CodeGenModel("AzureContentFilterSeverityResult")]
public partial class ContentFilterSeverityResult
{
    [CodeGenMember("Severity")]
    public ContentFilterSeverity Severity { get; }
}