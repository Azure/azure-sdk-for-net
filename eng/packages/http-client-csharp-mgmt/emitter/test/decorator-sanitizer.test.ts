// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { deepStrictEqual, strictEqual } from "assert";
import { describe, it } from "vitest";
import { removeUnusedDecoratorArguments } from "../src/decorator-sanitizer.js";
import { armProviderSchema, clientOption } from "../src/sdk-context-options.js";

describe("Decorator sanitizer", () => {
  it("removes unused arguments without claiming shared references", () => {
    const sharedType = {
      decorators: [
        {
          name: "TypeSpec.@maxLength",
          arguments: { value: 10 }
        }
      ]
    };
    const unusedDecorator = {
      name: "Azure.ResourceManager.Private.@armResourceInternal",
      arguments: { type: sharedType }
    };
    const providerSchemaDecorator = {
      name: armProviderSchema,
      arguments: { type: sharedType }
    };
    const clientOptionDecorator = {
      name: clientOption,
      arguments: { name: "disable-safe-flatten", value: true }
    };
    const codeModel = {
      decorators: [
        unusedDecorator,
        providerSchemaDecorator,
        clientOptionDecorator
      ],
      models: [sharedType]
    };

    removeUnusedDecoratorArguments(codeModel);

    deepStrictEqual(unusedDecorator.arguments, {});
    deepStrictEqual(sharedType.decorators[0].arguments, {});
    strictEqual(providerSchemaDecorator.arguments.type, sharedType);
    deepStrictEqual(clientOptionDecorator.arguments, {
      name: "disable-safe-flatten",
      value: true
    });
  });
});
