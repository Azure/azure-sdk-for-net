// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> Represents service version information of an <see cref="EntityRecognitionSkill"/>. </summary>
    public readonly partial struct EntityRecognitionSkillVersion : IEquatable<EntityRecognitionSkillVersion>
    {
        private readonly string _value;

        private const string V1Value = "#Microsoft.Skills.Text.EntityRecognitionSkill";
        private const string V3Value = "#Microsoft.Skills.Text.V3.EntityRecognitionSkill";

        /// <summary> Creates a new instance of <see cref="EntityRecognitionSkillVersion"/> </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EntityRecognitionSkillVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> Version 1 of the <see cref="EntityRecognitionSkill"/>. </summary>
        public static EntityRecognitionSkillVersion V1 { get; } = new EntityRecognitionSkillVersion(V1Value);

        /// <summary> Version 3 of the <see cref="EntityRecognitionSkill"/>. </summary>
        public static EntityRecognitionSkillVersion V3 { get; } = new EntityRecognitionSkillVersion(V3Value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EntityRecognitionSkillVersion other && Equals(other);

        /// <inheritdoc />
        public bool Equals(EntityRecognitionSkillVersion other) =>
            string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <summary> Defines the '==' operator on <see cref="EntityRecognitionSkillVersion"/> </summary>
        public static bool operator ==(EntityRecognitionSkillVersion lhs, EntityRecognitionSkillVersion rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary> Defines the '!=' operator on <see cref="EntityRecognitionSkillVersion"/>. </summary>
        public static bool operator !=(EntityRecognitionSkillVersion lhs, EntityRecognitionSkillVersion rhs) => !(lhs == rhs);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
