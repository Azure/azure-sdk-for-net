// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Collections that can be queried.
    /// </summary>
    public enum ADTCollection
    {
        /// <summary>
        /// ADT instance.
        /// </summary>
        DigitalTwins = 0,

        /// <summary>
        /// Relationships in an ADT instance.
        /// </summary>
        Relationship = 1,
    }
}
