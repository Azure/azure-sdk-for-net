// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The base network interface shared across regular and virtual machine scale set network interface.
    /// </summary>
    public interface INetworkInterfaceBaseBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets true if accelerated networkin is enabled for this network interface.
        /// </summary>
        bool IsAcceleratedNetworkingEnabled { get; }
    }
}