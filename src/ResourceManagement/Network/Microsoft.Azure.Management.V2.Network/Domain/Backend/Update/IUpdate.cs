// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.Backend.Update
{

    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResourceActions;
    /// <summary>
    /// The entirety of a backend update as part of a load balancer update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>
    {
    }
}