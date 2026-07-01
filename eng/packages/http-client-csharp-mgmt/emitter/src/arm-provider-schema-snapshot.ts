// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext, resolvePath } from "@typespec/compiler";
import { AzureMgmtEmitterOptions } from "./options.js";
import {
  ArmProviderSchema,
  convertArmProviderSchemaToArguments
} from "./resource-metadata.js";

export const legacyArmProviderSchemaFileName =
  "arm-provider-schema.legacy.json";
export const resolveArmResourcesProviderSchemaFileName =
  "arm-provider-schema.resolve-arm-resources.json";

export interface ArmProviderSchemaSnapshots {
  legacy: ArmProviderSchema;
  resolveArmResources: ArmProviderSchema;
}

export async function emitArmProviderSchemaSnapshots(
  context: EmitContext<AzureMgmtEmitterOptions>,
  snapshots: ArmProviderSchemaSnapshots
): Promise<void> {
  await context.program.host.mkdirp(context.emitterOutputDir);
  await writeArmProviderSchemaSnapshot(
    context,
    legacyArmProviderSchemaFileName,
    snapshots.legacy
  );
  await writeArmProviderSchemaSnapshot(
    context,
    resolveArmResourcesProviderSchemaFileName,
    snapshots.resolveArmResources
  );
}

async function writeArmProviderSchemaSnapshot(
  context: EmitContext<AzureMgmtEmitterOptions>,
  fileName: string,
  schema: ArmProviderSchema
): Promise<void> {
  const snapshot = convertArmProviderSchemaToArguments(schema);
  snapshot.resources.sort((left: any, right: any) =>
    (left.resourceIdPattern ?? "").localeCompare(right.resourceIdPattern ?? "")
  );

  await context.program.host.writeFile(
    resolvePath(context.emitterOutputDir, fileName),
    JSON.stringify(snapshot, null, 2)
  );
}
