import { getSession } from "../autorest-session";
import {
  generateArmResourceClientDecorator,
  generateEnumClientDecorator,
  generateObjectClientDecorator,
  generateOperationGroupClientDecorator,
} from "../generate/generate-client";
import { TypespecProgram } from "../interfaces";
import { getOptions } from "../options";
import { formatTypespecFile } from "../utils/format";
import { getClientImports } from "../utils/imports";
import { getNamespace } from "../utils/namespace";

export async function emitClient(filePath: string, program: TypespecProgram): Promise<void> {
  const content = generateClient(program);

  if (content === "") {
    return;
  }
  const session = getSession();
  session.writeFile({ filename: filePath, content: await formatTypespecFile(content, filePath) });
}

function generateClient(program: TypespecProgram) {
  const { isArm, isFullCompatible } = getOptions();
  const { models } = program;
  const { modules, namespaces: namespacesSet } = getClientImports(program);
  const imports = (
    isFullCompatible ? [...new Set<string>([...modules])] : [...new Set<string>([`import "./main.tsp";`, ...modules])]
  ).join("\n");

  const namespaces = [...new Set<string>([...namespacesSet, `using ${getNamespace(program)};`])].join("\n");
  const objects = models.objects
    .map(generateObjectClientDecorator)
    .filter((r) => r !== "")
    .join("\n\n");

  const armResources = isArm
    ? models.armResources
        .map(generateArmResourceClientDecorator)
        .filter((r) => r !== "")
        .join("\n\n")
    : "";

  const operationGroups = program.operationGroups
    .map(generateOperationGroupClientDecorator)
    .filter((r) => r !== "")
    .join("\n\n");

  const enums = models.enums
    .map(generateEnumClientDecorator)
    .filter((r) => r !== "")
    .join("\n\n");

  if (objects === "" && armResources === "" && enums === "" && operationGroups === "") {
    return "";
  }
  return [imports, "\n", namespaces, "\n", objects, "\n", armResources, "\n", operationGroups, "\n", enums].join("\n");
}
