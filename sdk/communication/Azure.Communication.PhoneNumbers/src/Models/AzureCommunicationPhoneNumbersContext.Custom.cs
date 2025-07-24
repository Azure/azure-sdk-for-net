// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Communication.PhoneNumbers
{
    public partial class AzureCommunicationPhoneNumbersContext
    {
        private AzureCommunicationPhoneNumbersContext _azureCommunicationPhoneNumbersContext;

        /// <summary> Gets the default instance </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureCommunicationPhoneNumbersContext Default => _azureCommunicationPhoneNumbersContext ??= new();
    }
}
