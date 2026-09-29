// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ElasticSan.Models;

namespace Azure.ResourceManager.ElasticSan
{
    public partial class ElasticSanData
    {
        /// <summary> Initializes a new instance of <see cref="ElasticSanData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="sku"> resource sku. </param>
        /// <param name="baseSizeTiB"> Base size of the Elastic San appliance in TiB. </param>
        /// <param name="extendedCapacitySizeTiB"> Extended size of the Elastic San appliance in TiB. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ElasticSanData(
            AzureLocation location,
            ElasticSanSku sku,
            long baseSizeTiB,
            long extendedCapacitySizeTiB) : this(location, sku, (long?)baseSizeTiB, (long?)extendedCapacitySizeTiB)
        {
        }
    }
}
