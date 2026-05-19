// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    public abstract partial class StoreWriteSettings
    {
        /// <summary> Initializes a new instance of <see cref="StoreWriteSettings"/>. </summary>
        protected StoreWriteSettings()
        {
            Metadata = new ChangeTrackingList<DataFactoryMetadataItemInfo>();
        }
    }
}
