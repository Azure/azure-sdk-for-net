// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec renamed, nested, or removed these legacy model members, so generation omits the GA constructor/property shape; reintroduce the source-compatible member in this partial.
    public partial class SecurityTaskData
    {
        // Preserve the GA parameterless constructor. The TypeSpec-generated constructor is internal
        // because SecurityTask is a proxy resource returned by read/list operations.
        /// <summary> Initializes a new instance of <see cref="SecurityTaskData"/>. </summary>
        public SecurityTaskData()
        {
            Properties = new SecurityTaskPropertiesInfo();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        // Preserve the GA flattened property on SecurityTaskData; see the backing setter in
        // Custom/Models/SecurityTaskPropertiesInfo.cs for why this remains custom code.
        /// <summary> Changing set of properties, depending on the task type that is derived from the name field. </summary>
        public SecurityTaskProperties SecurityTaskParameters
        {
            get => Properties is null ? default : Properties.SecurityTaskParameters;
            set => Properties.SecurityTaskParameters = value;
        }
    }
}
