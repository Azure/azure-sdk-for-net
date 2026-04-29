// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class PostgreSqlFlexibleServerNameAvailabilityContent
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The name of the resource for which availability needs to be checked. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlFlexibleServerNameAvailabilityContent(string name) : this()
        {
            Name = name;
        }
    }
}
