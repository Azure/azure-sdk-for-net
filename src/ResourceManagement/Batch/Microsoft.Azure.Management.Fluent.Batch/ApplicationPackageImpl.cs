// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{
    using Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for BatchAccount Application Package and its parent interfaces.
    /// </summary>
    internal partial class ApplicationPackageImpl :
        ExternalChildResource<
            Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage,
            Microsoft.Azure.Management.Batch.Models.ApplicationPackageInner,
            Microsoft.Azure.Management.Fluent.Batch.IApplication,
            Microsoft.Azure.Management.Fluent.Batch.ApplicationImpl>,
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

        public PackageState State
        {
            get
            {
                return Inner.State.GetValueOrDefault();
            }
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
            return Inner.Version;
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
            client.Delete(Parent.Parent.ResourceGroupName, Parent.Parent.Name, Parent.Name(), Name());
        }

        public override async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.DeleteAsync(Parent.Parent.ResourceGroupName, Parent.Parent.Name, Parent.Name(), Name(), cancellationToken);
        }

        public string Format
        {
            get
            {
                return Inner.Format;
            }
        }

        public string StorageUrl
        {
            get
            {
                return Inner.StorageUrl;
            }
        }

        public DateTime StorageUrlExpiry
        {
            get
            {
                return Inner.StorageUrlExpiry.GetValueOrDefault();
            }
        }

        public DateTime LastActivationTime
        {
            get
            {
                return Inner.LastActivationTime.GetValueOrDefault();
            }
        }

        IApplication IChildResource<IApplication>.Parent
        {
            get
            {
                return Parent;
            }
        }

        public void Activate(string format)
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