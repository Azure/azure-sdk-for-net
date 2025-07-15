// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
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

        /// <summary>
        /// Get the corresponding contextual parameter in this request path for a provided parameter.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="contextualParameter"></param>
        /// <returns></returns>
        public bool TryGetContextualParameter(ParameterProvider parameter, [MaybeNullWhen(false)] out ContextualParameter contextualParameter)
        {
            contextualParameter = null;
            if (parameter.Location != ParameterLocation.Path)
            {
                return false;
            }

            _contextualParameters ??= BuildContextualParameters(this);

            return _contextualParameters.TryGetValue(parameter.WireInfo.SerializedName, out contextualParameter);
        }

        /// <summary>
        /// This method accepts a <see cref="RequestPathPattern"/> as a contextual request path pattern
        /// of a certain resource or resource collection class,
        /// and builds a list of <see cref="ContextualParameter"/>s that represent the parameters
        /// provided by this contextual request path pattern.
        /// </summary>
        /// <param name="requestPathPattern">The contextual request path pattern.</param>
        /// <returns></returns>
        private static IReadOnlyDictionary<string, ContextualParameter> BuildContextualParameters(RequestPathPattern requestPathPattern)
        {
            // we use a stack here because we are building the contextual parameters in reverse order.
            var result = new Stack<ContextualParameter>();

            BuildContextualParameterHierarchy(requestPathPattern, result, 0);

            return result.ToArray().ToDictionary(p => p.VariableName);
        }

        private static void BuildContextualParameterHierarchy(RequestPathPattern current, Stack<ContextualParameter> parameterStack, int parentLayerCount)
        {
            // TODO -- handle scope/extension resources
            // we resolved it until to tenant, exit because it no longer contains parameters
            if (current == Tenant)
            {
                return;
            }
            // get the parent path
            var parent = current.GetParent();

            // handle the known special patterns
            if (current == Subscription)
            {
                // using the reference name of the last segment as the parameter name, aka subscriptionId
                parameterStack.Push(new ContextualParameter(current[0].Value, current[1].VariableName, id => id.SubscriptionId()));
            }
            else if (current == ManagementGroup)
            {
                // using the reference name of the last segment as the parameter name, aka managementGroupId
                parameterStack.Push(new ContextualParameter(current[^2].Value, current[^1].VariableName, id => BuildParentInvocation(parentLayerCount, id).Name()));
            }
            else if (current == ResourceGroup)
            {
                // using the reference name of the last segment as the parameter name, aka resourceGroupName
                parameterStack.Push(new ContextualParameter(current[^2].Value, current[^1].VariableName, id => id.ResourceGroupName()));
            }
            else
            {
                // get the diff between the current path and the parent path, we only handle the diff and defer the handling of the parent itself in the next recursion.
                var diffPath = parent.TrimAncestorFrom(current);
                // TODO -- this only handles the simplest cases right now, we need to add more cases as the generator evolves.
                var pairs = ReverselySplitIntoPairs(diffPath);
                var appendParent = false;
                foreach (var (key, value) in pairs)
                {
                    // we have a pair of segment, key and value
                    // In majority of cases, the key is a constant segment. In some rare scenarios, the key could be a variable.
                    // The value could be a constant or a variable segment.
                    if (!value.IsConstant)
                    {
                        if (key.IsProvidersSegment) // if the key is `providers` and the value is a parameter
                        {
                            if (current.Count <= 4) // path is /providers/{resourceProviderNamespace} or /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
                            {
                                // we have to reassign the value of parentLayerCount to a local variable to avoid the closure to wrap the parentLayerCount variable which changes during recursion.
                                int currentParentCount = parentLayerCount;
                                parameterStack.Push(new ContextualParameter(key.Value, value.VariableName, id => BuildParentInvocation(currentParentCount, id).Provider()));
                            }
                            else
                            {
                                // we have to reassign the value of parentLayerCount to a local variable to avoid the closure to wrap the parentLayerCount variable which changes during recursion.
                                int currentParentCount = parentLayerCount;
                                parameterStack.Push(new ContextualParameter(key.Value, value.VariableName, id => BuildParentInvocation(currentParentCount, id).ResourceType().Namespace()));
                            }
                            // do not append a new .Parent to the id
                        }
                        else // for all other normal keys
                        {
                            // we have to reassign the value of parentLayerCount to a local variable to avoid the closure to wrap the parentLayerCount variable which changes during recursion.
                            int currentParentCount = parentLayerCount;
                            parameterStack.Push(new ContextualParameter(key.Value, value.VariableName, id => BuildParentInvocation(currentParentCount, id).Name()));
                            appendParent = true;
                        }
                    }
                    else // in this branch value is a constant
                    {
                        if (key.IsProvidersSegment)
                        {
                            // if the key is not providers, we need to skip this level and increment the parent hierarchy
                            appendParent = true;
                        }
                    }
                }
                // check if we need to call .Parent on id
                if (appendParent)
                {
                    parentLayerCount++;
                }
            }
            // recursively get the parameters of its parent
            BuildContextualParameterHierarchy(parent, parameterStack, parentLayerCount);

            static ScopedApi<ResourceIdentifier> BuildParentInvocation(int parentLayerCount, ScopedApi<ResourceIdentifier> id)
            {
                var result = id;
                for (int i = 0; i < parentLayerCount; i++)
                {
                    result = result.Parent();
                }
                return result;
            }

            static IReadOnlyList<KeyValuePair<RequestPathSegment, RequestPathSegment>> ReverselySplitIntoPairs(IReadOnlyList<RequestPathSegment> requestPath)
            {
                // in our current cases, we will always have even segments.
                Debug.Assert(requestPath.Count % 2 == 0, "The request path should always have an even number of segments for pairing.");
                int maxNumberOfPairs = requestPath.Count / 2;
                var pairs = new KeyValuePair<RequestPathSegment, RequestPathSegment>[maxNumberOfPairs];

                for (int i = 0; i < maxNumberOfPairs; i++)
                {
                    // each pair is a key-value pair, where the key is the first segment and the value is the second segment.
                    // please note that we are filling the pairs in reverse order
                    pairs[^(i + 1)] = new KeyValuePair<RequestPathSegment, RequestPathSegment>(
                        requestPath[i * 2],
                        requestPath[i * 2 + 1]);
                }

                return pairs;
            }
        }
    }
}
