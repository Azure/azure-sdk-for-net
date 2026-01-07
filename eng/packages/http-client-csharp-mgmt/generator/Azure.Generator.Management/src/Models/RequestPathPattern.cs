// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Management.Models
{
    /// <summary>
    /// This class provides the pattern of an operation request path.
    /// </summary>
    internal class RequestPathPattern : IEquatable<RequestPathPattern>, IReadOnlyList<RequestPathSegment>
    {
        private const string ProviderPath = "/subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}";
        private const string FeaturePath = "/subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features";

        public static readonly RequestPathPattern ManagementGroup = new("/providers/Microsoft.Management/managementGroups/{managementGroupId}");
        public static readonly RequestPathPattern ResourceGroup = new("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}");
        public static readonly RequestPathPattern Subscription = new("/subscriptions/{subscriptionId}");
        public static readonly RequestPathPattern Tenant = new(string.Empty);

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

        public RequestPathPattern(string path)
        {
            _path = path;
            _segments = ParseSegments(path);
        }

        public RequestPathPattern(IEnumerable<RequestPathSegment> segments)
        {
            _segments = [.. segments];
            _path = string.Join("/", _segments); // TODO -- leading slash???
        }

        private static IReadOnlyList<RequestPathSegment> ParseSegments(string path)
            => path.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(segment => new RequestPathSegment(segment))
                .ToArray();

        public int Count => _segments.Count;

        public string SerializedPath => _path;

        public RequestPathSegment this[int index] => _segments[index];

        /// <summary>
        /// Check if this <see cref="RequestPathPattern"/> is a prefix path of the other request path.
        /// Note that this.IsAncestorOf(this) will return false which indicates that this method is testing the "proper ancestor" like a proper subset.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsAncestorOf(RequestPathPattern other)
        {
            // Ancestor detection: compare only constant segments, skip variable segments.
            // To be the parent of other, you must at least be shorter than other.
            if (other.Count <= Count)
                return false;
            for (int i = 0; i < Count; i++)
            {
                if (this[i].IsConstant)
                {
                    if (!this[i].Equals(other[i]))
                        return false;
                }
                else // variable segment
                {
                    if (!other[i].IsConstant)
                        continue;
                    return false;
                }
            }
            return true;
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

        public override bool Equals(object? obj) => obj is RequestPathPattern other && Equals(other);

        public override int GetHashCode() => _path.GetHashCode();

        public override string ToString() => _path;

        public IEnumerator<RequestPathSegment> GetEnumerator() => _segments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _segments.GetEnumerator();

        public static bool operator ==(RequestPathPattern left, RequestPathPattern right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RequestPathPattern left, RequestPathPattern right)
        {
            return !(left == right);
        }

        public static implicit operator string(RequestPathPattern requestPath)
        {
            return requestPath._path;
        }

        private IReadOnlyDictionary<string, ContextualParameter>? _contextualParameters;
        private IReadOnlyDictionary<string, ContextualParameter>? _contextualParametersByKey;

        /// <summary>
        /// Get the corresponding contextual parameter in this request path for a provided parameter.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="contextualParameter"></param>
        /// <param name="operationPath">Optional operation request path pattern to match parameters by key.</param>
        /// <returns></returns>
        public bool TryGetContextualParameter(ParameterProvider parameter, [MaybeNullWhen(false)] out ContextualParameter contextualParameter, RequestPathPattern? operationPath = null)
        {
            contextualParameter = null;
            if (parameter.Location != ParameterLocation.Path)
            {
                return false;
            }

            // Build contextual parameter dictionaries lazily
            if (_contextualParameters is null)
            {
                var contextualParams = ContextualParameterBuilder.BuildContextualParameters(this);
                _contextualParameters = contextualParams.ToDictionary(p => p.VariableName);
                _contextualParametersByKey = contextualParams.Where(p => !string.IsNullOrEmpty(p.Key)).ToDictionary(p => p.Key);
            }

            var parameterName = parameter.WireInfo.SerializedName;

            // First, try to match by parameter name
            if (_contextualParameters.TryGetValue(parameterName, out contextualParameter))
            {
                return true;
            }

            // If no match by name and operation path is provided, try to match by key
            if (operationPath is not null && _contextualParametersByKey is not null)
            {
                // Find the key for this parameter in the operation path
                string? key = GetParameterKey(operationPath, parameterName);
                if (key != null && _contextualParametersByKey.TryGetValue(key, out contextualParameter))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the key (preceding segment) for a given parameter in a request path.
        /// For example, in "/fleets/{name}/children/{childName}", the key for "name" is "fleets".
        /// </summary>
        /// <param name="requestPath">The request path pattern.</param>
        /// <param name="parameterName">The parameter name to find the key for.</param>
        /// <returns>The key if found, otherwise null.</returns>
        private static string? GetParameterKey(RequestPathPattern requestPath, string parameterName)
        {
            for (int i = 0; i < requestPath.Count; i++)
            {
                var segment = requestPath[i];
                if (!segment.IsConstant && segment.VariableName == parameterName)
                {
                    // Found the parameter, check if there's a preceding constant segment
                    if (i > 0 && requestPath[i - 1].IsConstant)
                    {
                        return requestPath[i - 1].Value;
                    }
                    break;
                }
            }
            return null;
        }
    }
}
