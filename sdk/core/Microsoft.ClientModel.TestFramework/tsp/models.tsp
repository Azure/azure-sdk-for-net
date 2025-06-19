import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;

//@access(Access.internal)
model BodyKeySanitizer {
  jsonPath: string;
  value: string;
  regex: string;
  groupForReplace: string;
}
//@access(Access.internal)
model BodyRegexSanitizer {
  regex: string;
  value: string;
  groupForReplace: string;
  condition: Condition;
}
model Condition {
  uriRegex: string;
  responseHeader: HeaderCondition;
}
model CustomDefaultMatcher {
  excludedHeaders: string;
  compareBodies: boolean;
  ignoredHeaders: string;
  ignoredQueryParameters: string;
}
model HeaderCondition {
  key: string;
  valueRegex: string;
}
model HeaderRegexSanitizer {
  key: string;
  value: string;
  regex: string;
  groupForReplace: string;
}
model HeaderTransform {
  key: string;
  value: string;
  condition: Condition;
}
enum MatcherType {
  bodilessMatcher: 0,
  customDefaultMatcher: 1,
}
model ProxyOptions {
  transport: ProxyOptionsTransport;
}
model ProxyOptionsTransport {
  allowAutoRedirect: boolean;
  tlsValidationCert: string;
  certificates: [ ProxyOptionsTransportCertificationsItem ];
}
model ProxyOptionsTransportCertificationsItem {
  pemValue: string;
  pemKey: string;
}
model SanitizersToRemove {
  sanitizers: [ string ];
}
enum SanitizerType {
  bodyKeySanitizer: 0,
  headerRegexSanitizer: 1,
  uriRegexSanitizer: 2,
}
model StartInformation {
  xRecordingFile: string;
  xRecodingAssetsFiles: string;
}
model UriRegexSanitizer {
  regex: string;
  value: string;
  groupForReplace: string;
}