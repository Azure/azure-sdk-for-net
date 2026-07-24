// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.Data.AppConfiguration
{
    // TODO: Remove this customization when https://github.com/Azure/azure-sdk-for-net/issues/61315 is resolved.
    [ModelReaderWriterBuildable(typeof(ResponseError))]
    public partial class AzureDataAppConfigurationContext
    {
    }
}
