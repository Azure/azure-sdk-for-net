// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DevCenter.Models
{
    // Backward-compat factory method for DevCenterOperationStatus to match the baseline SDK.
    public static partial class ArmDevCenterModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.DevCenterOperationStatus"/>. </summary>
        public static DevCenterOperationStatus DevCenterOperationStatus(ResourceIdentifier id = default, string name = default, string status = default, float? percentComplete = default, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, IEnumerable<OperationStatusResult> operations = default, ResponseError error = default, ResourceIdentifier resourceId = default, BinaryData properties = default)
        {
            operations ??= new List<OperationStatusResult>();
            IDictionary<string, BinaryData> additionalProps = new Dictionary<string, BinaryData>();
            if (resourceId != null)
            {
                additionalProps["resourceId"] = new BinaryData("\"" + resourceId.ToString() + "\"");
            }
            return new DevCenterOperationStatus(
                id,
                name,
                status,
                percentComplete,
                startOn,
                endOn,
                operations?.ToList(),
                error,
                additionalProps,
                properties);
        }
    }
}
