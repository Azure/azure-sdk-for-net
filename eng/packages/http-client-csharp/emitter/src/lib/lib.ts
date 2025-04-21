// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createTypeSpecLibrary, DiagnosticDefinition, DiagnosticMessages } from "@typespec/compiler";
import { $lib as httpClientCSharpLib } from "@typespec/http-client-csharp";
import { AzureEmitterOptionsSchema } from "../options.js";

const diags: { [code: string]: DiagnosticDefinition<DiagnosticMessages> } = {
  ...httpClientCSharpLib.diagnostics,
  "invalid-model-namespace-usage": {
    severity: "warning",
    messages: {
      default:
        "Cannot generate CSharp SDK since no public root client is defined in typespec file.",
    },
  }
};

export const $lib = createTypeSpecLibrary({
  name: "@azure-typespec/http-client-csharp",
  diagnostics: diags,
  emitter: {
    options: AzureEmitterOptionsSchema
  }
});
