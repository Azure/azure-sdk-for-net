// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Quantum.Jobs.Models;
using NUnit.Framework;

namespace Azure.Quantum.Jobs.Tests
{
    public class QuantumJobClientRecordedTestSanitizer : RecordedTestSanitizer
    {
        public QuantumJobClientRecordedTestSanitizer()
            : base()
        {
            JsonPathSanitizers.Add("$..containerUri");
            JsonPathSanitizers.Add("$..inputDataUri");
            JsonPathSanitizers.Add("$..outputDataUri");
            JsonPathSanitizers.Add("$..sasUri");
        }
    }
}
