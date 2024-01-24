// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.ResourceManager.Maintenance
{
    public partial class MaintenanceConfigurationData
    {
        /// <summary> Effective start date of the maintenance window in YYYY-MM-DD HH:mm format. The start date can be set to either the current date or future date. The window will be created in the time zone provided and adjusted to daylight savings according to that time zone. </summary>
        [CodeGenMember("StartOn")]
        [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(SerializeStartOn))]
        public DateTimeOffset? StartOn { get; set; }
        /// <summary> Effective expiration date of the maintenance window in YYYY-MM-DD HH:mm format. The window will be created in the time zone provided and adjusted to daylight savings according to that time zone. Expiration date must be set to a future date. If not provided, it will be set to the maximum datetime 9999-12-31 23:59:59. </summary>
        [CodeGenMember("ExpireOn")]
        [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(SerializeExpireOn))]
        public DateTimeOffset? ExpireOn { get; set; }
    }
}
