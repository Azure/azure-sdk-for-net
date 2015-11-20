// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Provides parameter values to a freshness scoring function.
    /// </summary>
    public class FreshnessScoringParameters
    {
        /// <summary>
        /// Initializes a new instance of the FreshnessScoringParameters class.
        /// </summary>
        public FreshnessScoringParameters() { }

        /// <summary>
        /// Initializes a new instance of the FreshnessScoringParameters class.
        /// </summary>
        public FreshnessScoringParameters(TimeSpan boostingDuration)
        {
            BoostingDuration = boostingDuration;
        }

        /// <summary>
        /// Gets or sets the expiration period after which boosting will stop
        /// for a particular document.
        /// </summary>
        [JsonProperty(PropertyName = "boostingDuration")]
        public TimeSpan BoostingDuration { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
        }
    }
}
