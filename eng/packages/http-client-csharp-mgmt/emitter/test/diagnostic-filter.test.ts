import { Diagnostic, NoTarget } from "@typespec/compiler";
import { describe, it } from "vitest";
import { strictEqual, deepStrictEqual } from "assert";
import {
  filterSuppressedDiagnostics,
  suppressedUpstreamDiagnosticCodes
} from "../src/options.js";

function createDiagnostic(code: string): Diagnostic {
  return {
    code,
    severity: "warning",
    message: `Test diagnostic: ${code}`,
    target: NoTarget
  };
}

describe("Diagnostic filtering", () => {
  it("filters out suppressed TCGC diagnostic", () => {
    const diagnostics: Diagnostic[] = [
      createDiagnostic(
        "@azure-tools/typespec-client-generator-core/unsupported-generic-decorator-arg-type"
      )
    ];
    const result = filterSuppressedDiagnostics(diagnostics);
    strictEqual(result.length, 0);
  });

  it("filters out suppressed patch convenience method diagnostic", () => {
    const diagnostics: Diagnostic[] = [
      createDiagnostic(
        "@typespec/http-client-csharp/unsupported-patch-convenience-method"
      )
    ];
    const result = filterSuppressedDiagnostics(diagnostics);
    strictEqual(result.length, 0);
  });

  it("preserves non-suppressed diagnostics", () => {
    const diagnostics: Diagnostic[] = [
      createDiagnostic("some-library/some-other-warning"),
      createDiagnostic(
        "@azure-typespec/http-client-csharp-mgmt/malformed-resource-detected"
      )
    ];
    const result = filterSuppressedDiagnostics(diagnostics);
    strictEqual(result.length, 2);
    deepStrictEqual(
      result.map((d) => d.code),
      [
        "some-library/some-other-warning",
        "@azure-typespec/http-client-csharp-mgmt/malformed-resource-detected"
      ]
    );
  });

  it("filters suppressed diagnostics while preserving others", () => {
    const diagnostics: Diagnostic[] = [
      createDiagnostic("some-library/important-warning"),
      createDiagnostic(
        "@azure-tools/typespec-client-generator-core/unsupported-generic-decorator-arg-type"
      ),
      createDiagnostic(
        "@azure-typespec/http-client-csharp-mgmt/malformed-resource-detected"
      ),
      createDiagnostic(
        "@typespec/http-client-csharp/unsupported-patch-convenience-method"
      )
    ];
    const result = filterSuppressedDiagnostics(diagnostics);
    strictEqual(result.length, 2);
    deepStrictEqual(
      result.map((d) => d.code),
      [
        "some-library/important-warning",
        "@azure-typespec/http-client-csharp-mgmt/malformed-resource-detected"
      ]
    );
  });

  it("returns empty array when all diagnostics are suppressed", () => {
    const diagnostics: Diagnostic[] = [
      createDiagnostic(
        "@azure-tools/typespec-client-generator-core/unsupported-generic-decorator-arg-type"
      ),
      createDiagnostic(
        "@typespec/http-client-csharp/unsupported-patch-convenience-method"
      )
    ];
    const result = filterSuppressedDiagnostics(diagnostics);
    strictEqual(result.length, 0);
  });

  it("returns all diagnostics when none are suppressed", () => {
    const diagnostics: Diagnostic[] = [
      createDiagnostic("lib-a/warning-1"),
      createDiagnostic("lib-b/warning-2")
    ];
    const result = filterSuppressedDiagnostics(diagnostics);
    strictEqual(result.length, 2);
  });

  it("handles empty diagnostics array", () => {
    const result = filterSuppressedDiagnostics([]);
    strictEqual(result.length, 0);
  });

  it("suppressed codes set contains expected entries", () => {
    strictEqual(
      suppressedUpstreamDiagnosticCodes.has(
        "@azure-tools/typespec-client-generator-core/unsupported-generic-decorator-arg-type"
      ),
      true
    );
    strictEqual(
      suppressedUpstreamDiagnosticCodes.has(
        "@typespec/http-client-csharp/unsupported-patch-convenience-method"
      ),
      true
    );
    strictEqual(suppressedUpstreamDiagnosticCodes.size, 2);
  });
});
