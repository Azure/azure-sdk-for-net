// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")]
[CodeGenType("AzureContentFilterResultForPrompt")]
public partial class RequestContentFilterResult
{
    internal int? PromptIndex { get; }
    /// <summary> Gets the content filter results. </summary>
    [CodeGenMember("ContentFilterResults")]
    internal InternalAzureContentFilterResultForPromptContentFilterResults InternalResults { get; }

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
