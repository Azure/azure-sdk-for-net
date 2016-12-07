// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    /// <summary>
    /// Instantiate itself from a resource id, and give easy access to resource information like subscription, resourceGroup,
    /// resource name.
    /// </summary>
    public sealed partial class ResourceId
    {
        private string subscriptionId;
        private string resourceGroupName;
        private string name;
        private ResourceId parent;
        private string providerNamespace;
        private string resourceType;
        private string id;

        /// <return>Name of the provider.</return>
        public string ProviderNamespace
        {
            get
            {
                return this.providerNamespace;
            }
        }

        /// <return>Parent resource id of the resource if any, otherwise null.</return>
        public ResourceId Parent
        {
            get
            {
                return parent;
            }
        }

        /// <return>ResourceGroupName of the resource.</return>
        public string ResourceGroupName
        {
            get
            {
                return resourceGroupName;
            }
        }

        /// <return>Full type of the resource.</return>
        public string FullResourceType
        {
            get
            {
                if (parent == null)
                {
                    return providerNamespace + "/" + resourceType;
                }
                return parent.FullResourceType + "/" + resourceType;
            }
        }

        /// <return>Name of the resource.</return>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Returns parsed ResourceId object for a given resource id.
        /// </summary>
        /// <param name="id">Of the resource.</param>
        /// <return>ResourceId object.</return>
        public static ResourceId ParseResourceId(string id)
        {
            // Example of id is id=/subscriptions/9657ab5d-4a4a-4fd2-ae7a-4cd9fbd030ef/resourceGroups/ans/providers/Microsoft.Network/applicationGateways/something
            // Remove the first '/' and then split using '/'
            string[] splits = id.Substring(1).Split('/');

            if (splits.Length % 2 == 1)
            {
                throw new System.ArgumentException();
            }
            ResourceId resourceId = new ResourceId();

            resourceId.id = id;
            resourceId.subscriptionId = splits[1];
            resourceId.resourceGroupName = splits[3];

            // In case of a resource group Id is passed, then name is resource group name.
            if (splits.Length == 4)
            {
                resourceId.name = resourceId.resourceGroupName;
                return resourceId;
            }

            resourceId.providerNamespace = splits[5];
            resourceId.name = splits[splits.Length - 1];
            resourceId.resourceType = splits[splits.Length - 2];

            int numberOfParents = splits.Length / 2 - 4;
            if (numberOfParents == 0)
            {
                return resourceId;
            }
            string resourceType = splits[splits.Length - 2];

            resourceId.parent = ResourceId.ParseResourceId(id.Substring(0, id.Length - ("/" + resourceType + "/" + resourceId.Name).Length));

            return resourceId;
        }

        /// <return>The id of the resource.</return>
        public string Id
        {
            get
            {
                return id;
            }
        }

        /// <return>SubscriptionId of the resource.</return>
        public string SubscriptionId
        {
            get
            {
                return this.subscriptionId;
            }
        }

        /// <return>Type of the resource.</return>
        public string ResourceType
        {
            get
            {
                return this.resourceType;
            }
        }
    }
}