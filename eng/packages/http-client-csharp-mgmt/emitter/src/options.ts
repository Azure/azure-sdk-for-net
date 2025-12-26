// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  AzureEmitterOptions,
  AzureEmitterOptionsSchema
} from "@azure-typespec/http-client-csharp";
import { JSONSchemaType } from "@typespec/compiler";

export interface AzureMgmtEmitterOptions extends AzureEmitterOptions {
  "enable-wire-path-attribute"?: boolean;
  "use-resolve-arm-resources"?: boolean;
}

export const AzureMgmtEmitterOptionsSchema: JSONSchemaType<AzureMgmtEmitterOptions> =
  {
    type: "object",
    additionalProperties: false,
    properties: {
      ...AzureEmitterOptionsSchema.properties,
      "enable-wire-path-attribute": {
        type: "boolean",
        nullable: true,
        description:
          "Whether to enable the WirePathAttribute on model properties. The default value is 'false'.",
        default: false
      },
      "use-resolve-arm-resources": {
        type: "boolean",
        nullable: true,
        description:
          "Whether to use the resolveArmResources API from @azure-tools/typespec-azure-resource-manager for resource detection. When enabled, the standardized resolveArmResources API is used instead of the custom resource detection logic. The default value is 'false'.",
        default: false
      }
    }
  };
