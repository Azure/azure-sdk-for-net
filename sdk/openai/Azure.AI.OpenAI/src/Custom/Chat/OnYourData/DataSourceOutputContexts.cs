// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

/// <summary>
/// The <c>include_context</c> flags to request for an On Your Data retrieval result, which control what information
/// will be available on <see cref="ChatMessageContext"/> instances in the response.
/// </summary>
/// <remarks>
/// By default, <c>intent</c> and <c>citations</c> will be requested.
/// <para>
/// This value is provided as a bitmask flag. For example, to request <c>intent</c> and <c>all_retrieved_documents</c>
/// contexts, use the bitwise OR operator by assigning
/// <c><see cref="DataSourceOutputContexts.Intent"/> | <see cref="DataSourceOutputContexts.AllRetrievedDocuments"/></c>.
/// </para>
/// </remarks>
[Flags]
[Experimental("AOAI001")]
public enum DataSourceOutputContexts : int
{
    /// <summary> Requests that the inferred user intent be included in the response context. </summary>
    Intent = 1 << 0,
    /// <summary> Requests that citation information for retrieved documents be included in the response context. </summary>
    Citations = 1 << 1,
    /// <summary> Requests that the full content of all retrieved documents be included in the response context. </summary>
    AllRetrievedDocuments = 1 << 2,
}
