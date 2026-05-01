// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

// NOTE: All the GetArmDeployments and GetArmDeployment operations are existed in the library before, but now can't be generated from TypeSpec because of the scope implementation change.
// To avoid breaking customers who are using these operations, we use customization code to keep them, would like to be removed in the future when MPG can provide some better way to handle this kind of scenario.
namespace Azure.ResourceManager.Resources.Mocking
{
    public partial class MockableResourcesTenantResource : ArmResource
    {
        /// <summary> Gets a collection of ArmDeploymentResources in the TenantResource. </summary>
        /// <returns> An object representing collection of ArmDeploymentResources and their operations over a ArmDeploymentResource. </returns>
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
        public virtual Response<ArmDeploymentResource> GetArmDeployment(string deploymentName, CancellationToken cancellationToken = default)
        {
            return GetArmDeployments().Get(deploymentName, cancellationToken);
        }
    }
}
