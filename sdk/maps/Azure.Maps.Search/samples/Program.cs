// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Maps.Search;
using Azure.Maps.Search.Models;

namespace Azure.Maps.Search.Samples
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var credential = new DefaultAzureCredential(true);
            var clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            var routeClient = new SearchClient(credential, clientId: clientId);
        }
    }
}
