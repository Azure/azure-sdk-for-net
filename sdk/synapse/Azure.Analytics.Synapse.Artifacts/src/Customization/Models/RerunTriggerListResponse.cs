﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> A list of rerun triggers. </summary>
    public partial class RerunTriggerListResponse
    {
        /// <summary> Initializes a new instance of RerunTriggerListResponse. </summary>
        /// <param name="value"> List of rerun triggers. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RerunTriggerListResponse(IEnumerable<RerunTriggerResource> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value.ToList();
        }
    }
}
