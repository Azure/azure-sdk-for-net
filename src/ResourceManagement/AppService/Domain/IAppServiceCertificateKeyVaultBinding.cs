// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure App Service Key Vault binding.
    /// </summary>
    public interface IAppServiceCertificateKeyVaultBinding  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IIndependentChildResource<Microsoft.Azure.Management.AppService.Fluent.IAppServiceManager,Models.AppServiceCertificateResourceInner>
    {
        /// <summary>
        /// Gets the status of the Key Vault secret.
        /// </summary>
        Models.KeyVaultSecretStatus ProvisioningState { get; }

        /// <summary>
        /// Gets the key vault resource Id.
        /// </summary>
        string KeyVaultId { get; }

        /// <summary>
        /// Gets the key vault secret name.
        /// </summary>
        string KeyVaultSecretName { get; }
    }
}