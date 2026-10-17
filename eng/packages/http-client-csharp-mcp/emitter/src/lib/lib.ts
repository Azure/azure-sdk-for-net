// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createTypeSpecLibrary, paramMessage } from "@typespec/compiler";
import { McpEmitterOptionsSchema } from "../options.js";

export const $lib = createTypeSpecLibrary({
  name: "@azure-typespec/mcp-tools",
  diagnostics: {
    "invalid-configuration": {
      severity: "error",
      messages: {
        default: paramMessage`${"message"}`
      }
    }
  },
  emitter: {
    options: McpEmitterOptionsSchema
  }
});
