// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing the AutonomousDatabaseNationalCharacterSet data model.
    /// AutonomousDatabaseNationalCharacterSets resource definition
    /// </summary>
    public partial class AutonomousDatabaseNationalCharacterSetData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="AutonomousDatabaseNationalCharacterSetData"/>. </summary>
        public AutonomousDatabaseNationalCharacterSetData()
        {
        }

        /// <summary> The Oracle Autonomous Database supported national character sets. </summary>
        public string AutonomousDatabaseNationalCharacterSet
        {
            get => Properties?.CharacterSet;
            set => Properties.CharacterSet = value;
        }
    }
}
