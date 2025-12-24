// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  createTypeSpecLibrary,
  DiagnosticDefinition,
  DiagnosticMessages
} from "@typespec/compiler";
import { $lib as httpClientCSharpLib } from "@typespec/http-client-csharp";
import { AzureMgmtEmitterOptionsSchema } from "../options.js";

const diags: { [code: string]: DiagnosticDefinition<DiagnosticMessages> } = {
  ...httpClientCSharpLib.diagnostics,
  "duplicate-get-method": {
    severity: "error",
    messages: {
      default:
        "Resource {resourceName} has multiple Read methods defined: {operations}. Please ensure only one Read operation is defined per resource to avoid resource detection issues."
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
