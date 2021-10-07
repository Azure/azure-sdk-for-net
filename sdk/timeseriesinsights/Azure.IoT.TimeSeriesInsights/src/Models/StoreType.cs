// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Time Series Insights store type.
    /// </summary>
    public class StoreType
    {
        private readonly string _value;
        private const string WarmStoreValue = "WarmStore";
        private const string ColdStoreValue = "ColdStore";

        internal StoreType(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Time Series Insights warm store.
        /// </summary>
        public static StoreType WarmStore { get; } = new StoreType(WarmStoreValue);

        /// <summary>
        /// Time Series Insights cold store.
        /// </summary>
        public static StoreType ColdStore { get; } = new StoreType(ColdStoreValue);

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
