// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Management.Batch;
    using Resource.Fluent.Core;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// Represents a applicationPackage collection associated with a application.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoLmltcGxlbWVudGF0aW9uLkFwcGxpY2F0aW9uUGFja2FnZXNJbXBs
    public partial class ApplicationPackagesImpl :
        ExternalChildResourcesCached<ApplicationPackageImpl,
            IApplicationPackage,
            Management.Batch.Fluent.Models.ApplicationPackageInner,
            IApplication,
            ApplicationImpl>
    {
        private IApplicationPackageOperations client;
        private ApplicationImpl parent;

        internal ApplicationPackagesImpl(IApplicationPackageOperations client, ApplicationImpl parent)
            : base(parent, "ApplicationPackage")
        {
            this.client = client;
            this.parent = parent;
            CacheCollection();
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:E3D9E623E212362C450DC90E92DF3FCC
        public ApplicationPackageImpl Define(string name)
        {
            return PrepareDefine(name);
        }

        ///GENMHASH:FC8ECF797E9AF86E82C3899A3D5C00BB:F0D1229265F1637BBE32E524D479B677
        internal void Remove(string applicationPackageName)
        {
            PrepareRemove(applicationPackageName);
        }

        ///GENMHASH:6A122C62EB559D6E6E53725061B422FB:31266E0F5C59A745DCBC67FE70DED1E8
        protected override IList<ApplicationPackageImpl> ListChildResources()
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

        ///GENMHASH:8E8DA5B84731A2D412247D25A544C502:2574C4932A56E8A550A63AD4C374CD50
        protected override ApplicationPackageImpl NewChildResource(string name)
        {
            return ApplicationPackageImpl.NewApplicationPackage(name, parent, client);
        }

        ///GENMHASH:FDBA2803E9882B732C94FBD64DC9D13B:3CEA2921F291B19D8593A8BD0C8FFC02
        internal void AddApplicationPackage(ApplicationPackageImpl applicationPackage)
        {
            AddChildResource(applicationPackage);
        }

        ///GENMHASH:310B2185D2F2431DF2BBDBC06E585C74:F487B2409E11AB3B3255E980C7B88B89
        internal IDictionary<string, Microsoft.Azure.Management.Batch.Fluent.IApplicationPackage> AsMap()
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
