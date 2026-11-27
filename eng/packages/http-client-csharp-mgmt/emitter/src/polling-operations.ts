// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import type {
  SdkHttpOperation,
  SdkMethod
} from "@azure-tools/typespec-client-generator-core";

/**
 * Recognize the standard provider-scoped ARM polling routes. These endpoints can
 * be declared independently of an LRO, whose polling URL is returned in a header,
 * so LRO operation links alone do not identify them.
 *
 * Limit this heuristic to GETs with a parameter at the end of a tenant or
 * subscription provider path (optionally scoped to a location). In particular,
 * do not hide resource operations or actions merely because their names match.
 */
export function isProviderPollingOperation(
  method: SdkMethod<SdkHttpOperation> | undefined
): boolean {
  const operation = method?.operation;
  if (!operation || operation.kind !== "http" || operation.verb !== "get") {
    return false;
  }
  const path = operation.path.split("?", 1)[0];
  return /^\/(?:subscriptions\/\{[^/{}]+\}\/)?providers\/[^/{}]+\/(?:locations\/\{[^/{}]+\}\/)?(?:(?:[a-z][a-z0-9]*)?operation(?:Statuses|Results)|operationsStatus)\/\{[^/{}]+\}$/i.test(
    path
  );
}
