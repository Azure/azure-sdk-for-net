// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> AutonomousDbVersion resource model. </summary>
    public partial class AutonomousDBVersionProperties
    {
        /// <summary> Initializes a new instance of <see cref="AutonomousDBVersionProperties"/>. </summary>
        /// <param name="version"> Supported Autonomous Db versions. </param>
        public AutonomousDBVersionProperties(string version)
        {
            Version = version;
        }
    }
}
