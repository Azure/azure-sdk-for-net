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
        // The factory and deserializer still pass sqlVmGroupName, but the generated constructor
        // would assign it to the getter-only alias. Keep the signature and ignore the legacy
        // value. See https://github.com/Azure/azure-sdk-for-net/issues/65199.
        internal SqlVmGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SqlVirtualMachineGroupProperties properties, string sqlVmGroupName, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        // Retain the legacy property as an alias for the resource name.
        /// <summary> Gets the name of the SQL virtual machine group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Please use Name instead.")]
        public string SqlVmGroupName => Name;
    }
}
