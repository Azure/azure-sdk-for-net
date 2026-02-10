import { TypespecProgram } from "../interfaces";
import { getOptions } from "../options";

export function getNamespaceStatement(program: TypespecProgram) {
  return `namespace ${getNamespace(program)};`;
}

export function getNamespace(program: TypespecProgram) {
  const { namespace } = getOptions();

  return namespace ?? program.serviceInformation.name.replace(/ /g, "").replace(/-/g, "");
}
