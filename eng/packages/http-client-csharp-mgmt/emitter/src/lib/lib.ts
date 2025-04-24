// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { AzureEmitterOptionsSchema } from "@azure-typespec/http-client-csharp";
import { createTypeSpecLibrary } from "@typespec/compiler";
import { $lib as httpClientCSharpLib } from "@typespec/http-client-csharp";

export const $lib = createTypeSpecLibrary({
  name: "@azure-typespec/http-client-csharp-mgmt",
  diagnostics: httpClientCSharpLib.diagnostics,
  emitter: {
    options: AzureEmitterOptionsSchema
  }
});
