// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public static class ResourceUtils
    {
        public static string GroupFromResourceId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return ResourceId.FromString(id).ResourceGroupName;
        }

        public static string ResourceProviderFromResourceId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return ResourceId.FromString(id).ProviderNamespace;
        }

        public static string NameFromResourceId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return ResourceId.FromString(id).Name;
        }

        public static string ResourceTypeFromResourceId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return ResourceId.FromString(id).ResourceType;
        }

        public static string ParentResourcePathFromResourceId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return ResourceId.FromString(id)?.Parent?.Id;
        }

        public static string ConstructResourceId(
            string subscriptionId,
            string resourceGroupName,
            string resourceProviderNamespace,
            string resourceType,
            string resourceName,
            string parentResourcePath)
        {
            string prefixedParentPath = parentResourcePath;
            if (!string.IsNullOrEmpty(parentResourcePath))
            {
                prefixedParentPath = "/" + parentResourcePath;
            }
            return string.Format(
                    "/subscriptions/{0}/resourcegroups/{1}/providers/{2}{3}/{4}/{5}",
                    subscriptionId,
                    resourceGroupName,
                    resourceProviderNamespace,
                    prefixedParentPath,
                    resourceType,
                    resourceName);
        }

        public static string CreateODataFilterForTags(string tagName, string tagValue)
        {
            if (tagName == null)
            {
                return null;
            }
            else if (tagValue == null)
            {
                return $"tagname eq {tagName}";
            }
            else
            {
                return $"tagname eq {tagName} and tagvalue eq {tagValue}";
            }
        }
    }
}
