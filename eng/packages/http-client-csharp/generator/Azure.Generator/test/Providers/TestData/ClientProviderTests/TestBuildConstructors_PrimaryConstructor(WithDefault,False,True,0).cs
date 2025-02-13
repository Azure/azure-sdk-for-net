global::Samples.Argument.AssertNotNull(endpoint, nameof(endpoint));
global::Samples.Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

options ??= new global::Samples.TestClientOptions();

_endpoint = endpoint;
_tokenCredential = tokenCredential;
Pipeline = global::Azure.Core.Pipeline.HttpPipelineBuilder.Build(options, new global::Azure.Core.Pipeline.HttpPipelinePolicy[] { new global::Azure.Core.Pipeline.BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) });
