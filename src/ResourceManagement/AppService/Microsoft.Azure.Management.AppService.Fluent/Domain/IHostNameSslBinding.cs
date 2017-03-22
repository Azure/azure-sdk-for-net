// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A Host name - SSL certificate binding definition.
    /// </summary>
    public interface IHostNameSslBinding  :
        IHasInner<Models.HostNameSslState>,
        IChildResource<Microsoft.Azure.Management.AppService.Fluent.IWebAppBase>
    {
        /// <summary>
        /// Gets the SSL cert thumbprint.
        /// </summary>
        string Thumbprint { get; }

        /// <summary>
        /// Gets the virtual IP address assigned to the host name if IP based SSL is enabled.
        /// </summary>
        string VirtualIP { get; }

        /// <summary>
        /// Gets the SSL type.
        /// </summary>
        Models.SslState SslState { get; }
    }
}