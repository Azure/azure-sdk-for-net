// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

/**
 * This module handles the transformation of subscriptionId parameters from client scope to method scope.
 *
 * TCGC puts subscriptionId parameters into the client by default. However, in the management plane SDK,
 * subscriptionId is always part of the operation context and should be a method parameter.
 *
 * In some cases (e.g., GroupQuotaSubscription), subscriptionId in the path is NOT the contextual subscription
 * but a different subscription to operate on. These parameters must be in the method signature.
 *
 * This transformation:
 * 1. For each method, if operation has a subscriptionId path parameter and method.parameters doesn't have it,
 *    insert the parameter in the correct position
 * 2. Recursively traverse from the method's client back to root, removing subscriptionId from all client parameters
 */

import { CodeModel, InputClient } from "@typespec/http-client-csharp";
import { traverseClient } from "./sdk-client-utils.js";

// Local type definitions matching the runtime structure
interface InputParameterLike {
  kind: string;
  name: string;
  summary?: string;
  doc?: string;
  type: unknown;
  optional: boolean;
  readOnly: boolean;
  access?: string;
  serializedName: string;
  isApiVersion: boolean;
  defaultValue?: unknown;
  crossLanguageDefinitionId: string;
  scope?: string;
  location?: string;
}

interface ServiceMethod {
  operation?: {
    parameters?: InputParameterLike[];
  };
  parameters?: InputParameterLike[];
}

/**
 * Transforms subscriptionId parameters from client scope to method scope for all clients in the code model.
 */
export function transformSubscriptionIdParameters(codeModel: CodeModel): void {
  // Collect all clients (including nested children)
  const allClients: InputClient[] = [];
  for (const client of codeModel.clients) {
    traverseClient(client, allClients);
  }

  // Process each client's methods
  for (const client of allClients) {
    for (const method of client.methods as unknown as ServiceMethod[]) {
      if (processMethodSubscriptionId(method)) {
        // If we added subscriptionId to the method, remove it from this client and all parents
        removeSubscriptionIdFromClientChain(client);
      }
    }
  }
}

/**
 * Processes a method to add subscriptionId parameter if needed.
 * Returns true if subscriptionId was added to the method.
 */
function processMethodSubscriptionId(method: ServiceMethod): boolean {
  if (!method.operation?.parameters) {
    return false;
  }

  // Find subscriptionId in operation parameters (path parameter, case-sensitive match)
  const subscriptionIdOpParam = method.operation.parameters.find(
    (p) => p.kind === "path" && p.serializedName === "subscriptionId"
  );

  if (!subscriptionIdOpParam) {
    return false;
  }

  // Check if subscriptionId already exists in method parameters
  const hasSubscriptionIdInMethod = method.parameters?.some(
    (p) => p.serializedName === "subscriptionId"
  );

  if (hasSubscriptionIdInMethod) {
    return false;
  }

  // Change operation parameter scope to Method
  subscriptionIdOpParam.scope = "Method";

  // Create method parameter from operation parameter
  const subscriptionIdMethodParam: InputParameterLike = {
    kind: "method",
    name: subscriptionIdOpParam.name,
    summary: subscriptionIdOpParam.summary,
    doc: subscriptionIdOpParam.doc,
    type: subscriptionIdOpParam.type,
    optional: subscriptionIdOpParam.optional,
    readOnly: subscriptionIdOpParam.readOnly,
    access: subscriptionIdOpParam.access,
    serializedName: subscriptionIdOpParam.serializedName,
    isApiVersion: subscriptionIdOpParam.isApiVersion,
    defaultValue: subscriptionIdOpParam.defaultValue,
    scope: "Method",
    location: "Path",
    crossLanguageDefinitionId: subscriptionIdOpParam.crossLanguageDefinitionId
  };

  // Find correct insert position based on operation parameter order
  const insertPosition = findInsertPosition(
    method.operation.parameters,
    method.parameters || []
  );

  // Insert the parameter
  if (!method.parameters) {
    method.parameters = [];
  }
  method.parameters.splice(insertPosition, 0, subscriptionIdMethodParam);

  return true;
}

/**
 * Finds the position to insert subscriptionId in method parameters
 * based on its position in operation parameters.
 */
function findInsertPosition(
  operationParams: InputParameterLike[],
  methodParams: InputParameterLike[]
): number {
  // Find which parameter subscriptionId comes after in operation parameters
  let insertAfterSerializedName: string | undefined;
  for (const param of operationParams) {
    if (param.serializedName === "subscriptionId") {
      break;
    }
    insertAfterSerializedName = param.serializedName;
  }

  // If subscriptionId is the first parameter, insert at the beginning
  if (!insertAfterSerializedName) {
    return 0;
  }

  // Find the position after the parameter it follows
  for (let i = 0; i < methodParams.length; i++) {
    if (methodParams[i].serializedName === insertAfterSerializedName) {
      return i + 1;
    }
  }

  // If not found, insert at the end
  return methodParams.length;
}

/**
 * Removes subscriptionId from a client and all its parent clients.
 */
function removeSubscriptionIdFromClientChain(client: InputClient): void {
  let current: InputClient | undefined = client;
  while (current) {
    removeSubscriptionIdFromClient(current);
    current = current.parent;
  }
}

/**
 * Removes subscriptionId from a single client's parameters.
 */
function removeSubscriptionIdFromClient(client: InputClient): void {
  const clientParams = client.parameters as unknown as
    | InputParameterLike[]
    | undefined;
  if (!clientParams) {
    return;
  }
  (client as unknown as { parameters: InputParameterLike[] }).parameters =
    clientParams.filter((p) => p.serializedName !== "subscriptionId");
}
