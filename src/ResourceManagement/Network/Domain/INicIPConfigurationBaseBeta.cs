// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The base IP configuration shared across IP configurations in regular and virtual machine scale set
    /// network interface.
    /// </summary>
    public interface INicIPConfigurationBaseBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <return>The application gateway backends associated with this network IP configuration.</return>
        System.Collections.Generic.IReadOnlyCollection<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend> ListAssociatedApplicationGatewayBackends();
    }
}