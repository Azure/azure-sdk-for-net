// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Update
{
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of an application gateway frontend definition allowing to specify an existing public IP address to make
    /// the application gateway available at as Internet-facing.
    /// </summary>
    public interface IWithPublicIPAddress  :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Update.IWithExistingPublicIPAddress<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Update.IUpdate>
    {
    }

    /// <summary>
    /// The entirety of an application gateway frontend update as part of an application gateway update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Update.IWithPublicIPAddress
    {
    }
}