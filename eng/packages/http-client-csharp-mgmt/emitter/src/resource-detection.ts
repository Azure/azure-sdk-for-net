// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  CodeModel,
  InputClient,
  InputModelType
} from "@typespec/http-client-csharp";
import {
  calculateResourceTypeFromPath,
  ResourceMetadata
} from "./resource-metadata.js";
import { DecoratorInfo } from "@azure-tools/typespec-client-generator-core";

// https://github.com/microsoft/typespec/blob/main/packages/rest/README.md#parentresource
export const parentResource = "TypeSpec.Rest.@parentResource";
export const parentResourceRegex = "TypeSpec\\.Rest\\.@parentResource";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armresourceoperations
export const armResourceOperations =
  "Azure.ResourceManager.@armResourceOperations";
export const armResourceOperationsRegex =
  "Azure\\.ResourceManager\\.@armResourceOperations";

// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#armResourceRead
export const armResourceRead = "Azure.ResourceManager.@armResourceRead";
export const armResourceReadRegex =
  "Azure\\.ResourceManager\\.@armResourceRead";

export const armResourceCreateOrUpdate =
  "Azure.ResourceManager.@armResourceCreateOrUpdate";
export const armResourceCreateOrUpdateRegex =
  "Azure\\.ResourceManager\\.@armResourceCreateOrUpdate";
// https://github.com/Azure/typespec-azure/blob/main/packages/typespec-azure-resource-manager/README.md#singleton
export const singleton = "Azure.ResourceManager.@singleton";
export const singletonRegex = "Azure\\.ResourceManager\\.@singleton";

// TODO: add this decorator to TCGC
export const resourceMetadata = "Azure.ClientGenerator.Core.@resourceSchema";
export const resourceMetadataRegex =
  "Azure\\.ClientGenerator\\.Core\\.@resourceSchema";

export function updateClients(codeModel: CodeModel) {
  // first we flatten all possible clients in the code model
  const clients = getAllClients(codeModel);

  // first pass to update all the clients with their own information
  const metadata: Map<InputClient, ResourceMetadata> = new Map();
  for (const client of clients) {
    gatherResourceMetadata(client, metadata);
  }

  // add the decorator to the client
  for (const client of clients) {
    const resourceMetadata = metadata.get(client);
    if (resourceMetadata) {
      addResourceMetadata(client, resourceMetadata);
    }
  }
}

function getAllClients(codeModel: CodeModel): InputClient[] {
  const clients: InputClient[] = [];
  for (const client of codeModel.clients) {
    traverseClient(client);
  }

  return clients;

  function traverseClient(client: InputClient) {
    clients.push(client);
    if (client.children) {
      for (const child of client.children) {
        traverseClient(child);
      }
    }
  }
}

function gatherResourceMetadata(
  client: InputClient,
  metadataMap: Map<InputClient, ResourceMetadata>
) {
  // TODO: we can implement this decorator in TCGC until we meet the corner case
  // if the client has resourceMetadata decorator, it is a resource client and we don't need to add it again
  if (client.decorators?.some((d) => d.name == resourceMetadata)) {
    return;
  }

  // TODO: Once we have the ability to get resource hierarchy from TCGC directly, we can remove this implementation
  // A resource client should have decorator armResourceOperations and contains either a get operation(containing armResourceRead deocrator) or a put operation(containing armResourceCreateOrUpdate decorator)
  if (
    client.decorators?.some((d) => d.name == armResourceOperations) &&
    client.methods.some(
      (m) =>
        m.operation.decorators?.some(
          (d) => d.name == armResourceRead || armResourceCreateOrUpdate
        )
    )
  ) {
    let resourceModel: InputModelType | undefined = undefined;
    let isSingleton: boolean = false;
    let resourceType: string | undefined = undefined;
    // We will try to get resource metadata from put operation firstly, if not found, we will try to get it from get operation
    const putOperation = client.methods.find(
      (m) =>
        m.operation.decorators?.some((d) => d.name == armResourceCreateOrUpdate)
    )?.operation;
    if (putOperation) {
      const path = putOperation.path;
      resourceType = calculateResourceTypeFromPath(path);
      resourceModel = putOperation.responses.filter((r) => r.bodyType)[0]
        .bodyType as InputModelType;
      isSingleton =
        resourceModel.decorators?.some((d) => d.name == singleton) ?? false;
    } else {
      const getOperation = client.methods.find(
        (m) => m.operation.decorators?.some((d) => d.name == armResourceRead)
      )?.operation;
      if (getOperation) {
        const path = getOperation.path;
        resourceType = calculateResourceTypeFromPath(path);
        resourceModel = getOperation.responses.filter((r) => r.bodyType)[0]
          .bodyType as InputModelType;
        isSingleton =
          resourceModel.decorators?.some((d) => d.name == singleton) ?? false;
      }
    }

    if (resourceModel && resourceType) {
      const metadata = {
        resourceModel: resourceModel,
        resourceClient: client,
        resourceType: resourceType,
        isSingleton: isSingleton,
      };
      metadataMap.set(client, metadata);
    }
  }
}

function addResourceMetadata(client: InputClient, metadata: ResourceMetadata) {
  const resourceMetadataDecorator: DecoratorInfo = {
    name: resourceMetadata,
    arguments: {
      resourceModel: metadata.resourceModel.crossLanguageDefinitionId,
      isSingleton: metadata.isSingleton,
      resourceType: metadata.resourceType
    }
  };

  if (!client.decorators) {
    client.decorators = [];
  }

  client.decorators.push(resourceMetadataDecorator);
}
