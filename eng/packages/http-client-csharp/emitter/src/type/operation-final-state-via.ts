// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
import { FinalStateValue } from "@azure-tools/typespec-azure-core";

export enum OperationFinalStateVia {
  AzureAsyncOperation,
  Location,
  OriginalUri,
  OperationLocation,
  CustomLink,
  CustomOperationReference,
  NoResult,
}

export function convertLroFinalStateVia(finalStateValue: FinalStateValue): OperationFinalStateVia {
  switch (finalStateValue) {
    case FinalStateValue.azureAsyncOperation:
      return OperationFinalStateVia.AzureAsyncOperation;
    // TODO: we don't have implementation of custom-link and custom-operation-reference yet
    // case FinalStateValue.customLink:
    //     return OperationFinalStateVia.CustomLink;

    // And right now some existing API specs are not correctly defined so that they are parsed
    // into `custom-operation-reference` which should be `operation-location`.
    // so let's fallback `custom-operation-reference` into `operation-location` as a work-around
    case FinalStateValue.customOperationReference:
      return OperationFinalStateVia.OperationLocation;
    case FinalStateValue.location:
      return OperationFinalStateVia.Location;
    case FinalStateValue.originalUri:
      return OperationFinalStateVia.OriginalUri;
    case FinalStateValue.operationLocation:
      return OperationFinalStateVia.OperationLocation;
    default:
      throw `Unsupported LRO final state value: ${finalStateValue}`;
  }
}
