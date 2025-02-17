// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { InputOperation } from "./input-operation.js";

export interface OperationPaging {
  NextLinkName?: string;
  ItemName?: string;
  NextLinkOperation?: InputOperation;
  NextLinkOperationRef?: (p: any) => void;
}
