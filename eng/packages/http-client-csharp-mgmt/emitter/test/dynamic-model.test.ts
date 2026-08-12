import { describe, expect, it } from "vitest";
import { azureSDKContextOptions } from "../src/sdk-context-options.js";

describe("dynamicModel", () => {
  it("preserves the decorator in the code model", () => {
    expect(azureSDKContextOptions.additionalDecorators).toContain(
      "TypeSpec\\.HttpClient\\.CSharp\\.@dynamicModel"
    );
  });
});
