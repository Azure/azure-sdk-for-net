// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Management.Batch;
    using Management.Batch.Fluent.Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for BatchAccount Application and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoLmltcGxlbWVudGF0aW9uLkFwcGxpY2F0aW9uSW1wbA==
    internal partial class ApplicationImpl :
        ExternalChildResource<IApplication,
            ApplicationInner,
            IBatchAccount,
            BatchAccountImpl>,
        IApplication,
        Application.Definition.IDefinition<BatchAccount.Definition.IWithApplicationAndStorage>,
        Application.UpdateDefinition.IUpdateDefinition<BatchAccount.Update.IUpdate>,
        Application.Update.IUpdate
    {
        private ApplicationPackagesImpl applicationPackages;

        ///GENMHASH:E599FB9EB31E9A9D449368FB30F00A12:AE61E46F25E32E41F3889C4B879C0A37
        internal ApplicationImpl(string name,
            BatchAccountImpl batchAccount,
            ApplicationInner inner)
            : base(name, batchAccount, inner)
        {
            applicationPackages = new ApplicationPackagesImpl(batchAccount.Manager.Inner.ApplicationPackage, this);
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        ///GENMHASH:19FB5490B29F08AC39628CD5F893E975:D646459DD47DA53CB973DA0F86C056D7
        internal string DisplayName()
        {
            return Inner.DisplayName;
        }

        ///GENMHASH:EFC1A644FBCF1755C5FEB8713E37C978:7F01B6BD1881008A6F33AB93CA13267F
        internal IDictionary<string, IApplicationPackage> ApplicationPackages()
        {
            return applicationPackages.AsMap();
        }

        ///GENMHASH:146B96CEA6724B4FE81949C8EF098DD8:D586D4DA834AE90247EFB379AC82287B
        internal bool UpdatesAllowed()
        {
            return Inner.AllowUpdates.GetValueOrDefault();
        }

        ///GENMHASH:DB556E99F2F976BBB535413BB03A1680:AA1EF1036345377E11FFEFAC3E263093
        internal string DefaultVersion()
        {
            return Inner.DefaultVersion;
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:02EEC4EFE8B735CE832BF91D77CEE31E
        public async override Task<IApplication> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var createParameter = new AddApplicationParametersInner
                                    {
                                        DisplayName = Inner.DisplayName,
                                        AllowUpdates = Inner.AllowUpdates
                                    };

            var inner = await Parent.Manager.Inner.Application.CreateAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(), 
                createParameter, 
                cancellationToken);

            SetInner(inner);
            await applicationPackages.CommitAndGetAllAsync(cancellationToken);
            return this;
        }

        ///GENMHASH:F08598A17ADD014E223DFD77272641FF:E166AAF3CE55ADF2533B6CBBEC6343E8
        public async override Task<IApplication> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var updateParameter = new UpdateApplicationParametersInner
                                    {
                                        DisplayName = Inner.DisplayName,
                                        AllowUpdates = Inner.AllowUpdates
                                    };

            await Parent.Manager.Inner.Application.UpdateAsync(Parent.ResourceGroupName, Parent.Name, Name(), updateParameter, cancellationToken);
            await applicationPackages.CommitAndGetAllAsync(cancellationToken);

            return this;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:F0565BDDC7B68F770608A54BA76D915F
        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Parent.Manager.Inner.Application.DeleteAsync(Parent.ResourceGroupName, Parent.Name, Name(), cancellationToken);
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:409C31CA8E99C248AA5D2D551769B232
        public override async Task<IApplication> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ApplicationInner inner = await GetInnerAsync(cancellationToken);
            SetInner(inner);
            applicationPackages.Refresh();

            return this;
        }

        protected override async Task<ApplicationInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Parent.Manager.Inner.Application.GetAsync(Parent.ResourceGroupName, Parent.Name, Inner.Id, cancellationToken);
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:F50FC9984285FA3EFE81DE58B2255BD1
        public BatchAccountImpl Attach()
        {
            return Parent.WithApplication(this);
        }

        ///GENMHASH:55BB543F59A0455E86C35D9906806D3C:DE335AE9836427CB73B730ED4780F396
        public ApplicationImpl WithAllowUpdates(bool allowUpdates)
        {
            Inner.AllowUpdates = allowUpdates;
            return this;
        }

        ///GENMHASH:EDAD7B033C93B5FEE1419E438619ABF3:BFAAB8F642DD8AD46F649E149BFDC452
        public ApplicationImpl WithDisplayName(string displayName)
        {
            Inner.DisplayName = displayName;
            return this;
        }

        ///GENMHASH:5D2E49B9EB1EE6B00286D10BF760C32B:AD92800DE9BADB7C037AA5D5C472BE5C
        internal static ApplicationImpl NewApplication(string name, BatchAccountImpl parent)
        {
            var inner = new ApplicationInner();
            inner.Id = name;
            var applicationImpl = new ApplicationImpl(name, parent, inner);

            return applicationImpl;
        }

        ///GENMHASH:C6B1C7CD3390E5A764EB666D3725852A:7231626F972ED418CDDF43B085F82CC0
        public Application.Update.IUpdate WithoutApplicationPackage(string applicationPackageName)
        {
            applicationPackages.Remove(applicationPackageName);
            return this;
        }

        ///GENMHASH:82B5410A627E77D5AD19CCC6720999BE:1C157E45BB454131D222F2E92047ADE6
        private ApplicationImpl WithApplicationPackage(ApplicationPackageImpl applicationPackage)
        {
            applicationPackages.AddApplicationPackage(applicationPackage);
            return this;
        }

        ///GENMHASH:0E8D1C15183C29E7CCEE3E8F4004573F:2356C0760522C333B1326ECB5D2FFE2D
        public ApplicationImpl DefineNewApplicationPackage(string applicationPackageName)
        {
            WithApplicationPackage(applicationPackages.Define(applicationPackageName));
            return this;
        }

        BatchAccount.Update.IUpdate ISettable<BatchAccount.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}
