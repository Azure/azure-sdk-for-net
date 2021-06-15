// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-operators#contains-operators">Contains operators</see> in the ADT Query language.
    /// </summary>
    public enum QueryContainOperator
    {
        /// <summary>
        /// IN operator defined by the ADT query language.
        /// </summary>
        IN = 1,

        /// <summary>
        /// NIN (not in) operator defined by the ADT query language
        /// </summary>
        NIN = 2
    }
}
