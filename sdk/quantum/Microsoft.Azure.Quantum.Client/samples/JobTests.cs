// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Quantum.Client;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
//using NUnit.Framework;


namespace Microsoft.Azure.Quantum.JobTests
{
    public class JobTests : ClientTestBase
    {
        public JobTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }
    }
}
