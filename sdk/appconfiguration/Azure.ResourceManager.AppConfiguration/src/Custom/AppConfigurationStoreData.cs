// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.AppConfiguration.Models;

namespace Azure.ResourceManager.AppConfiguration
{
    // add back a ctor back for backward compatibility
    public partial class AppConfigurationStoreData
    {
        /// <summary> Initializes a new instance of <see cref="AppConfigurationStoreData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The sku of the configuration store. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public AppConfigurationStoreData(AzureLocation location, AppConfigurationSku sku) : base(location)
        {
            Argument.AssertNotNull(sku, nameof(sku));

            Sku = sku;
        }
    }
}
