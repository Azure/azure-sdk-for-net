// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { describe, it, expect } from "vitest";
import type {
  SdkHttpOperation,
  SdkMethod
} from "@azure-tools/typespec-client-generator-core";
import { isProviderPollingOperation } from "../src/polling-operations.js";

describe("provider polling operation detection", () => {
  it.each([
    ["get", "/providers/Microsoft.Foo/operationStatuses/{operationId}", true],
    [
      "get",
      "/subscriptions/{subscriptionId}/providers/Microsoft.Foo/operationResults/{operationId}",
      true
    ],
    [
      "get",
      "/providers/Microsoft.Foo/locations/{location}/operationStatuses/{operationId}",
      true
    ],
    [
      "get",
      "/subscriptions/{subscriptionId}/providers/Microsoft.Foo/locations/{location}/operationResults/{operationId}",
      true
    ],
    ["get", "/providers/Microsoft.Foo/operationStatuses/{name}", true],
    [
      "get",
      "/providers/Microsoft.Foo/operationResults/{operationId}?kind=Location",
      true
    ],
    [
      "get",
      "/providers/Microsoft.Foo/neuroShieldOperationStatuses/{operationId}",
      true
    ],
    [
      "get",
      "/providers/Microsoft.Foo/scheduledActionsOperationStatuses/{operationId}",
      true
    ],
    [
      "get",
      "/providers/Microsoft.Foo/operationStatusesArchive/{operationId}",
      false
    ],
    [
      "get",
      "/providers/Microsoft.Foo/staticSitesOperationResults/{operationId}",
      true
    ],
    [
      "get",
      "/providers/Microsoft.Foo/operationResultsArchive/{operationId}",
      false
    ],
    ["get", "/providers/Microsoft.Foo/operationsStatus/{operationId}", true],
    [
      "get",
      "/providers/Microsoft.Foo/operationsStatusHistory/{operationId}",
      false
    ],
    ["get", "/providers/Microsoft.Foo/operationStatuses/fixed", false],
    [
      "get",
      "/providers/Microsoft.Foo/operationStatuses/{operationId}/details",
      false
    ],
    ["post", "/providers/Microsoft.Foo/operationStatuses/{operationId}", false],
    ["get", "/providers/Microsoft.Foo/operations/{operationId}", false],
    [
      "get",
      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Foo/operationStatuses/{operationId}",
      false
    ],
    [
      "get",
      "/providers/Microsoft.Foo/widgets/{name}/operationStatuses/{operationId}",
      false
    ],
    ["get", "/providers/Microsoft.Foo/operationStatuses", false]
  ])("%s %s => %s", (verb, path, expected) => {
    const method = {
      operation: { kind: "http", verb, path }
    } as SdkMethod<SdkHttpOperation>;
    expect(isProviderPollingOperation(method)).toBe(expected);
  });
});
