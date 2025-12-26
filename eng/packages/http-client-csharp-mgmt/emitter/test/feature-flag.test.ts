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

  it("use-resolve-arm-resources flag disabled by default", async () => {
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

    // Create emitter context without the flag
    const emitterContext = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(emitterContext);
    const codeModel = await createModel(sdkContext);

    // Build the schema - should use the default custom logic
    // Pass undefined for options to simulate no options passed
    const schema = buildArmProviderSchema(sdkContext, codeModel);

    // Verify the schema is valid and has resources
    ok(schema);
    ok(schema.resources);
    ok(schema.resources.length > 0);
    strictEqual(schema.resources[0].metadata.resourceType, "Microsoft.ContosoProviderHub/employees");
  });

  it("use-resolve-arm-resources flag enabled uses resolveArmResources API", async () => {
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

    // Create emitter context with the flag enabled
    const emitterContext = createEmitterContext(program);
    // Add the management-specific option (AzureMgmtEmitterOptions extends AzureEmitterOptions)
    const optionsWithFlag: AzureMgmtEmitterOptions = {
      ...emitterContext.options,
      "use-resolve-arm-resources": true
    };
    emitterContext.options = optionsWithFlag;

    const sdkContext = await createCSharpSdkContext(emitterContext);
    const codeModel = await createModel(sdkContext);

    // Build the schema - should use resolveArmResources API
    const schemaWithFlag = buildArmProviderSchema(sdkContext, codeModel, optionsWithFlag);

    // Also get the direct result from resolveArmResources to compare
    const directResolveSchema = resolveArmResources(program, sdkContext);

    // Both should produce the same result when normalized
    const normalizedSchemaWithFlag = normalizeSchemaForComparison(schemaWithFlag);
    const normalizedDirectResolve = normalizeSchemaForComparison(directResolveSchema);

    deepStrictEqual(normalizedSchemaWithFlag, normalizedDirectResolve);
  });

  it("use-resolve-arm-resources flag produces equivalent results to custom logic", async () => {
    const program = await typeSpecCompile(
      `
/** An Employee parent resource */
model EmployeeParent is TrackedResource<EmployeeParentProperties> {
  ...ResourceNameParameter<EmployeeParent>;
}

/** Employee parent properties */
model EmployeeParentProperties {
  /** Age of employee */
  age?: int32;
}

/** An Employee resource */
@parentResource(EmployeeParent)
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
interface EmployeesParent {
  get is ArmResourceRead<EmployeeParent>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<EmployeeParent>;
  delete is ArmResourceDeleteSync<EmployeeParent>;
}

@armResourceOperations
interface Employees {
  get is ArmResourceRead<Employee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Employee>;
  update is ArmCustomPatchSync<
    Employee,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<Employee, EmployeeProperties>
  >;
  delete is ArmResourceDeleteSync<Employee>;
}
      `,
      runner
    );

    // Test with flag disabled (default)
    const emitterContextDefault = createEmitterContext(program);
    const sdkContextDefault = await createCSharpSdkContext(emitterContextDefault);
    const codeModelDefault = await createModel(sdkContextDefault);
    const schemaDefault = buildArmProviderSchema(sdkContextDefault, codeModelDefault);

    // Test with flag enabled
    const emitterContextEnabled = createEmitterContext(program);
    // Add the management-specific option (AzureMgmtEmitterOptions extends AzureEmitterOptions)
    const optionsEnabled: AzureMgmtEmitterOptions = {
      ...emitterContextEnabled.options,
      "use-resolve-arm-resources": true
    };
    emitterContextEnabled.options = optionsEnabled;
    const sdkContextEnabled = await createCSharpSdkContext(emitterContextEnabled);
    const codeModelEnabled = await createModel(sdkContextEnabled);
    const schemaEnabled = buildArmProviderSchema(sdkContextEnabled, codeModelEnabled, optionsEnabled);

    // Both should produce equivalent results when normalized
    const normalizedDefault = normalizeSchemaForComparison(schemaDefault);
    const normalizedEnabled = normalizeSchemaForComparison(schemaEnabled);

    // Verify both have the same number of resources
    strictEqual(normalizedDefault.resources.length, normalizedEnabled.resources.length);
    
    // Verify both have the same number of non-resource methods
    strictEqual(normalizedDefault.nonResourceMethods.length, normalizedEnabled.nonResourceMethods.length);

    // Deep equality check
    deepStrictEqual(normalizedEnabled, normalizedDefault);
  });
});
