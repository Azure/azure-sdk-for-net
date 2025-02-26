// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Models;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Azure.Generator.Utilities
{
    internal class ScopeDetection
    {
        private ConcurrentDictionary<RequestPath, RequestPath> _scopePathMap;

        public ScopeDetection()
        {
            _scopePathMap = new();
        }

        public RequestPath GetScopePath(RequestPath requestPath)
        {
            if (_scopePathMap.TryGetValue(requestPath, out var scope))
            {
                return scope;
            }

            scope = CalculateScopePath(requestPath);
            _scopePathMap.TryAdd(requestPath, scope);
            return scope;
        }

        private static RequestPath CalculateScopePath(RequestPath requestPath)
        {
            var indexOfProvider = requestPath.IndexOfLastProviders;
            // if there is no providers segment, myself should be a scope request path. Just return myself
            if (indexOfProvider >= 0)
            {
                if (indexOfProvider == 0 && ((string)requestPath).StartsWith(RequestPath.ManagementGroupScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                    return RequestPath.ManagementGroup;
                return new RequestPath(requestPath.Take(indexOfProvider));
            }
            if (((string)requestPath).StartsWith(RequestPath.ResourceGroupScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                return RequestPath.ResourceGroup;
            if (((string)requestPath).StartsWith(RequestPath.SubscriptionScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                return RequestPath.Subscription;
            if (requestPath.Equals(RequestPath.TenantScopePrefix))
                return RequestPath.Tenant;
            return requestPath;
        }

        /// <summary>
        /// Returns true if this request path is a parameterized scope, like the "/{scope}" in "/{scope}/providers/M.C/virtualMachines/{vmName}"
        /// Also returns true when this scope is explicitly set as a parameterized scope in the configuration
        /// </summary>
        /// <param name="scopePath"></param>
        /// <returns></returns>
        public static bool IsParameterizedScope(RequestPath scopePath)
        {
            //// if this path could be found inside the configuration, we just return true for that.
            //if (Configuration.MgmtConfiguration.ParameterizedScopes.Contains(scopePath))
            //    return true;

            // if the path is not in the configuration, we go through the default logic to check if it is parameterized scope
            return IsRawParameterizedScope(scopePath);
        }

        public static bool IsRawParameterizedScope(RequestPath scopePath)
        {
            // if a request is an implicit scope, it must only have one segment
            if (scopePath.Count != 1)
                return false;

            // now the path only has one segment
            var first = scopePath.First();
            // then we need to ensure the corresponding parameter enables `x-ms-skip-url-encoding`
            if (RequestPath.IsSegmentConstant(first))
                return false; // actually this cannot happen

            return true;
        }
    }
}
