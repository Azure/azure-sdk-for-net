// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    internal static class ClientOptionsExtensions
    {
        public static void ConfigureLogging(this ClientOptions clientOptions)
        {
            IList<string> loggedHeaderNames = clientOptions.Diagnostics.LoggedHeaderNames;
            loggedHeaderNames.Add("Access-Control-Allow-Credentials");
            loggedHeaderNames.Add("Access-Control-Allow-Headers");
            loggedHeaderNames.Add("Access-Control-Allow-Methods");
            loggedHeaderNames.Add("Access-Control-Allow-Origin");
            loggedHeaderNames.Add("Etag");
            loggedHeaderNames.Add("Last-Modified");
            loggedHeaderNames.Add("Strict-transport-security");
            loggedHeaderNames.Add("Sync-Token");
            loggedHeaderNames.Add("x-ms-correlation-request-id");
            loggedHeaderNames.Add("x-ms-request-id ");
        }
    }
}
