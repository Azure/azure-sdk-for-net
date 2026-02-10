import { CodeModel } from "@autorest/codemodel";
import { isResponseSchema } from "./schemas";

export function markErrorModels(codeModel: CodeModel) {
  for (const operationGroup of codeModel.operationGroups) {
    for (const operation of operationGroup.operations) {
      const exceptions = operation.exceptions ?? [];
      for (const exception of exceptions) {
        if (isResponseSchema(exception)) {
          exception.schema.language.default.isError = true;
        }
      }
    }
  }
}
