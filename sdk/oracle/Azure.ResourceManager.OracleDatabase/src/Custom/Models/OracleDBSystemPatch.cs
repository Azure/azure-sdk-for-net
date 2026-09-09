// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class OracleDBSystemPatch
    {
        // TODO: Remove this workaround after https://github.com/microsoft/typespec/issues/11696 is fixed.
        /// <summary> The source of the DB system update. </summary>
        [CodeGenMember("DBSystemUpdateSource")]
        public DBSystemSourceType? DbSystemUpdateSource { get; set; }
    }
}
