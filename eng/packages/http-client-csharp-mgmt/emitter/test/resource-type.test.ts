import { describe, it } from "vitest";
import {
  calculateResourceTypeFromPath,
  ResourceScope
} from "../src/resource-metadata.js";
import {
  getOperationScopeFromPath,
  extractParentResourceTypeFromPath,
  getParentTypeDiscriminator
} from "../src/resolve-arm-resources-converter.js";
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
    const path =
      "/providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.ManagementGroup);
  });

  it("tenant scope for single provider path", async () => {
    const path = "/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.Tenant);
  });

  it("extension scope for multiple provider segments (serviceGroups)", async () => {
    const path =
      "/providers/Microsoft.Management/serviceGroups/{servicegroupName}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.Extension);
  });

  it("resource group scope takes priority over nested extension resources", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Something/parentResource/{parentName}/providers/Microsoft.Edge/sites/{siteName}";
    const scope = getOperationScopeFromPath(path);
    strictEqual(scope, ResourceScope.ResourceGroup);
  });
});

describe("Extract Parent Resource Type From Path", () => {
  it("extracts parent type from extension resource targeting virtualMachines", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{assignmentName}";
    const parentType = extractParentResourceTypeFromPath(path);
    strictEqual(parentType, "Microsoft.Compute/virtualMachines");
  });

  it("extracts parent type from extension resource targeting HybridCompute machines", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{assignmentName}";
    const parentType = extractParentResourceTypeFromPath(path);
    strictEqual(parentType, "Microsoft.HybridCompute/machines");
  });

  it("returns undefined for non-extension resource path", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";
    const parentType = extractParentResourceTypeFromPath(path);
    strictEqual(parentType, undefined);
  });

  it("returns undefined for subscription-scoped resource", async () => {
    const path =
      "/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines/{vmName}";
    const parentType = extractParentResourceTypeFromPath(path);
    strictEqual(parentType, undefined);
  });

  it("returns undefined for tenant-scoped resource", async () => {
    const path = "/providers/Microsoft.Compute/virtualMachines/{vmName}";
    const parentType = extractParentResourceTypeFromPath(path);
    strictEqual(parentType, undefined);
  });

  it("returns undefined for scope-based extension path", async () => {
    const path = "/{scope}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{assignmentName}";
    const parentType = extractParentResourceTypeFromPath(path);
    strictEqual(parentType, undefined);
  });

  it("extracts parent type from nested sub-resource extension", async () => {
    const path =
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{assignmentName}";
    const parentType = extractParentResourceTypeFromPath(path);
    strictEqual(parentType, "Microsoft.Compute/virtualMachineScaleSets");
  });
});

describe("Get Parent Type Discriminator", () => {
  it("returns known mapping for Microsoft.Compute/virtualMachines", async () => {
    const discriminator = getParentTypeDiscriminator("Microsoft.Compute/virtualMachines");
    strictEqual(discriminator, "VirtualMachine");
  });

  it("returns known mapping for Microsoft.HybridCompute/machines", async () => {
    const discriminator = getParentTypeDiscriminator("Microsoft.HybridCompute/machines");
    strictEqual(discriminator, "Machine");
  });

  it("returns known mapping for Microsoft.Compute/virtualMachineScaleSets", async () => {
    const discriminator = getParentTypeDiscriminator("Microsoft.Compute/virtualMachineScaleSets");
    strictEqual(discriminator, "VirtualMachineScaleSet");
  });

  it("returns known mapping for Microsoft.ConnectedVMwarevSphere/virtualMachines", async () => {
    const discriminator = getParentTypeDiscriminator("Microsoft.ConnectedVMwarevSphere/virtualMachines");
    strictEqual(discriminator, "VMwarevSphereVirtualMachine");
  });

  it("generates discriminator for unknown type with plural name", async () => {
    const discriminator = getParentTypeDiscriminator("Microsoft.Storage/storageAccounts");
    strictEqual(discriminator, "StorageAccount");
  });

  it("generates discriminator for unknown type with singular name", async () => {
    const discriminator = getParentTypeDiscriminator("Microsoft.Network/virtualNetwork");
    strictEqual(discriminator, "VirtualNetwork");
  });

  it("handles empty string gracefully", async () => {
    const discriminator = getParentTypeDiscriminator("");
    strictEqual(discriminator, "");
  });

  it("handles single segment gracefully", async () => {
    const discriminator = getParentTypeDiscriminator("Microsoft.Compute");
    strictEqual(discriminator, "");
  });
});
