// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Context class which will be filled in by the System.ClientModel.SourceGeneration.
    /// For more information see 'https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md'
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AzureDataAppConfigurationContext : ModelReaderWriterContext
    {
        private AzureDataAppConfigurationContext _azureDataAppConfigurationContext;

        /// <summary> Gets the default instance </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureDataAppConfigurationContext Default => _azureDataAppConfigurationContext ??= new();
    }
}
