import { beforeEach, describe, it } from "vitest";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import { TestHost } from "@typespec/compiler/testing";
import { createModel } from "@typespec/http-client-csharp";
import { buildArmProviderSchema } from "../src/resource-detection.js";
import { resolveArmResources } from "../src/resolve-arm-resources-converter.js";
import { ok, strictEqual } from "assert";

/**
 * Regression test for: Collection.CreateOrUpdate not emitted when PUT uses
 * Foundations.ArmCreateOperation with body type different from resource model.
 *
 * Trigger: a resource whose @put is declared via
 *   Azure.ResourceManager.Foundations.ArmCreateOperation<HttpParameters, BodyParameter, Response, Error>
 * where BodyParameter is a separate "*CreateOrUpdateParameters" model (not the
 * resource model). This is the pattern used by the Cosmos DB ARM spec
 * (DatabaseAccountGetResults).
 *
 * The PUT operation lacks the @armResourceCreateOrUpdate decorator (because
 * Foundations.ArmCreateOperation is the lower-level building block that does
 * not apply the decorator), so the standardized resolveArmResources API does
 * not return it under lifecycle.createOrUpdate. The emitter must still
 * classify it as a Create lifecycle op based on the HTTP verb and path so the
 * resource Collection<T> gets a generated CreateOrUpdate / CreateOrUpdateAsync
 * method.
 */

const FOUNDATIONS_ARM_CREATE_OPERATION_TSP = `
interface Operations extends Azure.ResourceManager.Operations {}

@doc("The provisioning state of a resource.")
union ProvisioningState {
  string,
  Succeeded: "Succeeded",
  Failed: "Failed",
  Canceled: "Canceled",
}

@doc("Widget resource properties.")
model WidgetProperties {
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;
  size?: int32;
}

@doc("The Widget resource (response shape).")
model Widget is TrackedResource<WidgetProperties> {
  ...ResourceNameParameter<Widget>;
}

@doc("Body shape used to create or update a Widget (intentionally different from Widget).")
model WidgetCreateOrUpdateContent {
  location: string;
  properties?: WidgetProperties;
  tags?: Record<string>;
}

@armResourceOperations
interface Widgets {
  get is ArmResourceRead<Widget>;

  // PUT declared via the low-level Foundations.ArmCreateOperation building
  // block with a body type that differs from the resource model. This is the
  // pattern that triggers the missing-CreateOrUpdate bug.
  @put
  createOrUpdate is Azure.ResourceManager.Foundations.ArmCreateOperation<
    ResourceInstanceParameters<Widget>,
    WidgetCreateOrUpdateContent,
    ArmResourceUpdatedResponse<Widget> | ArmResourceCreatedResponse<Widget>,
    ErrorResponse
  >;

  delete is ArmResourceDeleteWithoutOkAsync<Widget>;
}
`;

function findWidget(armProviderSchema: { resources: any[] }) {
  return armProviderSchema.resources.find(
    (r: any) => r.metadata.resourceType === "Microsoft.ContosoProviderHub/widgets"
  );
}

describe("Foundations.ArmCreateOperation classification", () => {
  let runner: TestHost;
  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });

  it("legacy buildArmProviderSchema classifies Foundations.ArmCreateOperation PUT as Create", async () => {
    const program = await typeSpecCompile(
      FOUNDATIONS_ARM_CREATE_OPERATION_TSP,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);

    const armProviderSchema = buildArmProviderSchema(sdkContext, root);
    const widget = findWidget(armProviderSchema);
    ok(widget, "Widget resource should be detected");
    const methodKinds = widget.metadata.methods.map((m: any) => m.kind);
    ok(
      methodKinds.includes("Create"),
      `expected a Create method to be detected for the Foundations.ArmCreateOperation PUT, got kinds=${JSON.stringify(methodKinds)}`
    );
  });

  it("resolveArmResources classifies Foundations.ArmCreateOperation PUT as Create", async () => {
    const program = await typeSpecCompile(
      FOUNDATIONS_ARM_CREATE_OPERATION_TSP,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    // resolveArmResources is independent of createModel but createModel
    // populates the SDK context with the methods we look up.
    createModel(sdkContext);

    const armProviderSchema = resolveArmResources(program, sdkContext);
    const widget = findWidget(armProviderSchema);
    ok(widget, "Widget resource should be detected by resolveArmResources");
    const methodKinds = widget.metadata.methods.map((m: any) => m.kind);
    ok(
      methodKinds.includes("Create"),
      `expected a Create method to be detected via resolveArmResources for the Foundations.ArmCreateOperation PUT, got kinds=${JSON.stringify(methodKinds)}`
    );

    // The Create method's operationPath must equal the resource instance path
    // (this is what wires the generated Collection.CreateOrUpdate to the
    // already-emitted *RestOperations.CreateCreateOrUpdateRequest).
    const createMethod = widget.metadata.methods.find(
      (m: any) => m.kind === "Create"
    );
    ok(createMethod);
    strictEqual(
      createMethod.operationPath.path,
      widget.metadata.resourceIdPattern.path
    );
  });
});
