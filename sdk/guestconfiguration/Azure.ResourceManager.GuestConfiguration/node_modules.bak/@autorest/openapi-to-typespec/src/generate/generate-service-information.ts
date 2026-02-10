import { ApiVersion } from "../constants";
import { TypespecProgram, EndpointParameter, Auth } from "../interfaces";
import { getOptions } from "../options";
import { generateDocs } from "../utils/docs";
import { getNamespaceStatement } from "../utils/namespace";

export function generateServiceInformation(program: TypespecProgram) {
  const { serviceInformation } = program;
  const definitions: string[] = [];
  const { isArm } = getOptions();
  if (isArm) {
    definitions.push(`@armProviderNamespace`);
  }

  generateUseAuth(serviceInformation.authentication, definitions);
  definitions.push(`@service(#{
    title: "${serviceInformation.name}"
  })`);

  if (serviceInformation.versions) {
    definitions.push(`@versioned(Versions)`);
  }

  if (isArm && serviceInformation.armCommonTypeVersion) {
    if (serviceInformation.armCommonTypeVersion !== serviceInformation.userSetArmCommonTypeVersion) {
      definitions.push(
        `// FIXME: ${
          serviceInformation.userSetArmCommonTypeVersion
            ? `Common type version ${serviceInformation.userSetArmCommonTypeVersion} is not supported for now.`
            : "Common type version not set."
        } Set to v3.`,
      );
    }
    definitions.push(
      `@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.${serviceInformation.armCommonTypeVersion})`,
    );
  }

  if (!isArm && serviceInformation.endpoint) {
    definitions.push(`@server("${serviceInformation.endpoint}", ${JSON.stringify(serviceInformation.doc) ?? ""}`);
    const parametrizedHost = getEndpointParameters(serviceInformation.endpoint);
    const hasParameters =
      (serviceInformation.endpointParameters && serviceInformation.endpointParameters.length) ||
      parametrizedHost.length;

    const allParams: EndpointParameter[] = [
      ...(serviceInformation.endpointParameters ?? []).filter((p) => !parametrizedHost.some((e) => e.name === p.name)),
      ...parametrizedHost,
    ];
    if (hasParameters) {
      definitions.push(", {");
      for (const param of allParams ?? []) {
        const doc = generateDocs(param);
        doc && definitions.push(doc);
        definitions.push(`${param.name}: ${param.name.startsWith(ApiVersion) ? "Versions" : "string"} `);
      }
    }
    hasParameters && definitions.push("}");
    definitions.push(")");
  }
  const serviceDoc = generateDocs(serviceInformation);
  serviceDoc && definitions.push(serviceDoc);

  definitions.push(getNamespaceStatement(program));

  if (serviceInformation.versions) {
    definitions.push("");
    definitions.push(`/**\n* The available API versions.\n*/`);
    definitions.push(`enum Versions {`);
    for (const version of serviceInformation.versions) {
      definitions.push(`/**\n* The ${version} API version.\n*/`);
      definitions.push(
        `${version.startsWith("v") ? "" : "v"}${version.replaceAll("-", "_").replaceAll(".", "_")}: "${version}",`,
      );
    }
    definitions.push("}");
  }

  return definitions.join("\n");
}

function getEndpointParameters(endpoint: string) {
  const regex = /{([^{}]+)}/g;
  const params: EndpointParameter[] = [];
  let match;
  while ((match = regex.exec(endpoint)) !== null) {
    params.push({ name: match[1] });
  }

  return params;
}

function generateUseAuth(authDefinitions: Auth[] | undefined, statements: string[]): void {
  if (!authDefinitions) {
    return;
  }

  const authFlows: string[] = [];

  for (const auth of authDefinitions) {
    if (auth.kind === "AadOauth2Auth") {
      const scopes = `[${auth.scopes.map((s) => `"${s}"`).join()}]`;
      authFlows.push(`AadOauth2Auth<${scopes}>`);
    }

    if (auth.kind === "ApiKeyAuth") {
      authFlows.push(`ApiKeyAuth<ApiKeyLocation.${auth.location}, "${auth.name}">`);
    }
  }

  if (!authFlows.length) {
    return;
  }

  statements.push(`@useAuth(${authFlows.join(" | ")})`);

  return;
}
