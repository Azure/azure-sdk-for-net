// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Blobs.Test
{
    /// <summary>
    /// Thread-safe pipeline policy that counts session-auth and CreateSession
    /// requests using <see cref="Interlocked"/>.  Used by session tests to
    /// assert the correct authentication strategy without manual message iteration.
    /// </summary>
    internal class SessionAuthCountingPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _containerName;
        private int _getSessionAuthCount;
        private int _createSessionCount;
        private int _nonGetSessionAuthCount;
        private int _bearerGetBlobCount;
        private int _bearerNonGetCount;
        private int _getLayoutCount;
        private int _layoutSessionAuthCount;
        private int _layoutBearerCount;
        private int _routedRequestCount;
        private volatile bool _enabled;
        private readonly List<string> _getBlobSessionTokens = new List<string>();
        private readonly List<string> _routedHosts = new List<string>();
        private readonly object _tokensLock = new object();

        /// <summary>Session tokens observed on GET blob requests, in order.</summary>
        public IReadOnlyList<string> GetBlobSessionTokens
        {
            get
            {
                lock (_tokensLock)
                {
                    return _getBlobSessionTokens.ToArray();
                }
            }
        }

        /// <summary>Number of GET blob requests authenticated with a session token.</summary>
        public int GetSessionAuthCount => _getSessionAuthCount;

        /// <summary>Number of CreateSession POST requests observed.</summary>
        public int CreateSessionCount => _createSessionCount;

        /// <summary>Number of non-GET requests that carried a session auth header (should typically be 0).</summary>
        public int NonGetSessionAuthCount => _nonGetSessionAuthCount;

        /// <summary>Number of GET blob requests authenticated with a bearer token.</summary>
        public int BearerGetBlobCount => _bearerGetBlobCount;

        /// <summary>Number of non-GET-blob requests authenticated with a bearer token.</summary>
        public int BearerNonGetCount => _bearerNonGetCount;

        /// <summary>Number of Get Blob Layout requests observed (GET with <c>comp=layout</c>).</summary>
        public int GetLayoutCount => _getLayoutCount;

        /// <summary>Number of layout requests authenticated with a session token.</summary>
        public int LayoutSessionAuthCount => _layoutSessionAuthCount;

        /// <summary>Number of layout requests authenticated with a bearer token.</summary>
        public int LayoutBearerCount => _layoutBearerCount;

        /// <summary>
        /// Number of requests whose URI host was rewritten by
        /// <c>DataLocalityPolicy</c> to a layout endpoint. The policy preserves the
        /// original authority on the Host header, so a mismatch between the request
        /// URI host and the Host header is proof locality-aware routing was applied.
        /// </summary>
        public int RoutedRequestCount => _routedRequestCount;

        /// <summary>Layout endpoint hosts requests were routed to, in order.</summary>
        public IReadOnlyList<string> RoutedHosts
        {
            get
            {
                lock (_tokensLock)
                {
                    return _routedHosts.ToArray();
                }
            }
        }

        /// <param name="containerName">
        /// Container name to scope counting to, or <c>null</c> to match any container.
        /// </param>
        public SessionAuthCountingPolicy(string containerName) => _containerName = containerName;

        public void Start() => _enabled = true;

        public void Reset()
        {
            Interlocked.Exchange(ref _getSessionAuthCount, 0);
            Interlocked.Exchange(ref _createSessionCount, 0);
            Interlocked.Exchange(ref _nonGetSessionAuthCount, 0);
            Interlocked.Exchange(ref _bearerGetBlobCount, 0);
            Interlocked.Exchange(ref _bearerNonGetCount, 0);
            Interlocked.Exchange(ref _getLayoutCount, 0);
            Interlocked.Exchange(ref _layoutSessionAuthCount, 0);
            Interlocked.Exchange(ref _layoutBearerCount, 0);
            Interlocked.Exchange(ref _routedRequestCount, 0);
            lock (_tokensLock)
            {
                _getBlobSessionTokens.Clear();
                _routedHosts.Clear();
            }
        }

        public override void OnReceivedResponse(HttpMessage message)
        {
            if (!_enabled)
            {
                return;
            }

            BlobUriBuilder uriBuilder = new BlobUriBuilder(message.Request.Uri.ToUri());
            bool containerMatch = _containerName == null
                || string.Equals(uriBuilder.BlobContainerName, _containerName, StringComparison.InvariantCultureIgnoreCase);

            bool hasAuth = message.Request.Headers.TryGetValue("Authorization", out string authHeader);
            bool hasSessionAuth = hasAuth && authHeader.StartsWith("Session ", StringComparison.Ordinal);
            bool hasBearerAuth = hasAuth && authHeader.StartsWith("Bearer ", StringComparison.Ordinal);

            // Get Blob Layout is a GET against the blob URI with comp=layout. It must
            // not be lumped in with the data GETs, or it would skew the session and
            // bearer blob counts.
            bool isLayoutRequest = message.Request.Method == RequestMethod.Get
                && containerMatch
                && !string.IsNullOrEmpty(uriBuilder.BlobName)
                && uriBuilder.Query != null
                && uriBuilder.Query.Contains("comp=layout");

            bool isGetBlob = message.Request.Method == RequestMethod.Get
                && containerMatch
                && !string.IsNullOrEmpty(uriBuilder.BlobName)
                && !isLayoutRequest;

            if (isLayoutRequest)
            {
                Interlocked.Increment(ref _getLayoutCount);
                if (hasSessionAuth)
                {
                    Interlocked.Increment(ref _layoutSessionAuthCount);
                }
                if (hasBearerAuth)
                {
                    Interlocked.Increment(ref _layoutBearerCount);
                }
            }

            // DataLocalityPolicy rewrites the request URI host to the layout endpoint
            // while preserving the original authority on the Host header, so a
            // mismatch here is the on-the-wire signal that routing was applied.
            if (message.Request.Headers.TryGetValue("Host", out string hostHeader)
                && !string.IsNullOrEmpty(hostHeader))
            {
                string requestHost = message.Request.Uri.Host;
                string hostHeaderHost = hostHeader.Split(':')[0];
                if (!string.Equals(requestHost, hostHeaderHost, StringComparison.OrdinalIgnoreCase))
                {
                    Interlocked.Increment(ref _routedRequestCount);
                    lock (_tokensLock)
                    {
                        _routedHosts.Add(requestHost);
                    }
                }
            }

            if (hasSessionAuth)
            {
                if (isGetBlob)
                {
                    Interlocked.Increment(ref _getSessionAuthCount);
                    // Authorization is "Session {sessionToken}:{perRequestSignature}".
                    // The signature is HMAC'd per request, so capture only the session
                    // token portion (between "Session " and the last ':') so that
                    // "same session" comparisons across requests work.
                    const string scheme = "Session ";
                    string sessionToken = authHeader;
                    int lastColon = authHeader.LastIndexOf(':');
                    if (lastColon > scheme.Length)
                    {
                        sessionToken = authHeader.Substring(scheme.Length, lastColon - scheme.Length);
                    }
                    lock (_tokensLock)
                    {
                        _getBlobSessionTokens.Add(sessionToken);
                    }
                }
                else if (!isLayoutRequest)
                {
                    Interlocked.Increment(ref _nonGetSessionAuthCount);
                }
            }

            if (hasBearerAuth)
            {
                if (isGetBlob)
                {
                    Interlocked.Increment(ref _bearerGetBlobCount);
                }
                else if (!isLayoutRequest)
                {
                    Interlocked.Increment(ref _bearerNonGetCount);
                }
            }

            if (message.Request.Method == RequestMethod.Post
                && containerMatch
                && string.IsNullOrEmpty(uriBuilder.BlobName)
                && uriBuilder.Query == "restype=container&comp=session")
            {
                Interlocked.Increment(ref _createSessionCount);
            }
        }
    }
}
