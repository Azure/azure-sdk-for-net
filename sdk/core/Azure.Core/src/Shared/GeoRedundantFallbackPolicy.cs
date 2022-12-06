// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Pipeline;

namespace Azure.Core.Shared
{
    /// <summary>
    /// Internal policy that can be used to support georedundant fallbacks for Azure services. The policy maintains the current healthy host
    /// across requests. It falls back only if no response is received from a request, i.e. any response is treated as an indication that the
    /// host is healthy.
    /// </summary>
    internal class GeoRedundantFallbackPolicy : HttpPipelineSynchronousPolicy, IDisposable
    {
        private readonly string[] _readFallbackHosts;
        private readonly string[] _writeFallbackHosts;
        private volatile int _readFallbackIndex = -1;
        private volatile int _writeFallbackIndex = -1;
        private readonly Timer _timer;
        private readonly TimeSpan _primaryCoolDown;

        /// <summary>
        /// Construct a new instance of the GeoRedundantFallbackPolicy.
        /// </summary>
        /// <param name="readFallbackHosts">The hosts to use as fallbacks for read operations.</param>
        /// <param name="writeFallbackHosts">The hosts to use as fallbacks for write operations.</param>
        /// <param name="primaryCoolDown">The amount of time to wait before the primary host will be used again after a failure.</param>
        public GeoRedundantFallbackPolicy(string[]? readFallbackHosts, string[]? writeFallbackHosts, TimeSpan? primaryCoolDown = default)
        {
            _readFallbackHosts = readFallbackHosts ?? Array.Empty<string>();
            _writeFallbackHosts = writeFallbackHosts ?? Array.Empty<string>();
            _primaryCoolDown = primaryCoolDown ?? TimeSpan.FromMinutes(10);
            _timer = new Timer(ResetPrimary, null, Timeout.Infinite, Timeout.Infinite);
        }

        private void ResetPrimary(object? state)
        {
            Interlocked.Exchange(ref _readFallbackIndex, -1);
            Interlocked.Exchange(ref _writeFallbackIndex, -1);
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// This can be used to indicate that the current host cannot be swapped for a specific request. This is useful when a client method
        /// must make multiple requests against the same endpoint.
        /// </summary>
        /// <param name="message">The message to mark the host affinity for.</param>
        /// <param name="hostAffinity">True if the host should not be swapped.</param>
        public static void SetHostAffinity(HttpMessage message, bool hostAffinity)
        {
            message.SetProperty(typeof(HostAffinityKey), hostAffinity);
        }

        private static bool GetHostAffinity(HttpMessage message)
        {
            return message.TryGetProperty(typeof(HostAffinityKey), out object? hostAffinity) && hostAffinity is true;
        }

        private static void SetPrimaryHost(HttpMessage message)
        {
            message.SetProperty(typeof(PrimaryHostKey), message.Request.Uri.Host!);
        }

        private static string GetPrimaryHost(HttpMessage message)
        {
            message.TryGetProperty(typeof(PrimaryHostKey), out object? primaryHost);
            return (string)primaryHost!;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        public override void OnSendingRequest(HttpMessage message)
        {
            // if host affinity is set, we should not change the host
            // client is responsible for setting this on a message that cannot fallback. Additionally,
            // client must set the host to the correct host based on previous calls.
            // Example - Method Foo makes two requests that must go to the same endpoint:
            // var firstMessage = _pipeline.CreateMessage();
            // ...
            // _pipeline.Send(firstMessage);
            //
            // var secondMessage = _pipeline.CreateMessage();
            // secondMessage.Request.Uri.Host = firstMessage.Request.Uri.Host;
            // GeoRedundantReadFallbackPolicy.SetHostAffinity(secondMessage, true);
            // ...
            // _pipeline.Send(secondMessage);
            if (message.HasResponse || GetHostAffinity(message) || message.Request.Uri.Host == null)
                return;

            bool isRead = message.Request.Method == RequestMethod.Get || message.Request.Method == RequestMethod.Head;

            if (message.ProcessingContext.RetryNumber == 0)
            {
                SetPrimaryHost(message);
                // set the host based on the fallback information
                UpdateHost(message, isRead);
                return;
            }

            ref int fallbackIndex = ref isRead ? ref _readFallbackIndex : ref _writeFallbackIndex;
            string[] fallbackHosts = isRead ? _readFallbackHosts : _writeFallbackHosts;
            int current = fallbackIndex;

            // we should only advance if another thread hasn't already done so
            if ((current == -1 && message.Request.Uri.Host.Equals(GetPrimaryHost(message), StringComparison.Ordinal)) ||
                (current != -1 && message.Request.Uri.Host.Equals(fallbackHosts[current], StringComparison.Ordinal)))
            {
                if (current == -1)
                    _timer.Change(_primaryCoolDown, Timeout.InfiniteTimeSpan);
                int next = current + 1;

                // reset to null to indicate primary should be used when we reach the end
                if (next >= fallbackHosts.Length)
                    next = -1;
                // advance the index
                Interlocked.CompareExchange(ref fallbackIndex, next, current);
            }

            UpdateHost(message, isRead);
        }

        private void UpdateHost(HttpMessage message, bool isRead)
        {
            if (isRead)
            {
                message.Request.Uri.Host = _readFallbackIndex != -1 ? _readFallbackHosts[_readFallbackIndex] : GetPrimaryHost(message);
            }
            else
            {
                message.Request.Uri.Host = _writeFallbackIndex != -1 ? _writeFallbackHosts[_writeFallbackIndex] : GetPrimaryHost(message);
            }
        }

        private class HostAffinityKey
        {
        }

        private class PrimaryHostKey
        {
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}