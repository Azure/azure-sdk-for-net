global::Samples.Argument.AssertNotNull(endpoint, nameof(endpoint));
global::Samples.Argument.AssertNotNull(credential, nameof(credential));

options ??= new global::Samples.TestClientOptions();

_endpoint = endpoint;
_keyCredential = credential;
Pipeline = global::Azure.Core.Pipeline.HttpPipelineBuilder.Build(options, new global::Azure.Core.Pipeline.HttpPipelinePolicy[] { new global::Azure.Core.AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) });
