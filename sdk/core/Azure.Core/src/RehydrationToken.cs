// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core
{
    /// <summary>
    /// Represents a token that can be used to rehydrate a long-running operation.
    /// </summary>
    public readonly partial struct RehydrationToken
    {
        /// <summary>
        /// Gets an ID representing the operation that can be used to poll for
        /// the status of the long-running operation.
        /// There are cases that operation id is not available, we return "NOT_SET" for unavailable operation id.
        /// </summary>
        public string Id { get; } = NextLinkOperationImplementation.NotSet;

        /// <summary>
        /// Version the <see cref="RehydrationToken"/> struct.
        /// </summary>
        public string Version { get; } = NextLinkOperationImplementation.RehydrationTokenVersion;

        /// <summary>
        /// The header source of the operation, could be None, OperationLocation, AzureAsyncOperation or Location.
        /// </summary>
        public string HeaderSource { get; }

        /// <summary>
        /// The polling Uri of the operation.
        /// </summary>
        public string NextRequestUri { get; }

        /// <summary>
        /// The initial Uri of the operation.
        /// </summary>
        public string InitialUri { get; }

        /// <summary>
        /// The Http request method of the operation.
        /// </summary>
        public RequestMethod RequestMethod { get; }

        /// <summary>
        /// The last known location of the operation.
        /// </summary>
        public string? LastKnownLocation { get; }

        /// <summary>
        /// The final state of the operation, could be AzureAsyncOperation, Location, OriginalUri, OperationLocation or LocationOverride.
        /// </summary>
        public string FinalStateVia { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RehydrationToken"/> struct.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="headerSource"></param>
        /// <param name="nextRequestUri"></param>
        /// <param name="initialUri"></param>
        /// <param name="requestMethod"></param>
        /// <param name="lastKnownLocation"></param>
        /// <param name="finalStateVia"></param>
        public RehydrationToken(string? id, string? version, string headerSource, string nextRequestUri, string initialUri, RequestMethod requestMethod, string? lastKnownLocation, string finalStateVia)
        {
            if (id is not null)
            {
                Id = id;
            }
            if (version is not null)
            {
                Version = version;
            }
            HeaderSource = headerSource;
            NextRequestUri = nextRequestUri;
            InitialUri = initialUri;
            RequestMethod = requestMethod;
            LastKnownLocation = lastKnownLocation;
            FinalStateVia = finalStateVia;
        }
    }
}
