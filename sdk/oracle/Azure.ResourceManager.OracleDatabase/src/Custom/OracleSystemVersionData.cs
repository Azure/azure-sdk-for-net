// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing the OracleSystemVersion data model.
    /// SystemVersion resource Definition
    /// </summary>
    public partial class OracleSystemVersionData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="OracleSystemVersionData"/>. </summary>
        public OracleSystemVersionData()
        {
        }

        /// <summary> A valid Oracle System Version. </summary>
        public string OracleSystemVersion
        {
            get => Properties?.SystemVersion;
            set => Properties.SystemVersion = value;
        }
    }
}
