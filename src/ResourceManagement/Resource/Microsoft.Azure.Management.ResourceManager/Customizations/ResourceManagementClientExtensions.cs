// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Rest.Azure
{
    public static class ResourceManagementClientExtensions
    {
        public static IResourceManagementClient GetResourceManagementClient(this IAzureContext context)
        {
           return ResourceManagementClient.CreateClient(context);
        }

        public static IResourceGroupsOperations GetResourceGroupOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().ResourceGroups;
        }

        public static IResourcesOperations GetResourceOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().Resources;
        }

        public static IProvidersOperations GetProviderOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().Providers;
        }

        public static ITagsOperations GetTagOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().Tags;
        }

        public static IDeploymentsOperations GetDeploymentOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().Deployments;
        }

        public static IDeploymentOperationsOperations GetDeploymentOperationOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().DeploymentOperations;
        }
    }
}
