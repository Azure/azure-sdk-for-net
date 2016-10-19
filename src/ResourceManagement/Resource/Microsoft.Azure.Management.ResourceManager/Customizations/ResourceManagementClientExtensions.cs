// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Rest.Azure
{
    public static class ResourceManagementClientExtensions
    {
        /// <summary>
        /// Get theResourceManagement client for the given context.  This client provides operations that manage 
        /// resources, resource groups, resource providers, and resource deployments.
        /// </summary>
        /// <param name="context">The context for the client to target.</param>
        /// <returns>The resource management client for the given context.</returns>
        private static IResourceManagementClient GetResourceManagementClient(this IAzureContext context)
        {
           return ResourceManagementClient.CreateClient(context);
        }

        /// <summary>
        /// Get operations for managing resource groups in the given context.
        /// </summary>
        /// <param name="context">The context for operations.</param>
        /// <returns>The operations for manageing resource groups in the given context.</returns>
        public static IResourceGroupsOperations GetResourceGroupOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().ResourceGroups;
        }

        /// <summary>
        /// Get operations for managing resources in the given context.
        /// </summary>
        /// <param name="context">The context for operations.</param>
        /// <returns>The operations for managing resources in the given context.</returns>
        public static IResourcesOperations GetResourceOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().Resources;
        }

        /// <summary>
        /// Get operations for discovering, registering, and unregistering resource providers in the given context.
        /// </summary>
        /// <param name="context">The context for operations.</param>
        /// <returns>The operations for managing resource providers in the given context.</returns>
        public static IProvidersOperations GetProviderOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().Providers;
        }

        /// <summary>
        /// Get operations for managing resource tags in the given context.
        /// </summary>
        /// <param name="context">The context for operations.</param>
        /// <returns>The operations for managing resource tags in the given context.</returns>
        public static ITagsOperations GetTagOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().Tags;
        }

        /// <summary>
        /// Get operations for managing resource template deployments in the given context.
        /// </summary>
        /// <param name="context">The context for operations.</param>
        /// <returns>The operations for managing resource template deployments in the given context.</returns>
        public static IDeploymentsOperations GetDeploymentOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().Deployments;
        }

        /// <summary>
        /// Get operations for managing resource template deployment operations in the given context.
        /// </summary>
        /// <param name="context">The context for operations.</param>
        /// <returns>The operations for manageing resource template deployment operations in the given context.</returns>
        public static IDeploymentOperationsOperations GetDeploymentOperationOperations(this IAzureContext context)
        {
            return context.GetResourceManagementClient().DeploymentOperations;
        }
    }
}
