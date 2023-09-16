// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;

#nullable enable

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Internal policy that can be used to support georedundant fallbacks for Azure services. The policy maintains the current healthy host
    /// across requests. It falls back only if no response is received from a request, i.e. any response is treated as an indication that the
    /// host is healthy.
    /// </summary>
    internal class GeoRedundantFallbackPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly Fallback _writeFallback;
        private readonly Fallback _readFallback;

        /// <summary>
        /// Construct a new instance of the GeoRedundantFallbackPolicy.
        /// </summary>
        /// <param name="readFallbackHosts">The hosts to use as fallbacks for read operations.</param>
        /// <param name="writeFallbackHosts">The hosts to use as fallbacks for write operations.</param>
        /// <param name="primaryCoolDown">The amount of time to wait before the primary host will be used again after a failure.</param>
        public GeoRedundantFallbackPolicy(string[]? readFallbackHosts, string[]? writeFallbackHosts, TimeSpan? primaryCoolDown = default)
        {
            var cooldown = primaryCoolDown ?? TimeSpan.FromMinutes(10);
            _writeFallback = new Fallback(writeFallbackHosts ?? Array.Empty<string>(), cooldown);
            _readFallback = new Fallback(readFallbackHosts ?? Array.Empty<string>(), cooldown);
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
            Fallback fallback = isRead ? _readFallback : _writeFallback;

            if (fallback.Hosts.Length == 0)
                return;

            if (message.ProcessingContext.RetryNumber == 0)
            {
                // store the primary host in the message
                SetPrimaryHost(message);
                // set the host based on the fallback information
                UpdateHostIfNeeded(message, fallback);
                return;
            }

            fallback.AdvanceIfNeeded(message);
            UpdateHostIfNeeded(message, fallback);
        }

        private static void UpdateHostIfNeeded(HttpMessage message, Fallback fallback)
        {
            fallback.ResetPrimaryIfNeeded();

            int currentIndex = fallback.Index;
            message.Request.Uri.Host = currentIndex != -1 ? fallback.Hosts[currentIndex] : GetPrimaryHost(message);
        }

        private class HostAffinityKey
        {
        }

        private class PrimaryHostKey
        {
        }

        private class Fallback
        {
            public string[] Hosts { get; }

            public int Index => Volatile.Read(ref _index);
            private int _index;
            private long _ticks;
            private readonly TimeSpan _cooldown;

            public Fallback(string[] hosts, TimeSpan cooldown)
            {
                Hosts = hosts;
                _index = -1;
                _ticks = -1;
                _cooldown = cooldown;
            }

            public void AdvanceIfNeeded(HttpMessage message)
            {
                int currentIndex = Index;
                long currentTicks = Volatile.Read(ref _ticks);

                // we should only advance if another thread hasn't already done so
                if ((currentIndex == -1 && message.Request.Uri.Host!.Equals(GetPrimaryHost(message), StringComparison.Ordinal)) ||
                    (currentIndex != -1 && message.Request.Uri.Host!.Equals(Hosts[currentIndex], StringComparison.Ordinal)))
                {
                    int next = currentIndex + 1;

                    // reset to null to indicate primary should be used when we reach the end
                    if (next >= Hosts.Length)
                        next = -1;

                    // attempt to advance the index - it's possible another thread has already done so in which case the index will not be updated
                    // in this thread
                    Interlocked.CompareExchange(ref _index, next, currentIndex);

                    // if we are falling back from primary, attempt to update the fallback ticks
                    if (currentIndex == -1)
                        Interlocked.CompareExchange(ref _ticks, Stopwatch.GetTimestamp(), currentTicks);
                }
            }

            public void ResetPrimaryIfNeeded()
            {
                long currentTicks = Volatile.Read(ref _ticks);
                int currentIndex = Index;

                if (currentTicks != -1)
                {
                    long nowTicks = Stopwatch.GetTimestamp();
                    if (nowTicks - currentTicks >= _cooldown.Ticks)
                    {
                        Interlocked.CompareExchange(ref _index, -1, currentIndex);
                        Interlocked.CompareExchange(ref _ticks, -1, currentTicks);
                    }
                }
            }
        }
    }
}
