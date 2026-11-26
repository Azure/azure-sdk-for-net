// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SqlVirtualMachine.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SqlVirtualMachine
{
    // TODO: Remove this workaround after https://github.com/microsoft/typespec/issues/11696 is fixed.
    public partial class SqlVmData
    {
        internal SqlVmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SqlVirtualMachineProperties properties, string sqlVmName, ManagedServiceIdentity identity, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            Identity = identity;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        // Retain the legacy property as an alias for the resource name.
        /// <summary> Gets the name of the SQL virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SqlVmName => Name;

        /// <summary> Operating System of the current SQL Virtual Machine. </summary>
        [CodeGenMember("OSType")]
        public SqlVmOsType? OsType => Properties?.OsType;
    }
}
