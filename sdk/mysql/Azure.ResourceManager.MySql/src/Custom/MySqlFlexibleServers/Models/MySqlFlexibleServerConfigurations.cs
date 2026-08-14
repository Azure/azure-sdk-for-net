// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    public partial class MySqlFlexibleServerConfigurations
    {
        /// <summary> The Configuration items on this page. </summary>
        public IReadOnlyList<MySqlFlexibleServerConfigurationData> Values { get => Value.ToList(); }
    }
}
