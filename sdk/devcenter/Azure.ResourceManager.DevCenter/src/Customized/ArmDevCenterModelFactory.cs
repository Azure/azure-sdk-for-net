// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DevCenter.Models
{
    /// <summary> Suppress generated factory methods for DevCenterOperationStatus.
    /// The generator emits a factory method with only the IReadOnlyDictionary properties param,
    /// but we need the full backward-compat overload matching the baseline SDK. </summary>
    [CodeGenSuppress("DevCenterOperationStatus", typeof(IReadOnlyDictionary<string, BinaryData>))]
    [CodeGenSuppress("DevCenterOperationStatus", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(float?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<OperationStatusResult>), typeof(ResponseError), typeof(ResourceIdentifier), typeof(BinaryData))]
    public static partial class ArmDevCenterModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.DevCenterOperationStatus"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DevCenterOperationStatus DevCenterOperationStatus(ResourceIdentifier id = default, string name = default, string status = default, float? percentComplete = default, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, IEnumerable<OperationStatusResult> operations = default, ResponseError error = default, ResourceIdentifier resourceId = default, BinaryData properties = default)
        {
            operations ??= new List<OperationStatusResult>();
            return new DevCenterOperationStatus(
                id,
                name,
                status,
                percentComplete,
                startOn,
                endOn,
                operations?.ToList(),
                error,
                null,
                properties);
        }
    }
}
