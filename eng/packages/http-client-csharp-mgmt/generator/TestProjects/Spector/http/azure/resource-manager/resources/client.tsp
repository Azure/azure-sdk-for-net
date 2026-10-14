// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

import "../../../../../../../node_modules/@azure-tools/azure-http-specs/specs/azure/resource-manager/resources/main.tsp";
import "@azure-tools/typespec-client-generator-core";

// Skip this scenario until the upstream GET/LIST request-name collision is fixed.
// https://github.com/microsoft/typespec/issues/12175
@@Azure.ClientGenerator.Core.scope(
  Azure.ResourceManager.Resources.Singleton.listByResourceGroup,
  "!csharp"
);
