// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.Hosting
{
    internal static class StorageQueueTriggerValidator
    {
        internal static async Task<bool> ValidateAsync(
            TriggerMetadata triggerMetadata,
            string connectionName,
            TokenCredential tokenCredential,
            IDictionary<string, string> env,
            ILogger logger)
        {
            QueueServiceClient serviceClient = null;

            if (TryGetConnectionString(env, connectionName, out string connectionString))
            {
                serviceClient = new QueueServiceClient(connectionString);
            }
            else if (tokenCredential != null && TryGetServiceUri(connectionName, out Uri serviceUri))
            {
                serviceClient = new QueueServiceClient(serviceUri, tokenCredential);
            }
            else
            {
                //TODO: Find better validation. for now, Cannot validate (no connection string and no service URI); skip.
                return true;
            }

            string queueName = TryGetQueueName(triggerMetadata);
            if (string.IsNullOrEmpty(queueName))
            {
                //TODO: What to do here.Maybe If we cannot determine the queue name we cannot probe. Do not fail validation; scaling/runtime will surface issues later.
                return true;
            }

            try
            {
                // Queue names in the runtime path are normalized to lower-case.
                queueName = queueName.ToLowerInvariant();
                var queueClient = serviceClient.GetQueueClient(queueName);
                // Lightweight exists call to verify auth + basic access. (HEAD request)
                await queueClient.ExistsAsync().ConfigureAwait(false);
                return true;
            }
            catch (RequestFailedException rfx)
            {
                //TODO: What about warnings here? Error ?
                logger.LogWarning($"[Queue Validate] Probe failed (Status {rfx.Status}) for '{triggerMetadata.FunctionName}'.");
                return false;
            }
            catch (Exception ex)
            {
                logger.LogWarning($"[Queue Validate] Unexpected probe error {ex.GetType().Name} for '{triggerMetadata.FunctionName}'.");
                return false;
            }
        }

        private static bool TryGetServiceUri(string connectionName, out Uri uri)
        {
            uri = null;
            string raw =
                Environment.GetEnvironmentVariable($"{connectionName}__queueServiceUri")
                ?? Environment.GetEnvironmentVariable($"{connectionName}__serviceUri");
            if (!string.IsNullOrEmpty(raw) && Uri.IsWellFormedUriString(raw, UriKind.Absolute))
            {
                uri = new Uri(raw);
                return true;
            }
            return false;
        }

        private static bool TryGetConnectionString(IDictionary<string, string> env, string connectionName, out string value)
        {
            value = null;
            if (env == null)
            {
                return false;
            }

            if (env.TryGetValue(connectionName, out var direct) && LooksLikeConnectionString(direct))
            {
                value = direct;
                return true;
            }
            if (env.TryGetValue($"ConnectionStrings:{connectionName}", out var cs) && LooksLikeConnectionString(cs))
            {
                value = cs;
                return true;
            }
            return false;
        }

        private static bool LooksLikeConnectionString(string candidate)
        {
            if (string.IsNullOrEmpty(candidate))
            {
                return false;
            }
            // Heuristic markers for a storage account connection string.
            return candidate.Contains("AccountKey=")
                && candidate.Contains("AccountName=");
        }

        private static string TryGetQueueName(TriggerMetadata triggerMetadata)
        {
            try
            {
                if (triggerMetadata?.Metadata == null)
                {
                    return null;
                }

                // Metadata is serialized (for scale controller) – attempt to parse JSON then look for common fields.
                using var doc = JsonDocument.Parse(triggerMetadata.Metadata.ToString());
                var root = doc.RootElement;
                if (root.ValueKind == JsonValueKind.Object)
                {
                    if (root.TryGetProperty("queueName", out var qn) && qn.ValueKind == JsonValueKind.String)
                    {
                        return qn.GetString();
                    }
                    if (root.TryGetProperty("QueueName", out var qn2) && qn2.ValueKind == JsonValueKind.String)
                    {
                        return qn2.GetString();
                    }
                }
            }
            catch
            {
                // TODO: Think of what to do here. For now, swallow and return null.
            }
            return null;
        }
    }
}
