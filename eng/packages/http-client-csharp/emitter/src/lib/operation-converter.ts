// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  SdkBodyParameter,
  SdkBuiltInKinds,
  SdkContext,
  SdkHeaderParameter,
  SdkHttpOperation,
  SdkHttpParameter,
  SdkHttpResponse,
  SdkPathParameter,
  SdkQueryParameter,
  SdkServiceMethod,
  SdkServiceResponseHeader,
  SdkType,
  shouldGenerateConvenient,
  shouldGenerateProtocol,
} from "@azure-tools/typespec-client-generator-core";
import { getDeprecated, isErrorModel } from "@typespec/compiler";
import { HttpStatusCodeRange } from "@typespec/http";
import { getResourceOperation } from "@typespec/rest";
import { NetEmitterOptions } from "../options.js";
import { BodyMediaType } from "../type/body-media-type.js";
import { collectionFormatToDelimMap } from "../type/collection-format.js";
import { HttpResponseHeader } from "../type/http-response-header.js";
import { InputConstant } from "../type/input-constant.js";
import { InputOperationParameterKind } from "../type/input-operation-parameter-kind.js";
import { InputOperation } from "../type/input-operation.js";
import { InputParameter } from "../type/input-parameter.js";
import { InputType } from "../type/input-type.js";
import { convertLroFinalStateVia } from "../type/operation-final-state-via.js";
import { OperationLongRunning } from "../type/operation-long-running.js";
import { OperationPaging } from "../type/operation-paging.js";
import { OperationResponse } from "../type/operation-response.js";
import { RequestLocation } from "../type/request-location.js";
import { parseHttpRequestMethod } from "../type/request-method.js";
import { SdkTypeMap } from "../type/sdk-type-map.js";
import { fromSdkModelType, fromSdkType } from "./converter.js";
import { getExternalDocs, getOperationId } from "./decorators.js";
import { fromSdkHttpExamples } from "./example-converter.js";
import { Logger } from "./logger.js";
import { isSdkPathParameter } from "./utils.js";

export function fromSdkServiceMethod(
  method: SdkServiceMethod<SdkHttpOperation>,
  uri: string,
  rootApiVersions: string[],
  sdkContext: SdkContext<NetEmitterOptions>,
  typeMap: SdkTypeMap,
): InputOperation {
  let generateConvenience = shouldGenerateConvenient(sdkContext, method.operation.__raw.operation);
  if (method.operation.verb === "patch" && generateConvenience) {
    Logger.getInstance().warn(
      `Convenience method is not supported for PATCH method, it will be automatically turned off. Please set the '@convenientAPI' to false for operation ${method.operation.__raw.operation.name}.`,
    );
    generateConvenience = false;
  }

  const parameterMap = fromSdkOperationParameters(
    method.operation,
    rootApiVersions,
    sdkContext,
    typeMap,
  );
  const responseMap = fromSdkHttpOperationResponses(
    method.operation.responses,
    sdkContext,
    typeMap,
  );
  return {
    Name: method.name,
    ResourceName:
      getResourceOperation(sdkContext.program, method.operation.__raw.operation)?.resourceType
        .name ??
      getOperationGroupName(sdkContext, method.operation, sdkContext.sdkPackage.rootNamespace),
    Deprecated: getDeprecated(sdkContext.program, method.__raw!),
    Summary: method.summary,
    Doc: method.doc,
    Accessibility: method.access,
    Parameters: [...parameterMap.values()],
    Responses: [...responseMap.values()],
    HttpMethod: parseHttpRequestMethod(method.operation.verb),
    RequestBodyMediaType: getBodyMediaType(method.operation.bodyParam?.type),
    Uri: uri,
    Path: method.operation.path,
    ExternalDocsUrl: getExternalDocs(sdkContext, method.operation.__raw.operation)?.url,
    RequestMediaTypes: getRequestMediaTypes(method.operation),
    BufferResponse: true,
    LongRunning: loadLongRunningOperation(method, sdkContext, typeMap),
    Paging: loadOperationPaging(method),
    GenerateProtocolMethod: shouldGenerateProtocol(sdkContext, method.operation.__raw.operation),
    GenerateConvenienceMethod: generateConvenience,
    CrossLanguageDefinitionId: method.crossLanguageDefinitionId,
    Decorators: method.decorators,
    Examples: method.operation.examples
      ? fromSdkHttpExamples(
          sdkContext,
          method.operation.examples,
          parameterMap,
          responseMap,
          typeMap,
        )
      : undefined,
  };
}

