// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The SummaryAspect. </summary>
    public readonly partial struct SummaryAspect : IEquatable<SummaryAspect>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SummaryAspect"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SummaryAspect(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string IssueValue = "issue";
        private const string ResolutionValue = "resolution";
        private const string ChapterTitleValue = "chapterTitle";
        private const string NarrativeValue = "narrative";

        /// <summary> A summary of issues in transcripts of web chats and service call transcripts between customer-service agents, and your customers. </summary>
        public static SummaryAspect Issue { get; } = new SummaryAspect(IssueValue);
        /// <summary> A summary of resolutions in transcripts of web chats and service call transcripts between customer-service agents, and your customers. </summary>
        public static SummaryAspect Resolution { get; } = new SummaryAspect(ResolutionValue);
        /// <summary> A chapter title of any conversation. It is usually one phrase or several phrases naturally combined together. Long conversation tends to have more chapters. The chapter boundary can be found from the summary context. </summary>
        public static SummaryAspect ChapterTitle { get; } = new SummaryAspect(ChapterTitleValue);
        /// <summary> A generic narrative summary of any conversation. It generally converts the conversational language into formal written language, compresses the text length and keeps the salient information. </summary>
        public static SummaryAspect Narrative { get; } = new SummaryAspect(NarrativeValue);
        /// <summary> Determines if two <see cref="SummaryAspect"/> values are the same. </summary>
        public static bool operator ==(SummaryAspect left, SummaryAspect right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SummaryAspect"/> values are not the same. </summary>
        public static bool operator !=(SummaryAspect left, SummaryAspect right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SummaryAspect"/>. </summary>
        public static implicit operator SummaryAspect(string value) => new SummaryAspect(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SummaryAspect other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SummaryAspect other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
