// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { deepStrictEqual, strictEqual } from "assert";
import { describe, it } from "vitest";
import { removeModelDecoratorArguments } from "../src/decorator-sanitizer.js";
import { armProviderSchema, clientOption } from "../src/sdk-context-options.js";

describe("Decorator sanitizer", () => {
  it("removes only listed model decorator arguments", () => {
    const sharedType = {
      decorators: [
        {
          name: "TypeSpec.@maxLength",
          arguments: { value: 10 }
        }
      ]
    };
    const modelDecorator = {
      name: "Azure.ResourceManager.Private.@armResourceInternal",
      arguments: { type: sharedType }
    };
    const unknownDecorator = {
      name: "Contoso.@unknown",
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
        modelDecorator,
        unknownDecorator,
        providerSchemaDecorator,
        clientOptionDecorator
      ],
      models: [sharedType]
    };

    removeModelDecoratorArguments(codeModel);

    deepStrictEqual(modelDecorator.arguments, {});
    strictEqual(unknownDecorator.arguments.type, sharedType);
    deepStrictEqual(sharedType.decorators[0].arguments, { value: 10 });
    strictEqual(providerSchemaDecorator.arguments.type, sharedType);
    deepStrictEqual(clientOptionDecorator.arguments, {
      name: "disable-safe-flatten",
      value: true
    });
  });
});
