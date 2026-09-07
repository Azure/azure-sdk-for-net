// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")]
[CodeGenType("AzureContentFilterSeverityResult")]
public partial class ContentFilterSeverityResult
{
    /// <summary> Gets the assessed severity level for this content filter category. </summary>
    [CodeGenMember("Severity")]
    public ContentFilterSeverity Severity { get; }
}
