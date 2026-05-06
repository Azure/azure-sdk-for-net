// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: Overrides for properties whose types differ from old API.
// - Type (string → ResourceType?)
// - IsRestoring (add setter)
// - DataStoreResourceId (IReadOnlyList<string> → IReadOnlyList<ResourceIdentifier>)
//
// Per PR review (deferred — needs spec update + regen, both currently blocked):
//
// 1. ResourceType: spec should @@alternateType `type` from string → Azure.Core.armResourceType
//    so the generator emits `ResourceType?` natively. The wrapper here would then become
//    redundant and can be deleted. TODO: file/track via the same regen-cleanup follow-up.
//
// 2. IsRestoring: the no-op setter exists because v1.15 GA exposed a settable property
//    even though the field is read-only on the service side. The right fix is to add
//    @visibility(Lifecycle.Read) on the spec property and drop the setter here. We have
//    not yet verified whether the spec already marks `isRestoring` read-only (which would
//    explain why the generated property has no setter). TODO: investigate and either
//    drop the no-op setter (if @visibility is in place) or add @visibility to the spec.
//
// 3. DataStoreResourceId: spec should @@alternateType the list element from string →
//    Azure.Core.armResourceIdentifier so the generator emits IReadOnlyList<ResourceIdentifier>
//    natively. The wrapper here would then become redundant and can be deleted.
//
// All three cleanups are deferred to a follow-up regen pass to keep this PR focused on
// review feedback; the spec changes are straightforward but each requires regeneration
// and surface re-validation.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeGroupVolume
    {
        /// <summary> Resource type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceType? ResourceType => Type != null ? new ResourceType(Type) : null;

        /// <summary> Restoring. </summary>
        public bool? IsRestoring
        {
            get => Properties is null ? default : Properties.IsRestoring;
            set { /* setter kept for backward compat; value is read-only from service */ }
        }

        /// <summary> Data store resource unique identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ResourceIdentifier> DataStoreResourceId
        {
            get
            {
                if (Properties is null)
                    return null;
                var ids = Properties.DataStoreResourceId;
                if (ids is null)
                    return null;
                return ids.Select(s => new ResourceIdentifier(s)).ToList().AsReadOnly();
            }
        }
    }
}
