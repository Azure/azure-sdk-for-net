// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    [CodeGenModel("QueryResult")]
    internal partial class QueryResult
    {
        // This class declaration makes the generated class of the same name use IReadOnlyList<string> instead of IReadOnlyList<object>,
        // makes the class internal,  and changes the namespace; do not remove.

        /// <summary> The query results. </summary>
        internal IReadOnlyList<string> Items { get; }
    }
}
