// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createTypeSpecLibrary } from "@typespec/compiler";
import { $lib as httpClientCSharpLib } from "@typespec/http-client-csharp";
import { AzureEmitterOptionsSchema } from "../options.js";

export const $lib = createTypeSpecLibrary({
  name: "@azure-typespec/http-client-csharp",
  diagnostics: httpClientCSharpLib.diagnostics,
  emitter: {
    options: AzureEmitterOptionsSchema
  }
});
