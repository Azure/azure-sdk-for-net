// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources.Mocking;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    // Suppress all these extension methods to avoid conflicts with the original Azure.ResourceMananger.Resources package.
    // These extension methods holder will still be available in the original Azure.ResourceMananger.Resources package which
    // and will delegate to the implementations in this separated package.
    [CodeGenSuppress("GetArmDeploymentResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetArmDeployments", typeof(ManagementGroupResource))]
    [CodeGenSuppress("GetArmDeploymentAsync", typeof(ManagementGroupResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetArmDeployment", typeof(ManagementGroupResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetArmDeployments", typeof(ResourceGroupResource))]
    [CodeGenSuppress("GetArmDeploymentAsync", typeof(ResourceGroupResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetArmDeployment", typeof(ResourceGroupResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetArmDeployments", typeof(SubscriptionResource))]
    [CodeGenSuppress("GetArmDeploymentAsync", typeof(SubscriptionResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetArmDeployment", typeof(SubscriptionResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetArmDeployments", typeof(TenantResource))]
    [CodeGenSuppress("GetArmDeploymentAsync", typeof(TenantResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetArmDeployment", typeof(TenantResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CalculateDeploymentTemplateHashAsync", typeof(TenantResource), typeof(BinaryData), typeof(CancellationToken))]
    [CodeGenSuppress("CalculateDeploymentTemplateHash", typeof(TenantResource), typeof(BinaryData), typeof(CancellationToken))]
    public static partial class ResourcesExtensions
    {
        /// <summary>
        /// Gets an object representing an <see cref="ArmDeploymentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ArmDeploymentResource.CreateResourceIdentifier" /> to create an <see cref="ArmDeploymentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesArmClient.GetDeploymentResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ArmDeploymentResource"/> object. </returns>
        public static ArmDeploymentResource GetDeploymentResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourcesArmClient(client).GetDeploymentResource(id);
        }

        /// <summary>
        /// Gets a collection of ArmDeploymentResources in the ManagementGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesManagementGroupResource.GetDeployments()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managementGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of ArmDeploymentResources and their operations over a ArmDeploymentResource. </returns>
        public static ArmDeploymentCollection GetDeployments(this ManagementGroupResource managementGroupResource)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));

            return GetMockableResourcesManagementGroupResource(managementGroupResource).GetDeployments();
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
        /// <description>To mock this method, please mock <see cref="MockableResourcesManagementGroupResource.GetDeploymentAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managementGroupResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ArmDeploymentResource>> GetDeploymentAsync(this ManagementGroupResource managementGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));

            return await GetMockableResourcesManagementGroupResource(managementGroupResource).GetDeploymentAsync(deploymentName, cancellationToken).ConfigureAwait(false);
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
        /// <description>To mock this method, please mock <see cref="MockableResourcesManagementGroupResource.GetDeployment(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managementGroupResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<ArmDeploymentResource> GetDeployment(this ManagementGroupResource managementGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));

            return GetMockableResourcesManagementGroupResource(managementGroupResource).GetDeployment(deploymentName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of ArmDeploymentResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesResourceGroupResource.GetDeployments()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of ArmDeploymentResources and their operations over a ArmDeploymentResource. </returns>
        public static ArmDeploymentCollection GetDeployments(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableResourcesResourceGroupResource(resourceGroupResource).GetDeployments();
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
        /// <description>To mock this method, please mock <see cref="MockableResourcesResourceGroupResource.GetDeploymentAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ArmDeploymentResource>> GetDeploymentAsync(this ResourceGroupResource resourceGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableResourcesResourceGroupResource(resourceGroupResource).GetDeploymentAsync(deploymentName, cancellationToken).ConfigureAwait(false);
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
        /// <description>To mock this method, please mock <see cref="MockableResourcesResourceGroupResource.GetDeployment(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<ArmDeploymentResource> GetDeployment(this ResourceGroupResource resourceGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableResourcesResourceGroupResource(resourceGroupResource).GetDeployment(deploymentName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of ArmDeploymentResources in the SubscriptionResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesSubscriptionResource.GetDeployments()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An object representing collection of ArmDeploymentResources and their operations over a ArmDeploymentResource. </returns>
        public static ArmDeploymentCollection GetDeployments(this SubscriptionResource subscriptionResource)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableResourcesSubscriptionResource(subscriptionResource).GetDeployments();
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
        /// <description>To mock this method, please mock <see cref="MockableResourcesSubscriptionResource.GetDeploymentAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ArmDeploymentResource>> GetDeploymentAsync(this SubscriptionResource subscriptionResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableResourcesSubscriptionResource(subscriptionResource).GetDeploymentAsync(deploymentName, cancellationToken).ConfigureAwait(false);
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
        /// <description>To mock this method, please mock <see cref="MockableResourcesSubscriptionResource.GetDeployment(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<ArmDeploymentResource> GetDeployment(this SubscriptionResource subscriptionResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableResourcesSubscriptionResource(subscriptionResource).GetDeployment(deploymentName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of ArmDeploymentResources in the TenantResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesTenantResource.GetDeployments()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> is null. </exception>
        /// <returns> An object representing collection of ArmDeploymentResources and their operations over a ArmDeploymentResource. </returns>
        public static ArmDeploymentCollection GetDeployments(this TenantResource tenantResource)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableResourcesTenantResource(tenantResource).GetDeployments();
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
        /// <description>To mock this method, please mock <see cref="MockableResourcesTenantResource.GetDeploymentAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ArmDeploymentResource>> GetDeploymentAsync(this TenantResource tenantResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return await GetMockableResourcesTenantResource(tenantResource).GetDeploymentAsync(deploymentName, cancellationToken).ConfigureAwait(false);
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
        /// <description>To mock this method, please mock <see cref="MockableResourcesTenantResource.GetDeployment(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<ArmDeploymentResource> GetDeployment(this TenantResource tenantResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableResourcesTenantResource(tenantResource).GetDeployment(deploymentName, cancellationToken);
        }

        /// <summary>
        /// Calculate the hash of the given template.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Resources/calculateTemplateHash</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CalculateTemplateHash</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesTenantResource.CalculateTemplateHash(BinaryData,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="template"/> is null. </exception>
        public static async Task<Response<TemplateHashResult>> CalculateTemplateHashAsync(this TenantResource tenantResource, BinaryData template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return await GetMockableResourcesTenantResource(tenantResource).CalculateTemplateHashAsync(template, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Calculate the hash of the given template.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Resources/calculateTemplateHash</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CalculateTemplateHash</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableResourcesTenantResource.CalculateTemplateHash(BinaryData,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="template"/> is null. </exception>
        public static Response<TemplateHashResult> CalculateTemplateHash(this TenantResource tenantResource, BinaryData template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableResourcesTenantResource(tenantResource).CalculateTemplateHash(template, cancellationToken);
        }
    }
}
