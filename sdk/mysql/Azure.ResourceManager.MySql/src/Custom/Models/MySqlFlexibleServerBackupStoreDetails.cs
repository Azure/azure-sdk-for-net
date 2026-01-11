// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    /// <summary>
    /// Details about the target where the backup content will be stored.
    /// Please note <see cref="MySqlFlexibleServerBackupStoreDetails"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="MySqlFlexibleServerFullBackupStoreDetails"/>.
    /// </summary>
    [CodeGenModel("BackupStoreDetails")]
    public abstract partial class MySqlFlexibleServerBackupStoreDetails
    {
    }
}
