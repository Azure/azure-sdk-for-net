// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createTypeSpecLibrary } from "@typespec/compiler";
import { $lib as mgmtLib } from "@azure-typespec/http-client-csharp-mgmt";
import { AzureProvisioningEmitterOptionsSchema } from "../options.js";

export const $lib = createTypeSpecLibrary({
  name: "@azure-typespec/http-client-csharp-provisioning",
  diagnostics: {
    ...mgmtLib.diagnostics
  },
  emitter: {
    options: AzureProvisioningEmitterOptionsSchema
  }
});
