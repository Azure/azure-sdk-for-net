// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats
{
    internal interface INetworkSdkStatsBatch
    {
        int Count { get; }
        IReadOnlyCollection<KeyValuePair<string, int>> ItemCountsByInstrumentationKey { get; }
        string? GetInstrumentationKey(int index);
    }

    internal sealed class ConfiguredNetworkStatsBatch : INetworkSdkStatsBatch
    {
        private readonly KeyValuePair<string, int>[] _customer;

        internal ConfiguredNetworkStatsBatch(string key, int count)
        {
            _customer = new[] { new KeyValuePair<string, int>(key, count) };
        }

        public int Count => _customer[0].Value;
        public IReadOnlyCollection<KeyValuePair<string, int>> ItemCountsByInstrumentationKey => _customer;
        public string GetInstrumentationKey(int index) => _customer[0].Key;
    }
}
