import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.Core;

namespace ProvisioningTypeSpec;

/** A resource that exercises BinaryData provisioning properties. */
@resource("binaryDataResources")
model BinaryDataResource is TrackedResource<BinaryDataResourceProperties> {
  ...ResourceNameParameter<
    BinaryDataResource,
    SegmentName = "binaryDataResources"
  >;
}

/** Properties containing both base64 bytes and arbitrary JSON data. */
model BinaryDataResourceProperties {
  /** Byte-oriented content that must be serialized as a base64 string. */
  content: bytes;

  /** Arbitrary JSON content that should keep JSON literal semantics. */
  metadata?: unknown;
}

@armResourceOperations
interface BinaryDataResources {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<BinaryDataResource>;

  get is ArmResourceRead<BinaryDataResource>;

  delete is ArmResourceDeleteWithoutOkAsync<BinaryDataResource>;
}
