﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class MagnitudeScoringFunction
    {
        /// <summary> Initializes a new instance of MagnitudeScoringFunction. </summary>
        /// <param name="fieldName"> The name of the field used as input to the scoring function. </param>
        /// <param name="boost"> A multiplier for the raw score. Must be a positive number not equal to 1.0. </param>
        /// <param name="parameters"> Parameter values for the magnitude scoring function. </param>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> or <paramref name="parameters"/> is null.</exception>
        public MagnitudeScoringFunction(string fieldName, double boost, MagnitudeScoringParameters parameters) : base(fieldName, boost)
        {
            Argument.AssertNotNullOrEmpty(fieldName, nameof(fieldName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Type = "magnitude";
        }
    }
}
