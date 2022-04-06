// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Test.Stress;
using CommandLine;

namespace Azure.ServiceTemplate.Template.Stress
{
    public class TemplateClientTest : StressTest<TemplateClientTest.TemplateClientOptions, TemplateClientTest.TemplateClientMetrics>
    {
        public TemplateClientTest(TemplateClientOptions options, TemplateClientMetrics metrics) : base(options, metrics)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/stress/TemplateClientTest.cs to write stress tests. */
        
    }
}
