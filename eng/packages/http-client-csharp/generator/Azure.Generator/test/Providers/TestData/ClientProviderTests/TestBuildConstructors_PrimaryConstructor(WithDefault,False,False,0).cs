global::sample.test.Argument.AssertNotNull(endpoint, nameof(endpoint));

options ??= new global::sample.test.TestClientOptions();

_endpoint = endpoint;
Pipeline = global::Azure.Core.Pipeline.HttpPipelineBuilder.Build(options, Array.Empty<global::Azure.Core.Pipeline.HttpPipelinePolicy>());
