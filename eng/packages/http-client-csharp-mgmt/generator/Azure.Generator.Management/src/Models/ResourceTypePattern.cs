// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Models
{
    /// <summary> Represents an ARM resource type pattern split into provider namespace and resource type segments. </summary>
    public sealed class ResourceTypePattern : IEquatable<ResourceTypePattern>, IReadOnlyList<RequestPathSegment>
    {
        private readonly IReadOnlyList<RequestPathSegment> _segments;
        private readonly string _resourceType;

        /// <summary> Initializes a new instance of <see cref="ResourceTypePattern"/> from a serialized resource type. </summary>
        /// <param name="resourceType">The serialized ARM resource type.</param>
        public ResourceTypePattern(string resourceType)
            : this(resourceType.Split('/', StringSplitOptions.RemoveEmptyEntries).Select(segment => new RequestPathSegment(segment)))
        {
        }

        /// <summary> Initializes a new instance of <see cref="ResourceTypePattern"/> from resource type segments. </summary>
        /// <param name="segments">The segments that compose the resource type.</param>
        public ResourceTypePattern(IEnumerable<RequestPathSegment> segments)
        {
            _segments = [.. segments];
            _resourceType = string.Join("/", _segments);
        }

        /// <inheritdoc />
        public int Count => _segments.Count;

        /// <summary> Gets the serialized ARM resource type. </summary>
        public string SerializedResourceType => _resourceType;

        /// <summary> Gets the <see cref="RequestPathSegment"/> at the specified index. </summary>
        /// <param name="index">The zero-based index of the segment to get.</param>
        /// <returns>The segment at the specified index.</returns>
        public RequestPathSegment this[int index] => _segments[index];

        /// <inheritdoc />
        public bool Equals(ResourceTypePattern? other)
        {
            if (Count != other?.Count)
            {
                return false;
            }

            for (int i = 0; i < Count; i++)
            {
                if (!_segments[i].Equals(other[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is ResourceTypePattern other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hash = new HashCode();
            foreach (var segment in _segments)
            {
                hash.Add(segment);
            }
            return hash.ToHashCode();
        }

        /// <inheritdoc />
        public override string ToString() => _resourceType;

        /// <inheritdoc />
        public IEnumerator<RequestPathSegment> GetEnumerator() => _segments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _segments.GetEnumerator();
    }
}
