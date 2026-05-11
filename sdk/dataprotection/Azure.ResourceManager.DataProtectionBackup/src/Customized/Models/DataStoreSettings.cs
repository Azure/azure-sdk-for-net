// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public abstract partial class DataStoreSettings
    {
        /// <summary> Initializes a new instance of <see cref="DataStoreSettings"/>. </summary>
        /// <param name="dataStoreType"> type of datastore; Operational/Vault/Archive. </param>
        protected DataStoreSettings(DataStoreType dataStoreType)    // This constructor is intentionally retained for backward compatibility.
        {
             DataStoreType = dataStoreType;
        }
    }
}
