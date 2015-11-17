// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class FreshnessScoringFunction : ScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the FreshnessScoringFunction class
        /// with required arguments.
        /// </summary>
        public FreshnessScoringFunction(FreshnessScoringParameters parameters, string fieldName, double boost)
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

            this.Freshness = parameters;
            this.FieldName = fieldName;
            this.Boost = boost;
        }

        /// <summary>
        /// Gets parameter values for the freshness scoring function.
        /// </summary>
        [JsonIgnore]
        public FreshnessScoringParameters Parameters 
        {
            get { return this.Freshness; }
        }
    }
}