export function getParameterDefaultValue(
  clientDefaultValue: any,
  parameterType: InputType,
): InputConstant | undefined {
  if (
    clientDefaultValue === undefined ||
    // a constant parameter should overwrite client default value
    parameterType.kind === "constant"
  ) {
    return undefined;
  }

  const kind = getValueType(clientDefaultValue);
  return {
    Type: {
      kind: kind,
      name: kind,
      crossLanguageDefinitionId: `TypeSpec.${kind}`,
    },
    Value: clientDefaultValue,
  };
}

function getValueType(value: any): SdkBuiltInKinds {
  switch (typeof value) {
    case "string":
      return "string";
    case "number":
      return "int32";
    case "boolean":
      return "boolean";
    case "bigint":
      return "int64";
    default:
      throw new Error(`Unsupported default value type: ${typeof value}`);
  }
}

function fromSdkOperationParameters(
  operation: SdkHttpOperation,
  rootApiVersions: string[],
  sdkContext: SdkContext<NetEmitterOptions>,
  typeMap: SdkTypeMap,
): Map<SdkHttpParameter, InputParameter> {
  const parameters = new Map<SdkHttpParameter, InputParameter>();
  for (const p of operation.parameters) {
    if (p.kind === "cookie") {
      Logger.getInstance().error(
        `Cookie parameter is not supported: ${p.name}, found in operation ${operation.path}`,
      );
      throw new Error(
        `Cookie parameter is not supported: ${p.name}, found in operation ${operation.path}`,
      );
    }
    const param = fromSdkHttpOperationParameter(p, rootApiVersions, sdkContext, typeMap);
    parameters.set(p, param);
  }

  if (operation.bodyParam) {
    const bodyParam = fromSdkHttpOperationParameter(
      operation.bodyParam,
      rootApiVersions,
      sdkContext,
      typeMap,
    );
    parameters.set(operation.bodyParam, bodyParam);
  }
  return parameters;
}

function fromSdkHttpOperationParameter(
  p: SdkPathParameter | SdkQueryParameter | SdkHeaderParameter | SdkBodyParameter,
  rootApiVersions: string[],
  sdkContext: SdkContext<NetEmitterOptions>,
  typeMap: SdkTypeMap,
): InputParameter {
  const isContentType =
    p.kind === "header" && p.serializedName.toLocaleLowerCase() === "content-type";
  const parameterType = fromSdkType(p.type, sdkContext, typeMap);
  const format = p.kind === "header" || p.kind === "query" ? p.collectionFormat : undefined;
  const serializedName = p.kind !== "body" ? p.serializedName : p.name;

  // TO-DO: In addition to checking if a path parameter is exploded, we should consider capturing the delimiter for
  // any path expansion to ensure the parameter values are delimited correctly during serialization.
  // https://github.com/microsoft/typespec/issues/5561
  const explode = isExplodedParameter(p);

  return {
    Name: p.name,
    NameInRequest: p.kind === "header" ? normalizeHeaderName(serializedName) : serializedName,
    Summary: p.summary,
    Doc: p.doc,
    Type: parameterType,
    Location: getParameterLocation(p),
    IsApiVersion:
      p.name.toLocaleLowerCase() === "apiversion" || p.name.toLocaleLowerCase() === "api-version",
    IsContentType: isContentType,
    IsEndpoint: false,
    Explode: explode,
    ArraySerializationDelimiter: format ? collectionFormatToDelimMap[format] : undefined,
    IsRequired: !p.optional,
    Kind: getParameterKind(p, parameterType, rootApiVersions.length > 0),
    DefaultValue: getParameterDefaultValue(p.clientDefaultValue, parameterType),
    Decorators: p.decorators,
    SkipUrlEncoding: isSdkPathParameter(p) ? p.allowReserved : false,
  } as InputParameter;
}

