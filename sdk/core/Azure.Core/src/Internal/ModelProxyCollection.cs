// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.Core
{
    // Ordered registration list exposed by ClientOptions.ModelProxies. Mirrors the null checks of
    // System.ClientModel's internal ModelProxyCollection; Azure.Core options have no freeze concept,
    // so the list is always mutable.
    internal sealed class ModelProxyCollection : Collection<ModelProxy>
    {
        public ModelProxyCollection()
        {
        }

        public ModelProxyCollection(IEnumerable<ModelProxy> items)
            : base(new List<ModelProxy>(items))
        {
        }

        protected override void InsertItem(int index, ModelProxy item)
        {
            Argument.AssertNotNull(item, nameof(item));
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, ModelProxy item)
        {
            Argument.AssertNotNull(item, "value");
            base.SetItem(index, item);
        }
    }
}
