// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class DatabaseExportDefinition
    {
        /// <summary> Initializes a new instance of <see cref="DatabaseExportDefinition"/>. </summary>
        /// <param name="storageKeyType"> Storage key type. </param>
        /// <param name="storageKey"> Storage key. </param>
        /// <param name="storageUri"> Storage Uri. </param>
        /// <param name="administratorLogin"> Administrator login name. </param>
        /// <param name="administratorLoginPassword"> Administrator login password. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="storageKey"/>, <paramref name="storageUri"/>, <paramref name="administratorLogin"/> or <paramref name="administratorLoginPassword"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DatabaseExportDefinition(StorageKeyType storageKeyType, string storageKey, Uri storageUri, string administratorLogin, string administratorLoginPassword)
        {
            Argument.AssertNotNull(storageKey, nameof(storageKey));
            Argument.AssertNotNull(storageUri, nameof(storageUri));
            Argument.AssertNotNull(administratorLogin, nameof(administratorLogin));
            Argument.AssertNotNull(administratorLoginPassword, nameof(administratorLoginPassword));

            StorageKeyType = storageKeyType;
            StorageKey = storageKey;
            StorageUri = storageUri;
            AdministratorLogin = administratorLogin;
            AdministratorLoginPassword = administratorLoginPassword;
        }
    }
}
