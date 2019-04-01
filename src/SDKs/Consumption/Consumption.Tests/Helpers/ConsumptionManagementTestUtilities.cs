// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net;
using System.Threading;

namespace Consumption.Tests.Helpers
{
    public static class ConsumptionTestUtilities
    {
        public static ConsumptionManagementClient GetConsumptionManagementClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            var client = context.GetServiceClient<ConsumptionManagementClient>(handlers:
                handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
            return client;
        }
    }
}