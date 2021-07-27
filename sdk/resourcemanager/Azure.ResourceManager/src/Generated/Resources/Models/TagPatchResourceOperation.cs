// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> The operation type for the patch API. </summary>
    public readonly partial struct TagPatchResourceOperation : IEquatable<TagPatchResourceOperation>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="TagPatchResourceOperation"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public TagPatchResourceOperation(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ReplaceValue = "Replace";
        private const string MergeValue = "Merge";
        private const string DeleteValue = "Delete";

        /// <summary> Replace. </summary>
        public static TagPatchResourceOperation Replace { get; } = new TagPatchResourceOperation(ReplaceValue);
        /// <summary> Merge. </summary>
        public static TagPatchResourceOperation Merge { get; } = new TagPatchResourceOperation(MergeValue);
        /// <summary> Delete. </summary>
        public static TagPatchResourceOperation Delete { get; } = new TagPatchResourceOperation(DeleteValue);
        /// <summary> Determines if two <see cref="TagPatchResourceOperation"/> values are the same. </summary>
        public static bool operator ==(TagPatchResourceOperation left, TagPatchResourceOperation right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TagPatchResourceOperation"/> values are not the same. </summary>
        public static bool operator !=(TagPatchResourceOperation left, TagPatchResourceOperation right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TagPatchResourceOperation"/>. </summary>
        public static implicit operator TagPatchResourceOperation(string value) => new TagPatchResourceOperation(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TagPatchResourceOperation other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TagPatchResourceOperation other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
