// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { BodyMediaType } from "./body-media-type.js";
import { HttpResponseHeader } from "./http-response-header.js";
import { InputType } from "./input-type.js";

export interface OperationResponse {
  StatusCodes: number[];
  BodyType?: InputType;
  BodyMediaType: BodyMediaType;
  Headers: HttpResponseHeader[];
  ContentTypes?: string[];
  IsErrorResponse: boolean;
}
