// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// </summary>
    [Flags]
    public enum PropertyNameHandling
    {
        /// <summary>
        /// </summary>
        Strict = 0,

        /// <summary>
        /// </summary>
        AllowPascalCaseReads = 1,

        /// <summary>
        /// </summary>
        WriteNewCamelCase = 2,

        /// <summary>
        /// </summary>
        WriteExistingCamelCase = 4,

        /// <summary>
        /// </summary>
        WriteCamelCase = WriteNewCamelCase | WriteExistingCamelCase,
    }
}
