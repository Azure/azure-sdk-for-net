// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[CodeGenModel("AzureContentFilterResultForPrompt")]
public partial class ContentFilterResultForPrompt
{
    internal int? PromptIndex { get; }
    /// <summary> Gets the content filter results. </summary>
    [CodeGenMember("ContentFilterResults")]
    internal InternalAzureContentFilterResultForPromptContentFilterResults InternalResults { get; }

    /// <inheritdoc cref="InternalAzureContentFilterResultForPromptContentFilterResults.Error"/>
    internal InternalAzureContentFilterResultForPromptContentFilterResultsError Error { get; set; }

    /// <inheritdoc cref="InternalAzureContentFilterResultForPromptContentFilterResults.Sexual"/>
    public ContentFilterSeverityResult Sexual => InternalResults?.Sexual;
    /// <inheritdoc cref="InternalAzureContentFilterResultForPromptContentFilterResults.Violence"/>
    public ContentFilterSeverityResult Violence => InternalResults?.Violence;
    /// <inheritdoc cref="InternalAzureContentFilterResultForPromptContentFilterResults.Hate"/>
    public ContentFilterSeverityResult Hate => InternalResults?.Hate;
    /// <inheritdoc cref="InternalAzureContentFilterResultForPromptContentFilterResults.SelfHarm"/>
    public ContentFilterSeverityResult SelfHarm => InternalResults?.SelfHarm;
    /// <inheritdoc cref="InternalAzureContentFilterResultForPromptContentFilterResults.Profanity"/>
    public ContentFilterDetectionResult Profanity => InternalResults?.Profanity;
    /// <inheritdoc cref="InternalAzureContentFilterResultForPromptContentFilterResults.CustomBlocklists"/>
    public ContentFilterBlocklistResult CustomBlocklists => InternalResults?.CustomBlocklists;
    /// <inheritdoc cref="InternalAzureContentFilterResultForPromptContentFilterResults.Jailbreak"/>
    public ContentFilterDetectionResult Jailbreak => InternalResults?.Jailbreak;
    /// <inheritdoc cref="InternalAzureContentFilterResultForPromptContentFilterResults.IndirectAttack"/>
    public ContentFilterDetectionResult IndirectAttack => InternalResults?.IndirectAttack;
}
