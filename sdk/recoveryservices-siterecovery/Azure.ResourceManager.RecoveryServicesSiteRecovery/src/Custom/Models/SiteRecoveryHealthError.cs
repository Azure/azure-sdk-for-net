// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class SiteRecoveryHealthError
    {
        /// <summary> The inner health errors. Back-compat alias exposing <see cref="InnerHealthErrors"/> as an <see cref="IList{T}"/>. </summary>
        public IList<SiteRecoveryInnerHealthError> SiteRecoveryInnerHealthErrorsList => InnerHealthErrors as IList<SiteRecoveryInnerHealthError>;
    }
}
