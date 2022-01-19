// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

[assembly: CodeGenSuppressType("PhoneNumbersClientOptions")]
namespace Azure.Communication.PhoneNumbers
{
    /// <summary> Client options for PhoneNumbersClient. </summary>
    public class PhoneNumbersClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_01_11_Preview_2;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary> Service version "2021-03-07". </summary>
            V2021_03_07 = 1,
            /// <summary> Service version "2022-01-11-preview". </summary>
            V2022_01_11_Preview_2 = 2,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of PhoneNumbersClientOptions. </summary>
        public PhoneNumbersClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2021_03_07 => "2021-03-07",
                ServiceVersion.V2022_01_11_Preview_2 => "2022-01-11-preview2",
                _ => throw new NotSupportedException()
            };
        }
    }
}
