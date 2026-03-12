// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Maps.Models;

namespace Azure.ResourceManager.Maps.Models
{
    public partial class MapsAccountPatch
    {
        /// <summary>
        /// The list of CORS rules.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<MapsCorsRule> CorsRulesValue => CorsRules;
    }
}
