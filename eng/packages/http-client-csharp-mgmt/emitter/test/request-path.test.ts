import { describe, it } from "vitest";
import { strictEqual, deepStrictEqual, ok, throws } from "assert";
import { RequestPath, ResourceType, isVariableSegment } from "../src/utils.js";
import { ResourceScope } from "../src/resource-metadata.js";

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

  describe("lastSegment", () => {
    it("should return the last segment", () => {
      const rp = new RequestPath("/a/b/c");
      strictEqual(rp.lastSegment, "c");
    });

    it("should return variable last segment", () => {
      const rp = new RequestPath("/providers/Microsoft.Compute/vms/{vmName}");
      strictEqual(rp.lastSegment, "{vmName}");
    });

    it("should return undefined for empty path", () => {
      const rp = new RequestPath("");
      strictEqual(rp.lastSegment, undefined);
    });
  });

  describe("resourceTypeSegment", () => {
    it("should return type segment for standard resource path", () => {
      const rp = new RequestPath(
        "/subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Compute/virtualMachines/{vmName}"
      );
      strictEqual(rp.resourceTypeSegment, "virtualMachines");
    });

    it("should return undefined when last segment is not a variable", () => {
      const rp = new RequestPath(
        "/subscriptions/{sub}/providers/Microsoft.Compute/virtualMachines"
      );
      strictEqual(rp.resourceTypeSegment, undefined);
    });

    it("should return undefined when second-to-last segment is a variable", () => {
      const rp = new RequestPath("/{a}/{b}");
      strictEqual(rp.resourceTypeSegment, undefined);
    });

    it("should return undefined for paths with fewer than 2 segments", () => {
      const rp = new RequestPath("/single");
      strictEqual(rp.resourceTypeSegment, undefined);
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

  describe("hasMultipleProviderSegments", () => {
    it("should return true for extension resource paths", () => {
      const rp = new RequestPath(
        "/providers/Microsoft.Management/serviceGroups/{name}/providers/Microsoft.Edge/sites/{siteName}"
      );
      ok(rp.hasMultipleProviderSegments);
    });

    it("should return false for single provider path", () => {
      const rp = new RequestPath(
        "/subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Compute/vms/{vmName}"
      );
      ok(!rp.hasMultipleProviderSegments);
    });

    it("should return false for no provider segments", () => {
      const rp = new RequestPath("/subscriptions/{sub}/resourceGroups/{rg}");
      ok(!rp.hasMultipleProviderSegments);
    });
  });

  describe("providerSegmentCount", () => {
    it("should return 0 for no provider segments", () => {
      const rp = new RequestPath("/subscriptions/{sub}/resourceGroups/{rg}");
      strictEqual(rp.providerSegmentCount, 0);
    });

    it("should return 1 for single provider path", () => {
      const rp = new RequestPath(
        "/subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Compute/vms/{vmName}"
      );
      strictEqual(rp.providerSegmentCount, 1);
    });

    it("should return 2 for extension resource paths", () => {
      const rp = new RequestPath(
        "/providers/Microsoft.Management/serviceGroups/{name}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.providerSegmentCount, 2);
    });
  });

  describe("operationScope", () => {
    it("should detect Extension scope from variable + providers prefix", () => {
      const rp = new RequestPath(
        "/{resourceUri}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScope.Extension);
    });

    it("should detect ResourceGroup scope", () => {
      const rp = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScope.ResourceGroup);
    });

    it("should detect Subscription scope", () => {
      const rp = new RequestPath(
        "/subscriptions/{subscriptionId}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScope.Subscription);
    });

    it("should detect ManagementGroup scope", () => {
      const rp = new RequestPath(
        "/providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScope.ManagementGroup);
    });

    it("should detect Tenant scope for single provider path", () => {
      const rp = new RequestPath("/providers/Microsoft.Edge/sites/{siteName}");
      strictEqual(rp.operationScope, ResourceScope.Tenant);
    });

    it("should detect Extension scope from multiple providers", () => {
      const rp = new RequestPath(
        "/providers/Microsoft.Management/serviceGroups/{servicegroupName}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScope.Extension);
    });

    it("should give ResourceGroup priority over nested extension resources", () => {
      const rp = new RequestPath(
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Something/parentResource/{parentName}/providers/Microsoft.Edge/sites/{siteName}"
      );
      strictEqual(rp.operationScope, ResourceScope.ResourceGroup);
    });
  });

  describe("parentPath", () => {
    it("should return the path without the last segment", () => {
      const rp = new RequestPath("/a/b/c");
      strictEqual(rp.parentPath, "/a/b");
    });

    it("should return undefined for single-segment paths", () => {
      const rp = new RequestPath("/a");
      strictEqual(rp.parentPath, undefined);
    });
  });
});

describe("ResourceType", () => {
  describe("fromPath", () => {
    it("should extract resource type from resource group resource", () => {
      const path =
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";
      strictEqual(
        ResourceType.fromPath(path),
        "Microsoft.Compute/virtualMachines"
      );
    });

    it("should extract resource type from sub resource", () => {
      const path =
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}";
      strictEqual(
        ResourceType.fromPath(path),
        "Microsoft.Compute/virtualMachines/extensions"
      );
    });

    it("should extract resource type from extension resource", () => {
      const path =
        "/subscriptions/{subscriptionId}/resourceGroups/{rg}/providers/Microsoft.Something/somethingElse/{name}/providers/Microsoft.Compute/virtualMachines/{vmName}";
      strictEqual(
        ResourceType.fromPath(path),
        "Microsoft.Compute/virtualMachines"
      );
    });

    it("should return Microsoft.Resources/resourceGroups for resource group path", () => {
      const path =
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";
      strictEqual(
        ResourceType.fromPath(path),
        "Microsoft.Resources/resourceGroups"
      );
    });

    it("should return Microsoft.Resources/subscriptions for subscription path", () => {
      strictEqual(
        ResourceType.fromPath("/subscriptions/{subscriptionId}"),
        "Microsoft.Resources/subscriptions"
      );
    });

    it("should return Microsoft.Resources/tenants for tenant path", () => {
      strictEqual(
        ResourceType.fromPath("/tenants/{tenantId}"),
        "Microsoft.Resources/tenants"
      );
    });

    it("should throw for path without resource type", () => {
      throws(() => ResourceType.fromPath("/unknown/path"));
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
