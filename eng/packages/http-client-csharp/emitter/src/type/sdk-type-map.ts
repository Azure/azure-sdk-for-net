// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { SdkType } from "@azure-tools/typespec-client-generator-core";
import { InputEnumType, InputModelType, InputType } from "./input-type.js";

export interface SdkTypeMap {
  types: Map<SdkType, InputType>;
  models: Map<string, InputModelType>;
  enums: Map<string, InputEnumType>;
}
