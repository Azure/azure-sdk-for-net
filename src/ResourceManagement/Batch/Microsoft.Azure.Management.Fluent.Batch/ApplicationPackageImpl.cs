// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{
    using Management.Batch;
    using Management.Batch.Models;
    using Resource.Core;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for BatchAccount Application Package and its parent interfaces.
    /// </summary>
    public partial class ApplicationPackageImpl :
        ExternalChildResource<
            IApplicationPackage,
            ApplicationPackageInner,
            IApplication,
            ApplicationImpl>,
        IApplicationPackage
    {
        private IApplicationPackageOperations client;

        internal ApplicationPackageImpl(string name, ApplicationImpl parent, ApplicationPackageInner inner, IApplicationPackageOperations client)
            : base(name, parent, inner)
        {
            this.client = client;
        }

        internal static ApplicationPackageImpl NewApplicationPackage(string name, ApplicationImpl parent, IApplicationPackageOperations client)
        {
            ApplicationPackageInner inner = new ApplicationPackageInner();
            inner.Version = name;
            return new ApplicationPackageImpl(name, parent, inner, client);
        }

        internal PackageState State()
        {
            return Inner.State.GetValueOrDefault();
        }

        public string Id
        {
            get
            {
                return Parent.Parent.Id + "/applications/" + Parent.Name() + "/versions/" + Name();
            }
        }

        public override string Name()
        {
            return ResourceUtils.NameFromResourceId(Inner.Id);
        }

        public override async Task<IApplicationPackage> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var applicationPackageInner = await client.CreateAsync(Parent.Parent.ResourceGroupName, Parent.Parent.Name, Parent.Name(), Name(), cancellationToken);
            SetInner(applicationPackageInner);

            return this;
        }

        public override Task<IApplicationPackage> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public void Delete()
        {
            client.Delete(Parent.Parent.ResourceGroupName, Parent.Parent.Name,Parent.Name(), Name());
        }

        public override async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.DeleteAsync(Parent.Parent.ResourceGroupName, Parent.Parent.Name,Parent.Name(), Name(), cancellationToken);
        }

        internal string Format()
        {
            return Inner.Format;
        }

        internal string StorageUrl()
        {
            return Inner.StorageUrl;
        }

        internal DateTime StorageUrlExpiry()
        {
            return Inner.StorageUrlExpiry.GetValueOrDefault();
        }

        internal DateTime LastActivationTime()
        {
            return Inner.LastActivationTime.GetValueOrDefault();
        }

        IApplication IChildResource<IApplication>.Parent
        {
            get
            {
                return Parent;
            }
        }

        internal void Activate(string format)
        {
            client.Activate(Parent.Parent.ResourceGroupName, Parent.Parent.Name, Parent.Name(), Name(), format);
        }

        public IApplicationPackage Refresh()
        {
            ApplicationPackageInner inner = client.Get(Parent.Parent.ResourceGroupName, Parent.Parent.Name, Parent.Name(), Name());
            SetInner(inner);
            return this;
        }
    }
}