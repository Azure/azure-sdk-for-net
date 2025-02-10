// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  SdkArrayExampleValue,
  SdkBooleanExampleValue,
  SdkContext,
  SdkDictionaryExampleValue,
  SdkExampleValue,
  SdkHttpOperationExample,
  SdkHttpParameter,
  SdkHttpParameterExampleValue,
  SdkHttpResponse,
  SdkHttpResponseExampleValue,
  SdkModelExampleValue,
  SdkNullExampleValue,
  SdkNumberExampleValue,
  SdkStringExampleValue,
  SdkUnionExampleValue,
  SdkUnknownExampleValue,
} from "@azure-tools/typespec-client-generator-core";
import { NetEmitterOptions } from "../options.js";
import {
  InputArrayExampleValue,
  InputBooleanExampleValue,
  InputDictionaryExampleValue,
  InputExampleValue,
  InputHttpOperationExample,
  InputModelExampleValue,
  InputNullExampleValue,
  InputNumberExampleValue,
  InputParameterExampleValue,
  InputStringExampleValue,
  InputUnionExampleValue,
  InputUnknownExampleValue,
  OperationResponseExample,
} from "../type/input-examples.js";
import { InputParameter } from "../type/input-parameter.js";
import {
  InputArrayType,
  InputDictionaryType,
  InputModelType,
  InputNullableType,
  InputPrimitiveType,
  InputUnionType,
} from "../type/input-type.js";
import { OperationResponse } from "../type/operation-response.js";
import { SdkTypeMap } from "../type/sdk-type-map.js";
import { fromSdkType } from "./converter.js";

export function fromSdkHttpExamples(
  sdkContext: SdkContext<NetEmitterOptions>,
  examples: SdkHttpOperationExample[],
  parameterMap: Map<SdkHttpParameter, InputParameter>,
  responseMap: Map<SdkHttpResponse, OperationResponse>,
  typeMap: SdkTypeMap,
): InputHttpOperationExample[] {
  return examples.map((example) => fromSdkHttpExample(example));

  function fromSdkHttpExample(example: SdkHttpOperationExample): InputHttpOperationExample {
    return {
      kind: "http",
      name: example.name,
      description: example.description,
      filePath: example.filePath,
      parameters: example.parameters.map((p) => fromSdkParameterExample(p)),
      responses: fromSdkOperationResponses(example.responses),
    };
  }

  function fromSdkParameterExample(
    parameter: SdkHttpParameterExampleValue,
  ): InputParameterExampleValue {
    return {
      parameter: parameterMap.get(parameter.parameter)!,
      value: fromSdkExample(parameter.value),
    };
  }

  function fromSdkOperationResponses(
    responses: SdkHttpResponseExampleValue[],
  ): OperationResponseExample[] {
    const result: OperationResponseExample[] = [];
    for (const response of responses) {
      result.push(fromSdkOperationResponse(response));
    }
    return result;
  }

  function fromSdkOperationResponse(
    response: SdkHttpResponseExampleValue,
  ): OperationResponseExample {
    return {
      response: responseMap.get(response.response)!,
      statusCode: response.statusCode,
      bodyValue: response.bodyValue ? fromSdkExample(response.bodyValue) : undefined,
    };
  }

  function fromSdkExample(example: SdkExampleValue): InputExampleValue {
    switch (example.kind) {
      case "string":
        return fromSdkStringExample(example);
      case "number":
        return fromSdkNumberExample(example);
      case "boolean":
        return fromSdkBooleanExample(example);
      case "union":
        return fromSdkUnionExample(example);
      case "array":
        return fromSdkArrayExample(example);
      case "dict":
        return fromSdkDictionaryExample(example);
      case "model":
        return fromSdkModelExample(example);
      case "unknown":
        return fromSdkAnyExample(example);
      case "null":
        return fromSdkNullExample(example);
    }
  }

  function fromSdkStringExample(example: SdkStringExampleValue): InputStringExampleValue {
    return {
      kind: "string",
      type: fromSdkType(example.type, sdkContext, typeMap),
      value: example.value,
    };
  }

  function fromSdkNumberExample(example: SdkNumberExampleValue): InputNumberExampleValue {
    return {
      kind: "number",
      type: fromSdkType(example.type, sdkContext, typeMap),
      value: example.value,
    };
  }

  function fromSdkBooleanExample(example: SdkBooleanExampleValue): InputBooleanExampleValue {
    return {
      kind: example.kind,
      type: fromSdkType(example.type, sdkContext, typeMap) as InputPrimitiveType,
      value: example.value,
    };
  }

  function fromSdkUnionExample(example: SdkUnionExampleValue): InputUnionExampleValue {
    return {
      kind: example.kind,
      type: fromSdkType(example.type, sdkContext, typeMap) as InputUnionType,
      value: example.value,
    };
  }

  function fromSdkArrayExample(example: SdkArrayExampleValue): InputArrayExampleValue {
    return {
      kind: example.kind,
      type: fromSdkType(example.type, sdkContext, typeMap) as InputArrayType,
      value: example.value.map((v) => fromSdkExample(v)),
    };
  }

  function fromSdkDictionaryExample(
    example: SdkDictionaryExampleValue,
  ): InputDictionaryExampleValue {
    return {
      kind: example.kind,
      type: fromSdkType(example.type, sdkContext, typeMap) as InputDictionaryType,
      value: fromExampleRecord(example.value),
    };
  }

  function fromSdkModelExample(example: SdkModelExampleValue): InputModelExampleValue {
    return {
      kind: example.kind,
      type: fromSdkType(example.type, sdkContext, typeMap) as InputModelType,
      value: fromExampleRecord(example.value),
      additionalPropertiesValue: example.additionalPropertiesValue
        ? fromExampleRecord(example.additionalPropertiesValue)
        : undefined,
    };
  }

  function fromSdkAnyExample(example: SdkUnknownExampleValue): InputUnknownExampleValue {
    return {
      kind: example.kind,
      type: fromSdkType(example.type, sdkContext, typeMap) as InputPrimitiveType,
      value: example.value,
    };
  }

  function fromSdkNullExample(example: SdkNullExampleValue): InputNullExampleValue {
    return {
      kind: example.kind,
      type: fromSdkType(example.type, sdkContext, typeMap) as InputNullableType,
      value: example.value,
    };
  }

  function fromExampleRecord(
    value: Record<string, SdkExampleValue>,
  ): Record<string, InputExampleValue> {
    return Object.entries(value).reduce(
      (acc, [key, value]) => {
        acc[key] = fromSdkExample(value);
        return acc;
      },
      {} as Record<string, InputExampleValue>,
    );
  }
}
