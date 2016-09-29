// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{
    using Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.Azure.Management.Fluent.Batch.Application.Definition;
    using Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using V2.Resource.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for BatchAccount Application and its parent interfaces.
    /// </summary>
    internal partial class ApplicationImpl :
        ExternalChildResource<Microsoft.Azure.Management.Fluent.Batch.IApplication,
            Microsoft.Azure.Management.Batch.Models.ApplicationInner,
            Microsoft.Azure.Management.Fluent.Batch.IBatchAccount,
            Microsoft.Azure.Management.Fluent.Batch.BatchAccountImpl>,
        IApplication,
        IDefinition<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage>,
        IUpdateDefinition<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate>,
        Application.Update.IUpdate
    {
        private IApplicationOperations client;
        private ApplicationPackagesImpl applicationPackages;

        internal ApplicationImpl(string name,
            BatchAccountImpl batchAccount,
            ApplicationInner inner,
            IApplicationOperations client,
            IApplicationPackageOperations applicationPackagesClient)
            : base(name, batchAccount, inner)
        {
            this.client = client;
            applicationPackages = new ApplicationPackagesImpl(applicationPackagesClient, this);
        }

        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        public string DisplayName
        {
            get
            {
                return Inner.DisplayName;
            }
        }

        public IDictionary<string, Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage> ApplicationPackages
        {
            get
            {
                return applicationPackages.AsMap();
            }
        }

        public bool UpdatesAllowed
        {
            get
            {
                return Inner.AllowUpdates.GetValueOrDefault();
            }
        }

        public string DefaultVersion
        {
            get
            {
                return Inner.DefaultVersion;
            }
        }

        public override async Task<IApplication> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var createParameter = new AddApplicationParametersInner();
            createParameter.DisplayName = Inner.DisplayName;
            createParameter.AllowUpdates = Inner.AllowUpdates;

            var inner = await client.CreateAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name, createParameter, cancellationToken);
            SetInner(inner);
            await applicationPackages.CommitAndGetAllAsync(cancellationToken);

            return this;
        }

        public override async Task<IApplication> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var updateParameter = new UpdateApplicationParametersInner();
            updateParameter.DisplayName = Inner.DisplayName;
            updateParameter.AllowUpdates = Inner.AllowUpdates;

            await client.UpdateAsync(Parent.ResourceGroupName, Parent.Name, Name, updateParameter, cancellationToken);
            await applicationPackages.CommitAndGetAllAsync(cancellationToken);

            return this;
        }

        public override async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.DeleteAsync(Parent.ResourceGroupName, Parent.Name, Name, cancellationToken);
        }

        public IApplication Refresh()
        {
            ApplicationInner inner = client.Get(Parent.ResourceGroupName, Parent.Name, Inner.Id);
            SetInner(inner);
            applicationPackages.Refresh();

            return this;
        }

        public BatchAccountImpl Attach()
        {
            return Parent.WithApplication(this);
        }

        public Application.Definition.IWithAttach<IWithApplicationAndStorage> WithAllowUpdates(bool allowUpdates)
        {
            Inner.AllowUpdates = allowUpdates;
            return this;
        }

        public Application.Definition.IWithAttach<IWithApplicationAndStorage> WithDisplayName(string displayName)
        {
            Inner.DisplayName = displayName;
            return this;
        }

        internal static ApplicationImpl NewApplication(string name,
            BatchAccountImpl parent,
            IApplicationOperations client,
            IApplicationPackageOperations applicationPackagesClient)
        {
            var inner = new ApplicationInner();
            inner.Id = name;
            var applicationImpl = new ApplicationImpl(name, parent, inner, client, applicationPackagesClient);

            return applicationImpl;
        }

        public Application.Update.IUpdate WithoutApplicationPackage(string applicationPackageName)
        {
            applicationPackages.Remove(applicationPackageName);
            return this;
        }

        private ApplicationImpl WithApplicationPackage(ApplicationPackageImpl applicationPackage)
        {
            applicationPackages.AddApplicationPackage(applicationPackage);
            return this;
        }

        public Application.Definition.IWithAttach<IWithApplicationAndStorage> DefineNewApplicationPackage(string applicationPackageName)
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