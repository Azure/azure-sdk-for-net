// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Sql;

namespace Azure.ResourceManager.Sql.Models
{
    // Make all properties settable to ensure backward compatibility with the previous version of the SDK, the code will be removed once https://github.com/Azure/azure-sdk-for-net/issues/60037 is resolved.
    internal partial class DatabaseExtensionsProperties
    {
        /// <summary> Operation mode of the operation: Import, Export, or PolybaseImport. </summary>
        [WirePath("operationMode")]
        public DatabaseExtensionOperationMode OperationMode { get; set; }

        /// <summary> Storage key type: StorageAccessKey, SharedAccessKey or ManagedIdentity. </summary>
        [WirePath("storageKeyType")]
        public StorageKeyType StorageKeyType { get; set; }

        /// <summary> Storage key for the storage account. If StorageKeyType is ManagedIdentity, this field should specify the Managed Identity's resource ID. </summary>
        [WirePath("storageKey")]
        public string StorageKey { get; set; }

        /// <summary> Storage Uri for the storage account. </summary>
        [WirePath("storageUri")]
        public Uri StorageUri { get; set; }
    }
}
