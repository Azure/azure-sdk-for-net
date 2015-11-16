// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class DistanceScoringFunction : ScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the DistanceScoringFunction class
        /// with required arguments.
        /// </summary>
        public DistanceScoringFunction(DistanceScoringParameters parameters, string fieldName, double boost)
            : this()
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (fieldName == null)
            {
                throw new ArgumentNullException("fieldName");
            }
            
            this.Distance = parameters;
            this.FieldName = fieldName;
            this.Boost = boost;
        }

        /// <summary>
        /// Gets parameter values for the distance scoring function.
        /// </summary>
        [JsonIgnore]
        public DistanceScoringParameters Parameters 
        {
            get { return this.Distance; }
        }
    }
}
