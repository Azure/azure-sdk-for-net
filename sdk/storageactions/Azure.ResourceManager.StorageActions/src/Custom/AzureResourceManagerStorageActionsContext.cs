// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.StorageActions
{
    // Temporary. Remove this when https://github.com/microsoft/typespec/issues/7988 is resolved.
    public partial class AzureResourceManagerStorageActionsContext : ModelReaderWriterContext
    {
        partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
        {
            factories.Add(typeof(SystemData), () => s_referenceContexts[typeof(AzureResourceManagerContext)].GetTypeBuilder(typeof(SystemData)));
        }
    }
}
