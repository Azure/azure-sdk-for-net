// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
  SdkContext,
  SdkCredentialParameter,
  SdkCredentialType,
  SdkHttpOperation,
  SdkPackage,
} from "@azure-tools/typespec-client-generator-core";
import { NoTarget } from "@typespec/compiler";
import { Oauth2Auth, OAuth2Flow } from "@typespec/http";
import { NetEmitterOptions } from "../options.js";
import { InputAuth } from "../type/input-auth.js";
import { reportDiagnostic } from "./lib.js";

export function processServiceAuthentication(
  sdkContext: SdkContext<NetEmitterOptions>,
  sdkPackage: SdkPackage<SdkHttpOperation>,
): InputAuth | undefined {
  let authClientParameter: SdkCredentialParameter | undefined = undefined;
  for (const client of sdkPackage.clients) {
    for (const parameter of client.initialization.properties) {
      if (parameter.kind === "credential") {
        authClientParameter = parameter;
        break;
      }
    }
  }

  if (!authClientParameter) {
    return undefined;
  }
  if (authClientParameter.type.kind === "credential") {
    return processAuthType(sdkContext, authClientParameter.type);
  }
  const inputAuth: InputAuth = {};
  for (const authType of authClientParameter.type.variantTypes) {
    const auth = processAuthType(sdkContext, authType);
    if (auth?.ApiKey) {
      inputAuth.ApiKey = auth.ApiKey;
    }
    if (auth?.OAuth2) {
      inputAuth.OAuth2 = auth.OAuth2;
    }
  }
  return inputAuth;
}

function processAuthType(
  sdkContext: SdkContext<NetEmitterOptions>,
  credentialType: SdkCredentialType,
): InputAuth | undefined {
  const scheme = credentialType.scheme;
  switch (scheme.type) {
    case "apiKey":
      if (scheme.in !== "header") {
        reportDiagnostic(sdkContext.program, {
          code: "unsupported-auth",
          format: {
            message: `Only header is supported for ApiKey authentication. ${scheme.in} is not supported.`,
          },
          target: credentialType.__raw ?? NoTarget,
        });
        return undefined;
      }
      return { ApiKey: { Name: scheme.name, In: scheme.in } } as InputAuth;
    case "oauth2":
      return processOAuth2(scheme);
    case "http": {
      const schemeOrApiKeyPrefix = scheme.scheme;
      switch (schemeOrApiKeyPrefix) {
        case "basic":
          reportDiagnostic(sdkContext.program, {
            code: "unsupported-auth",
            format: { message: `${schemeOrApiKeyPrefix} auth method is currently not supported.` },
            target: credentialType.__raw ?? NoTarget,
          });
          return undefined;
        case "bearer":
          return {
            ApiKey: {
              Name: "Authorization",
              In: "header",
              Prefix: "Bearer",
            },
          };
        default:
          return {
            ApiKey: {
              Name: "Authorization",
              In: "header",
              Prefix: schemeOrApiKeyPrefix,
            },
          };
      }
    }
    default:
      reportDiagnostic(sdkContext.program, {
        code: "unsupported-auth",
        format: { message: `un-supported authentication scheme ${scheme.type}` },
        target: credentialType.__raw ?? NoTarget,
      });
      return undefined;
  }
}

function processOAuth2(scheme: Oauth2Auth<OAuth2Flow[]>): InputAuth | undefined {
  let scopes: Set<string> | undefined = undefined;
  for (const flow of scheme.flows) {
    if (flow.scopes) {
      scopes ??= new Set<string>();
      for (const scope of flow.scopes) {
        scopes.add(scope.value);
      }
    }
  }
  return scopes
    ? ({
        OAuth2: { Scopes: Array.from(scopes.values()) },
      } as InputAuth)
    : undefined;
}
