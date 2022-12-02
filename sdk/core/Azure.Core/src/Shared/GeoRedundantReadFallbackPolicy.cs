// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Core.Shared
{
    /// <summary>
    ///
    /// </summary>
    internal class GeoRedundantReadFallbackPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string[] _readFallbackHosts;
        private int? _fallbackIndex;
        private readonly object _syncLock = new();

        /// <summary>
        ///
        /// </summary>
        /// <param name="readFallbackHosts"></param>
        public GeoRedundantReadFallbackPolicy(string[] readFallbackHosts)
        {
            _readFallbackHosts = readFallbackHosts;
        }

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
            // TODO implement policy for write hosts as well (or include in this policy)
            if (message.Request.Method != RequestMethod.Get && message.Request.Method != RequestMethod.Head)
                return;

            if (message.HasResponse || GetHostAffinity(message))
                return;

            if (message.ProcessingContext.RetryNumber == 0)
            {
                SetPrimaryHost(message);
                // avoid locking for common path - there is a chance that the index would be incremented here by another thread but we prioritize
                // throughput over correctness in this case
                if (_fallbackIndex == null)
                    return;
            }

            // must be under lock so that this can be synchronized across client calls - each call should leverage the fallback information
            // from all other calls
            lock (_syncLock)
            {
                // cannot change the host - client is responsible for setting this on a message that cannot fallback. Additionally,
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

                // first attempt - use fallback host if set
                if (message.ProcessingContext.RetryNumber == 0)
                {
                    UpdateHost(message);
                    return;
                }

                // subsequent attempt

                // we should only advance if another thread hasn't already done so
                bool shouldAdvance = (_fallbackIndex == null && message.Request.Uri.Host == GetPrimaryHost(message)) ||
                                  (_fallbackIndex != null && message.Request.Uri.Host == _readFallbackHosts[_fallbackIndex.Value]);

                if (!shouldAdvance)
                    return;

                // advance the index
                _fallbackIndex ??= -1;
                _fallbackIndex++;

                // reset to null to indicate primary should be used when we reach the end
                if (_fallbackIndex >= _readFallbackHosts.Length)
                    _fallbackIndex = null;

                UpdateHost(message);
            }
        }

        private void UpdateHost(HttpMessage message)
        {
            if (_fallbackIndex.HasValue)
            {
                message.Request.Uri.Host = _readFallbackHosts[_fallbackIndex.Value];
            }
            else
            {
                message.Request.Uri.Host = GetPrimaryHost(message);
            }
        }

        private class HostAffinityKey
        {
        }

        private class PrimaryHostKey
        {
        }
    }
}