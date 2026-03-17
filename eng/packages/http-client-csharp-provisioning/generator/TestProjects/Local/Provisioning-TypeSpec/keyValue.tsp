import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.Core;

namespace ProvisioningTypeSpec;

/** A key-value pair in a configuration store. */
@parentResource(ConfigurationStore)
@resource("keyValues")
model KeyValue is ProxyResource<KeyValueProperties> {
  ...ResourceNameParameter<KeyValue, SegmentName = "keyValues">;
}

/** The properties of a key-value. */
model KeyValueProperties {
  /** The value of the key-value. */
  value?: string;

  /** The content type of the key-value. */
  contentType?: string;
}

@armResourceOperations
interface KeyValues {
  createOrUpdate is ArmResourceCreateOrUpdateSync<KeyValue>;
  get is ArmResourceRead<KeyValue>;
  delete is ArmResourceDeleteSync<KeyValue>;
  list is ArmResourceListByParent<KeyValue>;
}
