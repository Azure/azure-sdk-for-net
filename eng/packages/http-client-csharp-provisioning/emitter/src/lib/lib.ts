// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  createTypeSpecLibrary,
  DiagnosticDefinition,
  DiagnosticMessages,
  paramMessage
} from "@typespec/compiler";
import { $lib as mgmtLib } from "@azure-typespec/http-client-csharp-mgmt";
import { AzureProvisioningEmitterOptionsSchema } from "../options.js";

const diags: { [code: string]: DiagnosticDefinition<DiagnosticMessages> } = {
  ...mgmtLib.diagnostics,
  "rbac-role-guid-conflict": {
    severity: "warning",
    messages: {
      default: paramMessage`${"message"}`
    }
  },
  "rbac-role-name-collision": {
    severity: "warning",
    messages: {
      default: paramMessage`${"message"}`
    }
  }
};

export const $lib = createTypeSpecLibrary({
  name: "@azure-typespec/http-client-csharp-provisioning",
  diagnostics: diags,
  emitter: {
    options: AzureProvisioningEmitterOptionsSchema
  }
});
