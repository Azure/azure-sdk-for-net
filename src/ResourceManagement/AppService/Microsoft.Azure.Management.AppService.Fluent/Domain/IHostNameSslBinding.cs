// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// A Host name - SSL certificate binding definition.
    /// </summary>
    public interface IHostNameSslBinding  :
        IWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.HostNameSslState>,
        IChildResource<Microsoft.Azure.Management.AppService.Fluent.IWebAppBase<object>>
    {
        string Thumbprint { get; }

        string VirtualIP { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.SslState SslState { get; }
    }
}