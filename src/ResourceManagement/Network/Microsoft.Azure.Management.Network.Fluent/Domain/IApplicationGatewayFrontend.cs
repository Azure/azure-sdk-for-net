// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an application gateway frontend.
    /// </summary>
    public interface IApplicationGatewayFrontend  :
        IWrapper<Models.ApplicationGatewayFrontendIPConfigurationInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IHasPrivateIpAddress,
        IHasSubnet,
        IHasPublicIpAddress
    {
        Microsoft.Azure.Management.Network.Fluent.ISubnet GetSubnet();

        bool IsPublic { get; }

        bool IsPrivate { get; }
    }
}