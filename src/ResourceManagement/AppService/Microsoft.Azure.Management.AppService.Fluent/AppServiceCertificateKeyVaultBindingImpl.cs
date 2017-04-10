// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for AppServicePlan.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZUNlcnRpZmljYXRlS2V5VmF1bHRCaW5kaW5nSW1wbA==
    internal partial class AppServiceCertificateKeyVaultBindingImpl :
        IndependentChildResourceImpl<
            IAppServiceCertificateKeyVaultBinding,
            IAppServiceCertificateOrder,
            AppServiceCertificateResourceInner,
            AppServiceCertificateKeyVaultBindingImpl,
            object,
            object,
            IAppServiceManager>,
        IAppServiceCertificateKeyVaultBinding
    {
        private AppServiceCertificateOrderImpl parent;

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:A3CF7B3DC953F353AAE8083D72F74056
        public new string Id()
        {
            return Inner.Id;
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:EF611182518FA724341200882E0C6D97
        protected async override Task<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateKeyVaultBinding> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Manager.Inner.AppServiceCertificateOrders.CreateOrUpdateCertificateAsync(parent.ResourceGroupName, parent.Name, Name, Inner);
            SetInner(inner);
            return this;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:3DB04077E6BABC0FB5A5ACDA19D11309
        public KeyVaultSecretStatus ProvisioningState()
        {
            return Inner.ProvisioningState.GetValueOrDefault();
        }

        ///GENMHASH:E859445AB65C00AE1D158E5C9BCF53DE:FB229960BFEFF46C67386E9D83795EA0
        public string KeyVaultId()
        {
            return Inner.KeyVaultId;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:360C34F1E1D3680D56F867742DA72A0F
        protected override async Task<AppServiceCertificateResourceInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.AppServiceCertificateOrders.GetCertificateAsync(parent.ResourceGroupName, parent.Name, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:D4A5D054CC36457C424453F9336F119D:DF50D77B281002A20A5029B77CA61F76
        public string KeyVaultSecretName()
        {
            return Inner.KeyVaultSecretName;
        }

        ///GENMHASH:B9EDBDEBBAFF9FA1B965F82D94B7D20D:D717DAAD2288A48502D0DF6C7AA6562A
        internal AppServiceCertificateKeyVaultBindingImpl(AppServiceCertificateResourceInner innerObject, AppServiceCertificateOrderImpl parent)
            : base(innerObject.Name, innerObject, (parent != null) ? parent.Manager : null)
        {
            this.parent = parent;
        }
    }
}
