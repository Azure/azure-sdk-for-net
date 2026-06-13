// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Consumption.Models
{
    // The shipped v1.x surface declared ConsumptionChargeSummary with a public parameterless protected ctor.
    // The MPG generator only emits a (long) protected ctor for this discriminator base, so we declare
    // an empty protected ctor here to preserve the shipped API for derived-type construction (mocking).
    public abstract partial class ConsumptionChargeSummary
    {
        /// <summary> Initializes a new instance of <see cref="ConsumptionChargeSummary"/>. </summary>
        protected ConsumptionChargeSummary()
        {
        }
    }
}
