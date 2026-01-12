// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Microsoft.TypeSpec.Generator.Snippets;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Generator.Management.Models
{
    internal class ContextualPath
    {
        public RequestPathPattern RawPath { get; }
        public IReadOnlyList<ContextualParameter> ContextualParameters { get; }
        public ContextualPath(RequestPathPattern rawPath)
        {
            RawPath = rawPath;
            ContextualParameters = BuildContextualParameters(rawPath);
        }

        /// <summary>
        /// This method accepts a <see cref="RequestPathPattern"/> as a contextual request path pattern
        /// of a certain resource or resource collection class,
        /// and builds a list of <see cref="ContextualParameter"/>s that represent the parameters
        /// provided by this contextual request path pattern.
        /// </summary>
        /// <param name="requestPathPattern">The contextual request path pattern.</param>
        /// <returns></returns>
        private static IReadOnlyList<ContextualParameter> BuildContextualParameters(RequestPathPattern requestPathPattern)
        {
            // we use a stack here because we are building the contextual parameters in reverse order.
            var result = new Stack<ContextualParameter>();

            BuildContextualParameterHierarchy(requestPathPattern, result, 0);

            return [.. result];
        }

        /// <summary>
        /// Builds a mapping from operation path parameters to contextual parameters.
        /// Parameters are matched by their key (the constant segment before the parameter) first,
        /// and if no key match is found, by their name.
        /// </summary>
        /// <param name="operationPath">The operation's request path.</param>
        /// <returns>A parameter mapping that maps operation parameter names to contextual parameters.</returns>
        public ParameterContextRegistry BuildParameterMapping(RequestPathPattern operationPath)
        {
            // we need to find the sharing part between contextual path and the incoming path
            var sharedSegmentsCount = RequestPathPattern.GetMaximumSharingSegmentsCount(RawPath, operationPath);

            return new ParameterContextRegistry(BuildParameterMappingCore(ContextualParameters, operationPath, sharedSegmentsCount));
        }

        private static IReadOnlyList<ParameterContextMapping> BuildParameterMappingCore(IReadOnlyList<ContextualParameter> contextualParameters, RequestPathPattern operationPath, int sharedSegmentsCount)
        {
            var parameterMappings = new List<ParameterContextMapping>();
            for (int i = 0, parameterIndex = 0; i < operationPath.Count; i++)
            {
                var segment = operationPath[i];
                // skip all the constant segments
                if (segment.IsConstant)
                {
                    continue;
                }
                // we can only assign contextual parameters when we are in the shared segments area where this part could be found in the contextual path.
                if (i < sharedSegmentsCount && parameterIndex < contextualParameters.Count)
                {
                    // we are in the area of contextual paths
                    var mapping = new ParameterContextMapping(segment.VariableName, contextualParameters[parameterIndex]);
                    parameterMappings.Add(mapping);
                }
                else
                {
                    var mapping = new ParameterContextMapping(segment.VariableName, null);
                    parameterMappings.Add(mapping);
                }
                parameterIndex++;
            }
            return parameterMappings;
        }

        /*
        private static Dictionary<string, ContextualParameter> BuildMappingForAncestorCase(ContextualPath contextualPath, RequestPathPattern operationPath)
        {
            // in this case, the contextual path is an ancestor of the operation path, therefore we just take the that many contextual parameters as the mapping.
            var contextualParameters = contextualPath.ContextualParameters;
            var mapping = new Dictionary<string, ContextualParameter>();
            int parameterIndex = 0;
            foreach (var segment in operationPath)
            {
                if (segment.IsConstant)
                {
                    continue;
                }
                if (parameterIndex >= contextualParameters.Count)
                {
                    break;
                }
                mapping[segment.VariableName] = contextualParameters[parameterIndex];
                parameterIndex++;
            }

            return mapping;
        }

        private static Dictionary<string, ContextualParameter> BuildMappingForNonAncestorCase(ContextualPath contextualPath, RequestPathPattern operationPath)
        {
            // find the maximum shared segments between the two paths, we put operationPath as the first argument because later we will iterate on it to match contextual parameters.
            var sharedSegments = RequestPathPattern.GetMaximumSharingSegments(operationPath, contextualPath.RawPath);
            var contextualParameters = contextualPath.ContextualParameters;
            var mapping = new Dictionary<string, ContextualParameter>();
            int parameterIndex = 0;
            foreach (var segment in sharedSegments)
            {
                if (segment.IsConstant)
                {
                    continue;
                }
                if (parameterIndex >= contextualParameters.Count)
                {
                    break;
                }
                mapping[segment.VariableName] = contextualParameters[parameterIndex];
                parameterIndex++;
            }

            return mapping;
        }
        */

        /// <summary>
        /// Extracts parameters with their keys from a request path.
        /// Each parameter is paired with the constant segment immediately before it (the key).
        /// </summary>
        private static IReadOnlyList<(string Key, string VariableName)> ExtractParametersWithKeys(RequestPathPattern requestPath)
        {
            var result = new List<(string, string)>();

            for (int i = 0; i < requestPath.Count; i++)
            {
                var segment = requestPath[i];
                if (!segment.IsConstant)
                {
                    // Found a parameter - look for the key (the constant segment before it)
                    string key = string.Empty;
                    if (i > 0 && requestPath[i - 1].IsConstant)
                    {
                        key = requestPath[i - 1].Value;
                    }
                    result.Add((key, segment.VariableName));
                }
            }

            return result;
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
            else if (current.Count == 1 && !current[0].IsConstant) // Extension resource case: single variable segment. Here we assume the extension resource's requestPathPattern start with one and only one variable segment
            {
                // Extension resource case: single variable segment
                parameterStack.Push(new ContextualParameter(current[0].VariableName, current[0].VariableName, id => BuildParentInvocation(parentLayerCount, id)));
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
                        if (!key.IsProvidersSegment)
                        {
                            // When the value is a constant (e.g., a singleton resource name) and the key is not providers,
                            // we need to skip this level and increment the parent hierarchy so that parameters from parent segments get the correct .Parent reference
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
