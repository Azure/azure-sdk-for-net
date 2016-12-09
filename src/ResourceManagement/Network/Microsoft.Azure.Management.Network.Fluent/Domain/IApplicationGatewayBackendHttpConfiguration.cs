// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an application gateway's backend HTTP configuration.
    /// </summary>
    public interface IApplicationGatewayBackendHttpConfiguration  :
        IWrapper<Models.ApplicationGatewayBackendHttpSettingsInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IHasProtocol<Models.ApplicationGatewayProtocol>,
        IHasPort
    {
        bool CookieBasedAffinity { get; }

        int RequestTimeout { get; }
    }
}