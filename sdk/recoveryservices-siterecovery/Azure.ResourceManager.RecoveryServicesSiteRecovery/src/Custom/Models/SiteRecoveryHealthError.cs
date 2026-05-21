// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class SiteRecoveryHealthError
    {
        // Back-compat alias for an even-older legacy name that the v1.x AutoRest baseline
        // SDK kept around for its own back-compat. The v1.x baseline shipped BOTH:
        //   * `IReadOnlyList<SiteRecoveryInnerHealthError> InnerHealthErrors`  (primary)
        //   * `IList<SiteRecoveryInnerHealthError> SiteRecoveryInnerHealthErrorsList`  (legacy alias)
        // MPG regenerates the primary `InnerHealthErrors` automatically, but does not
        // know about the legacy alias. ApiCompat against the v1.x baseline therefore
        // reports MembersMustExist for `SiteRecoveryInnerHealthErrorsList`. This forwarder
        // restores it as a view over the same backing list (no extra storage). It is hidden
        // from IntelliSense since callers should prefer the primary `InnerHealthErrors`.
        /// <summary> The inner health errors. Back-compat alias exposing <see cref="InnerHealthErrors"/> as an <see cref="IList{T}"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<SiteRecoveryInnerHealthError> SiteRecoveryInnerHealthErrorsList => InnerHealthErrors as IList<SiteRecoveryInnerHealthError>;
    }
}
