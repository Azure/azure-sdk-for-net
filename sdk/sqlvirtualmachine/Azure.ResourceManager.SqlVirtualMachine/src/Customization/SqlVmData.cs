// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.SqlVirtualMachine.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SqlVirtualMachine
{
    // TODO: Remove this workaround after https://github.com/microsoft/typespec/issues/11696 is fixed.
    public partial class SqlVmData
    {
        /// <summary> Operating System of the current SQL Virtual Machine. </summary>
        [CodeGenMember("OSType")]
        public SqlVmOsType? OsType => Properties?.OsType;
    }
}
