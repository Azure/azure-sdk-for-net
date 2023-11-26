// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A collection of statistics describing an individual input document.
    /// This information is provided on the result collection returned by an
    /// operation when the caller passes in a <see cref="TextAnalyticsRequestOptions"/>
    /// with IncludeStatistics set to true.
    /// </summary>
    [CodeGenModel("DocumentStatistics")]
    public readonly partial struct TextDocumentStatistics
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal TextDocumentStatistics(int characterCount, int transactionCount)
        {
            CharacterCount = characterCount;
            TransactionCount = transactionCount;
        }

        /// <summary>
        /// Gets the number of characters (in Unicode graphemes) the corresponding document contains.
        /// </summary>
        [CodeGenMember("CharactersCount")]
        public int CharacterCount { get; }

        /// <summary>
        /// Gets the number of transactions used by the service to analyze the
        /// input document.
        /// </summary>
        [CodeGenMember("TransactionsCount")]
        public int TransactionCount { get; }
    }
}
