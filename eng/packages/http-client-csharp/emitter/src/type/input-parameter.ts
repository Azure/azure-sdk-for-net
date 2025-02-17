// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { DecoratorInfo } from "@azure-tools/typespec-client-generator-core";
import { InputConstant } from "./input-constant.js";
import { InputOperationParameterKind } from "./input-operation-parameter-kind.js";
import { InputType } from "./input-type.js";
import { RequestLocation } from "./request-location.js";

//TODO: Define VirtualParameter for HLC
export interface VirtualParameter {}
export interface InputParameter {
  Name: string;
  NameInRequest: string;
  Summary?: string;
  Doc?: string;
  Type: InputType;
  Location: RequestLocation;
  DefaultValue?: InputConstant;
  VirtualParameter?: VirtualParameter; //for HLC, set null for typespec
  GroupedBy?: InputParameter;
  Kind: InputOperationParameterKind;
  IsRequired: boolean;
  IsApiVersion: boolean;
  IsResourceParameter: boolean;
  IsContentType: boolean;
  IsEndpoint: boolean;
  SkipUrlEncoding: boolean;
  Explode: boolean;
  ArraySerializationDelimiter?: string;
  HeaderCollectionPrefix?: string;
  Decorators?: DecoratorInfo[];
}
