// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Models;
using System.Collections.Concurrent;

namespace Azure.Generator.Utilities
{
    internal static class ResourceTypeBuilder
    {
        private static ConcurrentDictionary<RequestPath, ResourceTypeSegment> _requestPathToResourceTypeCache = new ConcurrentDictionary<RequestPath, ResourceTypeSegment>();

        public static ResourceTypeSegment GetResourceType(this RequestPath requestPath)
        {
            if (_requestPathToResourceTypeCache.TryGetValue(requestPath, out var resourceType))
                return resourceType;

            resourceType = CalculateResourceType(requestPath);
            _requestPathToResourceTypeCache.TryAdd(requestPath, resourceType);
            return resourceType;
        }

        private static ResourceTypeSegment CalculateResourceType(RequestPath requestPath)
        {
            //if (Configuration.MgmtConfiguration.RequestPathToResourceType.TryGetValue(requestPath.SerializedPath, out var resourceType))
            //    return new ResourceTypeSegment(resourceType);

            // we cannot directly return the new ResourceType here, the requestPath here can be a parameterized scope, which does not have a resource type
            // even if we have the configuration to assign explicit types to a parameterized scope, we do not have enough information to get which request path the current scope variable belongs
            // therefore we can only return a place holder here to let the caller decide the actual resource type
            if (requestPath.IsParameterizedScope())
                return ResourceTypeSegment.Scope;
            return ResourceTypeSegment.ParseRequestPath(requestPath);
        }
    }
}
