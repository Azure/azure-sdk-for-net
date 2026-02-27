import { describe, it } from "vitest";
import {
  calculateResourceTypeFromPath,
  ResourceScope
} from "../src/resource-metadata.js";
import { getOperationScopeFromPath } from "../src/resolve-arm-resources-converter.js";
import { strictEqual } from "assert";

describe("Resource Type Calculation", () => {
  it("resource group resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";
    const resourceType = calculateResourceTypeFromPath(path);
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines");
  });

  it("resource group sub resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}";
    const resourceType = calculateResourceTypeFromPath(path);
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines/extensions");
  });

  it("subscription resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines/{vmName}";
    const resourceType = calculateResourceTypeFromPath(path);
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines");
  });

  it("subscription sub resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}";
    const resourceType = calculateResourceTypeFromPath(path);
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines/extensions");
  });

  it("tenant resource", async () => {
    const path = "/providers/Microsoft.Compute/virtualMachines/{vmName}";
    const resourceType = calculateResourceTypeFromPath(path);
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines");
  });

  it("tenant sub resource", async () => {
    const path =
      "/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}";
    const resourceType = calculateResourceTypeFromPath(path);
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines/extensions");
  });

  it("extension resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Something/somethingElse/{name}/providers/Microsoft.Compute/virtualMachines/{vmName}";
    const resourceType = calculateResourceTypeFromPath(path);
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines");
  });

  it("extension sub resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Something/somethingElse/{name}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}";
    const resourceType = calculateResourceTypeFromPath(path);
    strictEqual(resourceType, "Microsoft.Compute/virtualMachines/extensions");
  });

  it("resource group", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";
    const resourceType = calculateResourceTypeFromPath(path);
    strictEqual(resourceType, "Microsoft.Resources/resourceGroups");
  });

  it("subscription", async () => {
    const path = "/subscriptions/{subscriptionId}";
    const resourceType = calculateResourceTypeFromPath(path);
    strictEqual(resourceType, "Microsoft.Resources/subscriptions");
  });

  it("tenant", async () => {
    const path = "/tenants/{tenantId}";
    const resourceType = calculateResourceTypeFromPath(path);
    strictEqual(resourceType, "Microsoft.Resources/tenants");
  });
});

describe("Operation Scope Detection", () => {
  it("extension scope from {resourceUri} prefix", async () => {
    const path = "/{resourceUri}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.Extension);
  });

  it("extension scope from {scope} prefix", async () => {
    const path = "/{scope}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.Extension);
  });

  it("resource group scope", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.ResourceGroup);
  });

  it("subscription scope", async () => {
    const path =
      "/subscriptions/{subscriptionId}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.Subscription);
  });

  it("management group scope", async () => {
    // ManagementGroup-scoped resources naturally have 2 /providers/ segments
    // (one for MG scope, one for resource RP) — this is NOT an extension.
    const path =
      "/providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.ManagementGroup);
  });

  it("management group scope for single provider", async () => {
    const path =
      "/providers/Microsoft.Management/managementGroups/{groupId}/subscriptions/{subscriptionId}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.ManagementGroup);
  });

  it("tenant scope for single provider path", async () => {
    const path = "/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.Tenant);
  });

  it("extension scope for multiple provider segments (serviceGroups)", async () => {
    // Multi-provider path that doesn't match RG/Sub/MG → Extension
    const path =
      "/providers/Microsoft.Management/serviceGroups/{servicegroupName}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.Extension);
  });

  it("resource group scope for nested providers under resource group", async () => {
    // Path starts with /subscriptions/.../resourceGroups/... → ResourceGroup
    // (RG regex matches before multi-provider check)
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Something/parentResource/{parentName}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.ResourceGroup);
  });

  it("resource group scope for variable provider name with RG prefix (Maintenance pattern)", async () => {
    // RG regex matches before multi-provider check. The actual Extension scope
    // for Maintenance RP is determined by the ARM library, not path analysis.
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.ResourceGroup);
  });

  it("resource group scope for variable provider name with RG prefix and parent resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.ResourceGroup);
  });

  it("subscription scope for variable provider without multiple providers", async () => {
    // A single-provider path with a variable provider name still follows
    // normal scope detection since it's not a multi-provider extension pattern.
    const path =
      "/subscriptions/{subscriptionId}/providers/{providerName}/{resourceType}/{resourceName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.Subscription);
  });
});
