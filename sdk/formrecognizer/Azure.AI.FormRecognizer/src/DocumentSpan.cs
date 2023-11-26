// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public readonly partial struct DocumentSpan : IEquatable<DocumentSpan>
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

        /// <summary>
        /// Zero-based index of the content represented by the span.
        /// </summary>
        [CodeGenMember("Offset")]
        public int Index { get; }

        /// <summary>
        /// Number of characters in the content represented by the span.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Indicates whether the current <see cref="DocumentSpan"/> is equal to another object. They are considered
        /// equal if they have the same type, the same <see cref="Index"/>, and the same <see cref="Length"/>.
        /// </summary>
        /// <param name="obj">An object to compare with this <see cref="DocumentSpan"/>.</param>
        /// <returns><c>true</c> if the current <see cref="DocumentSpan"/> is equal to the <paramref name="obj"/> parameter; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DocumentSpan other && Equals(other);

        /// <summary>
        /// Indicates whether the current <see cref="DocumentSpan"/> is equal to another object of the same type.
        /// They are considered equal if they have the same <see cref="Index"/> and the same <see cref="Length"/>.
        /// </summary>
        /// <param name="other">An object to compare with this <see cref="DocumentSpan"/>.</param>
        /// <returns><c>true</c> if the current <see cref="DocumentSpan"/> is equal to the <paramref name="other"/> parameter; otherwise, <c>false</c>.</returns>
        public bool Equals(DocumentSpan other) => Index == other.Index && Length == other.Length;

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => HashCodeBuilder.Combine(Index, Length);

        /// <summary>
        /// Returns a <c>string</c> representation of this <see cref="DocumentSpan"/>.
        /// </summary>
        /// <returns>A <c>string</c> representation of this <see cref="DocumentSpan"/>.</returns>
        public override string ToString() => $"Index: {Index}, Length: {Length}";
    }
}
