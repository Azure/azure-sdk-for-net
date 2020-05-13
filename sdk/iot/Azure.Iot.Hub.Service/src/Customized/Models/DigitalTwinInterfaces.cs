// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Iot.Hub.Service.Models
{
    /// <summary>
    /// The DigitalTwinInterfaces.
    /// </summary>
    public partial class DigitalTwinInterfaces
    {
        /// <summary>
        /// Interface(s) data on the digital twin.
        /// </summary>
        internal IReadOnlyDictionary<string, PnpInterface> Interfaces { get; }
    }
}
