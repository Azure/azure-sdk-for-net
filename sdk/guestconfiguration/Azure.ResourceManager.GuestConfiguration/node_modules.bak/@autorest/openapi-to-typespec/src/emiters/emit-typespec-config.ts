import { pascalCase } from "@azure-tools/codegen";
import { TypespecProgram } from "interfaces";
import { getSession } from "../autorest-session";
import { getOptions } from "../options";
import { formatFile } from "../utils/format";

export async function emitTypespecConfig(filePath: string, programDetails: TypespecProgram): Promise<void> {
  const session = getSession();
  const { isArm, isFullCompatible } = getOptions();
  let content = `
  emit:
    - "@azure-tools/typespec-autorest"

  options:
    "@azure-tools/typespec-autorest":
      azure-resource-provider-folder: "data-plane"
      emitter-output-dir: "{project-root}/.."
      examples-dir: "{project-root}/examples"
      output-file: "{azure-resource-provider-folder}/{service-name}/{version-status}/{version}/openapi.json"
    # Uncomment this line and add "@azure-tools/typespec-python" to your package.json to generate Python code
    # "@azure-tools/typespec-python":
    #   "basic-setup-py": true
    #   "package-version":
    #   "package-name":
    #   "output-path":
    # Uncomment this line and add "@azure-tools/typespec-java" to your package.json to generate Java code
    # "@azure-tools/typespec-java": true
    # Uncomment this line and add "@azure-tools/typespec-csharp" to your package.json to generate C# code
    # "@azure-tools/typespec-csharp": true
    # Uncomment this line and add "@azure-tools/typespec-ts" to your package.json to generate Typescript code
    # "@azure-tools/typespec-ts": true
`;

  if (isArm) {
    const inputFiles = session.configuration["input-file"];
    const swaggerName = inputFiles.length > 1 ? "openapi.json" : inputFiles[0].split("/").pop();
    content = `emit:
  - '@azure-tools/typespec-autorest'
options:
  '@azure-tools/typespec-autorest':
    omit-unreachable-types: true
    emitter-output-dir: "{project-root}/.."
    azure-resource-provider-folder: "resource-manager"
    output-file: "{azure-resource-provider-folder}/{service-name}/{version-status}/{version}/${swaggerName}"
    emit-lro-options: "all"
    examples-dir: "{project-root}/examples"
linter:
  extends:
    - "@azure-tools/typespec-azure-rulesets/resource-manager"
`;
  }

  session.writeFile({ filename: filePath, content: await formatFile(content, filePath) });
}
