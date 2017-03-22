// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class AppServiceCertificateKeyVaultBindingImpl 
    {
        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding.KeyVaultSecretName
        {
            get
            {
                return this.KeyVaultSecretName();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding.KeyVaultId
        {
            get
            {
                return this.KeyVaultId();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.KeyVaultSecretStatus Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }
    }
}