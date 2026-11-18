// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { deepStrictEqual, strictEqual } from "assert";
import { describe, it } from "vitest";
import { removeReferenceIdsFromUnknownValues } from "../src/reference-metadata-sanitizer.js";

describe("Reference metadata sanitizer", () => {
  it("removes reference IDs only from opaque values", () => {
    const opaqueValue = {
      $id: "2",
      kind: "unknown",
      value: {
        $id: "https://example.com/schema.json",
        nested: {
          $id: "nested"
        }
      }
    };
    const typedValue = {
      $id: "3",
      kind: "model",
      value: {
        $id: "4"
      }
    };
    const codeModel = {
      $id: "1",
      examples: [opaqueValue, typedValue]
    };

    removeReferenceIdsFromUnknownValues(codeModel);

    strictEqual(codeModel.$id, "1");
    strictEqual(opaqueValue.$id, "2");
    deepStrictEqual(opaqueValue.value, { nested: {} });
    strictEqual(typedValue.$id, "3");
    deepStrictEqual(typedValue.value, { $id: "4" });
  });
});
