// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Maps.Models
{
    /// <summary>
    /// Backward compatibility shim: the AutoRest-generated SDK exposed CORS rules via a
    /// flattened property named CorsRulesValue (from cors.corsRules). The TypeSpec migration
    /// renamed it to CorsRules. This shim preserves the old property name for existing callers.
    /// </summary>
    public partial class MapsAccountPatch
    {
        /// <summary>
        /// The list of CORS rules.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<MapsCorsRule> CorsRulesValue => CorsRules;
    }
}
