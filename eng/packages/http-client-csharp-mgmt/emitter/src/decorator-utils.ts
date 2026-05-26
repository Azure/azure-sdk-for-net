// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  SdkHttpOperation,
  SdkMethod
} from "@azure-tools/typespec-client-generator-core";
import { armResourceCollectionActionName } from "./sdk-context-options.js";

export function isArmResourceCollectionAction(
  method: SdkMethod<SdkHttpOperation> | undefined
): boolean {
  return (
    method?.__raw?.decorators?.some(
      (decorator) =>
        decorator.definition?.name === armResourceCollectionActionName
    ) ?? false
  );
}
