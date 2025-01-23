global::sample.namespace.Argument.AssertNotNull(endpoint, nameof(endpoint));
global::sample.namespace.Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

options ??= new global::sample.namespace.TestClientOptions();

_endpoint = endpoint;
_tokenCredential = tokenCredential;
Pipeline = global::Azure.Core.Pipeline.HttpPipelineBuilder.Build(options, new global::Azure.Core.Pipeline.HttpPipelinePolicy[] { new global::Azure.Core.Pipeline.BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) });
