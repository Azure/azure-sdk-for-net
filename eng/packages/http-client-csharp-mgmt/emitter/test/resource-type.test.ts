import { describe, it } from "vitest";
import {
  RequestPath,
  resolveResourceApiVersions,
  ResourceOperationKind,
  ResourceScopeKind
} from "../src/resource-metadata.js";
import { strictEqual, deepStrictEqual } from "assert";

describe("Resource Type Calculation", () => {
  it("resource group resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";
    const resourceType = new RequestPath(path).resourceType;
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines");
  });

  it("resource group sub resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}";
    const resourceType = new RequestPath(path).resourceType;
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines/extensions");
  });

  it("subscription resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines/{vmName}";
    const resourceType = new RequestPath(path).resourceType;
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines");
  });

  it("subscription sub resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}";
    const resourceType = new RequestPath(path).resourceType;
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines/extensions");
  });

  it("tenant resource", async () => {
    const path = "/providers/Microsoft.Compute/virtualMachines/{vmName}";
    const resourceType = new RequestPath(path).resourceType;
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines");
  });

  it("tenant sub resource", async () => {
    const path =
      "/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}";
    const resourceType = new RequestPath(path).resourceType;
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines/extensions");
  });

  it("extension resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Something/somethingElse/{name}/providers/Microsoft.Compute/virtualMachines/{vmName}";
    const resourceType = new RequestPath(path).resourceType;
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines");
  });

  it("extension sub resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Something/somethingElse/{name}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}";
    const resourceType = new RequestPath(path).resourceType;
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines/extensions");
  });

  it("resource group", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";
    const resourceType = new RequestPath(path).resourceType;
    strictEqual(resourceType, "Microsoft.Resources/resourceGroups");
  });

  it("subscription", async () => {
    const path = "/subscriptions/{subscriptionId}";
    const resourceType = new RequestPath(path).resourceType;
    strictEqual(resourceType, "Microsoft.Resources/subscriptions");
  });

  it("tenant", async () => {
    const path = "/tenants/{tenantId}";
    const resourceType = new RequestPath(path).resourceType;
    strictEqual(resourceType, "Microsoft.Resources/tenants");
  });
});

describe("Operation Scope Detection", () => {
  it("extension scope from {resourceUri} prefix", async () => {
    const path = "/{resourceUri}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = new RequestPath(path).operationScope;
    strictEqual(scope, ResourceScopeKind.Extension);
  });

  it("extension scope from {scope} prefix", async () => {
    const path = "/{scope}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = new RequestPath(path).operationScope;
    strictEqual(scope, ResourceScopeKind.Extension);
  });

  it("resource group scope", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = new RequestPath(path).operationScope;
    strictEqual(scope, ResourceScopeKind.ResourceGroup);
  });

  it("subscription scope", async () => {
    const path =
      "/subscriptions/{subscriptionId}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = new RequestPath(path).operationScope;
    strictEqual(scope, ResourceScopeKind.Subscription);
  });

  it("management group scope", async () => {
    const path =
      "/providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = new RequestPath(path).operationScope;
    strictEqual(scope, ResourceScopeKind.ManagementGroup);
  });

  it("tenant scope for single provider path", async () => {
    const path = "/providers/Microsoft.Edge/sites/{siteName}";
    const scope = new RequestPath(path).operationScope;
    strictEqual(scope, ResourceScopeKind.Tenant);
  });

  it("extension scope for multiple provider segments (serviceGroups)", async () => {
    const path =
      "/providers/Microsoft.Management/serviceGroups/{servicegroupName}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = new RequestPath(path).operationScope;
    strictEqual(scope, ResourceScopeKind.Extension);
  });

  it("extension scope from generic variable prefix with {resourceId}", async () => {
    const path =
      "/{resourceId}/providers/Microsoft.DataProtection/backupInstances";
    const scope = new RequestPath(path).operationScope;
    strictEqual(scope, ResourceScopeKind.Extension);
  });

  it("extension scope for resources extending a specific ARM resource within a resource group", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Something/parentResource/{parentName}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = new RequestPath(path).operationScope;
    strictEqual(scope, ResourceScopeKind.Extension);
  });
});

describe("Resolve Resource API Versions", () => {
  const methodApiVersionsMap = new Map<string, string[]>([
    ["create-method-id", ["2024-04-01", "2024-05-01"]],
    ["read-method-id", ["2024-04-01", "2024-05-01"]],
    ["delete-method-id", ["2024-05-01"]],
    ["list-method-id", ["2024-04-01", "2024-05-01"]],
    ["action-method-id", ["2024-05-01"]]
  ]);

  function makeMethod(methodId: string, kind: ResourceOperationKind) {
    return {
      methodId,
      kind,
      operationPath: "/fake/path",
      scope: { kind: ResourceScopeKind.ResourceGroup }
    };
  }

  it("prefers Create method versions", () => {
    const methods = [
      makeMethod("read-method-id", ResourceOperationKind.Read),
      makeMethod("create-method-id", ResourceOperationKind.Create),
      makeMethod("delete-method-id", ResourceOperationKind.Delete)
    ];
    const versions = resolveResourceApiVersions(methods, methodApiVersionsMap);
    deepStrictEqual(versions, ["2024-04-01", "2024-05-01"]);
  });

  it("falls back to Read method versions when no Create", () => {
    const methods = [
      makeMethod("read-method-id", ResourceOperationKind.Read),
      makeMethod("delete-method-id", ResourceOperationKind.Delete)
    ];
    const versions = resolveResourceApiVersions(methods, methodApiVersionsMap);
    deepStrictEqual(versions, ["2024-04-01", "2024-05-01"]);
  });

  it("returns empty array when no Create or Read method", () => {
    const methods = [
      makeMethod("list-method-id", ResourceOperationKind.List),
      makeMethod("action-method-id", ResourceOperationKind.Action)
    ];
    const versions = resolveResourceApiVersions(methods, methodApiVersionsMap);
    deepStrictEqual(versions, []);
  });

  it("returns empty array for empty methods list", () => {
    const versions = resolveResourceApiVersions([], methodApiVersionsMap);
    deepStrictEqual(versions, []);
  });

  it("returns empty array when method not in map", () => {
    const methods = [makeMethod("unknown-id", ResourceOperationKind.Create)];
    const versions = resolveResourceApiVersions(methods, methodApiVersionsMap);
    deepStrictEqual(versions, []);
  });
});
