// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    internal static class ClientOptionsExtensions
    {
        public static void ConfigureLogging(this ClientOptions clientOptions)
        {
            IList<string> loggedHeaderNames = clientOptions.Diagnostics.LoggedHeaderNames;
            loggedHeaderNames.Add("Operation-Location");
            loggedHeaderNames.Add("x-envoy-upstream-service-time");
            loggedHeaderNames.Add("apim-request-id");
            loggedHeaderNames.Add("Strict-Transport-Security");
            loggedHeaderNames.Add("x-content-type-options");
            loggedHeaderNames.Add("warn-text");

            clientOptions.Diagnostics.LoggedQueryParameters.Add("jobId");
            clientOptions.Diagnostics.LoggedQueryParameters.Add("$top");
            clientOptions.Diagnostics.LoggedQueryParameters.Add("$skip");
            clientOptions.Diagnostics.LoggedQueryParameters.Add("showStats");
            clientOptions.Diagnostics.LoggedQueryParameters.Add("model-version");
            clientOptions.Diagnostics.LoggedQueryParameters.Add("domain");
            clientOptions.Diagnostics.LoggedQueryParameters.Add("stringIndexType");
            clientOptions.Diagnostics.LoggedQueryParameters.Add("piiCategories");
            clientOptions.Diagnostics.LoggedQueryParameters.Add("opinionMining");

            clientOptions.Diagnostics.LoggedQueryParameters.Add("top");
            clientOptions.Diagnostics.LoggedQueryParameters.Add("skip");
        }
    }
}
