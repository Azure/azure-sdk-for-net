import { TypespecParameter } from "../interfaces";
import { getOptions } from "../options";
import { generateDecorators } from "../utils/decorators";
import { generateDocs } from "../utils/docs";
import { generateSuppressions } from "../utils/suppressions";

const _ARM_PARAM_REPLACEMENTS: { [key: string]: string } = {
  subscriptionId: "...SubscriptionIdParameter",
  location: "...LocationResourceParameter",
  resourceGroupName: "...ResourceGroupParameter",
};

export function generateParameter(parameter: TypespecParameter): string {
  const { isArm } = getOptions();
  if (isArm && _ARM_PARAM_REPLACEMENTS[parameter.name] !== undefined) {
    return _ARM_PARAM_REPLACEMENTS[parameter.name];
  }
  const definitions: string[] = [];
  const doc = generateDocs(parameter);
  definitions.push(doc);

  parameter.suppressions && definitions.push(...generateSuppressions(parameter.suppressions));
  const decorators = generateDecorators(parameter.decorators);
  decorators && definitions.push(decorators);
  let defaultValue = "";
  if (parameter.defaultValue) {
    defaultValue = ` = ${parameter.defaultValue}`;
  }
  definitions.push(`"${parameter.name}"${parameter.isOptional ? "?" : ""}: ${parameter.type}${defaultValue}`);

  return definitions.join("\n");
}
