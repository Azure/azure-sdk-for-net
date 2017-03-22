// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The entirety of a load balancer backend update as part of a load balancer update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>
    {
    }
}