// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class StorageAccountListResult
    {
        /// <summary> Initializes a new instance of StorageAccountListResult. </summary>
        internal StorageAccountListResult()
        {
            Value = new ChangeTrackingList<StorageAccountData>();
        }

        /// <summary> Initializes a new instance of StorageAccountListResult. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        internal StorageAccountListResult(IReadOnlyList<StorageAccountData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<StorageAccountData> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
