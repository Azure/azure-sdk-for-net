// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  createTypeSpecLibrary,
  DiagnosticDefinition,
  DiagnosticMessages,
  paramMessage
} from "@typespec/compiler";
import { $lib as httpClientCSharpLib } from "@typespec/http-client-csharp";
import { AzureMgmtEmitterOptionsSchema } from "../options.js";

const diags: { [code: string]: DiagnosticDefinition<DiagnosticMessages> } = {
  ...httpClientCSharpLib.diagnostics,
  "malformed-resource-detected": {
    severity: "warning",
    messages: {
      default: paramMessage`{message}`
    }
  }
};

export const $lib = createTypeSpecLibrary({
  name: "@azure-typespec/http-client-csharp-mgmt",
  diagnostics: diags,
  emitter: {
    options: AzureMgmtEmitterOptionsSchema
  }
});
