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
        BOOL = 1,
        NUMBER = 2,
        STRING = 3,
        PRIMATIVE = 4,
        OBJECT = 5
    }
}
