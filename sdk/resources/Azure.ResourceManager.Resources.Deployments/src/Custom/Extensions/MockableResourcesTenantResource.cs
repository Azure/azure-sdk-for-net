// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources.Mocking
{
    // Suppress all these extension methods to avoid conflicts with the original Azure.ResourceMananger.Resources package.
    // These extension methods holder will still be available in the original Azure.ResourceMananger.Resources package which
    // and will delegate to the implementations in this separated package.
    [CodeGenSuppress("GetArmDeployments", typeof(TenantResource))]
    [CodeGenSuppress("GetArmDeploymentAsync", typeof(TenantResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetArmDeployment", typeof(TenantResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CalculateDeploymentTemplateHashAsync", typeof(TenantResource), typeof(BinaryData), typeof(CancellationToken))]
    [CodeGenSuppress("CalculateDeploymentTemplateHash", typeof(TenantResource), typeof(BinaryData), typeof(CancellationToken))]
    public partial class MockableResourcesTenantResource : ArmResource
    {
        /// <summary> Gets a collection of ArmDeploymentResources in the TenantResource. </summary>
        /// <returns> An object representing collection of ArmDeploymentResources and their operations over a ArmDeploymentResource. </returns>
        public virtual ArmDeploymentCollection GetDeployments()
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
        public virtual async Task<Response<ArmDeploymentResource>> GetDeploymentAsync(string deploymentName, CancellationToken cancellationToken = default)
        {
            return await GetDeployments().GetAsync(deploymentName, cancellationToken).ConfigureAwait(false);
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
        /// </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<ArmDeploymentResource> GetDeployment(string deploymentName, CancellationToken cancellationToken = default)
        {
            return GetDeployments().Get(deploymentName, cancellationToken);
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
        /// </summary>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> is null. </exception>
        public virtual async Task<Response<TemplateHashResult>> CalculateTemplateHashAsync(BinaryData template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(template, nameof(template));

            using var scope = ArmDeploymentDeploymentsClientDiagnostics.CreateScope("MockableResourcesTenantResource.CalculateTemplateHash");
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
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> is null. </exception>
        public virtual Response<TemplateHashResult> CalculateTemplateHash(BinaryData template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(template, nameof(template));

            using var scope = ArmDeploymentDeploymentsClientDiagnostics.CreateScope("MockableResourcesTenantResource.CalculateTemplateHash");
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
