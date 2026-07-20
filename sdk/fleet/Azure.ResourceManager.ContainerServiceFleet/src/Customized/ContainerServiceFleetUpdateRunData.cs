// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.ContainerServiceFleet.Models;

namespace Azure.ResourceManager.ContainerServiceFleet
{
    // Because of a breaking change, it was manually added back to ensure compatibility.
    public partial class ContainerServiceFleetUpdateRunData
    {
        // TODO -- fix the getter when https://github.com/Azure/azure-sdk-for-net/issues/56421 is resolved.
        /// <summary> The list of stages that compose this update run. Min size: 1. </summary>
        public IList<ContainerServiceFleetUpdateStage> StrategyStages
        {
            get => Properties is null ? default : Properties.StrategyStages;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                if (Properties is null)
                {
                    Properties = new UpdateRunProperties();
                }
                Properties.Strategy = new ContainerServiceFleetUpdateRunStrategy(value);
            }
        }
    }
}
