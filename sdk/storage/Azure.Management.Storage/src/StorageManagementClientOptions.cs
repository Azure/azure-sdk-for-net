// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Management.Storage
{
    public class StorageManagementClientOptions: ClientOptions
    {
        private const ServiceVersion Latest = ServiceVersion.V2019_06_01;
        internal static StorageManagementClientOptions Default { get; } = new StorageManagementClientOptions();

        public StorageManagementClientOptions(ServiceVersion serviceVersion = Latest)
        {
            VersionString = serviceVersion switch
            {
                ServiceVersion.V2019_06_01 => "2019-06-01",
                _ => throw new ArgumentOutOfRangeException(nameof(serviceVersion))
            };
        }

        internal string VersionString { get; }

        public enum ServiceVersion
        {
#pragma warning disable CA1707
            V2019_06_01 = 1
#pragma warning restore CA1707
        }
    }
}