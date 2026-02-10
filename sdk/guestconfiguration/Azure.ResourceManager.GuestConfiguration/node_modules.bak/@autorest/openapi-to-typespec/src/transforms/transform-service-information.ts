import {
  CodeModel,
  ImplementationLocation,
  KeySecurityScheme,
  OAuth2SecurityScheme,
  ParameterLocation,
  SecurityScheme,
} from "@autorest/codemodel";
import { getArmCommonTypeVersion, getUserSetArmCommonTypeVersion } from "../autorest-session";
import { ApiVersion } from "../constants";
import { AadOauth2AuthFlow, ApiKeyAuthentication, Auth, EndpointParameter, ServiceInformation } from "../interfaces";
import { getOptions } from "../options";
import { getFirstEndpoint } from "../utils/get-endpoint";
import { isConstantSchema } from "../utils/schemas";

export function transformServiceInformation(model: CodeModel): ServiceInformation {
  const { isArm } = getOptions();
  return {
    name: model.info.title,
    doc: model.info.description ?? "// (missing-service-description) Add service description",
    endpoint: getFirstEndpoint(model),
    endpointParameters: transformEndpointParameters(model),
    versions: getApiVersions(model),
    armCommonTypeVersion: isArm ? getArmCommonTypeVersion() : undefined,
    userSetArmCommonTypeVersion: isArm ? getUserSetArmCommonTypeVersion() : undefined,
    authentication: isArm ? undefined : getAuth(model),
  };
}

function getAuth(model: CodeModel): Auth[] | undefined {
  if (!model.security.schemes?.length) {
    return undefined;
  }

  const distinctSchemes = getDistinctAuthSchemes(model);
  const auths: Auth[] = [];
  for (const scheme of distinctSchemes) {
    if (isAadOauth2Auth(scheme)) {
      const aadOauth: AadOauth2AuthFlow = {
        kind: "AadOauth2Auth",
        scopes: scheme.scopes,
      };

      auths.push(aadOauth);
    }

    if (isKeyAuth(scheme)) {
      const azureApiKeyAuthentication: ApiKeyAuthentication = {
        kind: "ApiKeyAuth",
        location: scheme.in,
        name: scheme.name,
      };

      auths.push(azureApiKeyAuthentication);
    }
  }

  return auths;
}

function getDistinctAuthSchemes(model: CodeModel): SecurityScheme[] {
  const distinct = Array.from(new Set(model.security.schemes?.map((s) => JSON.stringify(s)) ?? []));
  return distinct.map((s) => JSON.parse(s));
}

function isAadOauth2Auth(scheme: SecurityScheme): scheme is OAuth2SecurityScheme {
  return scheme.type === "OAuth2";
}

function isKeyAuth(scheme: SecurityScheme): scheme is KeySecurityScheme {
  return scheme.type === "Key";
}

export function transformEndpointParameters(model: CodeModel): EndpointParameter[] {
  const globalParameters = (model.globalParameters ?? []).filter(
    (p) => p.implementation === "Client" && p.protocol?.http?.in === "uri",
  );

  return globalParameters.map((p) => ({
    doc: p.language.default.description ?? "",
    name: p.language.default.serializedName,
  }));
}

function getApiVersions(model: CodeModel): string[] | undefined {
  if (!model.globalParameters || !model.globalParameters.length) {
    return undefined;
  }

  const apiVersionParams = (model.schemas.constants ?? [])
    .filter((c) => c.language.default.name.startsWith(ApiVersion))
    .map((c) => c.value.value)
    .concat(
      (model.schemas.choices ?? [])
        .filter((c) => c.language.default.name.startsWith(ApiVersion))
        .flatMap((c) => c.choices.map((x) => x.value)),
    );

  return apiVersionParams.length > 0 ? apiVersionParams : undefined;
}

function getEndpointParameter(codeModel: CodeModel) {
  if (!codeModel.globalParameters || !codeModel.globalParameters.length) {
    return [];
  }

  const urlParameters = codeModel.globalParameters.filter(
    (gp) => gp.implementation === ImplementationLocation.Client && gp.protocol.http?.in === ParameterLocation.Uri,
  );

  // Currently only support one parametrized host
  if (!urlParameters.length) {
    return [];
  }

  return urlParameters.map((urlParameter) => {
    let value: string | undefined;
    if (isConstantSchema(urlParameter.schema)) {
      value = urlParameter.schema.value.value;
    }
    return {
      name: urlParameter.language.default.serializedName,
      type: "string",
      description: urlParameter.language.default.description,
      value,
    };
  });
}

export function transformBaseUrl(codeModel: CodeModel) {
  let endpoint: string | undefined = "";
  let isCustom = false;

  const $host = (codeModel.globalParameters || []).find((p) => {
    const { name } = p.language.default;
    return name === "$host" && Boolean(p.clientDefaultValue);
  });

  let urlParameters: any[] = [];
  if (!$host) {
    // There are some swaggers that contain no operations for those we'll keep an empty endpoint
    if (codeModel.operationGroups && codeModel.operationGroups.length) {
      // No support yet for multi-baseUrl yet Issue #553
      const { requests } = codeModel.operationGroups[0].operations[0];
      urlParameters = getEndpointParameter(codeModel);
      isCustom = true;
      endpoint = requests?.[0].protocol.http?.uri;
    }
  } else {
    endpoint = $host.clientDefaultValue;
  }

  return {
    urlParameters,
    endpoint: endpoint,
    isCustom,
  };
}
