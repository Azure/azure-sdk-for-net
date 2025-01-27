// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Utilities
{
    internal static class RequestPathUtils
    {
        private const string ProviderPath = "/subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}";
        private const string FeaturePath = "/subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features";

        public const string ManagementGroupScopePrefix = "/providers/Microsoft.Management/managementGroups";
        public const string ResourceGroupScopePrefix = "/subscriptions/{subscriptionId}/resourceGroups";
        public const string SubscriptionScopePrefix = "/subscriptions";
        public const string TenantScopePrefix = "/tenants";
        public const string Providers = "/providers";

        public const string ManagementGroup = "/providers/Microsoft.Management/managementGroups/{managementGroupId}";
        public const string ResourceGroup = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";
        public const string Subscription = "/subscriptions/{subscriptionId}";
        public const string Tenant = "";

        private static readonly ConcurrentDictionary<string, string[]> _pathSegmentsCache = new();

        public static string[] GetPathSegments(string requestPath)
        {
            if (_pathSegmentsCache.TryGetValue(requestPath, out var segments))
            {
                return segments;
            }
            segments = requestPath.Split('/', StringSplitOptions.RemoveEmptyEntries);
            _pathSegmentsCache.TryAdd(requestPath, segments);
            return segments;
        }

        /// <summary>
        /// Check if this request path is a prefix path of the other request path.
        /// Note that this.IsAncestorOf(this) will return false which indicates that this method is testing the "proper ancestor" like a proper subset.
        /// </summary>
        /// <param name="ancestor"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsAncestorOf(string ancestor, string other)
        {
            var pathSegments = GetPathSegments(ancestor);
            var otherSegments = GetPathSegments(other);
            // To be the parent of other, you must at least be shorter than other.
            if (otherSegments.Count() <= pathSegments.Count())
                return false;
            for (int i = 0; i < pathSegments.Count(); i++)
            {
                // we need the segment to be identical when strict is true (which is the default value)
                // when strict is false, we also need the segment to be identical if it is constant.
                // but if it is a reference, we only require they have the same type, do not require they have the same variable name.
                // This case happens a lot during the management group parent detection - different RP calls this different things
                if (!pathSegments[i].Equals(otherSegments[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Trim this from the other and return the request path that remain.
        /// The result is "other - this" by removing this as a prefix of other.
        /// If this == other, return empty request path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">if this.IsAncestorOf(other) is false</exception>
        public static string TrimAncestorFrom(string path, string other)
        {
            if (TryTrimAncestorFrom(path, other, out var diff))
                return diff;

            throw new InvalidOperationException($"Request path {path} is not parent of {other}");
        }

        private static bool TryTrimAncestorFrom(string path, string other, [MaybeNullWhen(false)] out string diff)
        {
            var pathSegments = GetPathSegments(path);
            var otherSegments = GetPathSegments(other);
            diff = default;
            if (path == other)
            {
                diff = Tenant;
                return true;
            }
            if (IsAncestorOf(path, other))
            {
                diff = string.Join("", otherSegments.Skip(pathSegments.Length));
                return true;
            }
            // Handle the special case of trim provider from feature
            else if (path == ProviderPath && other.StartsWith(FeaturePath))
            {
                diff = string.Join("", otherSegments.Skip(pathSegments.Length + 2));
                return true;
            }
            return false;
        }

        public static bool IsConstant(string segment)
        {
            var trimmed = TrimRawSegment(segment);
            var isScope = trimmed == "scope";
            return !isScope && !segment.Contains('{');
        }

        private static string TrimRawSegment(string segment) => segment.TrimStart('{').TrimEnd('}');
    }
}
