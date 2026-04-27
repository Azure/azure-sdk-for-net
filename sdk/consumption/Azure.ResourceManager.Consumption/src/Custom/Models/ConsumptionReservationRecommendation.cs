// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Consumption.Models
{
    // Custom default ctor: the spec model uses `...Foundations.Resource` (spread, not extends),
    // so the MPG generator emits Tags as IDictionary<string,string> on the type but does not
    // initialize it in the parameterless constructor. Initialize it here so callers that
    // construct via the protected ctor (e.g. mocking, deserializers) get a non-null Tags collection.
    public abstract partial class ConsumptionReservationRecommendation
    {
        /// <summary> Initializes a new instance of <see cref="ConsumptionReservationRecommendation"/>. </summary>
        protected ConsumptionReservationRecommendation()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }
    }
}
