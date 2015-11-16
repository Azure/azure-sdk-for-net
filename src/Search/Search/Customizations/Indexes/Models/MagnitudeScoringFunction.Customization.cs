// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class MagnitudeScoringFunction : ScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the MagnitudeScoringFunction class
        /// with required arguments.
        /// </summary>
        public MagnitudeScoringFunction(MagnitudeScoringParameters parameters, string fieldName, double boost)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (fieldName == null)
            {
                throw new ArgumentNullException("fieldName");
            }

            this.Parameters = parameters;
            this.FieldName = fieldName;
            this.Boost = boost;
        }

        /// <summary>
        /// Gets parameter values for the magnitude scoring function.
        /// </summary>
        [JsonIgnore]
        public MagnitudeScoringParameters Parameters
        {
            get { return this.Magnitude; }
            set { this.Magnitude = value; }
        }
    }
}
