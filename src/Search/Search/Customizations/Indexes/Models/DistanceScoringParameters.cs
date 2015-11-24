// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;

    /// <summary>
    /// Provides parameter values to a distance scoring function.
    /// </summary>
    public class DistanceScoringParameters
    {
        /// <summary>
        /// Initializes a new instance of the DistanceScoringParameters class.
        /// </summary>
        public DistanceScoringParameters() { }

        /// <summary>
        /// Initializes a new instance of the DistanceScoringParameters class.
        /// </summary>
        public DistanceScoringParameters(string referencePointParameter, double boostingDistance)
        {
            ReferencePointParameter = referencePointParameter;
            BoostingDistance = boostingDistance;
        }

        /// <summary>
        /// Gets or sets the name of the parameter passed in search queries to
        /// specify the reference location.
        /// </summary>
        [JsonProperty(PropertyName = "referencePointParameter")]
        public string ReferencePointParameter { get; set; }

        /// <summary>
        /// Gets or sets the distance in kilometers from the reference
        /// location where the boosting range ends.
        /// </summary>
        [JsonProperty(PropertyName = "boostingDistance")]
        public double BoostingDistance { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (ReferencePointParameter == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ReferencePointParameter");
            }
        }
    }
}
