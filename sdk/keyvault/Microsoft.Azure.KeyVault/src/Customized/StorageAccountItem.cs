// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Models
{
    /// <summary>
    /// The storage account item containing storage account metadata.
    /// </summary>
    public partial class StorageAccountItem
    {
        /// <summary>
        /// The storage account identifier.
        /// </summary>
        public StorageAccountIdentifier Identifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Id))
                    return new StorageAccountIdentifier(Id);
                else
                    return null;
            }
        }
    }
}
