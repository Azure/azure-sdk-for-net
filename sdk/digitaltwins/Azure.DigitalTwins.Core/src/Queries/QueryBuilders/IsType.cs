// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Enum for the 5 types for the IS_TYPE function. Meant to be used with IsCondition if IS functions are not implemented as WHERE methods.
    /// </summary>
    public enum IsType
    {
        /// <summary>
        /// Boolean type.
        /// </summary>
        BOOL = 1,

        /// <summary>
        /// Number type.
        /// </summary>
        NUMBER = 2,

        /// <summary>
        /// String type.
        /// </summary>
        STR = 3,

        /// <summary>
        /// Primative type.
        /// </summary>
        PRIMATIVE = 4,

        /// <summary>
        /// Object in ADT query langauge.
        /// </summary>
        OBJ = 5
    }
}
