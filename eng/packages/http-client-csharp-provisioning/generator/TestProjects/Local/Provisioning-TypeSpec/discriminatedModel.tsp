import "@azure-tools/typespec-azure-core";

using Azure.ResourceManager;
using Azure.Core;

namespace ProvisioningTypeSpec;

/** The backup policy kind. */
enum BackupPolicyKind {
  /** A periodic backup policy. */
  Periodic,

  /** A continuous backup policy. */
  Continuous,
}

/** Base backup policy with discriminator. */
@discriminator("kind")
model BackupPolicy {
  /** The backup policy kind. */
  kind: BackupPolicyKind;

  /** The retention period in days. */
  retentionDays?: int32;

  /** Whether the backup policy is enabled. */
  isEnabled?: boolean;
}

/** Periodic backup policy. */
model PeriodicBackupPolicy extends BackupPolicy {
  /** Periodic backup kind. */
  kind: BackupPolicyKind.Periodic;

  /** The backup interval in hours. */
  intervalInHours: int32;
}

/** Continuous backup policy. */
model ContinuousBackupPolicy extends BackupPolicy {
  /** Continuous backup kind. */
  kind: BackupPolicyKind.Continuous;

  /** The continuous backup tier. */
  tier?: string;
}

/** Base backup policy with a string discriminator. */
@discriminator("strategy")
model StringDiscriminatedBackupPolicy {
  /** The backup strategy. */
  strategy: string;
}

/** Manual backup policy. */
model ManualBackupPolicy extends StringDiscriminatedBackupPolicy {
  /** Manual backup strategy. */
  strategy: "manual";
}
