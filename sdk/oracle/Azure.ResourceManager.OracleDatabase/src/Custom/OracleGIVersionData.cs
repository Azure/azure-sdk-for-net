// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing the OracleGIVersion data model.
    /// GiVersion resource definition
    /// </summary>
    public partial class OracleGIVersionData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="OracleGIVersionData"/>. </summary>
        public OracleGIVersionData()
        {
        }

        /// <summary> A valid Oracle Grid Infrastructure (GI) software version. </summary>
        public string OracleGIVersion
        {
            get => Properties?.Version;
            set => Properties.Version = value;
        }
    }
}
