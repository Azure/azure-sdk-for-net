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
    bodilessMatcher: 0,
    customDefaultMatcher: 1,
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
    bodyKeySanitizer: 0,
    headerRegexSanitizer: 1,
    uriRegexSanitizer: 2,
    BodyRegexSanitizer: 3,
  }
  model TestProxyStartInformation {
    xRecordingFile: string;
    xRecodingAssetsFiles: string;
  }
  model UriRegexSanitizer {
    regex: string;
    value: string;
    groupForReplace: string;
  }
}