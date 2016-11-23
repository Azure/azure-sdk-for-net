// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    public static class ResourceUtils
    {
        public static string GroupFromResourceId(string id)
        {
            return ResourceId.ParseResourceId(id).ResourceGroupName;
        }

        public static string ResourceProviderFromResourceId(string id)
        {
            return ResourceId.ParseResourceId(id).ProviderNamespace;
        }

        public static string NameFromResourceId(string id)
        {
            return ResourceId.ParseResourceId(id).Name;
        }

        public static string ResourceTypeFromResourceId(string id)
        {
            return ResourceId.ParseResourceId(id).ResourceType;
        }

        public static string ParentResourcePathFromResourceId(string id)
        {
            return ResourceId.ParseResourceId(id).Parent.Id;
        }
    }
}
