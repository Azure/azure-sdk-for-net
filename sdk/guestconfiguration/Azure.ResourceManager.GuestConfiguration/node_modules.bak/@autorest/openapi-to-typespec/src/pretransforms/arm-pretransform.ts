import { CodeModel } from "@autorest/codemodel";
import { getOptions } from "../options";
import { ArmResourceSchema, Metadata, tagSchemaAsResource } from "../utils/resource-discovery";

export function pretransformArmResources(codeModel: CodeModel, metadata: Metadata): void {
  const { isArm } = getOptions();
  if (!isArm) {
    return;
  }

  for (const schema of codeModel.schemas?.objects ?? []) {
    tagSchemaAsResource(schema, metadata);
  }
}
