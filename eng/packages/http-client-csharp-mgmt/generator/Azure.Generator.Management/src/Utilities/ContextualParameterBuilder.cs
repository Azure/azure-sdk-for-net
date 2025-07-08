// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Snippets;
using Microsoft.TypeSpec.Generator.Snippets;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Generator.Management.Utilities
{
    internal static class ContextualParameterBuilder
    {
        public static IReadOnlyList<ContextualParameter> BuildContextualParameters(RequestPathPattern requestPathPattern)
        {
            var result = new Stack<ContextualParameter>();

            BuildContextualParameterHierarchy(requestPathPattern, result, id => id);

            return [.. result];
        }

        private static void BuildContextualParameterHierarchy(RequestPathPattern current, Stack<ContextualParameter> parameterStack, Func<ScopedApi<ResourceIdentifier>, ScopedApi<ResourceIdentifier>> idMutator)
        {
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
                parameterStack.Push(new ContextualParameter(current[0].Value, current[1].VariableName, id => idMutator(id).SubscriptionId()));
            }
            else if (current == RequestPathPattern.ManagementGroup)
            {
                // using the reference name of the last segment as the parameter name, aka managementGroupId
                parameterStack.Push(new ContextualParameter(current[^2].Value, current[^1].VariableName, id => idMutator(id).Name()));
            }
            else if (current == RequestPathPattern.ResourceGroup)
            {
                // using the reference name of the last segment as the parameter name, aka resourceGroupName
                parameterStack.Push(new ContextualParameter(current[^2].Value, current[^1].VariableName, id => idMutator(id).ResourceGroupName()));
            }
            else
            {
                // get the diff between the current path and the parent path, we only handle the diff and defer the handling of the parent itself in the next recursion.
                var diffPath = parent.TrimAncestorFrom(current);
                // TODO -- this only handles the simplest cases right now, we need to add more cases as the generator evolves.
                var pairs = SplitIntoPairs(diffPath);

                // TODO -- come back here
            }
            // recurisvely get the parameters of its parent
            BuildContextualParameterHierarchy(parent, parameterStack, idMutator);
        }

        private static IReadOnlyList<KeyValuePair<RequestPathSegment, RequestPathSegment>> SplitIntoPairs(IReadOnlyList<RequestPathSegment> requestPath)
        {
            // in our current cases, we will always have even segments.
            Debug.Assert(requestPath.Count % 2 == 0, "The request path should always have an even number of segments for pairing.");
            int maxNumberOfPairs = requestPath.Count / 2;
            var pairs = new KeyValuePair<RequestPathSegment, RequestPathSegment>[maxNumberOfPairs];

            for (int i = 0; i < maxNumberOfPairs; i++)
            {
                // each pair is a key-value pair, where the key is the first segment and the value is the second segment.
                pairs[i] = new KeyValuePair<RequestPathSegment, RequestPathSegment>(
                    requestPath[i * 2],
                    requestPath[i * 2 + 1]);
            }

            return pairs;
        }
    }
}
