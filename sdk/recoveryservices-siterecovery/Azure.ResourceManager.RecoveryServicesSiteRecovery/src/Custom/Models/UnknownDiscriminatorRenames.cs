// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// SA1402 is suppressed for this file: every type below is an intentionally
// identical [CodeGenType] rename shim, bundled together for code-review clarity.
#pragma warning disable SA1402 // File may only contain a single type

// =============================================================================
// Back-compat shims for generator-synthesized "Unknown*" discriminator subclasses.
//
// For every abstract @discriminator base, MTG synthesizes an internal subclass
// named `Unknown{cleanBaseName}` to represent unrecognized discriminator values
// during deserialization (e.g. base `SiteRecoveryJobDetails` -> generated
// `UnknownSiteRecoveryJobDetails`). The synthesized name is hard-coded in the
// generator (InputModelType.cs) and there is no spec-level hook to rename it.
//
// In the v1.x AutoRest baseline these subclasses were generated under shorter
// names that did NOT carry the `SiteRecovery` prefix (e.g. `UnknownJobDetails`).
// Although these classes are `internal`, their type literal appears in the
// public `[PersistableModelProxy(typeof(Unknown...))]` attribute on the
// corresponding public discriminator base, which makes the typeof part of the
// public contract. Renaming the synthesized name breaks ApiCompat with a
// `CannotChangeAttribute` error on the public base.
//
// Each shim below uses `[CodeGenType("<generated name>")]` to rename the
// generator's synthesized class back to the v1.x baseline name, restoring the
// attribute literal exactly. The shims are bundled in one file because the
// pattern is identical; only the name pair varies.
// =============================================================================

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    [CodeGenType("UnknownSiteRecoveryAddDisksProviderSpecificContent")]
    internal partial class UnknownAddDisksProviderSpecificContent { }
    [CodeGenType("UnknownSiteRecoveryApplianceSpecificDetails")]
    internal partial class UnknownApplianceSpecificDetails { }
    [CodeGenType("UnknownSiteRecoveryApplyRecoveryPointProviderSpecificContent")]
    internal partial class UnknownApplyRecoveryPointProviderSpecificContent { }
    [CodeGenType("UnknownSiteRecoveryReplicationProviderSettings")]
    internal partial class UnknownConfigurationSettings { }
    [CodeGenType("UnknownSiteRecoveryCreateProtectionIntentProviderDetail")]
    internal partial class UnknownCreateProtectionIntentProviderSpecificDetails { }
    [CodeGenType("UnknownSiteRecoveryEventProviderSpecificDetails")]
    internal partial class UnknownEventProviderSpecificDetails { }
    [CodeGenType("UnknownSiteRecoveryEventSpecificDetails")]
    internal partial class UnknownEventSpecificDetails { }
    [CodeGenType("UnknownSiteRecoveryGroupTaskDetails")]
    internal partial class UnknownGroupTaskDetails { }
    [CodeGenType("UnknownSiteRecoveryJobDetails")]
    internal partial class UnknownJobDetails { }
    [CodeGenType("UnknownSiteRecoveryTaskTypeDetails")]
    internal partial class UnknownTaskTypeDetails { }
}
