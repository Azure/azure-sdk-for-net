// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Azure.Generator.Utilities
{
    internal class ScopeDetection
    {
        //public const string Subscriptions = "subscriptions";
        //public const string ResourceGroups = "resourceGroups";
        //public const string Tenant = "tenant";
        //public const string ManagementGroups = "managementGroups";
        //public const string Any = "*";

        private ConcurrentDictionary<string, string> _scopePathMap;

        public ScopeDetection()
        {
            _scopePathMap = new();
        }

        public string GetScopePath(string requestPath)
        {
            if (_scopePathMap.TryGetValue(requestPath, out var scope))
            {
                return scope;
            }

            scope = CalculateScopePath(requestPath);
            _scopePathMap.TryAdd(requestPath, scope);
            return scope;
        }

        private static string CalculateScopePath(string requestPath)
        {
            var indexOfProvider = requestPath.IndexOf(RequestPathUtils.Providers);
            // if there is no providers segment, myself should be a scope request path. Just return myself
            if (indexOfProvider >= 0)
            {
                if (indexOfProvider == 0 && requestPath.StartsWith(RequestPathUtils.ManagementGroupScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                    return RequestPathUtils.ManagementGroup;
                return requestPath.Substring(0, indexOfProvider);
            }
            if (requestPath.StartsWith(RequestPathUtils.ResourceGroupScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                return RequestPathUtils.ResourceGroup;
            if (requestPath.StartsWith(RequestPathUtils.SubscriptionScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                return RequestPathUtils.Subscription;
            if (requestPath.Equals(RequestPathUtils.TenantScopePrefix))
                return RequestPathUtils.Tenant;
            return requestPath;
        }

        /// <summary>
        /// Returns true if this request path is a parameterized scope, like the "/{scope}" in "/{scope}/providers/M.C/virtualMachines/{vmName}"
        /// Also returns true when this scope is explicitly set as a parameterized scope in the configuration
        /// </summary>
        /// <param name="scopePath"></param>
        /// <returns></returns>
        public static bool IsParameterizedScope(string scopePath)
        {
            //// if this path could be found inside the configuration, we just return true for that.
            //if (Configuration.MgmtConfiguration.ParameterizedScopes.Contains(scopePath))
            //    return true;

            // if the path is not in the configuration, we go through the default logic to check if it is parameterized scope
            return IsRawParameterizedScope(scopePath);
        }

        public static bool IsRawParameterizedScope(string scopePath)
        {
            var segments = RequestPathUtils.GetPathSegments(scopePath);
            // if a request is an implicit scope, it must only have one segment
            if (segments.Length != 1)
                return false;

            // now the path only has one segment
            var first = segments.First();
            // then we need to ensure the corresponding parameter enables `x-ms-skip-url-encoding`
            if (RequestPathUtils.IsConstant(first))
                return false; // actually this cannot happen

            return true;

            //// now the first segment is a reference
            //// we ensure this parameter enables x - ms - skip - url - encoding, aka Escape is false
            //return first.SkipUrlEncoding;
        }
    }
}
