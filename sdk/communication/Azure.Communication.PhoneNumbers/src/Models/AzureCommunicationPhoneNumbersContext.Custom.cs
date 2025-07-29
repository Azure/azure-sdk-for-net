// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ComponentModel;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// Context class which will be filled in by the System.ClientModel.SourceGeneration.
    /// For more information see 'https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md'
    /// </summary>
    public partial class AzureCommunicationPhoneNumbersContext : ModelReaderWriterContext
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        private AzureCommunicationPhoneNumbersContext _azureCommunicationPhoneNumbersContext;

        /// <summary> Gets the default instance </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureCommunicationPhoneNumbersContext Default => _azureCommunicationPhoneNumbersContext ??= new();
    }
}
