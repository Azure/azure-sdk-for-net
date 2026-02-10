import { join } from "path";
import { getSession } from "../autorest-session";
import { generateArmResource, generateArmResourceExamples } from "../generate/generate-arm-resource";
import { TypespecProgram, TspArmResource } from "../interfaces";
import { formatTypespecFile } from "../utils/format";
import { getNamespaceStatement } from "../utils/namespace";
import { Metadata } from "../utils/resource-discovery";
import { emitExamples } from "./emit-main";

export async function emitArmResources(program: TypespecProgram, metadata: Metadata, basePath: string) {
  // Create a file per resource
  const session = getSession();
  const { serviceInformation } = program;
  for (const armResource of program.models.armResources) {
    const { modules, namespaces } = getResourcesImports(program, armResource);
    const filePath = join(basePath, `${armResource.name}.tsp`);
    const generatedResource = generateArmResource(armResource);
    const content = [
      modules.join("\n"),
      "\n",
      namespaces.join("\n"),
      "\n",
      getNamespaceStatement(program),
      generatedResource,
    ].join("\n");
    session.writeFile({ filename: filePath, content: await formatTypespecFile(content, filePath) });
    // generate examples for each operation
    const examples = generateArmResourceExamples(armResource);
    emitExamples(examples, serviceInformation.versions, basePath);
  }

  const multiPathResources = Object.keys(metadata.Resources).filter((key) => key.endsWith("FixMe"));
  for (const resource of multiPathResources) {
    const originalName = resource.replace("FixMe", "");
    const filePath = join(basePath, `${resource}.tsp`);
    session.writeFile({
      filename: filePath,
      content: `// You defined multiple pathes under the model ${originalName}. Some operations will be lost. Turn on isFullCompatible to keep all operations, or fix your TypeSpec manually.`,
    });
  }
}

export function getResourcesImports(_program: TypespecProgram, armResource: TspArmResource) {
  const imports = {
    modules: [
      `import "@azure-tools/typespec-azure-core";`,
      `import "@azure-tools/typespec-azure-resource-manager";`,
      `import "@typespec/openapi";`,
      `import "@typespec/rest";`,
      `import "./models.tsp";`,
    ],
    namespaces: [
      `using TypeSpec.Rest;`,
      `using Azure.ResourceManager;`,
      `using TypeSpec.Http;`,
      `using TypeSpec.OpenAPI;`,
    ],
  };

  if (armResource.resourceParent?.name) {
    imports.modules.push(`import "./${armResource.resourceParent.name}.tsp";`);
  }

  return imports;
}
