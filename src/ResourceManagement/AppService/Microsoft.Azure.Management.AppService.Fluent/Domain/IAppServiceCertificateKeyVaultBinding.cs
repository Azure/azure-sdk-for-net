// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure App Service Certificate.
    /// </summary>
    public interface IAppServiceCertificateKeyVaultBinding  :
        IIndependentChildResource,
        IWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.AppServiceCertificateInner>
    {
        Microsoft.Azure.Management.AppService.Fluent.Models.KeyVaultSecretStatus ProvisioningState { get; }

        string KeyVaultId { get; }

        string KeyVaultSecretName { get; }
    }
}