function loadLongRunningOperation(
  method: SdkServiceMethod<SdkHttpOperation>,
  sdkContext: SdkContext<NetEmitterOptions>,
  typeMap: SdkTypeMap,
): OperationLongRunning | undefined {
  if (method.kind !== "lro") {
    return undefined;
  }
  return {
    FinalStateVia: convertLroFinalStateVia(method.lroMetadata.finalStateVia),
    FinalResponse: {
      // in swagger, we allow delete to return some meaningful body content
      // for now, let assume we don't allow return type
      StatusCodes: method.operation.verb === "delete" ? [204] : [200],
      BodyType:
        method.lroMetadata.finalResponse?.envelopeResult !== undefined
          ? fromSdkModelType(method.lroMetadata.finalResponse.envelopeResult, sdkContext, typeMap)
          : undefined,
      BodyMediaType: BodyMediaType.Json,
    } as OperationResponse,
    ResultPath: method.lroMetadata.finalResponse?.resultPath,
  };
}

function fromSdkHttpOperationResponses(
  operationResponses: SdkHttpResponse[],
  sdkContext: SdkContext<NetEmitterOptions>,
  typeMap: SdkTypeMap,
): Map<SdkHttpResponse, OperationResponse> {
  const responses = new Map<SdkHttpResponse, OperationResponse>();
  for (const r of operationResponses) {
    const range = r.statusCodes;
    responses.set(r, {
      StatusCodes: toStatusCodesArray(range),
      BodyType: r.type ? fromSdkType(r.type, sdkContext, typeMap) : undefined,
      BodyMediaType: BodyMediaType.Json,
      Headers: fromSdkServiceResponseHeaders(r.headers, sdkContext, typeMap),
      IsErrorResponse: r.type !== undefined && isErrorModel(sdkContext.program, r.type.__raw!),
      ContentTypes: r.contentTypes,
    });
  }
  return responses;
}

function fromSdkServiceResponseHeaders(
  headers: SdkServiceResponseHeader[],
  sdkContext: SdkContext<NetEmitterOptions>,
  typeMap: SdkTypeMap,
): HttpResponseHeader[] {
  return headers.map(
    (h) =>
      ({
        Name: h.__raw!.name,
        NameInResponse: h.serializedName,
        Summary: h.summary,
        Doc: h.doc,
        Type: fromSdkType(h.type, sdkContext, typeMap),
      }) as HttpResponseHeader,
  );
}

function toStatusCodesArray(range: number | HttpStatusCodeRange): number[] {
  if (typeof range === "number") return [range];

  const statusCodes: number[] = [range.end - range.start + 1];
  for (let i = range.start; i <= range.end; i++) {
    statusCodes.push(i);
  }
  return statusCodes;
}

function getBodyMediaType(type: SdkType | undefined) {
  if (type === undefined) {
    return BodyMediaType.None;
  }

  if (type.kind === "model") {
    return BodyMediaType.Json;
  } else if (type.kind === "string") {
    return BodyMediaType.Text;
  } else if (type.kind === "bytes") {
    return BodyMediaType.Binary;
  }
  return BodyMediaType.None;
}

function getRequestMediaTypes(op: SdkHttpOperation): string[] | undefined {
  const contentTypes = op.parameters.filter(
    (p) => p.kind === "header" && p.serializedName.toLocaleLowerCase() === "content-type",
  );
  if (contentTypes.length === 0) return undefined;
  return contentTypes.map((p) => getMediaTypes(p.type)).flat();
}

