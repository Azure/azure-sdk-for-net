// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.Core
{
    internal partial struct RehydrationToken
    {
        public string Version { get; } = "1.0.0";

        public HeaderSource HeaderSource { get; }

        public string NextRequestUri { get; }

        public string InitialUri { get; }

        public RequestMethod RequestMethod { get; }

        public bool OriginalResponseHasLocation { get; }

        public string? LastKnownLocation { get; }

        public OperationFinalStateVia FinalStateVia { get; }

        internal RehydrationToken(string version, HeaderSource headerSource, string nextRequestUri, string initialUri, RequestMethod requestMethod, bool originalResponseHasLocation, string? lastKnownLocation, OperationFinalStateVia finalStateVia)
        {
            Version = version;
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
