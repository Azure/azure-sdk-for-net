global::sample.namespace.Argument.AssertNotNull(endpoint, nameof(endpoint));

options ??= new global::sample.namespace.TestClientOptions();

_endpoint = endpoint;
Pipeline = global::Azure.Core.Pipeline.HttpPipelineBuilder.Build(options, Array.Empty<global::Azure.Core.Pipeline.HttpPipelinePolicy>());
