// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager
{
    public partial class AzureResourceManagerContext
    {
        partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
        {
            factories.Add(typeof(ManagedServiceIdentity), () => new ManagedServiceIdentityTypeBuilder());
        }

        private class ManagedServiceIdentityTypeBuilder : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(ManagedServiceIdentity);

            protected override object CreateInstance()
            {
                return new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            }
        }
    }
}
