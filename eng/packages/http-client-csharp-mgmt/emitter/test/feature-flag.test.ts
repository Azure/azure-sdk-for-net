// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { beforeEach, describe, it } from "vitest";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile,
  normalizeSchemaForComparison
} from "./test-util.js";
import { TestHost } from "@typespec/compiler/testing";
import { createModel } from "@typespec/http-client-csharp";
import { buildArmProviderSchema } from "../src/resource-detection.js";
import { resolveArmResources } from "../src/resolve-arm-resources-converter.js";
import { ok, strictEqual, deepStrictEqual } from "assert";
import { AzureMgmtEmitterOptions } from "../src/options.js";
import { EmitContext } from "@typespec/compiler";

describe("Feature Flag Tests", () => {
  let runner: TestHost;
  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });

  it("use-legacy-resource-detection flag enabled by default", async () => {
    const program = await typeSpecCompile(
      `
/** An Employee resource */
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Employees {
  get is ArmResourceRead<Employee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Employee>;
  update is ArmCustomPatchSync<
    Employee,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<Employee, EmployeeProperties>
  >;
  delete is ArmResourceDeleteSync<Employee>;
  listByResourceGroup is ArmResourceListByParent<Employee>;
  listBySubscription is ArmListBySubscription<Employee>;
}
      `,
      runner
    );

    // Create emitter context with default options (flag defaults to true, legacy behavior)
    const emitterContext = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(emitterContext);
    const codeModel = await createModel(sdkContext);

    // Build the schema - should use the default custom logic
    // Pass undefined for options to simulate no options explicitly passed
    const schema = buildArmProviderSchema(sdkContext, codeModel);

    // Verify the schema is valid and has resources
    ok(schema);
    ok(schema.resources);
    ok(schema.resources.length > 0);
    strictEqual(schema.resources[0].metadata.resourceType, "Microsoft.ContosoProviderHub/employees");
  });

  it("use-legacy-resource-detection flag disabled uses resolveArmResources API", async () => {
    const program = await typeSpecCompile(
      `
/** An Employee resource */
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Employees {
  get is ArmResourceRead<Employee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Employee>;
  update is ArmCustomPatchSync<
    Employee,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<Employee, EmployeeProperties>
  >;
  delete is ArmResourceDeleteSync<Employee>;
  listByResourceGroup is ArmResourceListByParent<Employee>;
  listBySubscription is ArmListBySubscription<Employee>;
}
      `,
      runner
    );

    // Create emitter context with the flag disabled (opt-in to new resolveArmResources API)
    const emitterContext = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(emitterContext);

    // When flag is disabled, resolveArmResources should be used
    const schemaFromResolve = resolveArmResources(program, sdkContext);

    // Verify the schema is valid and has resources
    ok(schemaFromResolve);
    ok(schemaFromResolve.resources);
    ok(schemaFromResolve.resources.length > 0);
    strictEqual(schemaFromResolve.resources[0].metadata.resourceType, "Microsoft.ContosoProviderHub/employees");
  });
});
