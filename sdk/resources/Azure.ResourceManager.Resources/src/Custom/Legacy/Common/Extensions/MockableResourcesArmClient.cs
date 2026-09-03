// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableResourcesArmClient : ArmResource
    {
        /// <summary>
        /// Gets an object representing an <see cref="ArmDeploymentResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ArmDeploymentResource.CreateResourceIdentifier" /> to create an <see cref="ArmDeploymentResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ArmDeploymentResource"/> object. </returns>
        [Obsolete("Use MockableResourcesDeploymentsArmClient.GetArmDeploymentResource instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmDeploymentResource GetArmDeploymentResource(ResourceIdentifier id)
        {
            ArmDeploymentResource.ValidateResourceId(id);
            return new ArmDeploymentResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="DeploymentStackResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DeploymentStackResource.CreateResourceIdentifier" /> to create a <see cref="DeploymentStackResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DeploymentStackResource"/> object. </returns>
        [Obsolete("Use Azure.ResourceManager.Resources.DeploymentStacks.Mocking.MockableResourcesDeploymentStacksArmClient instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DeploymentStackResource GetDeploymentStackResource(ResourceIdentifier id)
        {
            DeploymentStackResource.ValidateResourceId(id);
            return new DeploymentStackResource(Client, id);
        }
    }
}
