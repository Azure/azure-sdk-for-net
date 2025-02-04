// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  AccessFlags,
  DecoratorInfo,
  SdkBuiltInKinds,
  UsageFlags,
} from "@azure-tools/typespec-client-generator-core";
import { DateTimeKnownEncoding, DurationKnownEncoding } from "@typespec/compiler";

interface InputTypeBase {
  kind: string;
  summary?: string;
  doc?: string;
  deprecation?: string;
  decorators?: DecoratorInfo[];
}

export type InputType =
  | InputPrimitiveType
  | InputDateTimeType
  | InputDurationType
  | InputLiteralType
  | InputUnionType
  | InputModelType
  | InputEnumType
  | InputArrayType
  | InputDictionaryType
  | InputNullableType;

export interface InputPrimitiveType extends InputTypeBase {
  kind: SdkBuiltInKinds;
  name: string;
  encode?: string; // In TCGC this is required, and when there is no encoding, it just has the same value as kind
  crossLanguageDefinitionId: string;
  baseType?: InputPrimitiveType;
}

export interface InputLiteralType extends InputTypeBase {
  kind: "constant";
  valueType: InputPrimitiveType | InputEnumType; // this has to be inconsistent because currently we have possibility of having an enum underlying the literal type
  value: string | number | boolean | null;
}

export function isInputLiteralType(type: InputType): type is InputLiteralType {
  return type.kind === "constant";
}

export type InputDateTimeType = InputUtcDateTimeType | InputOffsetDateTimeType;

interface InputDateTimeTypeBase extends InputTypeBase {
  name: string;
  encode: DateTimeKnownEncoding;
  wireType: InputPrimitiveType;
  crossLanguageDefinitionId: string;
  baseType?: InputDateTimeType;
}

export interface InputUtcDateTimeType extends InputDateTimeTypeBase {
  kind: "utcDateTime";
}

export interface InputOffsetDateTimeType extends InputDateTimeTypeBase {
  kind: "offsetDateTime";
}

export interface InputDurationType extends InputTypeBase {
  kind: "duration";
  name: string;
  encode: DurationKnownEncoding;
  wireType: InputPrimitiveType;
  crossLanguageDefinitionId: string;
  baseType?: InputDurationType;
}

export interface InputUnionType extends InputTypeBase {
  kind: "union";
  name: string;
  variantTypes: InputType[];
}

export function isInputUnionType(type: InputType): type is InputUnionType {
  return type.kind === "union";
}

export interface InputModelType extends InputTypeBase {
  kind: "model";
  properties: InputModelProperty[];
  name: string;
  crossLanguageDefinitionId: string;
  access?: AccessFlags;
  usage: UsageFlags;
  additionalProperties?: InputType;
  discriminatorValue?: string;
  discriminatedSubtypes?: Record<string, InputModelType>;
  discriminatorProperty?: InputModelProperty;
  baseModel?: InputModelType;
}

export interface InputModelProperty extends InputTypeBase {
  kind: "property";
  name: string;
  serializedName: string;
  type: InputType;
  optional: boolean;
  readOnly: boolean;
  discriminator: boolean;
  crossLanguageDefinitionId: string;
  flatten: boolean;
}

export function isInputModelType(type: InputType): type is InputModelType {
  return type.kind === "model";
}

export interface InputEnumType extends InputTypeBase {
  kind: "enum";
  name: string;
  crossLanguageDefinitionId: string;
  valueType: InputPrimitiveType;
  values: InputEnumTypeValue[];
  isFixed: boolean;
  isFlags: boolean;
  usage: UsageFlags;
  access?: AccessFlags;
}

export interface InputEnumTypeValue extends InputTypeBase {
  kind: "enumvalue";
  name: string;
  value: string | number;
  enumType: InputEnumType;
  valueType: InputPrimitiveType;
}

export interface InputNullableType extends InputTypeBase {
  kind: "nullable";
  type: InputType;
}

export function isInputEnumType(type: InputType): type is InputEnumType {
  return type.kind === "enum";
}

export interface InputArrayType extends InputTypeBase {
  kind: "array";
  name: string;
  valueType: InputType;
  crossLanguageDefinitionId: string;
}

export function isInputArrayType(type: InputType): type is InputArrayType {
  return type.kind === "array";
}

export interface InputDictionaryType extends InputTypeBase {
  kind: "dict";
  keyType: InputType;
  valueType: InputType;
}

export function isInputDictionaryType(type: InputType): type is InputDictionaryType {
  return type.kind === "dict";
}
