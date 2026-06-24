// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class SqlNameAvailabilityContent
    {
        // Backward-compatible single-argument constructor
        /// <summary> Initializes a new instance of <see cref="SqlNameAvailabilityContent"/>. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SqlNameAvailabilityContent(string name) : this(name, SqlNameAvailabilityResourceType.MicrosoftSqlServers)
        {
        }
    }
}
