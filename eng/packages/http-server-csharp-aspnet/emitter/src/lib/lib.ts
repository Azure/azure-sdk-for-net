// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  createTypeSpecLibrary,
  DiagnosticDefinition,
  DiagnosticMessages
} from "@typespec/compiler";
import { $lib as httpClientCSharpLib } from "@typespec/http-client-csharp";
import { AspNetServerEmitterOptionsSchema } from "../options.js";

const diags: { [code: string]: DiagnosticDefinition<DiagnosticMessages> } = {
  ...httpClientCSharpLib.diagnostics
};

export const $lib = createTypeSpecLibrary({
  name: "@azure-typespec/http-server-csharp-aspnet",
  diagnostics: diags,
  emitter: {
    options: AspNetServerEmitterOptionsSchema
  }
});
