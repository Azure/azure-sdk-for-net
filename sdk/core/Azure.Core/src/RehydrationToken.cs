// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

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
        /// </summary>
        public Guid? Id { get; }

        internal string Version { get; } = "1.0.0";

        internal HeaderSource HeaderSource { get; }

        internal string NextRequestUri { get; }

        internal string InitialUri { get; }

        internal RequestMethod RequestMethod { get; }

        internal bool OriginalResponseHasLocation { get; }

        internal string? LastKnownLocation { get; }

        internal OperationFinalStateVia FinalStateVia { get; }

        internal RehydrationToken(Guid? id, string? version, HeaderSource headerSource, string nextRequestUri, string initialUri, RequestMethod requestMethod, bool originalResponseHasLocation, string? lastKnownLocation, OperationFinalStateVia finalStateVia)
        {
            Id = id;
            if (version is not null)
            {
                Version = version;
            }
            HeaderSource = headerSource;
            NextRequestUri = nextRequestUri;
            InitialUri = initialUri;
            RequestMethod = requestMethod;
            OriginalResponseHasLocation = originalResponseHasLocation;
            LastKnownLocation = lastKnownLocation;
            FinalStateVia = finalStateVia;
        }
    }
}
