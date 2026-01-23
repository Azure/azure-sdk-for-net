// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class ExascaleDBStorageVaultProperties
    {
        /// <summary> Initializes a new instance of <see cref="ExascaleDBStorageVaultProperties"/>. </summary>
        /// <param name="displayName"> The user-friendly name for the Exadata Database Storage Vault. The name does not need to be unique. </param>
        /// <param name="highCapacityDatabaseStorageInput"> Create exadata Database Storage Details. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="displayName"/> or <paramref name="highCapacityDatabaseStorageInput"/> is null. </exception>
        public ExascaleDBStorageVaultProperties(string displayName, ExascaleDBStorageInputDetails highCapacityDatabaseStorageInput)
        {
            Argument.AssertNotNull(displayName, nameof(displayName));
            Argument.AssertNotNull(highCapacityDatabaseStorageInput, nameof(highCapacityDatabaseStorageInput));

            DisplayName = displayName;
            HighCapacityDatabaseStorageInput = highCapacityDatabaseStorageInput;
            AttachedShapeAttributes = new ChangeTrackingList<ExascaleStorageShapeAttribute>();
        }
    }
}
