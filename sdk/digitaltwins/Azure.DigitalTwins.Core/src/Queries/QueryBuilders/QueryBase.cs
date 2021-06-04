// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.DigitalTwins.Core.QueryBuilder;

namespace Azure.DigitalTwins.Core.Queries.QueryBuilders
{
    /// <summary>
    ///
    /// </summary>
    public abstract class QueryBase
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public abstract AdtQueryBuilder Build();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public abstract string Stringify();
    }
}
