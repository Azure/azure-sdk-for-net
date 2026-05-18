// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// SA1402 is suppressed for this file: every type below is an intentionally
// identical safe-flatten ctor shim, bundled together for code-review clarity.
#pragma warning disable SA1402 // File may only contain a single type

// =============================================================================
// Back-compat shims for ARM "content" envelopes whose nested Properties model
// got safe-flattened by MPG.
//
// Each model below has the standard ARM envelope shape in the spec:
//     model XxxContent { properties: XxxProperties; }
// where XxxProperties contains exactly one (or only optional) public property.
// MPG's safe-flatten transform lifts that inner property up onto the parent
// (e.g. `XxxContent.<InnerProp>`), demotes `Properties` to internal, and emits
// only a parameterless `public XxxContent()` plus an internal
// `XxxContent(properties, bagOfUnknowns)` ctor.
//
// The legacy v1.x AutoRest SDK, by contrast, emitted a `public XxxContent(XxxProperties properties)`
// ctor. ApiCompat against the v1.x baseline therefore reports MembersMustExist
// for the missing ctor. Each shim below restores it by forwarding to the
// generated internal ctor with a null property bag.
//
// (Disabling safe-flatten via `@@clientOption(..., "disable-safe-flatten", true, "csharp")`
// is NOT a valid alternative here: legacy v1.x ALSO shipped the lifted/flat
// property name on the parent, so disabling flatten would break a different
// ApiCompat rule. Keeping safe-flatten and restoring the ctor is the only
// shape that matches the v1.x public surface on both axes.)
// =============================================================================

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class ClusterTestFailoverCleanupContent
    {
        /// <summary> Initializes a new instance of <see cref="ClusterTestFailoverCleanupContent"/>. </summary>
        /// <param name="properties"> Cluster test failover cleanup input properties. </param>
        public ClusterTestFailoverCleanupContent(ClusterTestFailoverCleanupContentProperties properties) : this(properties, additionalBinaryDataProperties: null) { }
    }
    public partial class MigrationItemResyncContent
    {
        /// <summary> Initializes a new instance of <see cref="MigrationItemResyncContent"/>. </summary>
        /// <param name="properties"> Resync input properties. </param>
        public MigrationItemResyncContent(MigrationItemResyncProperties properties) : this(properties, additionalBinaryDataProperties: null) { }
    }
    public partial class PauseReplicationContent
    {
        /// <summary> Initializes a new instance of <see cref="PauseReplicationContent"/>. </summary>
        /// <param name="properties"> Pause replication input properties. </param>
        public PauseReplicationContent(PauseReplicationProperties properties) : this(properties, additionalBinaryDataProperties: null) { }
    }
    public partial class RecoveryPlanTestFailoverCleanupContent
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryPlanTestFailoverCleanupContent"/>. </summary>
        /// <param name="properties"> Recovery plan test failover cleanup input properties. </param>
        public RecoveryPlanTestFailoverCleanupContent(RecoveryPlanTestFailoverCleanupProperties properties) : this(properties, additionalBinaryDataProperties: null) { }
    }
    public partial class ResumeReplicationContent
    {
        /// <summary> Initializes a new instance of <see cref="ResumeReplicationContent"/>. </summary>
        /// <param name="properties"> Resume replication input properties. </param>
        public ResumeReplicationContent(ResumeReplicationProperties properties) : this(properties, additionalBinaryDataProperties: null) { }
    }
    public partial class SiteRecoveryMigrateContent
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryMigrateContent"/>. </summary>
        /// <param name="properties"> Migrate input properties. </param>
        public SiteRecoveryMigrateContent(SiteRecoveryMigrateProperties properties) : this(properties, additionalBinaryDataProperties: null) { }
    }
    public partial class TestFailoverCleanupContent
    {
        /// <summary> Initializes a new instance of <see cref="TestFailoverCleanupContent"/>. </summary>
        /// <param name="properties"> Test failover cleanup input properties. </param>
        public TestFailoverCleanupContent(TestFailoverCleanupProperties properties) : this(properties, additionalBinaryDataProperties: null) { }
    }
    public partial class TestMigrateCleanupContent
    {
        /// <summary> Initializes a new instance of <see cref="TestMigrateCleanupContent"/>. </summary>
        /// <param name="properties"> Test migrate cleanup input properties. </param>
        public TestMigrateCleanupContent(TestMigrateCleanupProperties properties) : this(properties, additionalBinaryDataProperties: null) { }
    }
    public partial class TestMigrateContent
    {
        /// <summary> Initializes a new instance of <see cref="TestMigrateContent"/>. </summary>
        /// <param name="properties"> Test migrate input properties. </param>
        public TestMigrateContent(TestMigrateProperties properties) : this(properties, additionalBinaryDataProperties: null) { }
    }
}
