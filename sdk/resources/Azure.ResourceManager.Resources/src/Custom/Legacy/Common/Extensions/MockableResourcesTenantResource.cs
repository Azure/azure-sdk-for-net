// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources.Mocking
{
    /// <summary> A class to add extension methods to TenantResource. </summary>
    public partial class MockableResourcesTenantResource : ArmResource
    {
        [Obsolete("Use Azure.ResourceManager.Resources.Deployments instead.", false)]
        private ClientDiagnostics _armDeploymentDeploymentsClientDiagnostics;
        [Obsolete("Use Azure.ResourceManager.Resources.Deployments instead.", false)]
        private DeploymentsRestOperations _armDeploymentDeploymentsRestClient;

        [Obsolete("Use Azure.ResourceManager.Resources.Deployments instead.", false)]
        private ClientDiagnostics ArmDeploymentDeploymentsClientDiagnostics => _armDeploymentDeploymentsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Resources", ArmDeploymentResource.ResourceType.Namespace, Diagnostics);
        [Obsolete("Use Azure.ResourceManager.Resources.Deployments instead.", false)]
        private DeploymentsRestOperations ArmDeploymentDeploymentsRestClient => _armDeploymentDeploymentsRestClient ??= new DeploymentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ArmDeploymentResource.ResourceType));

        /// <summary> Gets a collection of ArmDeploymentResources in the TenantResource. </summary>
        /// <returns> An object representing collection of ArmDeploymentResources and their operations over a ArmDeploymentResource. </returns>
        [Obsolete("Use MockableResourcesDeploymentsTenantResource.GetArmDeployments instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmDeploymentCollection GetArmDeployments()
        {
            return GetCachedClient(client => new ArmDeploymentCollection(client, Id));
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
        /// <term>Default Api Version</term>
        /// <description>2025-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("Use MockableResourcesDeploymentsTenantResource.GetArmDeploymentAsync instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, CancellationToken cancellationToken = default)
        {
            return await GetArmDeployments().GetAsync(deploymentName, cancellationToken).ConfigureAwait(false);
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
        /// <term>Default Api Version</term>
        /// <description>2025-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("Use MockableResourcesDeploymentsTenantResource.GetArmDeployment instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ArmDeploymentResource> GetArmDeployment(string deploymentName, CancellationToken cancellationToken = default)
        {
            return GetArmDeployments().Get(deploymentName, cancellationToken);
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
        /// <term>Default Api Version</term>
        /// <description>2025-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> is null. </exception>
        [Obsolete("Use MockableResourcesDeploymentsTenantResource.CalculateDeploymentTemplateHashAsync instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<TemplateHashResult>> CalculateDeploymentTemplateHashAsync(BinaryData template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(template, nameof(template));

            using var scope = ArmDeploymentDeploymentsClientDiagnostics.CreateScope("MockableResourcesTenantResource.CalculateDeploymentTemplateHash");
            scope.Start();
            try
            {
                var response = await ArmDeploymentDeploymentsRestClient.CalculateTemplateHashAsync(template, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <term>Default Api Version</term>
        /// <description>2025-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> is null. </exception>
        [Obsolete("Use MockableResourcesDeploymentsTenantResource.CalculateDeploymentTemplateHash instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<TemplateHashResult> CalculateDeploymentTemplateHash(BinaryData template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(template, nameof(template));

            using var scope = ArmDeploymentDeploymentsClientDiagnostics.CreateScope("MockableResourcesTenantResource.CalculateDeploymentTemplateHash");
            scope.Start();
            try
            {
                var response = ArmDeploymentDeploymentsRestClient.CalculateTemplateHash(template, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
