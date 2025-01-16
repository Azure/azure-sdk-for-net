// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Models;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Azure.Generator.Utilities
{
    internal static class ScopeDetection
    {
        private static ConcurrentDictionary<RequestPath, RequestPath> _scopePathCache = new ConcurrentDictionary<RequestPath, RequestPath>();
        private static ConcurrentDictionary<RequestPath, ResourceTypeSegment[]?> _scopeTypesCache = new ConcurrentDictionary<RequestPath, ResourceTypeSegment[]?>();

        public static RequestPath GetScopePath(this RequestPath requestPath)
        {
            if (_scopePathCache.TryGetValue(requestPath, out var result))
                return result;

            result = CalculateScopePath(requestPath);
            _scopePathCache.TryAdd(requestPath, result);
            return result;
        }

        /// <summary>
        /// Returns true if this request path is a parameterized scope, like the "/{scope}" in "/{scope}/providers/M.C/virtualMachines/{vmName}"
        /// Also returns true when this scope is explicitly set as a parameterized scope in the configuration
        /// </summary>
        /// <param name="scopePath"></param>
        /// <returns></returns>
        public static bool IsParameterizedScope(this RequestPath scopePath)
        {
            //// if this path could be found inside the configuration, we just return true for that.
            //if (Configuration.MgmtConfiguration.ParameterizedScopes.Contains(scopePath))
            //    return true;

            // if the path is not in the configuration, we go through the default logic to check if it is parameterized scope
            return IsRawParameterizedScope(scopePath);
        }

        public static bool IsRawParameterizedScope(this RequestPath scopePath)
        {
            // if a request is an implicit scope, it must only have one segment
            if (scopePath.Count != 1)
                return false;
            // now the path only has one segment
            var first = scopePath.First();
            // then we need to ensure the corresponding parameter enables `x-ms-skip-url-encoding`
            if (first.IsConstant)
                return false; // actually this cannot happen
                              // now the first segment is a reference
                              // we ensure this parameter enables x-ms-skip-url-encoding, aka Escape is false
            return first.SkipUrlEncoding;
        }

        private static RequestPath CalculateScopePath(RequestPath requestPath)
        {
            var indexOfProvider = requestPath.IndexOfLastProviders;
            // if there is no providers segment, myself should be a scope request path. Just return myself
            if (indexOfProvider >= 0)
            {
                if (indexOfProvider == 0 && requestPath.SerializedPath.StartsWith(RequestPath.ManagementGroupScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                    return RequestPath.ManagementGroup;
                return RequestPath.FromSegments(requestPath.Take(indexOfProvider));
            }
            if (requestPath.SerializedPath.StartsWith(RequestPath.ResourceGroupScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                return RequestPath.ResourceGroup;
            if (requestPath.SerializedPath.StartsWith(RequestPath.SubscriptionScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                return RequestPath.Subscription;
            if (requestPath.SerializedPath.Equals(RequestPath.TenantScopePrefix))
                return RequestPath.Tenant;
            return requestPath;
        }

        public static ResourceTypeSegment[]? GetParameterizedScopeResourceTypes(this RequestPath requestPath)
        {
            if (_scopeTypesCache.TryGetValue(requestPath, out var result))
                return result;

            result = requestPath.CalculateScopeResourceTypes();
            _scopeTypesCache.TryAdd(requestPath, result);
            return result;
        }

        private static ResourceTypeSegment[]? CalculateScopeResourceTypes(this RequestPath requestPath)
        {
            var scope = requestPath.GetScopePath();
            if (!scope.IsParameterizedScope())
                return null;

            //if (Configuration.MgmtConfiguration.RequestPathToScopeResourceTypes.TryGetValue(requestPath, out var resourceTypes))
            //    return resourceTypes.Select(v => BuildResourceType(v)).ToArray();

            //if (Configuration.MgmtConfiguration.ParameterizedScopes.Contains(scope))
            //{
            //    // if this configuration has this scope configured
            //    // here we use this static method instead of scope.GetResourceType() to skip another check of IsParameterizedScope
            //    var resourceType = ResourceTypeSegment.ParseRequestPath(scope);
            //    return new[] { resourceType };
            //}

            // otherwise we just assume this is scope and this scope could be anything
            return new[] { ResourceTypeSegment.Subscription, ResourceTypeSegment.ResourceGroup, ResourceTypeSegment.ManagementGroup, ResourceTypeSegment.Tenant, ResourceTypeSegment.Any };
        }
    }
}
