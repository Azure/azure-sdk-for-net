// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class EntityRecognitionSkill
    {
#pragma warning disable CA1034 // Nested types should not be visible
        /// <summary> Represents service version information of an <see cref="EntityRecognitionSkill"/>. </summary>
        public readonly partial struct EntityRecognitionSkillVersion : IEquatable<EntityRecognitionSkillVersion>
        {
            private readonly string _value;

            private const string V1Value = "#Microsoft.Skills.Text.EntityRecognitionSkill";
            private const string V3Value = "#Microsoft.Skills.Text.V3.EntityRecognitionSkill";

            /// <summary> Creates a new instance of <see cref="EntityRecognitionSkillVersion"/>. </summary>
            /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
            public EntityRecognitionSkillVersion(string value)
            {
                _value = value ?? throw new ArgumentNullException(nameof(value));
            }

            /// <summary> Version 1 of the <see cref="EntityRecognitionSkill"/>. </summary>
            public static EntityRecognitionSkillVersion V1 { get; } = new EntityRecognitionSkillVersion(V1Value);

            /// <summary> Version 3 of the <see cref="EntityRecognitionSkill"/>. </summary>
            public static EntityRecognitionSkillVersion V3 { get; } = new EntityRecognitionSkillVersion(V3Value);

            /// <summary> Latest version of the <see cref="EntityRecognitionSkill"/>. </summary>
            public static EntityRecognitionSkillVersion Latest { get; } = EntityRecognitionSkillVersion.V3;

            /// <inheritdoc />
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object obj) => obj is EntityRecognitionSkillVersion other && Equals(other);

            /// <inheritdoc />
            public bool Equals(EntityRecognitionSkillVersion other) =>
                string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

            /// <summary> Defines the '==' operator on <see cref="EntityRecognitionSkillVersion"/>. </summary>
            public static bool operator ==(EntityRecognitionSkillVersion lhs, EntityRecognitionSkillVersion rhs) => lhs.Equals(rhs);

            /// <summary> Defines the '!=' operator on <see cref="EntityRecognitionSkillVersion"/>. </summary>
            public static bool operator !=(EntityRecognitionSkillVersion lhs, EntityRecognitionSkillVersion rhs) => !(lhs == rhs);

            /// <summary> Converts a string to a <see cref="EntityRecognitionSkillVersion"/>. </summary>
            public static implicit operator EntityRecognitionSkillVersion(string value) => new(value);

            /// <inheritdoc />
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode() => _value?.GetHashCode() ?? 0;

            /// <inheritdoc />
            public override string ToString() => _value;
        }
#pragma warning restore CA1034 // Nested types should not be visible
    }
}
