// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Clause objects make up an entire query. There are four different kinds of clauses, SELECT, FROM, JOIN and WHERE.
    /// Each kind of clause takes in a different set of arguments and are implemented as children of a general clause class.
    /// </summary>
    internal abstract class BaseClause
    {
        /// <summary>
        /// The type of the given clause (out of SELECT, FROM, JOIN and WHERE).
        /// </summary>
        public string Type { get; set; }
    }
}
