// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Storage.Tables.Models
{
    /// <summary> The properties for the table entity query response. </summary>
    public partial class TableEntityQueryResponse
    {
        /// <summary> The metadata response of the table. </summary>
        public string OdataMetadata { get; set; }
        /// <summary> List of table entities. </summary>
        public ICollection<IDictionary<string, object>> Value { get; set; }
    }
}
