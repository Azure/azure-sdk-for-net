// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;

    public partial class MagnitudeScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the MagnitudeScoringFunction class.
        /// </summary>
        public MagnitudeScoringFunction(
            string fieldName, 
            double boost, 
            double boostingRangeStart, 
            double boostingRangeEnd, 
            bool? shouldBoostBeyondRangeByConstant = default(bool?), 
            ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : this(
                fieldName, 
                boost, 
                new MagnitudeScoringParameters(boostingRangeStart, boostingRangeEnd, shouldBoostBeyondRangeByConstant), 
                interpolation)
        {
            // Initialization done by the other constructor.
        }
    }
}
