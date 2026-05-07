// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { beforeEach, describe, it } from "vitest";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";
import { TestHost } from "@typespec/compiler/testing";
import { createModel } from "@typespec/http-client-csharp";
import { buildArmProviderSchema } from "../src/resource-detection.js";
import { resolveArmResources } from "../src/resolve-arm-resources-converter.js";
import { validateAndPruneArmResources } from "../src/arm-resources-validator.js";
import { ok, strictEqual } from "assert";
import type { Diagnostic } from "@typespec/compiler";

const VALIDATION_DIAGNOSTIC_CODES = new Set([
  "@azure-typespec/http-client-csharp-mgmt/invalid-resource-read-response",
  "@azure-typespec/http-client-csharp-mgmt/non-pageable-list-operation",
  "@azure-typespec/http-client-csharp-mgmt/duplicate-resource-id",
  "@azure-typespec/http-client-csharp-mgmt/duplicate-resource-name"
]);

function getValidationDiagnostics(diagnostics: readonly Diagnostic[]) {
  return diagnostics.filter((d) => VALIDATION_DIAGNOSTIC_CODES.has(d.code));
}

describe("ARM Resources Validator", () => {
  let runner: TestHost;
  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });

  // Each test case runs the validation step against the schema produced by
  // both resource resolution paths (the new `resolveArmResources` converter
  // and the legacy `buildArmProviderSchema`) and asserts no validation
  // diagnostics are reported.
  const cases: { name: string; spec: string; expectedResources?: number }[] = [
    {
      name: "well-formed resource",
      expectedResources: 1,
      spec: `
/** Employee properties */
model EmployeeProperties {
  /** Age of employee */
  age?: int32;
}

/** An Employee resource */
model Employee is TrackedResource<EmployeeProperties> {
  ...ResourceNameParameter<Employee>;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Employees {
  get is ArmResourceRead<Employee>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Employee>;
  delete is ArmResourceDeleteWithoutOkAsync<Employee>;
  listByResourceGroup is ArmResourceListByParent<Employee>;
}
`
    },
    {
      name: "parent-child resources",
      expectedResources: 2,
      spec: `
/** Parent properties */
model ParentProperties {
  /** Parent name */
  displayName?: string;
}

/** Parent resource */
model Parent is TrackedResource<ParentProperties> {
  ...ResourceNameParameter<Parent>;
}

/** Child properties */
model ChildProperties {
  /** Child value */
  value?: string;
}

/** Child resource */
@parentResource(Parent)
model Child is ProxyResource<ChildProperties> {
  ...ResourceNameParameter<Child>;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Parents {
  get is ArmResourceRead<Parent>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Parent>;
  delete is ArmResourceDeleteWithoutOkAsync<Parent>;
  listByResourceGroup is ArmResourceListByParent<Parent>;
}

@armResourceOperations
interface Children {
  get is ArmResourceRead<Child>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Child>;
  delete is ArmResourceDeleteWithoutOkAsync<Child>;
  listByParent is ArmResourceListByParent<Child>;
}
`
    },
    {
      name: "multi-scope resources",
      spec: `
/** Widget properties */
model WidgetProperties {
  /** Color */
  color?: string;
}

/** A Widget resource */
model Widget is TrackedResource<WidgetProperties> {
  ...ResourceNameParameter<Widget>;
}

interface Operations extends Azure.ResourceManager.Operations {}

@armResourceOperations
interface Widgets {
  get is ArmResourceRead<Widget>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Widget>;
  delete is ArmResourceDeleteWithoutOkAsync<Widget>;
  listByResourceGroup is ArmResourceListByParent<Widget>;
  listBySubscription is ArmListBySubscription<Widget>;
}
`
    }
  ];

  for (const { name, spec, expectedResources } of cases) {
    it(`emits no error diagnostics for ${name} (resolveArmResources path)`, async () => {
      const program = await typeSpecCompile(spec, runner);
      const context = createEmitterContext(program);
      const sdkContext = await createCSharpSdkContext(context);

      const resolvedSchema = resolveArmResources(program, sdkContext);
      ok(resolvedSchema);
      if (expectedResources !== undefined) {
        strictEqual(resolvedSchema.resources.length, expectedResources);
      }

      const validatedSchema = validateAndPruneArmResources(
        program,
        sdkContext,
        resolvedSchema
      );
      ok(validatedSchema);

      strictEqual(
        getValidationDiagnostics(program.diagnostics).length,
        0,
        `${name} should not produce any validation diagnostics on the resolveArmResources path`
      );
    });

    it(`emits no error diagnostics for ${name} (buildArmProviderSchema path)`, async () => {
      const program = await typeSpecCompile(spec, runner);
      const context = createEmitterContext(program);
      const sdkContext = await createCSharpSdkContext(context);
      const [root] = createModel(sdkContext);

      const legacySchema = buildArmProviderSchema(sdkContext, root);
      ok(legacySchema);

      const validatedSchema = validateAndPruneArmResources(
        program,
        sdkContext,
        legacySchema
      );
      ok(validatedSchema);

      strictEqual(
        getValidationDiagnostics(program.diagnostics).length,
        0,
        `${name} should not produce any validation diagnostics on the buildArmProviderSchema path`
      );
    });
  }
});
