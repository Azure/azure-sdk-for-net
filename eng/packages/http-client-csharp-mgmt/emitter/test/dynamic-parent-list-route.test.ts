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

it("matches a shared dynamic-parent list operation to the complete collection route", async () => {
  const runner = await createEmitterTestHost();
  const program = await typeSpecCompile(
    `
model PrivateEndpointConnection is ProxyResource<PrivateEndpointConnectionProperties> {
  ...ResourceNameParameter<PrivateEndpointConnection>;
}
model PrivateEndpointConnectionProperties {}

union ParentType {
  string,
  topics: "topics",
  domains: "domains",
}

interface ProviderAOps
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
        route: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/{parentType}/{parentName}",
      }
    > {}

interface ProviderBOps
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
        route: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ProviderB/{parentType}/{parentName}",
      }
    > {}

#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-interface-requires-decorator" "Routed operations reproducer"
@armResourceOperations(#{ allowStaticRoutes: true })
interface PrivateEndpointConnections {
  @get
  @route("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContosoProviderHub/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}")
  getFromProviderA is ProviderAOps.ActionSync<
    PrivateEndpointConnection,
    void,
    PrivateEndpointConnection,
    Parameters = {
      @path privateEndpointConnectionName: string;
    }
  >;

  @get
  @route("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ProviderB/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}")
  getFromProviderB is ProviderBOps.ActionSync<
    PrivateEndpointConnection,
    void,
    PrivateEndpointConnection,
    Parameters = {
      @path privateEndpointConnectionName: string;
    }
  >;

  @get
  @list
  listByProviderA is ArmResourceListByParent<
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

  strictEqual(expandedResources.length, 4);
  const listTargets = expandedResources.filter((resource) =>
    resource.metadata.methods.some((method) => method.kind === "List")
  );

  strictEqual(listTargets.length, 2);
  for (const resource of listTargets) {
    ok(
      resource.metadata.resourceIdPattern.path.includes(
        "/providers/Microsoft.ContosoProviderHub/"
      ),
      `${resource.metadata.resourceName} matched the wrong provider route`
    );
  }
});
