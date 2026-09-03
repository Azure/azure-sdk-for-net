// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SqlVirtualMachine.Models
{
    // TODO: Remove this workaround after https://github.com/microsoft/typespec/issues/11696 is fixed.
    internal partial class SqlVirtualMachineProperties
    {
        [CodeGenMember("OSType")]
        public SqlVmOsType? OsType { get; }
    }
}
