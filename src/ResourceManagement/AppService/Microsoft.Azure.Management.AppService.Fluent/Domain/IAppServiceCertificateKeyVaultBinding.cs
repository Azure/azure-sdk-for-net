// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure App Service Certificate.
    /// </summary>
    public interface IAppServiceCertificateKeyVaultBinding  :
        IIndependentChildResource<IAppServiceManager, AppServiceCertificateResourceInner>
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