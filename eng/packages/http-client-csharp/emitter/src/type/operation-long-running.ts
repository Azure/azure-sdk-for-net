// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { OperationFinalStateVia } from "./operation-final-state-via.js";
import { OperationResponse } from "./operation-response.js";

export interface OperationLongRunning {
  FinalStateVia: OperationFinalStateVia;
  FinalResponse: OperationResponse;
  ResultPath?: string;
}
