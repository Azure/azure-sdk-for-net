import { CodeModel } from "@autorest/codemodel";

export function getFirstEndpoint(model: CodeModel) {
  for (const group of model.operationGroups) {
    for (const operation of group.operations) {
      for (const request of operation.requests ?? []) {
        if (!request.protocol.http) {
          continue;
        }

        const endpoint = request.protocol.http.uri;
        if (endpoint) {
          return endpoint;
        }
      }
    }
  }
}
