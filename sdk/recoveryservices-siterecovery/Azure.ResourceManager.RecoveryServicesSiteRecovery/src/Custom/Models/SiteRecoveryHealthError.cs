// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    /// <summary> Health Error. </summary>
    public partial class SiteRecoveryHealthError
    {
        /// <summary> The disk level operations list. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<SiteRecoveryInnerHealthError> InnerHealthErrors { get; }
    }
}
