// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Net.ClientModel.Internal.Core;

namespace System.Net.ClientModel.Core;

public class ClientPipeline
{
    private readonly ReadOnlyMemory<PipelinePolicy> _policies;
    private readonly PipelineTransport _transport;

    private readonly Type _clientType;

    private ClientPipeline(Type clientType, ReadOnlyMemory<PipelinePolicy> policies)
    {
        if (clientType is null) throw new ArgumentNullException(nameof(clientType));

        if (policies.Span[policies.Length - 1] is not PipelineTransport)
        {
            throw new ArgumentException("Last policy in the array must be of type 'PipelineTransport'.", nameof(policies));
        }

        _transport = (PipelineTransport)policies.Span[policies.Length - 1];
        _policies = policies;

        _clientType = clientType;
    }

    public static ClientPipeline GetPipeline(object client, PipelineOptions options, params PipelinePolicy[] perCallPolicies)
        => GetPipeline(client, options, perCallPolicies, ReadOnlySpan<PipelinePolicy>.Empty);

    public static ClientPipeline GetPipeline(object client,
        PipelineOptions options,
        ReadOnlySpan<PipelinePolicy> perCallPolicies,
        ReadOnlySpan<PipelinePolicy> perTryPolicies)
    {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (options is null) throw new ArgumentNullException(nameof(options));

        Type clientType = client.GetType();

        if (options.IsFrozen)
        {
            AssertValidClient(options.Pipeline._clientType, clientType);

            return options.Pipeline;
        }

        ClientPipeline pipeline = Create(client.GetType(), options, perCallPolicies, perTryPolicies);

        // Set and freeze the pipeline.
        options.SetPipeline(pipeline);

        return pipeline;
    }

    public static ClientPipeline GetPipeline(object client, RequestOptions options, params PipelinePolicy[] perCallPolicies)
        => GetPipeline(client, options, perCallPolicies, ReadOnlySpan<PipelinePolicy>.Empty);

    public static ClientPipeline GetPipeline(object client,
        RequestOptions options,
        ReadOnlySpan<PipelinePolicy> perCallPolicies,
        ReadOnlySpan<PipelinePolicy> perTryPolicies)
    {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (options is null) throw new ArgumentNullException(nameof(options));

        // If PipelineOptions haven't been modified, we don't need to create a new pipeline.
        if (!options.PipelineOptions.Modified)
        {
            options.PipelineOptions.Freeze();
            return options.PipelineOptions.Pipeline;
        }

        return GetPipeline(client, options.PipelineOptions, perCallPolicies, perTryPolicies);
    }

    // Simplest factory method: construct a pipeline from a list of policies
    internal static ClientPipeline Create(Type clientType, ReadOnlyMemory<PipelinePolicy> policies)
        => new ClientPipeline(clientType, policies);

    // Builder from options: lets a client-author specify policies without modifying
    // client-user's passed-in options.
    internal static ClientPipeline Create(
        Type clientType,
        PipelineOptions options,
        ReadOnlySpan<PipelinePolicy> perCallPolicies,
        ReadOnlySpan<PipelinePolicy> perTryPolicies)
    {
        if (clientType is null) throw new ArgumentNullException(nameof(clientType));
        if (options is null) throw new ArgumentNullException(nameof(options));

        int pipelineLength = perCallPolicies.Length + perTryPolicies.Length;

        if (options.PerTryPolicies != null)
        {
            pipelineLength += options.PerTryPolicies.Length;
        }

        if (options.PerCallPolicies != null)
        {
            pipelineLength += options.PerCallPolicies.Length;
        }

        pipelineLength += options.RetryPolicy is null ? 0 : 1;

        pipelineLength++; // for response buffering policy
        pipelineLength++; // for transport

        PipelinePolicy[] pipeline = new PipelinePolicy[pipelineLength];

        int index = 0;

        perCallPolicies.CopyTo(pipeline.AsSpan(index));
        index += perCallPolicies.Length;

        if (options.PerCallPolicies != null)
        {
            options.PerCallPolicies.CopyTo(pipeline.AsSpan(index));
            index += options.PerCallPolicies.Length;
        }

        if (options.RetryPolicy != null)
        {
            pipeline[index++] = options.RetryPolicy;
        }

        perTryPolicies.CopyTo(pipeline.AsSpan(index));
        index += perTryPolicies.Length;

        if (options.PerTryPolicies != null)
        {
            options.PerTryPolicies.CopyTo(pipeline.AsSpan(index));
            index += options.PerTryPolicies.Length;
        }

        TimeSpan networkTimeout = options.NetworkTimeout ?? ResponseBufferingPolicy.DefaultNetworkTimeout;
        ResponseBufferingPolicy bufferingPolicy = new(networkTimeout);
        pipeline[index++] = bufferingPolicy;

        if (options.Transport != null)
        {
            pipeline[index++] = options.Transport;
        }
        else
        {
            // Add default transport.
            pipeline[index++] = HttpClientPipelineTransport.Shared;
        }

        return new ClientPipeline(clientType, pipeline);
    }

    // TODO: note that without a common base type, nothing validates that ClientPipeline
    // and Azure.Core.HttpPipeline have the same API shape. This is something a human
    // must keep track of if we wanted to add a common base class later.
    public PipelineMessage CreateMessage(RequestOptions options)
    {
        PipelineMessage message = _transport.CreateMessage();
        options.Apply(message);
        return message;
    }

    public void Send(PipelineMessage message)
    {
        PipelineProcessor enumerator = new ClientPipelineProcessor(message, _policies);
        enumerator.ProcessNext();
    }

    public async ValueTask SendAsync(PipelineMessage message)
    {
        PipelineProcessor enumerator = new ClientPipelineProcessor(message, _policies);
        await enumerator.ProcessNextAsync().ConfigureAwait(false);
    }

    private static void AssertValidClient(Type cachedClient, Type callingClient)
    {
        if (cachedClient != callingClient)
        {
            throw new NotSupportedException($"Cannot use pipeline created by client of type '{cachedClient}' in client of type '{callingClient}'.");
        }
    }

    private class ClientPipelineProcessor : PipelineProcessor
    {
        private readonly PipelineMessage _message;
        private ReadOnlyMemory<PipelinePolicy> _policies;

        public ClientPipelineProcessor(
            PipelineMessage message,
            ReadOnlyMemory<PipelinePolicy> policies)
        {
            _message = message;
            _policies = policies;
        }

        public override int Length => _policies.Length;

        public override bool ProcessNext()
        {
            var first = _policies.Span[0];
            _policies = _policies.Slice(1);
            first.Process(_message, this);
            return _policies.Length > 0;
        }

        public override async ValueTask<bool> ProcessNextAsync()
        {
            var first = _policies.Span[0];
            _policies = _policies.Slice(1);
            await first.ProcessAsync(_message, this).ConfigureAwait(false);
            return _policies.Length > 0;
        }
    }
}
