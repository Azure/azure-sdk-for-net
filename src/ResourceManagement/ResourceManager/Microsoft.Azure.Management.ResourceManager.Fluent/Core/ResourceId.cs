// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    /// <summary>
    /// Instantiate itself from a resource id, and give easy access to resource information like subscription, resourceGroup,
    /// resource name.
    /// </summary>
    public sealed partial class ResourceId
    {
        private string subscriptionId = null;
        private string resourceGroupName = null;
        private string name = null;
        private string providerNamespace = null;
        private string resourceType = null;
        private string id = null;
        private string parentId = null;

        private static string badIdErrorText(string id)
        {
            return string.Format("The specified ID {0} is not a valid Azure resource ID.", id);
        }

        private ResourceId(string id)
        {
            if (id == null)
            {
                // Protect against NPEs from null IDs, preserving legacy behavior for null IDs
                return;
            }
            else
            {
                // Skip the first '/' if any, and then split using '/'
                string[] splits = (id.StartsWith("/")) ? id.Substring(1).Split('/') : id.Split('/');
                if (splits.Length % 2 == 1)
                {
                    throw new ArgumentException(badIdErrorText(id));
                }

                // Save the ID itself
                this.id = id;

                // Format of id:
                // /subscriptions/<subscriptionId>/resourceGroups/<resourceGroupName>/providers/<providerNamespace>(/<parentResourceType>/<parentName>)*/<resourceType>/<name>
                //  0             1                2              3                   4         5                                                        N-2            N-1

                // Extract resource type and name
                if (splits.Length < 2)
                {
                    throw new ArgumentException(badIdErrorText(id));
                }
                else
                {
                    name = splits[splits.Length - 1];
                    resourceType = splits[splits.Length - 2];
                }

                // Extract parent ID
                if (splits.Length < 10)
                {
                    parentId = null;
                }
                else
                {
                    string[] parentSplits = new string[splits.Length - 2];
                    Array.Copy(splits, parentSplits, splits.Length - 2);
                    parentId = "/" + string.Join("/", parentSplits);
                }

                for (int i = 0; i < splits.Length && i < 6; i++)
                {
                    switch (i)
                    {
                        case 0:
                            // Ensure "subscriptions"
                            if (string.Compare(splits[i], "subscriptions", StringComparison.OrdinalIgnoreCase) != 0)
                            {
                                throw new ArgumentException(badIdErrorText(id));
                            }
                            break;
                        case 1:
                            // Extract subscription ID
                            subscriptionId = splits[i];
                            break;
                        case 2:
                            // Ensure "resourceGroups"
                            if (string.Compare(splits[i], "resourceGroups", StringComparison.OrdinalIgnoreCase) != 0)
                            {
                                throw new ArgumentException(badIdErrorText(id));
                            }
                            break;
                        case 3:
                            // Extract resource group name
                            resourceGroupName = splits[i];
                            break;
                        case 4:
                            // Ensure "providers"
                            if (string.Compare(splits[i], "providers", StringComparison.OrdinalIgnoreCase) != 0)
                            {
                                throw new ArgumentException(badIdErrorText(id));
                            }
                            break;
                        case 5:
                            // Extract provider namespace
                            providerNamespace = splits[i];
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Returns parsed ResourceId object for a given resource id.
        /// </summary>
        /// <param name="id">of the resource.</param>
        /// <return>ResourceId object</return>
        public static ResourceId FromString(string id)
        {
            return new ResourceId(id);
        }

        /// <return>Subscription id of the resource.</return>
        public string SubscriptionId
        {
            get
            {
                return subscriptionId;
            }
        }

        /// <return>Resource group name of the resource.</return>
        public string ResourceGroupName
        {
            get
            {
                return resourceGroupName;
            }
        }

        /// <return>Name of the resource.</return>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <return>Parent resource id of the resource if any, otherwise null.</return>
        public ResourceId Parent
        {
            get
            {
                if (id == null || parentId == null)
                {
                    return null;
                }
                else
                {
                    return FromString(parentId);
                }
            }
        }

        /// <return>Name of the provider.</return>
        public string ProviderNamespace
        {
            get
            {
                return providerNamespace;
            }
        }

        /// <return>Type of the resource.</return>
        public string ResourceType
        {
            get
            {
                return resourceType;
            }
        }

        /// <return>Full type of the resource.</return>
        public string FullResourceType
        {
            get
            {
                if (parentId == null)
                {
                    return providerNamespace + "/" + resourceType;
                }
                else
                {
                    return this.Parent.FullResourceType + "/" + resourceType;
                }
            }
        }

        /// <return>The id of the resource.</return>
        public string Id
        {
            get
            {
                return id;
            }
        }
    }
}
 