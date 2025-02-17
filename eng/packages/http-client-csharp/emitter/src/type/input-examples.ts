// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { InputParameter } from "./input-parameter.js";
import {
  InputArrayType,
  InputDictionaryType,
  InputLiteralType,
  InputModelType,
  InputNullableType,
  InputPrimitiveType,
  InputType,
  InputUnionType,
} from "./input-type.js";
import { OperationResponse } from "./operation-response.js";

interface InputExampleBase {
  kind: string;
  name: string;
  description: string;
  filePath: string;
}

export interface InputHttpOperationExample extends InputExampleBase {
  kind: "http";
  parameters: InputParameterExampleValue[];
  responses: OperationResponseExample[];
}

export interface InputParameterExampleValue {
  parameter: InputParameter;
  value: InputExampleValue;
}

export interface OperationResponseExample {
  response: OperationResponse;
  statusCode: number;
  // TODO -- enable this when we are ready to write headers in responses.
  // headers: SdkHttpResponseHeaderExample[];
  bodyValue?: InputExampleValue;
}

export type InputExampleValue =
  | InputStringExampleValue
  | InputNumberExampleValue
  | InputBooleanExampleValue
  | InputNullExampleValue
  | InputUnknownExampleValue
  | InputArrayExampleValue
  | InputDictionaryExampleValue
  | InputUnionExampleValue
  | InputModelExampleValue;

export interface InputExampleTypeValueBase {
  kind: string;
  type: InputType;
  value: unknown;
}
export interface InputStringExampleValue extends InputExampleTypeValueBase {
  kind: "string";
  type: InputType;
  value: string;
}
export interface InputNumberExampleValue extends InputExampleTypeValueBase {
  kind: "number";
  type: InputType;
  value: number;
}
export interface InputBooleanExampleValue extends InputExampleTypeValueBase {
  kind: "boolean";
  type: InputPrimitiveType | InputLiteralType;
  value: boolean;
}
export interface InputNullExampleValue extends InputExampleTypeValueBase {
  kind: "null";
  type: InputNullableType;
  value: null;
}
export interface InputUnknownExampleValue extends InputExampleTypeValueBase {
  kind: "unknown";
  type: InputPrimitiveType;
  value: unknown;
}
export interface InputArrayExampleValue extends InputExampleTypeValueBase {
  kind: "array";
  type: InputArrayType;
  value: InputExampleValue[];
}
export interface InputDictionaryExampleValue extends InputExampleTypeValueBase {
  kind: "dict";
  type: InputDictionaryType;
  value: Record<string, InputExampleValue>;
}
export interface InputUnionExampleValue extends InputExampleTypeValueBase {
  kind: "union";
  type: InputUnionType;
  value: unknown;
}
export interface InputModelExampleValue extends InputExampleTypeValueBase {
  kind: "model";
  type: InputModelType;
  value: Record<string, InputExampleValue>;
  additionalPropertiesValue?: Record<string, InputExampleValue>;
}
