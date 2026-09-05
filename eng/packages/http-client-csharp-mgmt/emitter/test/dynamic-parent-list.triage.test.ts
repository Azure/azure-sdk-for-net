import { ok, strictEqual } from "assert";
import { createModel } from "@typespec/http-client-csharp";
import { it } from "vitest";
import { buildArmProviderSchema } from "../src/resource-detection.js";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";

it("distributes a shared list operation to every expanded dynamic-parent resource", async () => {
  // CODING_FLOW_EXECUTION_PROBE
  const runner = await createEmitterTestHost();
  const program = await typeSpecCompile(
    `
model Topic is TrackedResource<TopicProperties> {
  ...ResourceNameParameter<Topic>;
}
model TopicProperties {}

model Domain is TrackedResource<DomainProperties> {
  ...ResourceNameParameter<Domain>;
}
model DomainProperties {}

union ParentType {
  string,
  topics: "topics",
  domains: "domains",
}

model PrivateEndpointConnection is ProxyResource<PrivateEndpointConnectionProperties> {
  ...ResourceNameParameter<PrivateEndpointConnection>;
}
model PrivateEndpointConnectionProperties {}

@armResourceOperations
interface Topics {
  get is ArmResourceRead<Topic>;
}

@armResourceOperations
interface Domains {
  get is ArmResourceRead<Domain>;
}

@armResourceOperations
interface PrivateEndpointConnectionOps
  extends Azure.ResourceManager.Legacy.RoutedOperations<
      {
        ...ApiVersionParameter,
        ...SubscriptionIdParameter,
        ...ResourceGroupParameter,
        @path parentType: ParentType,
        @path parentName: string,
      },
      {},
      ResourceRoute = #{
        route: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Contoso/{parentType}/{parentName}",
      }
    > {}

#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-interface-requires-decorator" "Routed operations reproducer"
@armResourceOperations(#{ allowStaticRoutes: true })
interface PrivateEndpointConnections {
  @get
  @route("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Contoso/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}")
  get is PrivateEndpointConnectionOps.ActionSync<
    PrivateEndpointConnection,
    void,
    PrivateEndpointConnection,
    Parameters = {
      @path privateEndpointConnectionName: string;
    }
  >;

  @get
  @list
  listByResource is ArmResourceListByParent<
    PrivateEndpointConnection,
    Parameters = {
      @path parentType: ParentType;
      @path parentName: string;
    }
  >;
}
`,
    runner
  );
  const context = createEmitterContext(program);
  const sdkContext = await createCSharpSdkContext(context);
  const [root] = createModel(sdkContext);
  const schema = buildArmProviderSchema(sdkContext, root);
  const expandedResources = schema.resources.filter((resource) =>
    resource.metadata.resourceType.endsWith("/privateEndpointConnections")
  );

  strictEqual(expandedResources.length, 2);
  for (const resource of expandedResources) {
    ok(
      resource.metadata.methods.some((method) => method.kind === "List"),
      `${resource.metadata.resourceName} is missing the shared List operation`
    );
  }
});
