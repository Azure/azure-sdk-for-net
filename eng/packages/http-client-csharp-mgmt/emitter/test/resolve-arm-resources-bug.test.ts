// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

/**
 * This test file demonstrates a bug in the resolveArmResources API from
 * @azure-tools/typespec-azure-resource-manager.
 *
 * Bug Description:
 * When multiple singleton resources are defined with different @singleton keys
 * (e.g., Employee with default key and CurrentEmployee with "current" key),
 * the resolveArmResources API does not properly distinguish between them.
 * All resolved resources point to the same model type instead of their respective types.
 *
 * This test is marked with .skip because it demonstrates a bug in an external library
 * that needs to be fixed before the test will pass.
 */

import { beforeEach, describe, it } from "vitest";
import {
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import { TestHost } from "@typespec/compiler/testing";
import { resolveArmResources } from "@azure-tools/typespec-azure-resource-manager";
import { strictEqual, ok } from "assert";

/**
 * Shared TypeSpec schema for multiple singleton resources test.
 * Defines two singleton resources with different @singleton keys.
 */
const multipleSingletonsSchema = `
/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;
}

/** An Employee singleton resource with default key */
@singleton
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

/** A CurrentEmployee singleton resource with "current" key */
@singleton("current")
model CurrentEmployee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<CurrentEmployee>;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Employees {
  get is ArmResourceRead<Employee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Employee>;
}

@armResourceOperations
interface CurrentEmployees {
  get is ArmResourceRead<CurrentEmployee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<CurrentEmployee>;
}
`;

describe("resolveArmResources API Bug Demonstration", () => {
  let runner: TestHost;
  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });

  /**
   * This test demonstrates that resolveArmResources does not correctly return
   * multiple singleton resources with different @singleton keys.
   *
   * Expected behavior: The API should return both Employee and CurrentEmployee
   * as separate resources with their respective model types.
   *
   * Actual behavior: All resolved resources have type.name === "Employee",
   * meaning CurrentEmployee is never properly identified.
   */
  it.skip("should return distinct resources for multiple singletons with different keys", async () => {
    const program = await typeSpecCompile(multipleSingletonsSchema, runner);

    // Use resolveArmResources API to get all resolved ARM resources
    const provider = resolveArmResources(program);
    const resolvedResources = provider.resources ?? [];

    // Check that we have resources returned
    ok(resolvedResources.length > 0, "Should have at least one resolved resource");

    // Find resources by their model type name
    const employeeResources = resolvedResources.filter(
      (r) => r.type.name === "Employee"
    );
    const currentEmployeeResources = resolvedResources.filter(
      (r) => r.type.name === "CurrentEmployee"
    );

    // BUG: This assertion fails because resolveArmResources returns all resources
    // with type.name === "Employee" instead of distinguishing CurrentEmployee
    ok(
      currentEmployeeResources.length > 0,
      "Should have at least one CurrentEmployee resource - BUG: resolveArmResources does not return CurrentEmployee"
    );

    // Verify that Employee resources are returned correctly
    ok(
      employeeResources.length > 0,
      "Should have at least one Employee resource"
    );

    // Verify that the total count is correct (should be 2 distinct resources for CRUD operations)
    // Note: The API may return multiple entries per resource for different operation paths
    const uniqueResourceTypes = new Set(resolvedResources.map((r) => r.type.name));
    strictEqual(
      uniqueResourceTypes.size,
      2,
      "Should have exactly 2 unique resource types (Employee and CurrentEmployee)"
    );
  });

  /**
   * This test shows the current (buggy) behavior of resolveArmResources
   * where all resources point to the same model type.
   */
  it("demonstrates current buggy behavior - all resources have same type", async () => {
    const program = await typeSpecCompile(multipleSingletonsSchema, runner);

    // Use resolveArmResources API to get all resolved ARM resources
    const provider = resolveArmResources(program);
    const resolvedResources = provider.resources ?? [];

    // BUG: All resolved resources have type.name === "Employee"
    // CurrentEmployee is never returned despite being defined
    const allResourceTypeNames = resolvedResources.map((r) => r.type.name);
    const uniqueResourceTypes = new Set(allResourceTypeNames);

    // This assertion passes but demonstrates the bug:
    // We expect 2 unique types but only get 1
    strictEqual(
      uniqueResourceTypes.size,
      1,
      "BUG: resolveArmResources only returns Employee type, missing CurrentEmployee"
    );

    // All resources point to Employee
    ok(
      allResourceTypeNames.every((name) => name === "Employee"),
      "BUG: All resolved resources have type Employee"
    );

    // CurrentEmployee is never returned
    const hasCurrentEmployee = allResourceTypeNames.some(
      (name) => name === "CurrentEmployee"
    );
    strictEqual(
      hasCurrentEmployee,
      false,
      "BUG: CurrentEmployee is never returned by resolveArmResources"
    );
  });
});
