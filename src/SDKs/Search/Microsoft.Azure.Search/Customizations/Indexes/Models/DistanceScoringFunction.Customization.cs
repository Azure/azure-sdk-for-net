// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;

    public partial class DistanceScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the DistanceScoringFunction class.
        /// </summary>
        public DistanceScoringFunction(
            string fieldName, 
            double boost, 
            string referencePointParameter, 
            double boostingDistance, 
            ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : this(
                fieldName, 
                boost, 
                new DistanceScoringParameters(referencePointParameter, boostingDistance), 
                interpolation) 
        {
            // Other constructor handles all initialization. 
        }
    }
}
