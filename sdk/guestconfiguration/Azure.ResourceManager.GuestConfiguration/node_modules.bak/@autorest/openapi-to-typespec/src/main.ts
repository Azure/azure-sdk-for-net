// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

import { join } from "path";
import { CodeModel, codeModelSchema } from "@autorest/codemodel";
import { AutoRestExtension, AutorestExtensionHost, Session, startSession } from "@autorest/extension-base";
import { serialize } from "@azure-tools/codegen";
import { OpenAPI3Document } from "@azure-tools/openapi";
import { Metadata } from "utils/resource-discovery";
import { addArmCommonTypeModel, setArmCommonTypeVersion, setSession } from "./autorest-session";
import { emitArmResources } from "./emiters/emit-arm-resources";
import { emitClient } from "./emiters/emit-client";
import { emitMain } from "./emiters/emit-main";

import { emitModels } from "./emiters/emit-models";
import { emitPackage } from "./emiters/emit-package";
import { emitRoutes } from "./emiters/emit-routes";
import { emitTypespecConfig } from "./emiters/emit-typespec-config";
import { getModel } from "./model";
import { getOptions } from "./options";
import { pretransformArmResources } from "./pretransforms/arm-pretransform";
import { pretransformNames } from "./pretransforms/name-pretransform";
import { pretransformRename } from "./pretransforms/rename-pretransform";
import { parseMetadata } from "./resource/parse-metadata";
import { markErrorModels } from "./utils/errors";
import { markPagination } from "./utils/paging";
import { markResources } from "./utils/resources";

export async function processConverter(host: AutorestExtensionHost) {
  const session = await startSession<CodeModel>(host, codeModelSchema);
  setSession(session);
  const codeModel = session.model;
  pretransformNames(codeModel);
  const { isArm, isFullCompatible } = getOptions();
  let metadata: Metadata | undefined = undefined;
  if (isArm) {
    // await host.writeFile({ filename: "codeModel.yaml", content: serialize(codeModel, codeModelSchema) });
    metadata = parseMetadata(codeModel, session.configuration);
    // metadata.RenameMapping = session.configuration["rename-mapping"];
    // metadata.OverrideOperationName = session.configuration["override-operation-name"];
    await host.writeFile({ filename: "resources.json", content: JSON.stringify(metadata, null, 2) });
    pretransformArmResources(codeModel, metadata);
    pretransformRename(codeModel, metadata);
  }
  markPagination(codeModel); // TO-Delete
  markErrorModels(codeModel);
  markResources(codeModel);
  const programDetails = getModel(codeModel);
  if (isArm) {
    await emitArmResources(programDetails, metadata!, getOutputDirectory(session));
  }
  await emitModels(getFilePath(session, "models.tsp"), programDetails);
  await emitRoutes(programDetails, getOutputDirectory(session));
  await emitMain(programDetails, metadata, getOutputDirectory(session));
  await emitPackage(getFilePath(session, "package.json"), programDetails);
  await emitTypespecConfig(getFilePath(session, "tspconfig.yaml"), programDetails);
  await emitClient(getFilePath(session, isFullCompatible ? "back-compatible.tsp" : "client.tsp"), programDetails);
}

function getOutputDirectory(session: Session<CodeModel>) {
  return session.configuration["src-path"] ?? "";
}

function getFilePath(session: Session<CodeModel>, fileName: string) {
  return join(getOutputDirectory(session), fileName);
}

async function main() {
  const pluginHost = new AutoRestExtension();
  pluginHost.add("source-swagger-detector", processDetector);
  pluginHost.add("openapi-to-typespec", processConverter);
  await pluginHost.run();
}

main().catch((e) => {
  throw new Error(e);
});

export async function processDetector(host: AutorestExtensionHost) {
  const session = await startSession<OpenAPI3Document>(host, codeModelSchema);
  if (session.model.components?.schemas) {
    for (const v of Object.values(session.model.components.schemas)) {
      if (v["x-ms-metadata"]?.originalLocations) {
        for (const p of v["x-ms-metadata"].originalLocations) {
          const versionResult = p.match(/\/common-types\/resource-management\/(v\d)\//);
          if (versionResult) {
            setArmCommonTypeVersion(versionResult[1]);
          }

          const typeResult = p.match(/\/common-types\/resource-management\/(v\d)\/.*\/components\/schemas\/(.*)/);
          if (typeResult) {
            addArmCommonTypeModel(typeResult[2]);
          }
        }
      }
    }
  }
}
