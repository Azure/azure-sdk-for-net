import { createTypeSpecLibrary } from "@typespec/compiler";
import {
    $lib as httpClientCSharpLib,
  } from "@typespec/http-client-csharp";
import { AzureEmitterOptionsSchema } from "../options.js";

export const $lib = createTypeSpecLibrary({
  name: "@azure-typespec/http-client-csharp",
  diagnostics: httpClientCSharpLib.diagnostics,
  emitter: {
    options: AzureEmitterOptionsSchema,
  },
});