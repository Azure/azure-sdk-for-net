// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Data.Tables
{
    public class TableClientOptions : ClientOptions
    {
        private const ServiceVersion Latest = ServiceVersion.V2018_10_10;
        internal static TableClientOptions Default { get; } = new TableClientOptions();

        public TableClientOptions(ServiceVersion serviceVersion = Latest)
        {
            VersionString = serviceVersion switch
            {
                ServiceVersion.V2018_10_10 => "2018-10-10",
                _ => throw new ArgumentOutOfRangeException(nameof(serviceVersion))
            };
        }

        internal string VersionString { get; }

        public enum ServiceVersion
        {
#pragma warning disable CA1707
            V2018_10_10 = 1
#pragma warning restore CA1707
        }
    }
}
