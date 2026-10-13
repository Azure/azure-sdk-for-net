// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { getEffectiveApiVersionOverride } from "@azure-tools/typespec-azure-core";
import { CSharpEmitterContext } from "@typespec/http-client-csharp";

const overrideDecorator = "Azure.Core.Legacy.@overrideApiVersion";

export function applyApiVersionOverrides(context: CSharpEmitterContext): void {
  for (const [sdkClient, inputClient] of context.__typeCache.clients) {
    // Client hierarchies can omit namespaces carrying an inherited override.
    const declaration = sdkClient.__raw.type ?? sdkClient.__raw.services[0];
    let version = getEffectiveApiVersionOverride(context.program, declaration);
    if (version === undefined) {
      const defaultVersion = inputClient.parameters?.find((p) => p.isApiVersion)
        ?.defaultValue?.value;
      for (const method of sdkClient.methods) {
        let operation = method.__raw;
        while (operation) {
          const override = getEffectiveApiVersionOverride(
            context.program,
            operation
          );
          if (override !== undefined) {
            if (override === defaultVersion) version = override;
            break;
          }
          operation = operation.sourceOperation;
        }
        if (version !== undefined) break;
      }
    }
    if (version !== undefined) {
      inputClient.decorators = [
        ...(inputClient.decorators ?? []).filter(
          (d) => d.name !== overrideDecorator
        ),
        { name: overrideDecorator, arguments: { version } }
      ];
    }
  }
}
