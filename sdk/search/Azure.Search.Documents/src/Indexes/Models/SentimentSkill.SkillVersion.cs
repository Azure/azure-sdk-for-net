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
        public readonly partial struct SkillVersion : IEquatable<SkillVersion>
        {
            private readonly string _value;

            private const string V1Value = "#Microsoft.Skills.Text.SentimentSkill";
            private const string V3Value = "#Microsoft.Skills.Text.V3.SentimentSkill";

            /// <summary> Creates a new instance of <see cref="SkillVersion"/>. </summary>
            /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
            public SkillVersion(string value)
            {
                _value = value ?? throw new ArgumentNullException(nameof(value));
            }

            /// <summary> <see cref="SkillVersion.V1"/> version of the <see cref="SentimentSkill"/> is deprecated. Use the  <see cref="SkillVersion.V3"/> version instead. </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static SkillVersion V1 { get; } = new SkillVersion(V1Value);

            /// <summary> Version 3 of the <see cref="SkillVersion"/>. </summary>
            public static SkillVersion V3 { get; } = new SkillVersion(V3Value);

            /// <summary> Latest version of the <see cref="SkillVersion"/>. </summary>
            public static SkillVersion Latest { get; } = V3;

            /// <inheritdoc />
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object obj) => obj is SkillVersion other && Equals(other);

            /// <inheritdoc />
            public bool Equals(SkillVersion other) =>
                string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

            /// <summary> Defines the equal-to comparison operator on <see cref="SkillVersion"/>. </summary>
            public static bool operator ==(SkillVersion left, SkillVersion right) => left.Equals(right);

            /// <summary> Defines the not-equal-to comparison operator on <see cref="SkillVersion"/>. </summary>
            public static bool operator !=(SkillVersion left, SkillVersion right) => !(left == right);

            /// <summary> Defines the greater-than-or-equal-to comparison operator on <see cref="SkillVersion"/>. </summary>
            public static bool operator >=(SkillVersion left, SkillVersion right)
            {
                if (left == right)
                    return true;

                if (left == Latest)
                    return true;

                return false;
            }

            /// <summary> Defines the less-than-or-equal-to comparison operator on <see cref="SkillVersion"/>. </summary>
            public static bool operator <=(SkillVersion left, SkillVersion right)
            {
                if (left == right)
                    return true;

                return !(left >= right);
            }

            /// <summary> Converts a string to a <see cref="SkillVersion"/>. </summary>
            public static implicit operator SkillVersion(string value) => new(value);

            /// <inheritdoc />
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode() => _value?.GetHashCode() ?? 0;

            /// <inheritdoc />
            public override string ToString() => _value;
        }
#pragma warning restore CA1034 // Nested types should not be visible
    }
}
