// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Enum for the two types of WITH functions. Meant to be used with StartsWithEndsWithCondition if not implementing the literal WITH functions as WHERE methods.
    /// </summary>
    public enum WithType
    {
        /// <summary>
        /// STARTSWITH function in ADT query lang.
        /// </summary>
        STARTSWTIH = 1,

        /// <summary>
        /// ENDSWITH function in ADT query lang.
        /// </summary>
        ENDSWITH = 2
    }
}
