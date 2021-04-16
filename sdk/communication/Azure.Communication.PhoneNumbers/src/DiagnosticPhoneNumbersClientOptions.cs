// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary> Represents phone number client options that are diagnostic. </summary>
#pragma warning disable AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    public class DiagnosticPhoneNumbersClientOptions : PhoneNumbersClientOptions
#pragma warning restore AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2021_03_07;

        /// <summary> Initializes new instance of DiagnosticPhoneNumbersClientOptions. </summary>
        public DiagnosticPhoneNumbersClientOptions(ServiceVersion version = LatestVersion) : base(version)
        {
            AddHeaderParameters();
        }

        /// <summary>
        /// Add headers in <see cref="DiagnosticsOptions.LoggedHeaderNames"/>
        /// </summary>
        public void AddHeaderParameters()
        {
            // MS-CV headers
            Diagnostics.LoggedHeaderNames.Add("MS-CV");
        }
    }
}
