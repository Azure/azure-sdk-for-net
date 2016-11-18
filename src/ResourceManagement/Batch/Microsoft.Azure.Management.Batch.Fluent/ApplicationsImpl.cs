// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Management.Batch;
    using Management.Batch.Fluent.Models;
    using Resource.Fluent.Core;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents a application collection associated with a Batch Account.
    /// </summary>
    public partial class ApplicationsImpl :
        ExternalChildResourcesCached<
            ApplicationImpl,
            IApplication,
            ApplicationInner,
            IBatchAccount,
            BatchAccountImpl>
    {
        private IApplicationOperations client;
        private IApplicationPackageOperations applicationPackagesClient;
        private BatchAccountImpl parent;

        internal ApplicationsImpl(IApplicationOperations client, IApplicationPackageOperations applicationPackagesClient, BatchAccountImpl parent)
            : base(parent, "Application")
        {
            this.client = client;
            this.parent = parent;
            this.applicationPackagesClient = applicationPackagesClient;
            this.CacheCollection();
        }

        internal IDictionary<string, IApplication> AsMap()
        {
            var result = new Dictionary<string, IApplication>();

            foreach (var entry in Collection)
            {
                result.Add(entry.Key, entry.Value);
            }

            return new ReadOnlyDictionary<string, IApplication>(result);
        }

        internal ApplicationImpl Define(string name)
        {
            return PrepareDefine(name);
        }

        internal ApplicationImpl Update(string name)
        {
            return PrepareUpdate(name);
        }

        internal void Remove(string name)
        {
            PrepareRemove(name);
        }

        internal void AddApplication(ApplicationImpl application)
        {
            AddChildResource(application);
        }

        protected override IList<ApplicationImpl> ListChildResources()
        {
            var childResources = new List<ApplicationImpl>();
            if (Parent.Inner.Id == null || Parent.Inner.AutoStorage == null)
            {
                return childResources;
            }

            var applicationList = client.List(Parent.ResourceGroupName, Parent.Name);

            foreach (var application in applicationList)
            {
                childResources.Add(new ApplicationImpl(application.Id, parent, application, client, applicationPackagesClient));
            }

            return childResources;
        }

        protected override ApplicationImpl NewChildResource(string name)
        {
            ApplicationImpl application = ApplicationImpl.NewApplication(name, parent, client, applicationPackagesClient);
            return application;
        }
    }
}