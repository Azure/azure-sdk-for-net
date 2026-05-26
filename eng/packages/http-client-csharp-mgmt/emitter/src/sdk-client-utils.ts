// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

/**
 * Utility functions for working with SDK clients.
 * This module is shared by both resource-detection.ts and resolve-arm-resources-converter.ts
 * to avoid circular dependencies.
 */

import {
  SdkClientType,
  SdkContext,
  SdkHttpOperation,
  SdkServiceOperation
} from "@azure-tools/typespec-client-generator-core";

/**
 * Recursively traverse a client and its children, adding all to the provided array.
 */
export function traverseClient<T extends { children?: T[] }>(
  client: T,
  clients: T[]
) {
  clients.push(client);
  if (client.children) {
    for (const child of client.children) {
      traverseClient(child, clients);
    }
  }
}

/**
 * Get all SDK clients from the SDK package, including nested children.
 */
export function getAllSdkClients(
  sdkContext: SdkContext<any, SdkHttpOperation>
): SdkClientType<SdkServiceOperation>[] {
  const clients: SdkClientType<SdkServiceOperation>[] = [];
  for (const client of sdkContext.sdkPackage.clients) {
    traverseClient(client, clients);
  }

  return clients;
}
