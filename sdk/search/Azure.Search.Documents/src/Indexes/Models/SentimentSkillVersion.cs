// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SentimentSkill
    {
#pragma warning disable CA1034 // Nested types should not be visible
        /// <summary> Represents service version information of an <see cref="SentimentSkill"/>. </summary>
        public readonly partial struct SentimentSkillVersion : IEquatable<SentimentSkillVersion>
        {
            private readonly string _value;

            private const string V1Value = "#Microsoft.Skills.Text.SentimentSkill";
            private const string V3Value = "#Microsoft.Skills.Text.V3.SentimentSkill";

            /// <summary> Creates a new instance of <see cref="SentimentSkillVersion"/>. </summary>
            /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
            public SentimentSkillVersion(string value)
            {
                _value = value ?? throw new ArgumentNullException(nameof(value));
            }

            /// <summary> Version 1 of the <see cref="SentimentSkillVersion"/>. </summary>
            public static SentimentSkillVersion V1 { get; } = new SentimentSkillVersion(V1Value);

            /// <summary> Version 3 of the <see cref="SentimentSkillVersion"/>. </summary>
            public static SentimentSkillVersion V3 { get; } = new SentimentSkillVersion(V3Value);

            /// <summary> Latest version of the <see cref="SentimentSkillVersion"/> </summary>
            public static SentimentSkillVersion Latest { get; } = SentimentSkillVersion.V3;

            /// <inheritdoc />
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object obj) => obj is SentimentSkillVersion other && Equals(other);

            /// <inheritdoc />
            public bool Equals(SentimentSkillVersion other) =>
                string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

            /// <summary> Defines the '==' operator on <see cref="SentimentSkillVersion"/> </summary>
            public static bool operator ==(SentimentSkillVersion lhs, SentimentSkillVersion rhs) => lhs.Equals(rhs);

            /// <summary> Defines the '!=' operator on <see cref="SentimentSkillVersion"/>. </summary>
            public static bool operator !=(SentimentSkillVersion lhs, SentimentSkillVersion rhs) => !(lhs == rhs);

            /// <summary> Converts a string to a <see cref="SentimentSkillVersion"/>. </summary>
            public static implicit operator SentimentSkillVersion(string value) => new SentimentSkillVersion(value);

            /// <inheritdoc />
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode() => _value?.GetHashCode() ?? 0;

            /// <inheritdoc />
            public override string ToString() => _value;
        }
#pragma warning restore CA1034 // Nested types should not be visible
    }
}
