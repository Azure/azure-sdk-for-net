// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resources;
using ResourceGroups.Tests;
using Microsoft.Azure.Management.PowerBIEmbedded;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;

namespace PowerBIEmbedded.Tests.Helpers
{
    public static class PowerBITestUtilities
    {
        public static string DefaultLocation = "WestUS";

        public static PowerBIEmbeddedManagementClient GetPowerBiEmbeddedManagementClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            return context.GetServiceClient<PowerBIEmbeddedManagementClient>(handlers: handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        public static void WaitSeconds(double seconds)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(seconds));
            }
        }

        public static string GenerateName(string prefix = null, [System.Runtime.CompilerServices.CallerMemberName]string methodName = "GenerateName_failed")
        {
            return HttpMockServer.GetAssetName(methodName, prefix);
        }
    }
}
