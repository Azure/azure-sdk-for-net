import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

@resource("foos")
model Foo is TrackedResource<FooProperties> {
  ...ResourceNameParameter<Foo, SegmentName = "foos">;

  ...ExtendedLocationProperty;
}

@useSystemTextJsonConverter("csharp")
model FooProperties {
  /** the service url */
  serviceUrl?: url;

  /** something */
  something?: string;

  /** boolean value */
  boolValue?: boolean;

  /** float value */
  floatValue?: float32;

  /** double value */
  doubleValue?: float64;
}

@armResourceOperations
interface Foos {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Foo>;

  get is ArmResourceRead<Foo>;

  delete is ArmResourceDeleteWithoutOkAsync<Foo>;

  update is ArmCustomPatchAsync<Foo, Foo>;

  list is ArmResourceListByParent<Foo>;

  listBySubscription is ArmListBySubscription<Foo>;
}

@singleton
model FooSettings is ProxyResource<FooSettingsProperties> {
  @doc("The default Foo settings.")
  @segment("FooSettings")
  @key
  @visibility(Lifecycle.Read)
  @path
  @pattern("^[a-zA-Z0-9-]{3,24}$")
  name: string;
}

@armResourceOperations
interface FooSettingsOperations {
  get is ArmResourceRead<FooSettings>;
  createOrUpdate is ArmResourceCreateOrReplaceSync<FooSettings>;
  update is ArmCustomPatchSync<
    FooSettings,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<
      FooSettings,
      FooSettingsProperties
    >
  >;
  delete is ArmResourceDeleteSync<FooSettings>;
}

model FooSettingsProperties {
  accessControlEnabled?: boolean;

  @visibility(Lifecycle.Read)
  provisioningState?: ResourceProvisioningState;

  @visibility(Lifecycle.Read)
  metaData?: FooSettingsPropertiesMetaData;
}

model FooSettingsPropertiesMetaData {
  metaDatas?: string[];
}
