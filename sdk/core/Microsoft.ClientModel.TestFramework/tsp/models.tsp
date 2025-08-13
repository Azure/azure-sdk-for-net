namespace Microsoft.ClientModel.TestFramework.TestProxy {
  model BodyKeySanitizer {
    jsonPath: string;
    value?: string;
    regex?: string;
    groupForReplace?: string;
  }
  model BodyRegexSanitizer {
    regex: string;
    value?: string;
    groupForReplace?: string;
    condition?: SanitizerCondition;
  }
  model SanitizerCondition {
    uriRegex?: string;
    responseHeader?: HeaderCondition;
  }
  model CustomDefaultMatcher {
    excludedHeaders?: string;
    compareBodies?: boolean;
    ignoredHeaders?: string;
    ignoredQueryParameters?: string;
  }
  model HeaderCondition {
    key: string;
    valueRegex: string;
  }
  model HeaderRegexSanitizer {
    key: string;
    value?: string;
    regex?: string;
    groupForReplace?: string;
  }
  model HeaderTransform {
    key: string;
    value: string;
    condition?: SanitizerCondition;
  }
  enum MatcherType {
    bodilessMatcher: "BodilessMatcher",
    customDefaultMatcher: "CustomDefaultMatcher",
  }
  model ProxyOptions {
    transport: ProxyOptionsTransport;
  }
  model ProxyOptionsTransport {
    allowAutoRedirect: boolean;
    tlsValidationCert: string;
    certificates: Array<ProxyOptionsTransportCertificationsItem>;
  }
  model ProxyOptionsTransportCertificationsItem {
    pemValue: string;
    pemKey: string;
  }
  model SanitizersToRemove {
    sanitizers: Array<string>;
  }
  enum SanitizerType {
    bodyKeySanitizer: "BodyKeySanitizer",
    headerRegexSanitizer: "HeaderRegexSanitizer",
    uriRegexSanitizer: "UriRegexSanitizer",
    bodyRegexSanitizer: "BodyRegexSanitizer",
  }
  model TestProxyStartInformation {
    @encodedName("application/json", "x-recording-file")
    xRecordingFile: string;
    @encodedName("application/json", "x-recording-assets-file")
    xRecordingAssetsFiles?: string;
  }
  model UriRegexSanitizer {
    regex: string;
    value?: string;
    groupForReplace?: string;
  }
}