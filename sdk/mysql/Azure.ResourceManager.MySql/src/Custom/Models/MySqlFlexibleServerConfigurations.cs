// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    /// <summary> The response of a Configuration list operation. </summary>
    public partial class MySqlFlexibleServerConfigurations
    {
        /// <summary> The Configuration items on this page. </summary>
        [CodeGenMember("Value")]
        public IReadOnlyList<MySqlFlexibleServerConfigurationData> Values { get; }
    }
}
