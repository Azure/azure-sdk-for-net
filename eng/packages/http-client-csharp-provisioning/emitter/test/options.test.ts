// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { AzureMgmtEmitterOptionsSchema } from "@azure-typespec/http-client-csharp-mgmt";
import { describe, expect, it } from "vitest";
import { AzureProvisioningEmitterOptionsSchema } from "../src/options.js";

describe("resource detection defaults", () => {
  it("uses resolveArmResources by default for provisioning", () => {
    expect(
      AzureProvisioningEmitterOptionsSchema.properties[
        "use-legacy-resource-detection"
      ]
    ).toHaveProperty("default", false);
  });

  it("preserves legacy resource detection by default for management", () => {
    expect(
      AzureMgmtEmitterOptionsSchema.properties["use-legacy-resource-detection"]
    ).toHaveProperty("default", true);
  });
});
