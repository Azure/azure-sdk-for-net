import { describe, it } from "vitest";
import { calculateResourceTypeFromPath } from "../src/resource-metadata.js";
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
