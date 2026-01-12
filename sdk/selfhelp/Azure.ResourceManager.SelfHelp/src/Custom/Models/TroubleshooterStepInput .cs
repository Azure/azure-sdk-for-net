// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.SelfHelp;

namespace Azure.ResourceManager.SelfHelp.Models
{
    /// <summary> Details of step input. </summary>
    public partial class TroubleshooterStepInput
    {
        /// <summary> Gets the ResponseOptions. </summary>
        public IReadOnlyList<ResponseConfig> ResponseOptions { get; }
    }
}
