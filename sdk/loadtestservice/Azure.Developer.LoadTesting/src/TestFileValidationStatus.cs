// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Developer.LoadTesting
{
    /// <summary>
    /// enum to hold Test File ValidationStatus
    /// </summary>
    public enum TestFileValidationStatus
    {
        /// <summary>
        /// enum to denote Validation Initiated
        /// </summary>
        ValidationInitiated,

        /// <summary>
        /// enum to denote Validation Succes
        /// </summary>
        ValidationSuccess,

        /// <summary>
        /// enum to denote Validation Failed
        /// </summary>
        ValidationFailed,

        /// <summary>
        /// enum to denote Validation Check Timeout
        /// </summary>
        ValidationCheckTimeout
    }
}
