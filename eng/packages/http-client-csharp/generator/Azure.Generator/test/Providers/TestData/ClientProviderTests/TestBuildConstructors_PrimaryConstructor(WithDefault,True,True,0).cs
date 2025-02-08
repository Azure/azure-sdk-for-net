global::sample.test.Argument.AssertNotNull(endpoint, nameof(endpoint));
global::sample.test.Argument.AssertNotNull(keyCredential, nameof(keyCredential));

options ??= new global::sample.test.TestClientOptions();

_endpoint = endpoint;
_keyCredential = keyCredential;
Pipeline = global::Azure.Core.Pipeline.HttpPipelineBuilder.Build(options, new global::Azure.Core.Pipeline.HttpPipelinePolicy[] { new global::Azure.Core.AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) });
