import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

/** A public constructor overload must not suppress the safe-flattened generated constructor. */
@usage(Usage.input | Usage.output | Usage.json)
model CtorBugLinuxProfile {
  adminUsername: string;
  ssh: CtorBugSshConfiguration;
}

/** Control model without a custom constructor. */
@usage(Usage.input | Usage.output | Usage.json)
model CtorBugLinuxProfileControl {
  adminUsername: string;
  ssh: CtorBugSshConfiguration;
}

model CtorBugSshConfiguration {
  publicKeys: CtorBugSshPublicKey[];
}

model CtorBugSshPublicKey {
  keyData: string;
}
