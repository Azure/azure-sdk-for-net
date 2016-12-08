// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class AppServiceCertificateKeyVaultBindingImpl 
    {
        string Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding.KeyVaultSecretName
        {
            get
            {
                return this.KeyVaultSecretName();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding.KeyVaultId
        {
            get
            {
                return this.KeyVaultId();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.KeyVaultSecretStatus Microsoft.Azure.Management.Appservice.Fluent.IAppServiceCertificateKeyVaultBinding.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }
    }
}