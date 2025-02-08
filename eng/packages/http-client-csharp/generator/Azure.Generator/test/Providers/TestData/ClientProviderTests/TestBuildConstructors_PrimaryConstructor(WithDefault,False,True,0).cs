global::sample.test.Argument.AssertNotNull(endpoint, nameof(endpoint));
global::sample.test.Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

options ??= new global::sample.test.TestClientOptions();

_endpoint = endpoint;
_tokenCredential = tokenCredential;
Pipeline = global::Azure.Core.Pipeline.HttpPipelineBuilder.Build(options, new global::Azure.Core.Pipeline.HttpPipelinePolicy[] { new global::Azure.Core.Pipeline.BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) });
