// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing the OracleDBSystemShape data model.
    /// DbSystemShape resource definition
    /// </summary>
    public partial class OracleDBSystemShapeData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="OracleDBSystemShapeData"/>. </summary>
        public OracleDBSystemShapeData()
        {
        }

        /// <summary> The resource-specific properties for this resource. </summary>
        public OracleDBSystemShapeProperties Properties { get; set; }
    }
}
