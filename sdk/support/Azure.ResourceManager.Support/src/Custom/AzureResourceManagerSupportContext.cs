// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Support
{
    [ModelReaderWriterBuildable(typeof(ResponseError))]
    public partial class AzureResourceManagerSupportContext
    {
    }
}
