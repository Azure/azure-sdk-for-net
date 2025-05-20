// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Management.Models
{
    internal class RequestPath : IEquatable<RequestPath>, IReadOnlyList<string>
    {
        private const string ProviderPath = "/subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}";
        private const string FeaturePath = "/subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features";

        public const string ManagementGroupScopePrefix = "/providers/Microsoft.Management/managementGroups";
        public const string ResourceGroupScopePrefix = "/subscriptions/{subscriptionId}/resourceGroups";
        public const string SubscriptionScopePrefix = "/subscriptions";
        public const string TenantScopePrefix = "/tenants";
        public const string Providers = "/providers";

        public static readonly RequestPath ManagementGroup = new("/providers/Microsoft.Management/managementGroups/{managementGroupId}");
        public static readonly RequestPath ResourceGroup = new("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
        public static readonly RequestPath Subscription = new("/subscriptions/{subscriptionId}");
        public static readonly RequestPath Tenant = new(string.Empty);

        private string _path;
        private IReadOnlyList<string> _segments;

        public RequestPath(string path)
        {
            _path = path;
            _segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            IndexOfLastProviders = _path.LastIndexOf(Providers);
        }

        public RequestPath(IEnumerable<string> segments)
        {
            _segments = segments.ToArray();
            _path = string.Join("/", _segments);
        }

        public int Count => _segments.Count;

        public string SerializedPath => _path;

        public int IndexOfLastProviders { get; }

        public string this[int index] => _segments[index];

        /// <summary>
        /// Check if this <see cref="RequestPath"/> is a prefix path of the other request path.
        /// Note that this.IsAncestorOf(this) will return false which indicates that this method is testing the "proper ancestor" like a proper subset.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsAncestorOf(RequestPath other)
        {
            // To be the parent of other, you must at least be shorter than other.
            if (other.Count <= Count)
                return false;
            for (int i = 0; i < Count; i++)
            {
                // we need the segment to be identical when strict is true (which is the default value)
                // when strict is false, we also need the segment to be identical if it is constant.
                // but if it is a reference, we only require they have the same type, do not require they have the same variable name.
                // This case happens a lot during the management group parent detection - different RP calls this different things
                if (!this[i].Equals(other[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Trim this from the other and return the <see cref="RequestPath"/>that remain.
        /// The result is "other - this" by removing this as a prefix of other.
        /// If this == other, return empty request path
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">if this.IsAncestorOf(other) is false</exception>
        public RequestPath TrimAncestorFrom(RequestPath other)
        {
            if (TryTrimAncestorFrom(other, out var diff))
                return diff;

            throw new InvalidOperationException($"Request path {this} is not parent of {other}");
        }

        private bool TryTrimAncestorFrom(RequestPath other, [MaybeNullWhen(false)] out RequestPath diff)
        {
            diff = default;
            if (this == other)
            {
                diff = Tenant;
                return true;
            }
            if (IsAncestorOf(other))
            {
                diff = new RequestPath(string.Join("", other._segments.Skip(Count)));
                return true;
            }
            // Handle the special case of trim provider from feature
            else if (_path == ProviderPath && other._path.StartsWith(FeaturePath))
            {
                diff = new RequestPath(string.Join("", other._segments.Skip(Count + 2)));
                return true;
            }
            return false;
        }

        public bool Equals(RequestPath? other)
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

        public override bool Equals(object? obj) => obj is RequestPath other && Equals(other);

        public override int GetHashCode() => _path.GetHashCode();

        public override string ToString() => _path;

        public IEnumerator<String> GetEnumerator() => _segments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _segments.GetEnumerator();

        public static bool operator ==(RequestPath left, RequestPath right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RequestPath left, RequestPath right)
        {
            return !(left == right);
        }

        public static implicit operator string(RequestPath requestPath)
        {
            return requestPath._path;
        }

        public static bool IsSegmentConstant(string segment)
        {
            var trimmed = segment.TrimStart('{').TrimEnd('}');
            var isScope = trimmed == "scope";
            return !isScope && !segment.StartsWith('{');
        }
    }
}
