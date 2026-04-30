// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Mocking;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: All the GetArmDeployments and GetArmDeployment operations are existed in the library before, but now can't be generated from TypeSpec because of the scope implementation change.
// To avoid breaking customers who are using these operations, we use customization code to keep them, would like to be removed in the future when MPG can provide some better way to handle this kind of scenario.
namespace Azure.ResourceManager.Resources
{
    [CodeGenSuppress("WhatIfAtSubscriptionScopeAsync", typeof(WaitUntil), typeof(string), typeof(ArmDeploymentWhatIfContent), typeof(CancellationToken))]   // The WhatIf operations are all moved to ArmDeploymentResource. Not scope out this operation from the client.tsp is intentional for genrating other related classes for the customized WhatIf operations.
    [CodeGenSuppress("WhatIfAtSubscriptionScope", typeof(WaitUntil), typeof(string), typeof(ArmDeploymentWhatIfContent), typeof(CancellationToken))]        // The WhatIf operations are all moved to ArmDeploymentResource. Not scope out this operation from the client.tsp is intentional for genrating other related classes for the customized WhatIf operations.
    public static partial class ResourcesExtensions
    {
        private static MockableResourcesManagementGroupResource GetMockableResourcesManagementGroupResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableResourcesManagementGroupResource(client, resource.Id));
        }

        private static MockableResourcesResourceGroupResource GetMockableResourcesResourceGroupResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableResourcesResourceGroupResource(client, resource.Id));
        }

        /// <summary>
        /// Gets a collection of ArmDeploymentResources in the ManagementGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesManagementGroupResource.GetArmDeployments()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managementGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of ArmDeploymentResources and their operations over a ArmDeploymentResource. </returns>
        public static ArmDeploymentCollection GetArmDeployments(this ManagementGroupResource managementGroupResource)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));

            return GetMockableResourcesManagementGroupResource(managementGroupResource).GetArmDeployments();
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesManagementGroupResource.GetArmDeploymentAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managementGroupResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [Azure.Core.ForwardsClientCalls]
        public static async Task<Response<ArmDeploymentResource>> GetArmDeploymentAsync(this ManagementGroupResource managementGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));

            return await GetMockableResourcesManagementGroupResource(managementGroupResource).GetArmDeploymentAsync(deploymentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesManagementGroupResource.GetArmDeployment(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managementGroupResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [Azure.Core.ForwardsClientCalls]
        public static Response<ArmDeploymentResource> GetArmDeployment(this ManagementGroupResource managementGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));

            return GetMockableResourcesManagementGroupResource(managementGroupResource).GetArmDeployment(deploymentName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of ArmDeploymentResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesResourceGroupResource.GetArmDeployments()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of ArmDeploymentResources and their operations over a ArmDeploymentResource. </returns>
        public static ArmDeploymentCollection GetArmDeployments(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableResourcesResourceGroupResource(resourceGroupResource).GetArmDeployments();
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesResourceGroupResource.GetArmDeploymentAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [Azure.Core.ForwardsClientCalls]
        public static async Task<Response<ArmDeploymentResource>> GetArmDeploymentAsync(this ResourceGroupResource resourceGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableResourcesResourceGroupResource(resourceGroupResource).GetArmDeploymentAsync(deploymentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesResourceGroupResource.GetArmDeployment(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [Azure.Core.ForwardsClientCalls]
        public static Response<ArmDeploymentResource> GetArmDeployment(this ResourceGroupResource resourceGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableResourcesResourceGroupResource(resourceGroupResource).GetArmDeployment(deploymentName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of ArmDeploymentResources in the SubscriptionResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesSubscriptionResource.GetArmDeployments()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An object representing collection of ArmDeploymentResources and their operations over a ArmDeploymentResource. </returns>
        public static ArmDeploymentCollection GetArmDeployments(this SubscriptionResource subscriptionResource)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableResourcesSubscriptionResource(subscriptionResource).GetArmDeployments();
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesSubscriptionResource.GetArmDeploymentAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [Azure.Core.ForwardsClientCalls]
        public static async Task<Response<ArmDeploymentResource>> GetArmDeploymentAsync(this SubscriptionResource subscriptionResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableResourcesSubscriptionResource(subscriptionResource).GetArmDeploymentAsync(deploymentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesSubscriptionResource.GetArmDeployment(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [Azure.Core.ForwardsClientCalls]
        public static Response<ArmDeploymentResource> GetArmDeployment(this SubscriptionResource subscriptionResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableResourcesSubscriptionResource(subscriptionResource).GetArmDeployment(deploymentName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of ArmDeploymentResources in the TenantResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesTenantResource.GetArmDeployments()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> is null. </exception>
        /// <returns> An object representing collection of ArmDeploymentResources and their operations over a ArmDeploymentResource. </returns>
        public static ArmDeploymentCollection GetArmDeployments(this TenantResource tenantResource)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableResourcesTenantResource(tenantResource).GetArmDeployments();
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesTenantResource.GetArmDeploymentAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [Azure.Core.ForwardsClientCalls]
        public static async Task<Response<ArmDeploymentResource>> GetArmDeploymentAsync(this TenantResource tenantResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return await GetMockableResourcesTenantResource(tenantResource).GetArmDeploymentAsync(deploymentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesTenantResource.GetArmDeployment(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [Azure.Core.ForwardsClientCalls]
        public static Response<ArmDeploymentResource> GetArmDeployment(this TenantResource tenantResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableResourcesTenantResource(tenantResource).GetArmDeployment(deploymentName, cancellationToken);
        }
    }
}
