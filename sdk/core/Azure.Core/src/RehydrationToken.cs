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
        /// </summary>
        public string? Id { get; }

        // Version for this contract itself since we might change the members in the future.
        internal string Version { get; } = "1.0.0";

        // The below members are used to re-construct <cref="NextLinkOperationImplemenation">.
        // Value of <cref="NextLinkOperationImplemenration.HeaderSrouce">.
        internal string HeaderSource { get; }

        // The polling Uri of the operation.
        internal string NextRequestUri { get; }

        // The initial Uri of the operation.
        internal string InitialUri { get; }

        // The Http request method of the operation.
        internal RequestMethod RequestMethod { get; }

        // The last known location of the operation.
        internal string? LastKnownLocation { get; }

        // The final state of the operation, could be azure-async-operation, location, original-uri or operation-location.
        internal string FinalStateVia { get; }

        internal RehydrationToken(string? id, string? version, string headerSource, string nextRequestUri, string initialUri, RequestMethod requestMethod, string? lastKnownLocation, string finalStateVia)
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
            LastKnownLocation = lastKnownLocation;
            FinalStateVia = finalStateVia;
        }
    }
}
