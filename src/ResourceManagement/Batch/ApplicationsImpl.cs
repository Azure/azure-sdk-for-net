// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents a application collection associated with a Batch Account.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoLmltcGxlbWVudGF0aW9uLkFwcGxpY2F0aW9uc0ltcGw=
    internal partial class ApplicationsImpl :
        ExternalChildResourcesCached<
            ApplicationImpl,
            IApplication,
            ApplicationInner,
            IBatchAccount,
            BatchAccountImpl>
    {
        private BatchAccountImpl parent;

        ///GENMHASH:7F1D4CEF6D71CC38B50E5E83BB1A6DDB:C5EC5A81A9B660015E5BC8802942DF92
        internal ApplicationsImpl(BatchAccountImpl parent)
            : base(parent, "Application")
        {
            this.parent = parent;
            CacheCollection();
        }

        ///GENMHASH:310B2185D2F2431DF2BBDBC06E585C74:9EA9A37597EAD8A99691D15719026E07
        internal IReadOnlyDictionary<string, IApplication> AsMap()
        {
            var result = new Dictionary<string, IApplication>();

            foreach (var entry in Collection)
            {
                result.Add(entry.Key, entry.Value);
            }

            return new ReadOnlyDictionary<string, IApplication>(result);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:E3D9E623E212362C450DC90E92DF3FCC
        internal ApplicationImpl Define(string name)
        {
            return PrepareDefine(name);
        }

        ///GENMHASH:C45CF357E710B1EC18EFF0A7FCD36915:3FB710926B53C5FC505B69CE66B544B2
        internal ApplicationImpl Update(string name)
        {
            return PrepareUpdate(name);
        }

        ///GENMHASH:FC8ECF797E9AF86E82C3899A3D5C00BB:97028F0C4A32755497D72429D22C1125
        internal void Remove(string name)
        {
            PrepareRemove(name);
        }

        ///GENMHASH:1DACF83E7D1C232CF9905C507D6A7D1E:C98FDBA4C2E9BEA0F3A50E68D16BAFBC
        internal void AddApplication(ApplicationImpl application)
        {
            AddChildResource(application);
        }

        ///GENMHASH:6A122C62EB559D6E6E53725061B422FB:1236AAF317D02AEA462B940B4CC124B0
        protected override IList<ApplicationImpl> ListChildResources()
        {
            var childResources = new List<ApplicationImpl>();
            if (Parent.Inner.Id == null || Parent.AutoStorage() == null)
            {
                return childResources;
            }

            var applicationList = Extensions.Synchronize(() => Parent.Manager.Inner.Application.ListAsync(Parent.ResourceGroupName, Parent.Name));

            foreach (var application in applicationList)
            {
                childResources.Add(new ApplicationImpl(
                    application.Id,
                    parent,
                    application));
            }

            return childResources;
        }

        ///GENMHASH:8E8DA5B84731A2D412247D25A544C502:9982C2948E7BAC51FB839F919FEB2148
        protected override ApplicationImpl NewChildResource(string name)
        {
            ApplicationImpl application = ApplicationImpl.NewApplication(name, parent);
            return application;
        }
    }
}
