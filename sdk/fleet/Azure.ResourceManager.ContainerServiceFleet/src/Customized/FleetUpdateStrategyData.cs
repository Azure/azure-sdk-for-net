// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.ContainerServiceFleet.Models;

namespace Azure.ResourceManager.ContainerServiceFleet
{
    // Because of a breaking change, it was manually added back to ensure compatibility.
    public partial class FleetUpdateStrategyData
    {
        /// <summary> The list of stages that compose this update run. Min size: 1. </summary>
        public IList<ContainerServiceFleetUpdateStage> StrategyStages
        {
            get => Properties is null ? default : Properties.Strategy.Stages;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties = new FleetUpdateStrategyProperties { Strategy = new ContainerServiceFleetUpdateRunStrategy(value)  };
        }
    }
}
