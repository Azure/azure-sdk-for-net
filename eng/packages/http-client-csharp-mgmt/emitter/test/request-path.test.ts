import { describe, it } from "vitest";
import { strictEqual, deepStrictEqual, ok } from "assert";
import { RequestPath, isVariableSegment } from "../src/resource-metadata.js";
import { ResourceScopeKind } from "../src/resource-metadata.js";

describe("RequestPath", () => {
  describe("parse and segments", () => {
    it("should parse a simple path into segments", () => {
      const rp = new RequestPath("/subscriptions/{subscriptionId}");
      deepStrictEqual([...rp.segments], ["subscriptions", "{subscriptionId}"]);
    });

    it("should parse a resource group path", () => {
      const rp = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}"
      );
      deepStrictEqual(
        [...rp.segments],
        [
          "subscriptions",
          "{subscriptionId}",
          "resourceGroups",
          "{resourceGroupName}",
          "providers",
          "Microsoft.Compute",
          "virtualMachines",
          "{vmName}"
        ]
      );
    });

    it("should filter empty segments from leading/trailing slashes", () => {
      const rp = new RequestPath("/a/b/c/");
      deepStrictEqual([...rp.segments], ["a", "b", "c"]);
      strictEqual(rp.length, 3);
    });

    it("should preserve the original path string", () => {
      const path =
        "/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines/{vmName}";
      const rp = new RequestPath(path);
      strictEqual(rp.path, path);
      strictEqual(rp.toString(), path);
    });
  });

  describe("isPrefixOf", () => {
    it("should return true when path is prefix of longer path", () => {
      const parent = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{rg}"
      );
      const child = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{rg}/providers/Microsoft.Compute/vms/{vmName}"
      );
      ok(parent.isPrefixOf(child));
    });

    it("should return true when paths are equal", () => {
      const rp1 = new RequestPath("/a/{b}/c");
      const rp2 = new RequestPath("/a/{b}/c");
      ok(rp1.isPrefixOf(rp2));
    });

    it("should return false when path is not prefix", () => {
      const rp1 = new RequestPath("/a/b/c");
      const rp2 = new RequestPath("/a/x/c");
      ok(!rp1.isPrefixOf(rp2));
    });

    it("should return false when longer path used as prefix of shorter", () => {
      const longer = new RequestPath("/a/b/c/d");
      const shorter = new RequestPath("/a/b");
      ok(!longer.isPrefixOf(shorter));
    });

    it("should match variable segments regardless of name", () => {
      const rp1 = new RequestPath("/subscriptions/{sub1}");
      const rp2 = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{rg}"
      );
      ok(rp1.isPrefixOf(rp2));
    });
  });

  describe("getSharedSegmentCount", () => {
    it("should count matching segments", () => {
      const rp1 = new RequestPath("/a/b/c/d");
      const rp2 = new RequestPath("/a/b/x/y");
      strictEqual(rp1.getSharedSegmentCount(rp2), 2);
    });

    it("should treat variable segments as matching", () => {
      const rp1 = new RequestPath("/subscriptions/{sub1}/resourceGroups");
      const rp2 = new RequestPath("/subscriptions/{sub2}/resourceGroups");
      strictEqual(rp1.getSharedSegmentCount(rp2), 3);
    });

    it("should stop at first non-matching segment", () => {
      const rp1 = new RequestPath("/a/b/c/d/e");
      const rp2 = new RequestPath("/a/b/x/d/e");
      strictEqual(rp1.getSharedSegmentCount(rp2), 2);
    });

    it("should return 0 for completely different paths", () => {
      const rp1 = new RequestPath("/x/y");
      const rp2 = new RequestPath("/a/b");
      strictEqual(rp1.getSharedSegmentCount(rp2), 0);
    });
  });

  describe("singletonName", () => {
    it("should return the singleton name for fixed last segment", () => {
      const rp = new RequestPath(
        "/subscriptions/{sub}/providers/Microsoft.Compute/virtualMachines/{vmName}/default"
      );
      strictEqual(rp.singletonName, "default");
    });

    it("should return undefined for variable last segment", () => {
      const rp = new RequestPath(
        "/subscriptions/{sub}/providers/Microsoft.Compute/virtualMachines/{vmName}"
      );
      strictEqual(rp.singletonName, undefined);
    });
  });

  describe("equals", () => {
    it("should return true for identical paths", () => {
      const rp1 = new RequestPath("/subscriptions/{sub}/resourceGroups/{rg}");
      const rp2 = new RequestPath("/subscriptions/{sub}/resourceGroups/{rg}");
      ok(rp1.equals(rp2));
    });

    it("should return true when variable names differ", () => {
      const rp1 = new RequestPath(
        "/providers/Microsoft.Management/managementGroups/{name}"
      );
      const rp2 = new RequestPath(
        "/providers/Microsoft.Management/managementGroups/{groupId}"
      );
      ok(rp1.equals(rp2));
    });

    it("should return false for different fixed segments", () => {
      const rp1 = new RequestPath("/subscriptions/{sub}/resourceGroups/{rg}");
      const rp2 = new RequestPath(
        "/providers/Microsoft.Management/managementGroups/{groupId}"
      );
      ok(!rp1.equals(rp2));
    });

    it("should return false for different lengths", () => {
      const rp1 = new RequestPath("/a/b");
      const rp2 = new RequestPath("/a/b/c");
      ok(!rp1.equals(rp2));
    });

    it("should return false when variable vs fixed mismatch", () => {
      const rp1 = new RequestPath("/a/{b}");
      const rp2 = new RequestPath("/a/b");
      ok(!rp1.equals(rp2));
    });
  });

  describe("resourceType", () => {
    it("should extract resource type from resource group resource", () => {
      const rp = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}"
      );
      strictEqual(rp.resourceType, "Microsoft.Compute/virtualMachines");
    });

    it("should extract resource type from sub resource", () => {
      const rp = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}"
      );
      strictEqual(
        rp.resourceType,
        "Microsoft.Compute/virtualMachines/extensions"
      );
    });

    it("should extract resource type from extension resource", () => {
      const rp = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{rg}/providers/Microsoft.Something/somethingElse/{name}/providers/Microsoft.Compute/virtualMachines/{vmName}"
      );
      strictEqual(rp.resourceType, "Microsoft.Compute/virtualMachines");
    });

    it("should return Microsoft.Resources/resourceGroups for resource group path", () => {
      const rp = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}"
      );
      strictEqual(rp.resourceType, "Microsoft.Resources/resourceGroups");
    });

    it("should return Microsoft.Resources/subscriptions for subscription path", () => {
      const rp = new RequestPath("/subscriptions/{subscriptionId}");
      strictEqual(rp.resourceType, "Microsoft.Resources/subscriptions");
    });

    it("should return Microsoft.Resources/tenants for tenant path", () => {
      const rp = new RequestPath("/tenants/{tenantId}");
      strictEqual(rp.resourceType, "Microsoft.Resources/tenants");
    });

    it("should return undefined for path without determinable resource type", () => {
      const rp = new RequestPath("/unknown/path");
      strictEqual(rp.resourceType, undefined);
    });

    it("should return undefined for generic scope path like /{resourceUri}", () => {
      const rp = new RequestPath("/{resourceUri}");
      strictEqual(rp.resourceType, undefined);
    });
  });

  describe("scopePath", () => {
    it("should return scope for resource group resource", () => {
      const rp = new RequestPath(
        "/subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Compute/virtualMachines/{vmName}"
      );
      const scope = rp.scopePath;
      ok(scope !== undefined);
      ok(
        scope!.equals(
          new RequestPath("/subscriptions/{sub}/resourceGroups/{rg}")
        )
      );
    });

    it("should return scope for extension resource (before last providers)", () => {
      const rp = new RequestPath(
        "/subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Something/parent/{name}/providers/Microsoft.Compute/vms/{vmName}"
      );
      const scope = rp.scopePath;
      ok(scope !== undefined);
      ok(
        scope!.equals(
          new RequestPath(
            "/subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Something/parent/{name}"
          )
        )
      );
    });

    it("should return empty RequestPath for paths without providers", () => {
      const rp = new RequestPath("/subscriptions/{sub}/resourceGroups/{rg}");
      strictEqual(rp.scopePath.length, 0);
    });

    it("should return empty scope for tenant-scoped resources", () => {
      const rp = new RequestPath(
        "/providers/Microsoft.Compute/virtualMachines/{vmName}"
      );
      const scope = rp.scopePath;
      strictEqual(scope.length, 0);
    });
  });

  describe("operationScope", () => {
    it("should detect Extension scope from variable + providers prefix", () => {
      const rp = new RequestPath(
        "/{resourceUri}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScopeKind.Extension);
    });

    it("should detect ResourceGroup scope", () => {
      const rp = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScopeKind.ResourceGroup);
    });

    it("should detect Subscription scope", () => {
      const rp = new RequestPath(
        "/subscriptions/{subscriptionId}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScopeKind.Subscription);
    });

    it("should detect ManagementGroup scope", () => {
      const rp = new RequestPath(
        "/providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScopeKind.ManagementGroup);
    });

    it("should detect Tenant scope for single provider path", () => {
      const rp = new RequestPath("/providers/Microsoft.Edge/sites/{siteName}");
      strictEqual(rp.operationScope, ResourceScopeKind.Tenant);
    });

    it("should detect Extension scope from multiple providers", () => {
      const rp = new RequestPath(
        "/providers/Microsoft.Management/serviceGroups/{servicegroupName}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScopeKind.Extension);
    });

    it("should detect Extension for nested extension resources under ResourceGroup", () => {
      const rp = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Something/parentResource/{parentName}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScopeKind.Extension);
    });
  });
});

describe("isVariableSegment", () => {
  it("should return true for variable segments", () => {
    ok(isVariableSegment("{subscriptionId}"));
    ok(isVariableSegment("{resourceGroupName}"));
  });

  it("should return false for fixed segments", () => {
    ok(!isVariableSegment("subscriptions"));
    ok(!isVariableSegment("providers"));
    ok(!isVariableSegment(""));
  });
});
