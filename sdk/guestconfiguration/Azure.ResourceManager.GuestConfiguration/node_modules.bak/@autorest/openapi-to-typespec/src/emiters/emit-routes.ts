import { join } from "path";
import { getSession } from "../autorest-session";
import { generateOperationGroup, generateOperationGroupExamples } from "../generate/generate-operations";
import { TypespecProgram } from "../interfaces";
import { getOptions } from "../options";
import { formatTypespecFile } from "../utils/format";
import { getRoutesImports } from "../utils/imports";
import { getNamespaceStatement } from "../utils/namespace";
import { emitExamples } from "./emit-main";

export async function emitRoutes(program: TypespecProgram, basePath: string): Promise<void> {
  if (program.operationGroups.length === 0) {
    return;
  }
  const content = generateRoutes(program);
  const session = getSession();
  const filePath = join(basePath, "routes.tsp");
  session.writeFile({ filename: filePath, content: await formatTypespecFile(content, filePath) });

  for (const operationGroup of program.operationGroups) {
    const examples = generateOperationGroupExamples(operationGroup);
    emitExamples(examples, program.serviceInformation.versions, basePath);
  }
}

function generateRoutes(program: TypespecProgram) {
  const { isArm } = getOptions();
  const { operationGroups } = program;
  const { modules, namespaces } = getRoutesImports(program);
  const content = operationGroups.map(generateOperationGroup);

  const result = [...modules, "\n", ...namespaces, "\n", getNamespaceStatement(program), "\n", ...content].join("\n");
  if (isArm) {
    return (
      "// FIXME: Operations in this file are not detected as a resource operation, please confirm the conversion result manually\n\n" +
      result
    );
  }

  return result;
}
