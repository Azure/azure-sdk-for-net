﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Test.Stress;
using CommandLine;

namespace Azure.Security.ConfidentialLedgerBugBash.Stress
{
    public class ConfidentialLedgerBugBashClientTest : StressTest<ConfidentialLedgerBugBashClientTest.ConfidentialLedgerBugBashClientStressOptions, ConfidentialLedgerBugBashClientTest.ConfidentialLedgerBugBashClientStressMetrics>
    {
        public ConfidentialLedgerBugBashClientTest(ConfidentialLedgerBugBashClientStressOptions options, ConfidentialLedgerBugBashClientStressMetrics metrics) : base(options, metrics)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/stress/TemplateClientTest.cs to write stress tests. */

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("exec some async operation");
            });
        }
        public class ConfidentialLedgerBugBashClientStressMetrics : StressMetrics
        {
        }

        public class ConfidentialLedgerBugBashClientStressOptions : StressOptions
        {
        }
    }
}
