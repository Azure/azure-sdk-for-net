// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Maps.Models
{
    /// <summary> Parameters used to update an existing Maps Account. </summary>
    public partial class MapsAccountPatch
    {
        /// <summary>
        /// The list of CORS rules.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<MapsCorsRule> CorsRulesValue => CorsRules;
    }
}
