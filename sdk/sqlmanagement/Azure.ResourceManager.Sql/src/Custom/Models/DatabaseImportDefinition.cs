// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class DatabaseImportDefinition
    {
        /// <summary> Backward-compatible 5-argument constructor including administrator login password. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DatabaseImportDefinition(StorageKeyType storageKeyType, string storageKey, Uri storageUri, string administratorLogin, string administratorLoginPassword)
            : this(storageKeyType, storageKey, storageUri, administratorLogin)
        {
            AdministratorLoginPassword = administratorLoginPassword;
        }
    }
}
