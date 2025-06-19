import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;

@access(Access.internal)
model BodyKeySanitizer {
  jsonPath: string;
  value: string;
  regex: string;
  groupForReplace: string;
}
@access(Access.internal)
model BodyRegexSanitizer {
  regex: string;
  value: string;
  groupForReplace: string;
  condition: Condition;
}
@access(Access.internal)
model Condition {
  uriRegex: string;
  responseHeader: HeaderCondition;
}
@access(Access.internal)
model CustomDefaultMatcher {
  excludedHeaders: string;
  compareBodies: boolean;
  ignoredHeaders: string;
  ignoredQueryParameters: string;
}
@access(Access.internal)
model HeaderCondition {
  key: string;
  valueRegex: string;
}
@access(Access.internal)
model HeaderRegexSanitizer {
  key: string;
  value: string;
  regex: string;
  groupForReplace: string;
}
@access(Access.internal)
model HeaderTransform {
  key: string;
  value: string;
  condition: Condition;
}
@access(Access.internal)
enum MatcherType {
  bodilessMatcher: 0,
  customDefaultMatcher: 1,
}
@access(Access.internal)
model ProxyOptions {
  transport: ProxyOptionsTransport;
}
@access(Access.internal)
model ProxyOptionsTransport {
  allowAutoRedirect: boolean;
  tlsValidationCert: string;
  certificates: [ ProxyOptionsTransportCertificationsItem ];
}
@access(Access.internal)
model ProxyOptionsTransportCertificationsItem {
  pemValue: string;
  pemKey: string;
}
@access(Access.internal)
model SanitizersToRemove {
  sanitizers: [ string ];
}
@access(Access.internal)
enum SanitizerType {
  bodyKeySanitizer: 0,
  headerRegexSanitizer: 1,
  uriRegexSanitizer: 2,
}
@access(Access.internal)
model StartInformation {
  xRecordingFile: string;
  xRecodingAssetsFiles: string;
}
@access(Access.internal)
model UriRegexSanitizer {
  regex: string;
  value: string;
  groupForReplace: string;
}