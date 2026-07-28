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
