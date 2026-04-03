import { TestHost } from "@typespec/compiler/testing";
import { UsageFlags } from "@azure-tools/typespec-client-generator-core";
import { strictEqual } from "assert";
import { beforeEach, describe, it } from "vitest";
import { createModel } from "@typespec/http-client-csharp";
import {
  createCSharpSdkContext,
  createEmitterContext,
  createEmitterTestHost,
  typeSpecCompile
} from "./test-util.js";

describe("Test GetInputType for enum", () => {
  let runner: TestHost;
  beforeEach(async () => {
    runner = await createEmitterTestHost();
  });
  it("Fixed string enum", async () => {
    const program = await typeSpecCompile(
      `
        @doc("fixed string enum")
        enum SimpleEnum {
            @doc("Enum value one")
            One: "1",
            @doc("Enum value two")
            Two: "2",
            @doc("Enum value four")
            Four: "4"
        }
        #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Operation 'test' should be defined using a signature from the Azure.Core namespace."
        @doc("test fixed enum.")
        op test(@doc("fixed enum as input.")@body input: SimpleEnum): string[];
      `,
      runner,
      { IsNamespaceNeeded: true }
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);
    const inputParamArray =
      root.clients[0].methods[0].operation.parameters.filter(
        (p) => p.name === "input"
      );
    strictEqual(1, inputParamArray.length);
    const type = inputParamArray[0].type;
    strictEqual(type.kind, "enum");
    strictEqual(type.name, "SimpleEnum");
    strictEqual(type.isFixed, true);
    strictEqual(type.doc, "fixed string enum");
    strictEqual(
      type.crossLanguageDefinitionId,
      "Azure.Csharp.Testing.SimpleEnum"
    );
    strictEqual(type.access, undefined);
    strictEqual(type.valueType.kind, "string");
    strictEqual(type.values.length, 3);
    strictEqual(type.values[0].name, "One");
    strictEqual(type.values[0].value, "1");
    strictEqual(type.values[1].name, "Two");
    strictEqual(type.values[1].value, "2");
    strictEqual(type.values[2].name, "Four");
    strictEqual(type.values[2].value, "4");
    strictEqual(type.usage, UsageFlags.Input | UsageFlags.Json);
  });
  it("Fixed int enum", async () => {
    const program = await typeSpecCompile(
      `
      @doc("Fixed int enum")
      enum FixedIntEnum {
          @doc("Enum value one")
          One: 1,
          @doc("Enum value two")
          Two: 2,
          @doc("Enum value four")
          Four: 4
      }
      #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Operation 'test' should be defined using a signature from the Azure.Core namespace."
      @doc("test fixed enum.")
      op test(@doc("fixed enum as input.")@body input: FixedIntEnum): string[];
    `,
      runner,
      { IsNamespaceNeeded: true }
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);
    const inputParamArray =
      root.clients[0].methods[0].operation.parameters.filter(
        (p) => p.name === "input"
      );
    strictEqual(1, inputParamArray.length);
    const type = inputParamArray[0].type;
    strictEqual(type.kind, "enum");
    strictEqual(type.name, "FixedIntEnum");
    strictEqual(
      type.crossLanguageDefinitionId,
      "Azure.Csharp.Testing.FixedIntEnum"
    );
    strictEqual(type.access, undefined);
    strictEqual(type.doc, "Fixed int enum");
    strictEqual(type.valueType.crossLanguageDefinitionId, "TypeSpec.int32");
    strictEqual(type.valueType.kind, "int32");
    strictEqual(type.values.length, 3);
    strictEqual(type.values[0].name, "One");
    strictEqual(type.values[0].value, 1);
    strictEqual(type.values[1].name, "Two");
    strictEqual(type.values[1].value, 2);
    strictEqual(type.values[2].name, "Four");
    strictEqual(type.values[2].value, 4);
    strictEqual(type.isFixed, true);
    strictEqual(type.usage, UsageFlags.Input | UsageFlags.Json);
  });
  it("Debug single member enum with alternateType", async () => {
    const program = await typeSpecCompile(
      `
        enum Colors {
          green,
        }
        model EmployeeProperties {
          @Azure.ClientGenerator.Core.alternateType("green")
          favoriteColor: Colors;
        }
        #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "test"
        op test(@body input: EmployeeProperties): string[];
      `,
      runner,
      { IsNamespaceNeeded: true, IsTCGCNeeded: true }
    );
    const context = createEmitterContext(program);
    const sdkContext = await createCSharpSdkContext(context);
    const [root] = createModel(sdkContext);
    
    // Find the model
    const model = root.models.find((m: any) => m.name === "EmployeeProperties");
    console.log("Model found:", model?.name);
    
    const prop = model?.properties?.find((p: any) => p.name === "favoriteColor");
    console.log("favoriteColor type kind:", prop?.type?.kind);
    console.log("favoriteColor type name:", prop?.type?.name);
    if (prop?.type?.kind === "constant") {
      console.log("  constant value:", prop.type.value);
      console.log("  constant valueType.kind:", prop.type.valueType?.kind);
    }
    if (prop?.type?.kind === "enum") {
      console.log("  enum isFixed:", prop.type.isFixed);
      console.log("  enum values:", prop.type.values?.map((v: any) => `${v.name}=${v.value}`));
    }
    
    console.log("\nEnums:", root.enums?.map((e: any) => ({
      name: e.name,
      isFixed: e.isFixed,
      values: e.values?.map((v: any) => `${v.name}=${v.value}`)
    })));
    
    console.log("Constants:", root.constants?.map((c: any) => ({
      name: c.name,
      value: c.value,
      kind: c.kind
    })));
    
    // The issue: type should be enum Colors, not constant "green"
    strictEqual(model !== undefined, true);
    strictEqual(prop !== undefined, true);
  });
});
