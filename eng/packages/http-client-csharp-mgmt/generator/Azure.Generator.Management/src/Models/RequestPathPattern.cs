// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Snippets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Management.Models
{
    /// <summary>
    /// This class provides the pattern of an operation request path.
    /// </summary>
    public class RequestPathPattern : IEquatable<RequestPathPattern>, IReadOnlyList<RequestPathSegment>
    {
        private const string ProviderPath = "/subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}";
        private const string FeaturePath = "/subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features";

        /// <summary> The request path pattern for a management group resource. </summary>
        public static readonly RequestPathPattern ManagementGroup = new("/providers/Microsoft.Management/managementGroups/{managementGroupId}");
        /// <summary> The request path pattern for a resource group resource. </summary>
        public static readonly RequestPathPattern ResourceGroup = new("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
        /// <summary> The request path pattern for a subscription-level resource. </summary>
        public static readonly RequestPathPattern Subscription = new("/subscriptions/{subscriptionId}");
        /// <summary> The request path pattern for a tenant-level resource. </summary>
        public static readonly RequestPathPattern Tenant = new(string.Empty);

        /// <summary> Gets the <see cref="RequestPathPattern"/> corresponding to the given <see cref="ResourceScope"/>. </summary>
        /// <param name="scope">The resource scope.</param>
        /// <param name="path">The request path, required when the scope is <see cref="ResourceScope.Extension"/>.</param>
        /// <returns>The request path pattern for the specified scope.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the scope is unhandled or when an extension scope is used without a path.</exception>
        public static RequestPathPattern GetFromScope(ResourceScope scope, RequestPathPattern? path = null)
        {
            return scope switch
            {
                ResourceScope.ResourceGroup => ResourceGroup,
                ResourceScope.Subscription => Subscription,
                ResourceScope.ManagementGroup => ManagementGroup,
                ResourceScope.Extension =>
                    path is null
                        ? throw new InvalidOperationException("Extension scope requires a path parameter.")
                        : new RequestPathPattern(path._segments.Take(1)),
                ResourceScope.Tenant => Tenant,
                _ => throw new InvalidOperationException($"Unhandled scope {scope}"),
            };
        }

        private string _path;
        private IReadOnlyList<RequestPathSegment> _segments;

        /// <summary> Initializes a new instance of <see cref="RequestPathPattern"/> from a raw path string. </summary>
        /// <param name="path">The raw request path string.</param>
        public RequestPathPattern(string path)
        {
            _path = path;
            _segments = ParseSegments(path);
        }

        /// <summary> Initializes a new instance of <see cref="RequestPathPattern"/> from a sequence of segments. </summary>
        /// <param name="segments">The segments that compose the request path.</param>
        public RequestPathPattern(IEnumerable<RequestPathSegment> segments)
        {
            _segments = [.. segments];
            _path = string.Join("/", _segments); // TODO -- leading slash???
        }

        private static IReadOnlyList<RequestPathSegment> ParseSegments(string path)
            => path.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(segment => new RequestPathSegment(segment))
                .ToArray();

        /// <summary> Gets the number of segments in this request path. </summary>
        public int Count => _segments.Count;

        /// <summary> Gets the serialized string representation of this request path. </summary>
        public string SerializedPath => _path;

        /// <summary> Gets the <see cref="RequestPathSegment"/> at the specified index. </summary>
        /// <param name="index">The zero-based index of the segment to get.</param>
        /// <returns>The segment at the specified index.</returns>
        public RequestPathSegment this[int index] => _segments[index];

        /// <summary>
        /// Check if this <see cref="RequestPathPattern"/> is a prefix path of the other request path.
        /// Note that this.IsAncestorOf(this) will return false which indicates that this method is testing the "proper ancestor" like a proper subset.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsAncestorOf(RequestPathPattern other)
        {
            // To be the ancestor of other, you must be shorter than other,
            // and all segments of this must match the beginning of other.
            return other.Count > Count && GetMaximumSharingSegmentsCount(this, other) == Count;
        }

        /// <summary>
        /// Trim this from the other and return the <see cref="RequestPathPattern"/>that remain.
        /// The result is "other - this" by removing this as a prefix of other.
        /// If this == other, return empty request path
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">if this.IsAncestorOf(other) is false</exception>
        public RequestPathPattern TrimAncestorFrom(RequestPathPattern other)
        {
            if (TryTrimAncestorFrom(other, out var diff))
                return diff;

            throw new InvalidOperationException($"Request path {this} is not parent of {other}");
        }

        private bool TryTrimAncestorFrom(RequestPathPattern other, [MaybeNullWhen(false)] out RequestPathPattern diff)
        {
            diff = default;
            if (this == other)
            {
                diff = Tenant;
                return true;
            }
            if (IsAncestorOf(other))
            {
                diff = new RequestPathPattern(other._segments.Skip(Count));
                return true;
            }
            // Handle the special case of trim provider from feature
            else if (_path == ProviderPath && other._path.StartsWith(FeaturePath))
            {
                diff = new RequestPathPattern(other._segments.Skip(Count + 2));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the number of shared segments between two <see cref="RequestPathPattern"/> instances,
        /// starting from the beginning of the paths. Segments are considered shared if both are variable segments,
        /// or if both are constant segments with equal values. The comparison stops at the first non-matching segment.
        /// </summary>
        /// <param name="left">The first <see cref="RequestPathPattern"/> to compare.</param>
        /// <param name="right">The second <see cref="RequestPathPattern"/> to compare.</param>
        /// <returns>
        /// The count of shared segments between the two paths.
        /// </returns>
        public static int GetMaximumSharingSegmentsCount(RequestPathPattern left, RequestPathPattern right)
        {
            var minCount = Math.Min(left.Count, right.Count);
            var count = 0;
            for (int i = 0; i < minCount; i++)
            {
                // if both of them are variable segments, we consider them as a match
                if (!left[i].IsConstant && !right[i].IsConstant)
                {
                    count++;
                    continue;
                }
                // if not both of them are constant, they do not match, we stop
                if (left[i].IsConstant != right[i].IsConstant)
                {
                    break;
                }
                // now both of them are constant segments, we compare their values
                if (left[i].Equals(right[i]))
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        /// <summary> Gets the parent request path by removing the last resource type/name segment pair. </summary>
        /// <returns>The parent <see cref="RequestPathPattern"/>.</returns>
        public RequestPathPattern GetParent()
        {
            // if the request path has 0 or 1 segment, we call its parent the Tenant.
            if (Count < 2)
            {
                return Tenant;
            }

            // if there are 4 or more segments,
            // there is a possibility that if we trim off the last two segments, we get a `providers` segment pair.
            // such as in `/providers/Microsoft.Management/managementGroups/{managementGroupId}`.
            // in this case, we need to trim off 2 more segments to get its real parent.
            if (Count >= 4 && _segments[^4].IsProvidersSegment)
            {
                return new RequestPathPattern(_segments.Take(Count - 4));
            }
            // otherwise, we return the parent by removing its last two segments
            return new RequestPathPattern(_segments.Take(Count - 2));
        }

        /// <inheritdoc />
        public bool Equals(RequestPathPattern? other)
        {
            if (Count != other?.Count)
                return false;
            for (int i = 0; i < Count; i++)
            {
                if (!this[i].Equals(other[i]))
                    return false;
            }
            return true;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is RequestPathPattern other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => _path.GetHashCode();

        /// <inheritdoc />
        public override string ToString() => _path;

        /// <inheritdoc />
        public IEnumerator<RequestPathSegment> GetEnumerator() => _segments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _segments.GetEnumerator();

        /// <summary> Determines whether two <see cref="RequestPathPattern"/> instances are equal. </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns><c>true</c> if the instances are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(RequestPathPattern? left, RequestPathPattern? right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (left is null || right is null)
                return false;
            return left.Equals(right);
        }

        /// <summary> Determines whether two <see cref="RequestPathPattern"/> instances are not equal. </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns><c>true</c> if the instances are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(RequestPathPattern? left, RequestPathPattern? right)
        {
            return !(left == right);
        }

        /// <summary> Implicitly converts a <see cref="RequestPathPattern"/> to its string representation. </summary>
        /// <param name="requestPath">The request path pattern to convert.</param>
        public static implicit operator string(RequestPathPattern requestPath)
        {
            return requestPath._path;
        }
    }
}
