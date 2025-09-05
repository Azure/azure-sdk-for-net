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

  update is ArmCustomPatchSync<Bar, Bar>;

  list is ArmResourceListByParent<Bar>;
}

@singleton("current")
@parentResource(Bar)
model BarSettingsResource is ProxyResource<BarSettingsProperties> {
  ...ResourceNameParameter<BarSettingsResource, SegmentName = "settings">;

  stringArray?: string[];
  property: BarQuotaProperties;
  anotherProperty: BarQuotaProperties;
}

@parentResource(Bar)
model BarQuotaResource is ProxyResource<BarQuotaProperties> {
  ...ResourceNameParameter<BarQuotaResource, SegmentName = "quotas", Type = QuotaName>;
}

model BarQuotaProperties {
  /** enabled */
  left: int32;
}

model BarSettingsProperties {
  /** enabled */
  @visibility(Lifecycle.Read)
  isEnabled?: boolean;
}

@doc("Available Playwright quota types.")
union QuotaName {
  string,

  @doc("Quota for execution duration in minutes.")
  ExecutionMinutes: "ExecutionMinutes",
}

@armResourceOperations
interface BarSettingsOperations {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<BarSettingsResource>;
  
  get is ArmResourceRead<BarSettingsResource>;
}

@armResourceOperations
interface BarQuotaOperations {
  get is ArmResourceRead<BarQuotaResource>;
  update is ArmCustomPatchAsync<BarQuotaResource, BarQuotaResource>;
}
