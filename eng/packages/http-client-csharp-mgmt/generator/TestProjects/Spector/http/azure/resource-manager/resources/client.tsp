// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

import "../../../../../../../node_modules/@azure-tools/azure-http-specs/specs/azure/resource-manager/resources/main.tsp";
import "@azure-tools/typespec-client-generator-core";

// GET and LIST otherwise both become CreateGetByResourceGroupRequest in the REST client.
@@Azure.ClientGenerator.Core.clientName(
  Azure.ResourceManager.Resources.Singleton.listByResourceGroup,
  "getAllByResourceGroup",
  "csharp"
);
