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
model Foo is TrackedResource<FooProperties, false> {
  ...ResourceNameParameter<Foo, SegmentName = "foos">;

  ...ExtendedLocationProperty;

  #suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Existing usage of legacy type"
  ...Azure.ResourceManager.Legacy.ManagedServiceIdentityV4Property;

  ...ResourcePlanProperty;
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

  optionalProperty?: SafeFlattenModel;

  /** Test ApplicationProfile flattening scenario */
  vmProfile?: VmProfile;

  /** ETag property for testing etag parameter name generation */
  etag?: Azure.Core.eTag;

  /** WritableSubResource property for testing WritableSubResource type replacement */
  writableSubResourceProp?: WritableSubResourceProp;

  /** Test case for multi-layer safe flatten */
  computeFleetVmProfile?: ComputeFleetVmProfile;
}

model WritableSubResourceProp {
}

model NestedFooModel {
  properties: FooProperties;
}

model SafeFlattenModel {
  flattenedProperty?: string[];
}

// Test case for ApplicationProfile -> GalleryApplications flattening
// This tests that when a suffix (Profile) is stripped, singular/plural matching works correctly
model ApplicationProfile {
  /** Specifies the gallery applications that should be made available */
  galleryApplications?: string[];
}

model VmProfile {
  /** Application profile */
  applicationProfile?: ApplicationProfile;
}

// Test case for multi-layer safe flatten with internal properties
// This should flatten CapacityReservationGroupId all the way up to ComputeFleetVmProfile
model TestSubResource {
  id?: armResourceIdentifier;
}

model CapacityReservationProfile {
  capacityReservationGroup?: TestSubResource;
}

model ComputeFleetVmProfile {
  capacityReservation?: CapacityReservationProfile;
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

  @get
  @action("listDependencies")
  listDependencies is ArmResourceActionSync<
    Foo,
    void,
    ArmResponse<FooDependency[]>
  >;
}

model FooActionRequest {
  id: string;
}

model FooActionResult {
  msg: string;
  error?: Azure.ResourceManager.Foundations.ErrorDetail;
}

model FooDependency {
  dependencyName: string;
  version?: string;
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
