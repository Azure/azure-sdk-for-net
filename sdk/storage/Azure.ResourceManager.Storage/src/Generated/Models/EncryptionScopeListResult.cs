// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> List of encryption scopes requested, and if paging is required, a URL to the next page of encryption scopes. </summary>
    internal partial class EncryptionScopeListResult
    {
        /// <summary> Initializes a new instance of EncryptionScopeListResult. </summary>
        internal EncryptionScopeListResult()
        {
            Value = new ChangeTrackingList<EncryptionScopeData>();
        }

        /// <summary> Initializes a new instance of EncryptionScopeListResult. </summary>
        /// <param name="value"> List of encryption scopes requested. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of encryption scopes. Returned when total number of requested encryption scopes exceeds the maximum page size. </param>
        internal EncryptionScopeListResult(IReadOnlyList<EncryptionScopeData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> List of encryption scopes requested. </summary>
        public IReadOnlyList<EncryptionScopeData> Value { get; }
        /// <summary> Request URL that can be used to query next page of encryption scopes. Returned when total number of requested encryption scopes exceeds the maximum page size. </summary>
        public string NextLink { get; }
    }
}
