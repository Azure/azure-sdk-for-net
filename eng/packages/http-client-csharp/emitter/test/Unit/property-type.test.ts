import { TestHost } from "@typespec/compiler/testing";
import { UsageFlags } from "@azure-tools/typespec-client-generator-core";
import { strictEqual } from "assert";
import { beforeEach, describe, it } from "vitest";
import { createModel } from "@typespec/http-client-csharp";
import { createCSharpSdkContext, createEmitterContext, createEmitterTestHost, typeSpecCompile, } from "./test-util.js";

describe("Test GetInputType for array", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });
    it("array as request", async () => {
        const program = await typeSpecCompile(`
        op test(@body input: string[]): string[];
      `, runner);
        const context = createEmitterContext(program);
        const sdkContext = await createCSharpSdkContext(context);
        const root = createModel(sdkContext);
        const inputParamArray = root.Clients[0].Operations[0].Parameters.filter((p) => p.Name === "input");
        strictEqual(1, inputParamArray.length);
        const type = inputParamArray[0].Type;
        strictEqual(type.kind, "array");
        strictEqual(type.crossLanguageDefinitionId, "TypeSpec.Array");
        strictEqual(type.valueType.kind, "string");
        strictEqual(type.valueType.crossLanguageDefinitionId, "TypeSpec.string");
    });
    it("array as response", async () => {
        const program = await typeSpecCompile(`
        op test(): string[];
      `, runner);
        const context = createEmitterContext(program);
        const sdkContext = await createCSharpSdkContext(context);
        const root = createModel(sdkContext);
        const bodyType = root.Clients[0].Operations[0].Responses[0].BodyType;
        strictEqual(bodyType?.kind, "array");
        strictEqual(bodyType.crossLanguageDefinitionId, "TypeSpec.Array");
        strictEqual(bodyType.valueType.kind, "string");
        strictEqual(bodyType.valueType.crossLanguageDefinitionId, "TypeSpec.string");
    });
});
describe("Test GetInputType for enum", () => {
    let runner;
    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });
    it("Fixed string enum", async () => {
        const program = await typeSpecCompile(`
        #suppress "@azure-tools/typespec-azure-core/use-extensible-enum" "Enums should be defined without the @fixed decorator."
        @doc("fixed string enum")
        @fixed
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
      `, runner, { IsNamespaceNeeded: true, IsAzureCoreNeeded: true });
        const context = createEmitterContext(program);
        const sdkContext = await createCSharpSdkContext(context);
        const root = createModel(sdkContext);
        const inputParamArray = root.Clients[0].Operations[0].Parameters.filter((p) => p.Name === "input");
        strictEqual(1, inputParamArray.length);
        const type = inputParamArray[0].Type;
        strictEqual(type.kind, "enum");
        strictEqual(type.name, "SimpleEnum");
        strictEqual(type.isFixed, true);
        strictEqual(type.doc, "fixed string enum");
        strictEqual(type.crossLanguageDefinitionId, "Azure.Csharp.Testing.SimpleEnum");
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
        const program = await typeSpecCompile(`
      #suppress "@azure-tools/typespec-azure-core/use-extensible-enum" "Enums should be defined without the @fixed decorator."
      @doc("Fixed int enum")
      @fixed
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
    `, runner, { IsNamespaceNeeded: true, IsAzureCoreNeeded: true });
        const context = createEmitterContext(program);
        const sdkContext = await createCSharpSdkContext(context);
        const root = createModel(sdkContext);
        const inputParamArray = root.Clients[0].Operations[0].Parameters.filter((p) => p.Name === "input");
        strictEqual(1, inputParamArray.length);
        const type = inputParamArray[0].Type;
        strictEqual(type.kind, "enum");
        strictEqual(type.name, "FixedIntEnum");
        strictEqual(type.crossLanguageDefinitionId, "Azure.Csharp.Testing.FixedIntEnum");
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
    it("fixed enum", async () => {
        const program = await typeSpecCompile(`
        @doc("Fixed enum")
        enum FixedEnum {
            One: "1",
            Two: "2",
            Four: "4"
        }
        op test(@body input: FixedEnum): string[];
      `, runner);
        const context = createEmitterContext(program);
        const sdkContext = await createCSharpSdkContext(context);
        const root = createModel(sdkContext);
        const inputParamArray = root.Clients[0].Operations[0].Parameters.filter((p) => p.Name === "input");
        strictEqual(1, inputParamArray.length);
        const type = inputParamArray[0].Type;
        strictEqual(type.kind, "enum");
        strictEqual(type.name, "FixedEnum");
        strictEqual(type.crossLanguageDefinitionId, "Azure.Csharp.Testing.FixedEnum");
        strictEqual(type.access, undefined);
        strictEqual(type.doc, "Fixed enum");
        strictEqual(type.valueType.kind, "string");
        strictEqual(type.valueType.crossLanguageDefinitionId, "TypeSpec.string");
        strictEqual(type.values.length, 3);
        strictEqual(type.values[0].name, "One");
        strictEqual(type.values[0].value, "1");
        strictEqual(type.values[1].name, "Two");
        strictEqual(type.values[1].value, "2");
        strictEqual(type.values[2].name, "Four");
        strictEqual(type.values[2].value, "4");
        strictEqual(type.usage, UsageFlags.Input | UsageFlags.Json);
        strictEqual(type.isFixed, true);
    });
});
//# sourceMappingURL=property-type.test.js.map