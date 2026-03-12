import "@azure-tools/typespec-azure-core";
import "./foo.tsp";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.Core;

namespace MgmtTypeSpec;

/**
 * Test case for safe-flatten with a custom constructor.
 * Reproduces issue https://github.com/Azure/azure-sdk-for-net/issues/57016
 *
 * ContainerServiceSshConfiguration has a single public property, so it
 * will be safe-flattened in ContainerServiceLinuxProfile. The generated
 * public constructor should use the flattened parameter (IList<ContainerServiceSshPublicKey>).
 * When a custom constructor is added with the original (unflattened) parameter type
 * (ContainerServiceSshConfiguration), the generated flattened constructor should NOT
 * be removed.
 */

model ContainerServiceSshPublicKey {
  /** SSH public key certificate data. */
  keyData: string;
}

/** SSH configuration for Linux-based VMs running on Azure. */
model ContainerServiceSshConfiguration {
  /** The list of SSH public keys used to authenticate with Linux-based VMs. */
  @identifiers(#[])
  publicKeys: ContainerServiceSshPublicKey[];
}

/** Profile for Linux VMs in the container service cluster. */
model ContainerServiceLinuxProfile {
  /** The administrator username to use for Linux VMs. */
  @pattern("^[A-Za-z][-A-Za-z0-9_]*$")
  adminUsername: string;

  /** The SSH configuration for Linux-based VMs running on Azure. */
  ssh: ContainerServiceSshConfiguration;
}

@resource("safeFlattenCtor")
@parentResource(Foo)
model SafeFlattenCtorTest is ProxyResource<ContainerServiceLinuxProfile> {
  ...ResourceNameParameter<SafeFlattenCtorTest, SegmentName = "safeFlattenCtor">;
}

@armResourceOperations
interface SafeFlattenCtorOps {
  get is ArmResourceRead<SafeFlattenCtorTest>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<SafeFlattenCtorTest>;
}
