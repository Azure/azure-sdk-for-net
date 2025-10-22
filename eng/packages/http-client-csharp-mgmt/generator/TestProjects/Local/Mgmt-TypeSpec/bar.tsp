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
  flattenedNestedProperty: BarNestedQuotaProperties;
  optionalFlattenProperty?: optionalFlattenPropertyType;
  discriminatorProperty: LimitJsonObject;
}

@parentResource(Bar)
model BarQuotaResource is ProxyResource<BarQuotaProperties> {
  ...ResourceNameParameter<BarQuotaResource, SegmentName = "quotas", Type = QuotaName>;
}

model BarNestedQuotaProperties extends BarMiddleNestedQuotaProperties {
  prop1: string[];
  prop2: int32;
}

model BarMiddleNestedQuotaProperties extends BarDeeplyNestedQuotaProperties {
  middleProp1: int32;
  middleProp2: Record<string>;
}

model optionalFlattenPropertyType {
  randomCollectionProp: string[];
}

model BarDeeplyNestedQuotaProperties {
  innerProp1?: int32;
  innerProp2: string;
}

/**
 * LimitJson abstract class.
 */
@discriminator("limitObjectType")
model LimitJsonObject {
  /**
   * The limit object type.
   */
  limitObjectType: LimitType;
}

/**
 * The limit object type.
 */
union LimitType {
  string,
  #suppress "@azure-tools/typespec-azure-core/documentation-required" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  LimitValue: "LimitValue",
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
