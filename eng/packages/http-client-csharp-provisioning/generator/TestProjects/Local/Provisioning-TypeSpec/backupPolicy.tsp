import "@azure-tools/typespec-azure-core";

using Azure.ResourceManager;
using Azure.Core;

namespace ProvisioningTypeSpec;

/** Base backup policy with discriminator. */
@discriminator("kind")
model BackupPolicy {
  /** The backup policy kind. */
  kind: string;

  /** The retention period in days. */
  retentionDays?: int32;

  // TODO: remove this extra property once the FlattenPropertyVisitor bug is fixed.
  // Without it, BackupPolicy gets flattened to internal because it has only one
  // non-discriminator property. See https://github.com/Azure/azure-sdk-for-net/issues/56708
  /** Whether the backup policy is enabled. */
  isEnabled?: boolean;
}

/** Periodic backup policy. */
model PeriodicBackupPolicy extends BackupPolicy {
  /** Periodic backup kind. */
  kind: "Periodic";

  /** The backup interval in hours. */
  intervalInHours: int32;
}

/** Continuous backup policy. */
model ContinuousBackupPolicy extends BackupPolicy {
  /** Continuous backup kind. */
  kind: "Continuous";

  /** The continuous backup tier. */
  tier?: string;
}
