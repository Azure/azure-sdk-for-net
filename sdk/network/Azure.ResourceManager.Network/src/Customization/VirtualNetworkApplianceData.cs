// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkApplianceData type. </summary>
    public partial class VirtualNetworkApplianceData
    {
        /// <summary> Gets or sets the bandwidth in gigabits per second as an invariant-culture string. </summary>
        /// <remarks> For numeric access, use <see cref="BandwidthGbps"/>. Setting this property to null clears the bandwidth. </remarks>
        /// <exception cref="FormatException"> The value is not a valid invariant-culture floating-point number. </exception>
        /// <exception cref="OverflowException"> The value is outside the supported range on frameworks that throw for floating-point overflow. </exception>
        public string BandwidthInGbps
        {
            // Preserve the released string API while reading and writing the generated numeric wire property.
            get => BandwidthGbps?.ToString("R", CultureInfo.InvariantCulture);
            set => BandwidthGbps = value is null
                ? (double?)null
                : double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
        }
    }
}
