// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{
    using Management.Batch;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// Represents a applicationPackage collection associated with a application.
    /// </summary>
    internal partial class ApplicationPackagesImpl :
        ExternalChildResources<Microsoft.Azure.Management.Fluent.Batch.ApplicationPackageImpl,
            Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage,
            Microsoft.Azure.Management.Batch.Models.ApplicationPackageInner,
            Microsoft.Azure.Management.Fluent.Batch.IApplication,
            Microsoft.Azure.Management.Fluent.Batch.ApplicationImpl>
    {
        private IApplicationPackageOperations client;
        private ApplicationImpl parent;

        internal ApplicationPackagesImpl(IApplicationPackageOperations client, ApplicationImpl parent)
            : base(parent, "ApplicationPackage")
        {
            this.client = client;
            this.parent = parent;
            InitializeCollection();
        }

        public ApplicationPackageImpl Define(string name)
        {
            return PrepareDefine(name);
        }

        public void Remove(string applicationPackageName)
        {
            PrepareRemove(applicationPackageName);
        }

        protected override IList<Microsoft.Azure.Management.Fluent.Batch.ApplicationPackageImpl> ListChildResources()
        {
            var childResources = new List<ApplicationPackageImpl>();

            if (parent.Inner.Packages == null || !parent.Inner.Packages.Any())
            {
                return childResources;
            }

            var applicationPackageList = parent.Inner.Packages;

            foreach (var applicationPackage in applicationPackageList)
            {
                childResources.Add(new ApplicationPackageImpl(applicationPackage.Version, parent, applicationPackage, client));
            }

            return childResources;
        }

        protected override ApplicationPackageImpl NewChildResource(string name)
        {
            return ApplicationPackageImpl.NewApplicationPackage(name, parent, client);
        }

        public void AddApplicationPackage(ApplicationPackageImpl applicationPackage)
        {
            AddChildResource(applicationPackage);
        }

        public IDictionary<string, Microsoft.Azure.Management.Fluent.Batch.IApplicationPackage> AsMap()
        {
            var result = new Dictionary<string, IApplicationPackage>();

            foreach (var entry in Collection)
            {
                ApplicationPackageImpl applicationPackage = entry.Value;
                result.Add(entry.Key, applicationPackage);
            }

            return new ReadOnlyDictionary<string, IApplicationPackage>(result);
        }
    }
}