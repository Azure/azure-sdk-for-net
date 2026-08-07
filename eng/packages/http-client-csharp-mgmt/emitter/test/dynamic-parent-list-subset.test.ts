import { ok, strictEqual } from "assert";
import { createModel } from "@typespec/http-client-csharp";
import { it } from "vitest";
import { buildArmProviderSchema } from "../src/resource-detection.js";
import { RequestPath } from "../src/resource-metadata.js";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";

it("distributes a shared list operation only to supported expanded dynamic-parent resources", async () => {
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

model PartnerNamespace is TrackedResource<PartnerNamespaceProperties> {
  ...ResourceNameParameter<PartnerNamespace>;
}
model PartnerNamespaceProperties {}

union ParentType {
  string,
  topics: "topics",
  domains: "domains",
  partnerNamespaces: "partnerNamespaces",
}

union ListParentType {
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
interface PartnerNamespaces {
  get is ArmResourceRead<PartnerNamespace>;
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
      @path parentType: ListParentType;
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

  strictEqual(expandedResources.length, 3);
  const listTargetTypes = expandedResources
    .filter((resource) =>
      resource.metadata.methods.some((method) => method.kind === "List")
    )
    .map((resource) => resource.metadata.resourceIdPattern.segments.at(-4))
    .sort();

  strictEqual(
    listTargetTypes.join(","),
    "domains,topics",
    "the shared List operation should only target parents supported by its enum"
  );
  for (const resource of expandedResources) {
    const listMethods = resource.metadata.methods.filter(
      (method) => method.kind === "List"
    );
    ok(
      listMethods.length <= 1,
      `${resource.metadata.resourceName} has duplicate List operations`
    );
    if (listMethods.length === 1) {
      const expectedScope = RequestPath.fromSegments(
        resource.metadata.resourceIdPattern.segments.slice(0, -2)
      );
      strictEqual(
        listMethods[0].scope.scopeIdPattern.path,
        expectedScope.path,
        `${resource.metadata.resourceName} List operation should use its concrete parent scope`
      );
    }
  }
});
