import "@azure-tools/typespec-client-generator-core";
import "./foo.tsp";

using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

@resource("bars")
@parentResource(Foo)
model Bar is TrackedResource<BarProperties> {
  ...ResourceNameParameter<Bar, SegmentName = "bars">;
}

model BarProperties {
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
interface Bars {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Bar>;

  get is ArmResourceRead<Bar>;

  delete is ArmResourceDeleteWithoutOkAsync<Bar>;

  update is ArmCustomPatchAsync<Bar, Bar>;

  list is ArmResourceListByParent<Bar>;
}

@singleton("current")
@parentResource(Bar)
model BarSettings is ProxyResource<BarSettingsProperties> {
  ...ResourceNameParameter<BarSettings, SegmentName = "settings">;
}

model BarSettingsProperties {
  /** enabled */
  isEnabled?: boolean;
}

@armResourceOperations
interface BarSettingsOperations {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<BarSettings>;
  
  get is ArmResourceRead<BarSettings>;
}
