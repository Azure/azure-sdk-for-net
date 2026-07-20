// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class SiteRecoveryHealthError
    {
        // v1.x get-only IReadOnlyList<> view of the `SiteRecoveryInnerHealthErrorsList` primary.
        /// <summary> The inner health errors. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<SiteRecoveryInnerHealthError> InnerHealthErrors => (IReadOnlyList<SiteRecoveryInnerHealthError>)SiteRecoveryInnerHealthErrorsList;
    }
}
