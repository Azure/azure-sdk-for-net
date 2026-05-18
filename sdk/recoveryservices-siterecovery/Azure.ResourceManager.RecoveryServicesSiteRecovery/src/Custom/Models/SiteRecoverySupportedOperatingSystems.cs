// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    // Back-compat: v1.x AutoRest baseline shipped this property as IReadOnlyList<T>:
    //     public IReadOnlyList<SiteRecoverySupportedOSProperty> SupportedOSList { get; }
    // MPG's natural emit for the TypeSpec property `SupportedOSProperties.supportedOsList`
    // is `public IList<SiteRecoverySupportedOSProperty> SupportedOSList { get; }`. Same
    // name but a different collection interface — ApiCompat rejects this as a signature
    // change (CannotChangeMemberSignature).
    //
    // Fix: suppress the generated `SupportedOSList` on this flattened resource model and
    // re-emit it with the correct IReadOnlyList<T> type. The underlying storage on
    // `SupportedOSProperties.SupportedOSList` (still IList<T>) is unchanged — we just
    // expose a read-only view at this level to match the v1.x signature.
    [CodeGenSuppress("SupportedOSList")]
    public partial class SiteRecoverySupportedOperatingSystems
    {
        /// <summary> The supported operating systems property list. </summary>
        public IReadOnlyList<SiteRecoverySupportedOSProperty> SupportedOSList
            => Properties is null ? default : (IReadOnlyList<SiteRecoverySupportedOSProperty>)Properties.SupportedOSList;
    }
}
