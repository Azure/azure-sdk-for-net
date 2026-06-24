// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the SubscriptionNetworkManagerConnectionResource type. </summary>
    [CodeGenSuppress("Data")]
    public partial class SubscriptionNetworkManagerConnectionResource
    {
        /// <summary> Gets or sets the Data compatibility property. </summary>
        public virtual NetworkManagerConnectionData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }

                return new NetworkManagerConnectionData();
            }
        }
    }
}
