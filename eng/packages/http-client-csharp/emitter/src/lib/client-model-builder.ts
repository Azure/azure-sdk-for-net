// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  SdkClientType,
  SdkContext,
  SdkEndpointParameter,
  SdkEndpointType,
  SdkHttpOperation,
  SdkServiceMethod,
  SdkType,
  UsageFlags,
} from "@azure-tools/typespec-client-generator-core";
import { NoTarget } from "@typespec/compiler";
import { NetEmitterOptions, resolveOptions } from "../options.js";
import { CodeModel } from "../type/code-model.js";
import { InputClient } from "../type/input-client.js";
import { InputOperationParameterKind } from "../type/input-operation-parameter-kind.js";
import { InputParameter } from "../type/input-parameter.js";
import { InputEnumType, InputModelType, InputType } from "../type/input-type.js";
import { RequestLocation } from "../type/request-location.js";
import { SdkTypeMap } from "../type/sdk-type-map.js";
import { fromSdkType } from "./converter.js";
import { reportDiagnostic } from "./lib.js";
import { Logger } from "./logger.js";
import { navigateModels } from "./model.js";
import { fromSdkServiceMethod, getParameterDefaultValue } from "./operation-converter.js";
import { processServiceAuthentication } from "./service-authentication.js";

export function createModel(sdkContext: SdkContext<NetEmitterOptions>): CodeModel {
  const sdkPackage = sdkContext.sdkPackage;

  const sdkTypeMap: SdkTypeMap = {
    types: new Map<SdkType, InputType>(),
    models: new Map<string, InputModelType>(),
    enums: new Map<string, InputEnumType>(),
  };

  navigateModels(sdkContext, sdkTypeMap);

  const sdkApiVersionEnums = sdkPackage.enums.filter((e) => e.usage === UsageFlags.ApiVersionEnum);

  const rootClients = sdkPackage.clients.filter((c) => c.initialization.access === "public");
  if (rootClients.length === 0) {
    reportDiagnostic(sdkContext.program, { code: "no-root-client", format: {}, target: NoTarget });
    return {} as CodeModel;
  }

  const rootApiVersions =
    sdkApiVersionEnums.length > 0
      ? sdkApiVersionEnums[0].values.map((v) => v.value as string).flat()
      : rootClients[0].apiVersions;

  const inputClients: InputClient[] = [];
  fromSdkClients(rootClients, inputClients, []);

  const clientModel: CodeModel = {
    Name: sdkPackage.rootNamespace,
    ApiVersions: rootApiVersions,
    Enums: Array.from(sdkTypeMap.enums.values()),
    Models: Array.from(sdkTypeMap.models.values()),
    Clients: inputClients,
    Auth: processServiceAuthentication(sdkContext, sdkPackage),
  };
  return clientModel;

  function fromSdkClients(
    clients: SdkClientType<SdkHttpOperation>[],
    inputClients: InputClient[],
    parentClientNames: string[],
  ) {
    for (const client of clients) {
      const inputClient = emitClient(client, parentClientNames);
      inputClients.push(inputClient);
      const subClients = client.methods
        .filter((m) => m.kind === "clientaccessor")
        .map((m) => m.response as SdkClientType<SdkHttpOperation>);
      parentClientNames.push(inputClient.Name);
      fromSdkClients(subClients, inputClients, parentClientNames);
      parentClientNames.pop();
    }
  }

  function emitClient(client: SdkClientType<SdkHttpOperation>, parentNames: string[]): InputClient {
    const endpointParameter = client.initialization.properties.find(
      (p) => p.kind === "endpoint",
    ) as SdkEndpointParameter;
    const uri = getMethodUri(endpointParameter);
    const clientParameters = fromSdkEndpointParameter(endpointParameter);
    return {
      Name: getClientName(client, parentNames),
      Summary: client.summary,
      Doc: client.doc,
      Operations: client.methods
        .filter((m) => m.kind !== "clientaccessor")
        .map((m) =>
          fromSdkServiceMethod(
            m as SdkServiceMethod<SdkHttpOperation>,
            uri,
            rootApiVersions,
            sdkContext,
            sdkTypeMap,
          ),
        ),
      Protocol: {},
      Parent: parentNames.length > 0 ? parentNames[parentNames.length - 1] : undefined,
      Parameters: clientParameters,
      Decorators: client.decorators,
    };
  }

  function getClientName(
    client: SdkClientType<SdkHttpOperation>,
    parentClientNames: string[],
  ): string {
    const clientName = client.name;

    if (parentClientNames.length === 0) return clientName;
    if (parentClientNames.length >= 2)
      return `${parentClientNames.slice(parentClientNames.length - 1).join("")}${clientName}`;

    if (
      clientName === "Models" &&
      resolveOptions(sdkContext.emitContext)["model-namespace"] !== false
    ) {
      Logger.getInstance().warn(`Invalid client name "${clientName}"`);
      return "ModelsOps";
    }

    return clientName;
  }

  function fromSdkEndpointParameter(p: SdkEndpointParameter): InputParameter[] {
    if (p.type.kind === "union") {
      return fromSdkEndpointType(p.type.variantTypes[0]);
    } else {
      return fromSdkEndpointType(p.type);
    }
  }

  function fromSdkEndpointType(type: SdkEndpointType): InputParameter[] {
    // TODO: support free-style endpoint url with multiple parameters
    const endpointExpr = type.serverUrl
      .replace("https://", "")
      .replace("http://", "")
      .split("/")[0];
    if (!/^\{\w+\}$/.test(endpointExpr))
      throw new Error(`Unsupported server url "${type.serverUrl}"`);
    const endpointVariableName = endpointExpr.substring(1, endpointExpr.length - 1);

    const parameters: InputParameter[] = [];
    for (const parameter of type.templateArguments) {
      const isEndpoint = parameter.name === endpointVariableName;
      const parameterType: InputType = isEndpoint
        ? {
            kind: "url",
            name: "url",
            crossLanguageDefinitionId: "TypeSpec.url",
          }
        : fromSdkType(parameter.type, sdkContext, sdkTypeMap); // TODO: consolidate with converter.fromSdkEndpointType
      parameters.push({
        Name: parameter.name,
        NameInRequest: parameter.serializedName,
        Summary: parameter.summary,
        Doc: parameter.doc,
        // TODO: we should do the magic in generator
        Type: parameterType,
        Location: RequestLocation.Uri,
        IsApiVersion: parameter.isApiVersionParam,
        IsResourceParameter: false,
        IsContentType: false,
        IsRequired: !parameter.optional,
        IsEndpoint: isEndpoint,
        SkipUrlEncoding: false,
        Explode: false,
        Kind: InputOperationParameterKind.Client,
        DefaultValue: getParameterDefaultValue(parameter.clientDefaultValue, parameterType),
      });
    }
    return parameters;
  }
}

function getMethodUri(p: SdkEndpointParameter | undefined): string {
  if (!p) return "";

  if (p.type.kind === "endpoint" && p.type.templateArguments.length > 0) return p.type.serverUrl;

  if (p.type.kind === "union" && p.type.variantTypes.length > 0)
    return (p.type.variantTypes[0] as SdkEndpointType).serverUrl;

  return `{${p.name}}`;
}
