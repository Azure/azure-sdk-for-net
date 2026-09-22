import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-client-generator-core";
import "@typespec/http-client-csharp";
import "./foo.tsp";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;
using Azure.Core;

namespace MgmtTypeSpec;

/**
 * Test case for multi-layer flatten with @flattenProperty where a [CodeGenMember]
 * customization reorders a property, causing constructor parameter mismatch.
 * Reproduces issue https://github.com/Azure/azure-sdk-for-net/issues/55110
 */

/** Single-property model that triggers safe-flatten. */
model SafeFlattenInner {
  @visibility(Lifecycle.Create, Lifecycle.Read)
  selectionType: string;
}

/** Extensible enum type whose property will be overridden via [CodeGenMember]. */
union FlattenChannel {
  string,
  Rapid: "Rapid",
  Stable: "Stable",
}

/**
 * Properties model with a safe-flattened sub-model and a customized property.
 * Also marked with @useSystemTextJsonConverter so the generated JsonConverter.Read
 * is verified to call the dynamic-model deserialization overload that takes the raw payload.
 */
@TypeSpec.HttpClient.CSharp.dynamicModel
@useSystemTextJsonConverter("csharp")
model MultiFlattenProperties {
  /** Required property that will be customized via [CodeGenMember] to change its position. */
  channel: FlattenChannel;

  /** Property whose type has a single public property, triggering safe-flatten. */
  inner?: SafeFlattenInner;

  /** Additional property after inner to verify it is not skipped. */
  disabled?: boolean;
}

@resource("multiFlatten")
@parentResource(Foo)
model MultiFlattenTest is ProxyResource<MultiFlattenProperties> {
  ...ResourceNameParameter<MultiFlattenTest, SegmentName = "multiFlatten">;
}

@armResourceOperations
interface MultiFlattenOps {
  get is ArmResourceRead<MultiFlattenTest>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<MultiFlattenTest>;
}
