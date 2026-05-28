// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class FunctionAppAlwaysReadyConfig
    {
        /// <summary> Sets the number of 'Always Ready' instances for a given function group or a specific function. For additional information see https://aka.ms/flexconsumption/alwaysready. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("instanceCount")]
        public float? InstanceCount
        {
            get => AlwaysReadyInstanceCount.Value;
            set => AlwaysReadyInstanceCount = (int?)value;
        }
    }
}