function getMediaTypes(type: SdkType): string[] {
  if (type.kind === "constant") {
    if (type.valueType.kind !== "string") {
      throw `Media type in "content-type" should be string. But get ${type.valueType.kind}.`;
    }
    return [type.value as string];
  } else if (type.kind === "union") {
    const mediaTypes: string[] = [];
    for (const unionItem of type.variantTypes) {
      if (unionItem.kind === "constant" && unionItem.valueType.kind === "string") {
        mediaTypes.push(unionItem.value as string);
      } else {
        throw `Media type in "content-type" should be string. But get ${unionItem.kind}.`;
      }
    }
    return mediaTypes;
  } else if (type.kind === "enum") {
    if (type.valueType.kind !== "string") {
      throw `Media type in "content-type" should be string. But get ${type.valueType.kind}.`;
    }
    return type.values.map((v) => v.value as string);
  }
  return [];
}

function loadOperationPaging(
  method: SdkServiceMethod<SdkHttpOperation>,
): OperationPaging | undefined {
  if (method.kind !== "paging" || method.__raw_paged_metadata === undefined) {
    return undefined;
  }

  return {
    ItemName: method.__raw_paged_metadata.itemsProperty?.name,
    NextLinkName: method.__raw_paged_metadata.nextLinkProperty?.name,
  };
}

// TODO: https://github.com/Azure/typespec-azure/issues/1441
function getParameterLocation(
  p: SdkPathParameter | SdkQueryParameter | SdkHeaderParameter | SdkBodyParameter | undefined,
): RequestLocation {
  switch (p?.kind) {
    case "path":
      return RequestLocation.Path;
    case "header":
      return RequestLocation.Header;
    case "query":
      return RequestLocation.Query;
    case "body":
      return RequestLocation.Body;
    default:
      return RequestLocation.None;
  }
}

function getParameterKind(
  p: SdkPathParameter | SdkQueryParameter | SdkHeaderParameter | SdkBodyParameter,
  type: InputType,
  hasGlobalApiVersion: boolean,
): InputOperationParameterKind {
  if (p.kind === "body") {
    /** TODO: remove this and use the spread metadata of parameter when https://github.com/Azure/typespec-azure/issues/1513 is resolved */
    if (type.kind === "model" && p.type !== p.correspondingMethodParams[0]?.type) {
      return InputOperationParameterKind.Spread;
    }
    return InputOperationParameterKind.Method;
  }

  /** remove this, use p.onClient directly when https://github.com/Azure/typespec-azure/issues/1532 is resolved */
  const paramOnClient =
    p.correspondingMethodParams &&
    p.correspondingMethodParams.length > 0 &&
    p.correspondingMethodParams[0].onClient;

  return type.kind === "constant"
    ? InputOperationParameterKind.Constant
    : p.isApiVersionParam
      ? hasGlobalApiVersion
        ? InputOperationParameterKind.Client
        : InputOperationParameterKind.Method
      : paramOnClient // use p.onClient when https://github.com/Azure/typespec-azure/issues/1532 is resolved
        ? InputOperationParameterKind.Client
        : InputOperationParameterKind.Method;
}

function getOperationGroupName(
  context: SdkContext,
  operation: SdkHttpOperation,
  namespace: string,
): string {
  const explicitOperationId = getOperationId(context, operation.__raw.operation);
  if (explicitOperationId) {
    const ids: string[] = explicitOperationId.split("_");
    if (ids.length > 1) {
      return ids.slice(0, -2).join("_");
    }
  }

  if (operation.__raw.operation.interface) {
    return operation.__raw.operation.interface.name;
  }
  if (operation.__raw.operation.namespace) {
    return operation.__raw.operation.namespace.name;
  }
  return namespace;
}

// TODO: remove after https://github.com/Azure/typespec-azure/issues/1227 is fixed
function normalizeHeaderName(name: string): string {
  switch (name.toLocaleLowerCase()) {
    case "accept":
      return "Accept";
    case "content-type":
      return "Content-Type";
    default:
      return name;
  }
}

function isExplodedParameter(p: SdkHttpParameter): boolean {
  return (p.kind === "path" || p.kind === "query") && p.explode === true;
}
