// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { DecoratorInfo } from "@azure-tools/typespec-client-generator-core";
import { InputOperation } from "./input-operation.js";
import { InputParameter } from "./input-parameter.js";
import { Protocols } from "./protocols.js";

export interface InputClient {
  Name: string;
  Summary?: string;
  Doc?: string;
  Operations: InputOperation[];
  Protocol?: Protocols;
  Parent?: string;
  Parameters?: InputParameter[];
  Decorators?: DecoratorInfo[];
}
