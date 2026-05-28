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
  },
  "resource-model-not-associated-with-arm-resource": {
    severity: "warning",
    messages: {
      default: paramMessage`Resource model '${"modelName"}' was not detected as an ARM resource because no GET operation returns it from a valid resource instance path.`
    }
  },
  "resource-name-empty-string": {
    severity: "warning",
    messages: {
      default: paramMessage`@@clientOption(..., "resource-name", ...) value is an empty string and will be ignored.`
    }
  },
  "resource-name-bad-entry": {
    severity: "warning",
    messages: {
      default: paramMessage`@@clientOption(..., "resource-name", ...) entry '${"key"}' is not a non-empty string and will be ignored.`
    }
  },
  "resource-name-empty-record": {
    severity: "warning",
    messages: {
      default: paramMessage`@@clientOption(..., "resource-name", ...) value is an empty record and will be ignored.`
    }
  },
  "resource-name-bad-type": {
    severity: "warning",
    messages: {
      default: paramMessage`@@clientOption(..., "resource-name", ...) value must be a string or a Record<enumValue, string>; received ${"actualType"}.`
    }
  },
  "resource-name-string-on-expandable": {
    severity: "warning",
    messages: {
      default: paramMessage`@@clientOption(..., "resource-name", "${"value"}", ...) is a plain string but its Read operation's path '${"path"}' contains a {parentType} segment (expandable). Use a Record<enumValue, string> map form instead.`
    }
  },
  "resource-name-map-on-non-expandable": {
    severity: "warning",
    messages: {
      default: paramMessage`@@clientOption(..., "resource-name", ...) value is a Record but its Read operation's path '${"path"}' does not contain a {parentType} segment (non-expandable). Use a plain string instead.`
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
