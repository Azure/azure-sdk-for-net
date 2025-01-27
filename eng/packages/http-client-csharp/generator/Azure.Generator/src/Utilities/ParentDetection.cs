// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Utilities
{
    internal class ParentDetection
    {
        private ConcurrentDictionary<string, string> _requestPathToParentCache;
        //private ConcurrentDictionary<ResourceProvider, IReadOnlyList<ResourceProvider>> _resourceParentsMap = new();

        public ParentDetection()
        {
            _requestPathToParentCache = new();
        }

        public string GetParentRequestPath(string requestPath)
        {
            if (_requestPathToParentCache.TryGetValue(requestPath, out var result))
            {
                return result;
            }

            result = GetParent(requestPath);
            _requestPathToParentCache.TryAdd(requestPath, result);
            return result;
        }

        private string GetParent(string requestPath)
        {
            // find a parent resource in the resource list
            // we are taking the resource with a path that is the child of this operationSet and taking the longest candidate
            // or null if none matched
            // NOTE that we are always using fuzzy match in the IsAncestorOf method, we need to block the ById operations - they literally can be anyone's ancestor when there is no better choice.
            // We will never want this
            var scope = AzureClientPlugin.Instance.ScopeDetection.GetScopePath(requestPath);
            var candidates = AzureClientPlugin.Instance.OutputLibrary.ResourceOperationSets.Value.Select(operationSet => operationSet.RequestPath)
                .Concat(new List<string> { RequestPathUtils.ResourceGroup, RequestPathUtils.Subscription, RequestPathUtils.ManagementGroup }) // When generating management group in management.json, the path is /providers/Microsoft.Management/managementGroups/{groupId} while RequestPath.ManagementGroup is /providers/Microsoft.Management/managementGroups/{managementGroupId}. We pick the first one.
                //.Concat(Configuration.MgmtConfiguration.ParameterizedScopes)
                .Where(r => RequestPathUtils.IsAncestorOf(r, requestPath)).OrderByDescending(r => RequestPathUtils.GetPathSegments(r).Length);
            if (candidates.Any())
            {
                var parent = candidates.First();
                if (parent == RequestPathUtils.Tenant)
                {
                    // when generating for tenant and a scope path like policy assignment in Azure.ResourceManager, Tenant could be the only parent in context.Library.ResourceOperationSets.
                    // we need to return the parameterized scope instead.
                    if (scope != requestPath && ScopeDetection.IsParameterizedScope(scope))
                        parent = scope;
                }
                return parent;
            }
            // the only option left is the tenant. But we have our last chance that its parent could be the scope of this
            // if the scope of this request path is parameterized, we return the scope as its parent
            if (scope != requestPath && ScopeDetection.IsParameterizedScope(scope))
                return scope;
            // we do not have much choice to make, return tenant as the parent
            return RequestPathUtils.Tenant;
        }
    }
}
