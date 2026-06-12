// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> An alert rule resource data. </summary>
    [Obsolete("This API is no longer supported.", false)]
    public partial class AlertRuleData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="AlertRuleData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="alertRuleName"> The name of the alert rule. </param>
        /// <param name="isEnabled"> Whether the alert rule is enabled. </param>
        /// <param name="condition"> The condition that results in the alert rule being activated. </param>
        public AlertRuleData(AzureLocation location, string alertRuleName, bool isEnabled, BinaryData condition) : base() => throw new NotSupportedException("This API is no longer supported.");
    }
}
