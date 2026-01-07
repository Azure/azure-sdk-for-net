// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Rest;
using TypeSpec.Http;
using Azure.ResourceManager;
using Azure.Core;

namespace MgmtTypeSpec;

@armResourceOperations
interface Configurations {
  @route("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Advisor/configurations")
  @list
  @get
  listByResourceGroup(
    ...ApiVersionParameter,
    ...SubscriptionIdParameter,

    /**
     * The name of the Azure resource group.
     */
    @path
    resourceGroup: string,
  ): ArmResponse<ConfigurationListResult> | ErrorResponse;
}

model ConfigurationData is ProxyResource<ConfigurationProperties> {
  ...ResourceNameParameter<ConfigurationData, SegmentName = "configurations">;
}

model ConfigurationProperties {
  exclude?: boolean;
  lowCpuThreshold?: string;
}

model ConfigurationListResult is Azure.Core.Page<ConfigurationData>;
