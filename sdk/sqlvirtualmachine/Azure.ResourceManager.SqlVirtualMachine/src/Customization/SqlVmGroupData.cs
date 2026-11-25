// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SqlVirtualMachine.Models;

namespace Azure.ResourceManager.SqlVirtualMachine
{
    public partial class SqlVmGroupData
    {
        private readonly string _sqlVmGroupName;

        internal SqlVmGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SqlVirtualMachineGroupProperties properties, string sqlVmGroupName, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            _sqlVmGroupName = sqlVmGroupName;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        // Preserve a legacy factory name independently of the resource name.
        /// <summary> Gets the name of the SQL virtual machine group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SqlVmGroupName => _sqlVmGroupName ?? Name;
    }
}
