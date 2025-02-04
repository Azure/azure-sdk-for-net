// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { SdkContext } from "@azure-tools/typespec-client-generator-core";
import { getDoc, getSummary } from "@typespec/compiler";
import { HttpServer } from "@typespec/http";
import { getExtensions } from "@typespec/openapi";
import { NetEmitterOptions } from "../options.js";
import { InputConstant } from "../type/input-constant.js";
import { InputOperationParameterKind } from "../type/input-operation-parameter-kind.js";
import { InputParameter } from "../type/input-parameter.js";
import { InputType } from "../type/input-type.js";
import { RequestLocation } from "../type/request-location.js";
import { SdkTypeMap } from "../type/sdk-type-map.js";
import { getDefaultValue, getInputType } from "./model.js";

export interface TypeSpecServer {
  url: string;
  description?: string;
  parameters: InputParameter[];
}

export function resolveServers(
  context: SdkContext<NetEmitterOptions>,
  servers: HttpServer[],
  typeMap: SdkTypeMap,
): TypeSpecServer[] {
  return servers.map((server) => {
    const parameters: InputParameter[] = [];
    let url: string = server.url;
    const endpoint: string = url.replace("http://", "").replace("https://", "").split("/")[0];
    for (const [name, prop] of server.parameters) {
      const isEndpoint: boolean = endpoint === `{${name}}`;
      let defaultValue: InputConstant | undefined = undefined;
      const value = prop.default ? getDefaultValue(prop.default) : "";
      const inputType: InputType = isEndpoint
        ? {
            kind: "url",
            name: "url",
            crossLanguageDefinitionId: "TypeSpec.url",
          }
        : getInputType(context, prop, typeMap);

      if (value) {
        defaultValue = {
          Type: inputType,
          Value: value,
        };
      }
      const variable: InputParameter = {
        Name: name,
        NameInRequest: name,
        Summary: getSummary(context.program, prop),
        Doc: getDoc(context.program, prop),
        Type: inputType,
        Location: RequestLocation.Uri,
        IsApiVersion: name.toLowerCase() === "apiversion" || name.toLowerCase() === "api-version",
        IsResourceParameter: false,
        IsContentType: false,
        IsRequired: true,
        IsEndpoint: isEndpoint,
        SkipUrlEncoding:
          // TODO: update this when https://github.com/Azure/typespec-azure/issues/1022 is resolved
          getExtensions(context.program, prop).get("x-ms-skip-url-encoding") === true,
        Explode: false,
        Kind: InputOperationParameterKind.Client,
        DefaultValue: defaultValue,
      };

      parameters.push(variable);
    }
    /* add default server. */
    if (server.url && parameters.length === 0) {
      const variable: InputParameter = {
        Name: "host",
        NameInRequest: "host",
        Doc: server.description,
        Type: {
          kind: "string",
          name: "string",
          crossLanguageDefinitionId: "TypeSpec.string",
        },
        Location: RequestLocation.Uri,
        IsApiVersion: false,
        IsResourceParameter: false,
        IsContentType: false,
        IsRequired: true,
        IsEndpoint: true,
        SkipUrlEncoding: false,
        Explode: false,
        Kind: InputOperationParameterKind.Client,
        DefaultValue: {
          Type: {
            kind: "string",
            name: "string",
            crossLanguageDefinitionId: "TypeSpec.string",
          },
          Value: server.url,
        } as InputConstant,
      };
      url = `{host}`;
      parameters.push(variable);
    }
    return {
      url: url,
      description: server.description,
      parameters,
    };
  });
}
