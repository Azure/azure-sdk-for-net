// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Snippets;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Snippets;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;

namespace Azure.Generator.Management.Utilities
{
    internal static class ContextualParameterBuilder
    {
        /// <summary>
        /// This method accepts a <see cref="RequestPathPattern"/> as a contextual request path pattern
        /// of a certain resource or resource collection class,
        /// and builds a list of <see cref="ContextualParameter"/>s that represent the parameters
        /// provided by this contextual request path pattern.
        /// </summary>
        /// <param name="requestPathPattern">The contextual request path pattern.</param>
        /// <returns></returns>
        public static IReadOnlyList<ContextualParameter> BuildContextualParameters(RequestPathPattern requestPathPattern)
        {
            // we use a stack here because we are building the contextual parameters in reverse order.
            var result = new Stack<ContextualParameter>();

            BuildContextualParameterHierarchy(requestPathPattern, result, 0);

            return [.. result];
        }

        private static void BuildContextualParameterHierarchy(RequestPathPattern current, Stack<ContextualParameter> parameterStack, int parentLayerCount)
        {
            // TODO -- handle scope/extension resources
            // we resolved it until to tenant, exit because it no longer contains parameters
            if (current == RequestPathPattern.Tenant)
            {
                return;
            }
            // get the parent path
            var parent = current.GetParent();

            // handle the known special patterns
            if (current == RequestPathPattern.Subscription)
            {
                // using the reference name of the last segment as the parameter name, aka subscriptionId
                parameterStack.Push(new ContextualParameter(current[0].Value, current[1].VariableName, id => id.SubscriptionId()));
            }
            else if (current == RequestPathPattern.ManagementGroup)
            {
                // using the reference name of the last segment as the parameter name, aka managementGroupId
                parameterStack.Push(new ContextualParameter(current[^2].Value, current[^1].VariableName, id => BuildParentInvocation(parentLayerCount, id).Name()));
            }
            else if (current == RequestPathPattern.ResourceGroup)
            {
                // using the reference name of the last segment as the parameter name, aka resourceGroupName
                parameterStack.Push(new ContextualParameter(current[^2].Value, current[^1].VariableName, id => id.ResourceGroupName()));
            }
            else if (current.Count == 1 && !current[0].IsConstant) // Extension resource case: single variable segment
            {
                // Extension resource case: single variable segment
                parameterStack.Push(new ContextualParameter(current[0].Value, current[0].VariableName, id => BuildParentInvocation(parentLayerCount, id)));
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
