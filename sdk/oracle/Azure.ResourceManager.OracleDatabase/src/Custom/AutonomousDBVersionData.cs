// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing the AutonomousDBVersion data model.
    /// AutonomousDbVersion resource definition
    /// </summary>
    public partial class AutonomousDBVersionData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="AutonomousDBVersionData"/>. </summary>
        public AutonomousDBVersionData()
        {
        }

        /// <summary> The resource-specific properties for this resource. </summary>
        public AutonomousDBVersionProperties Properties { get; set; }
    }
}
