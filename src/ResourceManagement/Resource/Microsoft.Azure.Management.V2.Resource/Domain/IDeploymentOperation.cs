/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource
{

    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using System;
    using Microsoft.Azure.Management.V2.Resource.Core;

    /// <summary>
    /// An immutable client-side representation of a deployment operation.
    /// </summary>
    public interface IDeploymentOperation  :
        IIndexable,
        IRefreshable<IDeploymentOperation>,
        IWrapper<DeploymentOperationInner>
    {
        /// <returns>the deployment operation id</returns>
        string OperationId { get; }

        /// <returns>the state of the provisioning resource being deployed</returns>
        string ProvisioningState { get; }

        /// <returns>the date and time of the operation</returns>
        DateTime? Timestamp { get; }

        /// <returns>the operation status code.=</returns>
        string StatusCode { get; }

        /// <returns>the operation status message</returns>
        object StatusMessage { get; }

        /// <returns>the target resource</returns>
        TargetResource TargetResource { get; }

    }
}