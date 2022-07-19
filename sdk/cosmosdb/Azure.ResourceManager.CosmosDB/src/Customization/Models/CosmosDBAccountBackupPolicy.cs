// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    /// <summary>
    /// The object representing the policy for taking backups on an account.
    /// Serialized Name: BackupPolicy
    /// Please note <see cref="CosmosDBAccountBackupPolicy"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="ContinuousModeBackupPolicy"/> and <see cref="PeriodicModeBackupPolicy"/>.
    /// </summary>
    public abstract partial class CosmosDBAccountBackupPolicy
    {
    }
}
