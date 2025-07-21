// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing the AutonomousDatabaseCharacterSet data model.
    /// AutonomousDatabaseCharacterSets resource definition
    /// </summary>
    public partial class AutonomousDatabaseCharacterSetData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="AutonomousDatabaseCharacterSetData"/>. </summary>
        public AutonomousDatabaseCharacterSetData()
        {
        }

        /// <summary> The Oracle Autonomous Database supported character sets. </summary>
        public string AutonomousDatabaseCharacterSet
        {
            get => Properties?.CharacterSet;
            set => Properties.CharacterSet = value;
        }
    }
}
