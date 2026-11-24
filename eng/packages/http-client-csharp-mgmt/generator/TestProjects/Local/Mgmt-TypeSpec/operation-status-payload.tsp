import "./foo.tsp";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

/** A service-defined type whose name could collide with the generated common status error. */
enum OperationStatusError {
  Retryable,
}

/** Service error metadata renamed in a C# customization. */
model ServiceError {
  serviceCode: string;
}

/** Service metadata with a C# name matching an internal helper's simple name. */
model ServiceOptional {
  value: string;
}

/** An operation status with service-specific properties. */
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Exercise a service status derived from the ARM common schema"
model ExtendedOperationStatus extends Azure.ResourceManager.CommonTypes.OperationStatusResult {
  /** Additional operation properties. */
  properties?: Record<unknown>;

  /** A service-specific error classification. */
  classification?: OperationStatusError;

  /** Service error metadata. */
  serviceError?: ServiceError;

  /** Optional service metadata. */
  serviceOptional?: ServiceOptional;
}

@armResourceOperations
interface ExtendedOperationStatuses {
  @get
  @action("getExtendedOperationStatus")
  getExtendedOperationStatus is ArmResourceActionSync<Foo, void, ArmResponse<ExtendedOperationStatus>>;

  @action("submitExtendedOperationStatus")
  submitExtendedOperationStatus is ArmResourceActionSync<Foo, ExtendedOperationStatus, ArmResponse<ExtendedOperationStatus>>;
}
