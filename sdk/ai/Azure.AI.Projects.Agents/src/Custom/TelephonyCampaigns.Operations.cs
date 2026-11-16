// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

public partial class TelephonyCampaigns
{
    private OperationResult ProcessCampaignOperation(PipelineMessage message, RequestOptions options, bool waitUntilCompleted, string agentName, string campaignName)
    {
        message.BufferResponse = true;
        PipelineResponse response = Pipeline.ProcessMessage(message, options);
        CampaignOperationResult operation = new(this, agentName, campaignName, response);
        if (waitUntilCompleted)
        {
            operation.WaitForCompletion(options);
        }
        return operation;
    }

    private async Task<OperationResult> ProcessCampaignOperationAsync(PipelineMessage message, RequestOptions options, bool waitUntilCompleted, string agentName, string campaignName)
    {
        message.BufferResponse = true;
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        CampaignOperationResult operation = new(this, agentName, campaignName, response);
        if (waitUntilCompleted)
        {
            await operation.WaitForCompletionAsync(options).ConfigureAwait(false);
        }
        return operation;
    }

    private sealed class CampaignOperationResult : OperationResult
    {
        private readonly TelephonyCampaigns _client;
        private readonly string _agentName;
        private readonly string _campaignName;
        private readonly string _operationId;
        private bool _monitorSucceeded;

        internal CampaignOperationResult(TelephonyCampaigns client, string agentName, string campaignName, PipelineResponse response)
            : base(response)
        {
            _client = client;
            _agentName = agentName;
            _campaignName = campaignName;
            HasCompleted = response.IsError;
            // Campaign.operation_id can change after another action; only this response identifies our operation.
            if (!HasCompleted && (!response.Headers.TryGetValue("Operation-Id", out _operationId) || string.IsNullOrWhiteSpace(_operationId)))
            {
                throw new InvalidOperationException("The campaign operation response must include its initiating Operation-Id.");
            }
        }

        public override ContinuationToken RehydrationToken { get; protected set; }

        public override ClientResult UpdateStatus(RequestOptions options = default)
        {
            if (HasCompleted)
            {
                return ClientResult.FromResponse(GetRawResponse());
            }
            if (!_monitorSucceeded)
            {
                ClientResult monitor = _client.GetOperation(_agentName, _campaignName, _operationId, options);
                if (!ApplyMonitor(monitor))
                {
                    return monitor;
                }
            }
            PipelineResponse monitorResponse = GetRawResponse();
            ClientResult result = _client.Get(_agentName, _campaignName, _operationId, options);
            SetRawResponse(result.GetRawResponse());
            monitorResponse.Dispose();
            HasCompleted = true;
            return result;
        }

        public override async ValueTask<ClientResult> UpdateStatusAsync(RequestOptions options = default)
        {
            if (HasCompleted)
            {
                return ClientResult.FromResponse(GetRawResponse());
            }
            if (!_monitorSucceeded)
            {
                ClientResult monitor = await _client.GetOperationAsync(_agentName, _campaignName, _operationId, options).ConfigureAwait(false);
                if (!ApplyMonitor(monitor))
                {
                    return monitor;
                }
            }
            PipelineResponse monitorResponse = GetRawResponse();
            ClientResult result = await _client.GetAsync(_agentName, _campaignName, _operationId, options).ConfigureAwait(false);
            SetRawResponse(result.GetRawResponse());
            monitorResponse.Dispose();
            HasCompleted = true;
            return result;
        }

        private bool ApplyMonitor(ClientResult result)
        {
            PipelineResponse response = result.GetRawResponse();
            SetRawResponse(response);
            if (response.IsError)
            {
                HasCompleted = true;
                return false;
            }
            TelephonyCampaignOperation monitor = (TelephonyCampaignOperation)result;
            if (monitor.Id != _operationId || string.IsNullOrEmpty(monitor.Status.ToString()))
            {
                throw new JsonException("The campaign monitor must identify the initiating operation and its status.");
            }
            _monitorSucceeded = monitor.Status == AgentsJobStatus.Succeeded;
            HasCompleted = monitor.Status == AgentsJobStatus.Failed || monitor.Status == AgentsJobStatus.Cancelled ||
                string.Equals(monitor.Status.ToString(), "canceled", StringComparison.OrdinalIgnoreCase);
            return _monitorSucceeded;
        }

        public override void WaitForCompletion(CancellationToken cancellationToken = default)
            => WaitForCompletion(cancellationToken.ToRequestOptions());

        public override ValueTask WaitForCompletionAsync(CancellationToken cancellationToken = default)
            => WaitForCompletionAsync(cancellationToken.ToRequestOptions());

        internal void WaitForCompletion(RequestOptions options)
        {
            CancellationToken cancellationToken = options?.CancellationToken ?? default;
            while (!HasCompleted)
            {
                TimeSpan remaining = GetPollingDelay();
                while (remaining > TimeSpan.Zero)
                {
                    TimeSpan delay = remaining > TimeSpan.FromDays(1) ? TimeSpan.FromDays(1) : remaining;
                    if (cancellationToken.WaitHandle.WaitOne(delay))
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                    remaining -= delay;
                }
                UpdateStatus(options);
            }
        }

        internal async ValueTask WaitForCompletionAsync(RequestOptions options)
        {
            CancellationToken cancellationToken = options?.CancellationToken ?? default;
            while (!HasCompleted)
            {
                TimeSpan remaining = GetPollingDelay();
                while (remaining > TimeSpan.Zero)
                {
                    TimeSpan delay = remaining > TimeSpan.FromDays(1) ? TimeSpan.FromDays(1) : remaining;
                    await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
                    remaining -= delay;
                }
                await UpdateStatusAsync(options).ConfigureAwait(false);
            }
        }

        private TimeSpan GetPollingDelay()
        {
            if (!GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
            {
                return TimeSpan.FromSeconds(1);
            }
            if (!int.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out int seconds))
            {
                throw new FormatException("The campaign Retry-After header must contain a nonnegative number of seconds.");
            }
            return TimeSpan.FromSeconds(seconds);
        }
    }
}
