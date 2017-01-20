// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    /// <summary>
    /// Instantiate itself from a resource id, and give easy access to resource information like subscription, resourceGroup,
    /// resource name.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlc291cmNlcy5mbHVlbnRjb3JlLmFybS5SZXNvdXJjZUlk
    public sealed partial class ResourceId
    {
        private string subscriptionId = null;
        private string resourceGroupName = null;
        private string name = null;
        private string providerNamespace = null;
        private string resourceType = null;
        private string id = null;
        private string parentId = null;

        ///GENMHASH:B70D6F6BA20797441C0D5C0B0242CAD5:AC79278EB6C329B8058928B3B6E10DDE
        private static string badIdErrorText(string id)
        {
            return string.Format("The specified ID {0} is not a valid Azure resource ID.", id);
        }

        ///GENMHASH:B3F84178E98FD024C51BD0808983A7FD:292C69501E9130E0BF7366C3B6D23CFE
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
        ///GENMHASH:9716C5DFA259044737E756C8AC3056E1:344B4D5F59338530C5B0E76F0C6A5F45
        public static ResourceId FromString(string id)
        {
            return new ResourceId(id);
        }

        /// <return>Subscription id of the resource.</return>
        ///GENMHASH:561EEE43F415BCC5A5C6A30A1481AA8F:A3EF4727161FD92A5C3223C68024FB22
        public string SubscriptionId
        {
            get
            {
                return subscriptionId;
            }
        }

        /// <return>Resource group name of the resource.</return>
        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:72046A7721B0FDB28FEFB6DE190C3DA2
        public string ResourceGroupName
        {
            get
            {
                return resourceGroupName;
            }
        }

        /// <return>Name of the resource.</return>
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:9DFC3C722BEBD17B99B0AB691D43FC18
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <return>Parent resource id of the resource if any, otherwise null.</return>
        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:B5C3D5D089935CE04104F835B60237C6
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
        ///GENMHASH:D9D849D8C16B3DA934C69A95A1DDDB51:423582EDA5B1F4E232FE4036B6D476AA
        public string ProviderNamespace
        {
            get
            {
                return providerNamespace;
            }
        }

        /// <return>Type of the resource.</return>
        ///GENMHASH:EC2A5EE0E9C0A186CA88677B91632991:EC34A1788A024AA626A6DA489C78DC7D
        public string ResourceType
        {
            get
            {
                return resourceType;
            }
        }

        /// <return>Full type of the resource.</return>
        ///GENMHASH:59B5C5F8B8F571E387358FC7DB0134FF:7D81E6B7DE551A7F8C0A7A24B55F4E2F
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
        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:B865F40D3CB1A8C2252FEDBC45724D15
        public string Id
        {
            get
            {
                return id;
            }
        }
    }
}
 
