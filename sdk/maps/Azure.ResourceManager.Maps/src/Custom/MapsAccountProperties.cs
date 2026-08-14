// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Maps.Models
{
    // Backward compat: AutoRest-generated SDK exposed CORS rules via a flattened property
    // named CorsRulesValue (from cors.corsRules). TypeSpec renamed it to CorsRules.
    // This shim preserves the old property name for existing callers.
    public partial class MapsAccountProperties
    {
        /// <summary>
        /// The list of CORS rules.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<MapsCorsRule> CorsRulesValue => CorsRules;
    }
}
