import { CodeModel, HttpMethod, Operation } from "@autorest/codemodel";

export function getHttpMethod(_codeModel: CodeModel, operation: Operation): HttpMethod {
  return operation.requests?.[0].protocol.http?.method;
}
