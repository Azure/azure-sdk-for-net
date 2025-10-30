import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-liftr-base";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;
using Azure.Core;
using LiftrBase;

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
  something: string;

  /** boolean value */
  boolValue?: boolean;

  /** float value */
  floatValue?: float32;

  /** double value */
  doubleValue?: float64;

  prop1: string[];
  prop2?: int32[];

  nestedProperty: NestedFooModel;

  /** ETag property for testing etag parameter name generation */
  etag?: Azure.Core.eTag;
}

model NestedFooModel {
  properties: FooProperties;
}

@armResourceOperations
interface Foos {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Foo>;

  get is ArmResourceRead<Foo>;

  delete is ArmResourceDeleteWithoutOkAsync<Foo>;

  list is ArmResourceListByParent<Foo>;

  listBySubscription is ArmListBySubscription<Foo>;

  @action("exportDependencies")
  fooAction is ArmResourceActionAsync<
    Foo,
    FooActionRequest,
    FooActionResult,
    LroHeaders = ArmAsyncOperationHeader<FinalResult = FooActionResult> &
      ArmLroLocationHeader<FinalResult = FooActionResult> &
      Azure.Core.Foundations.RetryAfterHeader
  >;
}

model FooActionRequest {
  id: string;
}

model FooActionResult {
  msg: string;
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

model FooSettingsProperties is BaseResourceProperties {
  accessControlEnabled?: boolean;

  @visibility(Lifecycle.Read)
  metaData?: FooSettingsPropertiesMetaData;
}

model FooSettingsPropertiesMetaData {
  metaDatas?: string[];
}
