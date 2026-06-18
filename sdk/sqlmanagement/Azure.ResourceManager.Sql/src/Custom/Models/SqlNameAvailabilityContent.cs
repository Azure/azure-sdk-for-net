// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class SqlNameAvailabilityContent
    {
        /// <summary> Backward-compatible single-argument constructor; defaults to <see cref="SqlNameAvailabilityResourceType.MicrosoftSqlServers"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SqlNameAvailabilityContent(string name) : this(name, SqlNameAvailabilityResourceType.MicrosoftSqlServers)
        {
        }
    }
}
