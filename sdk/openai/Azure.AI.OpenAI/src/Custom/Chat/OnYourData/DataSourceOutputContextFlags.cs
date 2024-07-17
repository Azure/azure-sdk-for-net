// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI.Chat;

/// <summary>
/// The <c>include_context</c> flags to request for an On Your Data retrieval result, which control what information
/// will be available on <see cref="AzureChatMessageContext"/> instances in the response.
/// </summary>
/// <remarks>
/// By default, <c>intent</c> and <c>citations</c> will be requested.
/// <para>
/// This value is provided as a bitmask flag. For example, to request <c>intent</c> and <c>all_retrieved_documents</c>
/// contexts, use the bitwise OR operator by assigning
/// <c><see cref="DataSourceOutputContextFlags.Intent"/> | <see cref="DataSourceOutputContextFlags.AllRetrievedDocuments"/></c>.
/// </para>
/// </remarks>
[Flags]
public enum DataSourceOutputContextFlags : int
{
    Intent = 1 << 0,
    Citations = 1 << 1,
    AllRetrievedDocuments = 1 << 2,
}