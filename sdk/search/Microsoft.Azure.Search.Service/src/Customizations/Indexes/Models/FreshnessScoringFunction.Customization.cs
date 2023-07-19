// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Microsoft.Rest;
    using Newtonsoft.Json;

    public partial class FreshnessScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the FreshnessScoringFunction class.
        /// </summary>
        public FreshnessScoringFunction(
            string fieldName, 
            double boost, 
            TimeSpan boostingDuration, 
            ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : this(fieldName, boost, new FreshnessScoringParameters(boostingDuration), interpolation)
        {
            // Initialization done by other constructor.
        }
    }
}
