import { describe, it, beforeEach } from "vitest";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile,
  normalizeSchemaForComparison
} from "./test-util.js";
import { TestHost } from "@typespec/compiler/testing";
import { createModel } from "@typespec/http-client-csharp";
import { buildArmProviderSchema } from "../src/resource-detection.js";
import { resolveArmResources } from "../src/resolve-arm-resources-converter.js";
import { ok, strictEqual, deepStrictEqual } from "assert";
import { ResourceScope } from "../src/resource-metadata.js";

describe("Debug Test", () => {
  let runner: TestHost;
  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });

  it("debug interface with only action operations (no get)", async () => {
    const program = await typeSpecCompile(
      `
/** A ScheduledAction resource model */
model ScheduledAction is TrackedResource<ScheduledActionProperties> {
  ...ResourceNameParameter<ScheduledAction>;
}

/** ScheduledAction properties */
model ScheduledActionProperties {
  /** Action type */
  actionType?: string;
}

/** Request model for GetAssociatedScheduledActions */
model GetAssociatedScheduledActionsRequest {
  /** Resource IDs to query */
  resourceIds: string[];
}

/** Response model for GetAssociatedScheduledActions */
model GetAssociatedScheduledActionsResponse {
  /** List of scheduled actions */
  scheduledActions: ScheduledAction[];
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface ScheduledActionExtension {
  @post
  @segment("getAssociatedScheduledActions")
  getAssociatedScheduledActions is ArmResourceActionSync<
    ScheduledAction,
    GetAssociatedScheduledActionsRequest,
    GetAssociatedScheduledActionsResponse
  >;

  @doc("Action to retrieve the PostgreSQL versions.")
  @autoRoute
  @armResourceAction(ScheduledAction)
  @post
  getPostgresVersions(
    ...ResourceInstanceParameters<GetAssociatedScheduledActionsRequest>
  ): ArmResponse<GetAssociatedScheduledActionsResponse> | ErrorResponse;
}
`,
      runner
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const root = createModel(sdkContext);

    // Build ARM provider schema and verify its structure
    const armProviderSchemaResult = buildArmProviderSchema(sdkContext, root);
    console.log("\n=== buildArmProviderSchema result ===");
    console.log(JSON.stringify(armProviderSchemaResult, null, 2));

    const resolvedSchema = resolveArmResources(program, sdkContext);
    console.log("\n=== resolveArmResources result ===");
    console.log(JSON.stringify(resolvedSchema, null, 2));

    ok(armProviderSchemaResult);
  });
});
