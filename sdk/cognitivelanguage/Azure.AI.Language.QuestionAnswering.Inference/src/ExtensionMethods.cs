// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering.Inference
{
    internal static class ExtensionMethods
    {
        public static void ConfigureLogging(this ClientOptions options)
        {
            IList<string> loggedHeaderNames = options.Diagnostics.LoggedHeaderNames;
            loggedHeaderNames.Add("Operation-Location");
            loggedHeaderNames.Add("Strict-Transport-Security");
            loggedHeaderNames.Add("apim-request-id");
            loggedHeaderNames.Add("x-content-type-options");
            loggedHeaderNames.Add("x-envoy-upstream-service-time");

            IList<string> loggedQueryParameters = options.Diagnostics.LoggedQueryParameters;
            loggedQueryParameters.Add("deploymentName");
            loggedQueryParameters.Add("projectName");
        }
    }
}
