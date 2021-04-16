// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("PhoneNumbersClientOptions")]
    public partial class PhoneNumbersClientOptions
    {
        /// <summary>
        /// Add headers in <see cref="DiagnosticsOptions.LoggedHeaderNames"/>
        /// </summary>
        public PhoneNumbersClientOptions AddHeaderParameters()
        {
            // MS-CV headers
            Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return this;
        }
    }
}
