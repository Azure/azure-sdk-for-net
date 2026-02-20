// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Elastic.Models
{
    /// <summary> Definition of the properties for a TagRules resource. </summary>
    public partial class ElasticTagRuleProperties
    {
        /// <summary> Provisioning state of the monitoring tag rules. </summary>
        public ElasticProvisioningState? ProvisioningState { get; set; }
    }
}
