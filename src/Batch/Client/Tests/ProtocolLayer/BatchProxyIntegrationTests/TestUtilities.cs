// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace BatchProxyIntegrationTests
{
    using System;
    using System.Linq;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.Protocol;
    using Microsoft.Azure.Batch.Protocol.Models;
    using Xunit.Abstractions;

    public static class TestUtilities
    {
        public static void DeleteJobIfExistsNoThrow(BatchServiceClient client, string jobId, ITestOutputHelper output)
        {
            try
            {
                client.Job.Delete(jobId);
            }
            catch (BatchException e)
            {
                output.WriteLine("Job failed to delete: {0}", e);
            }
        }

        public static void DeletePoolIfExistsNoThrow(BatchServiceClient client, string poolId, ITestOutputHelper output)
        {
            try
            {
                client.Pool.Delete(poolId);
            }
            catch (BatchException e)
            {
                output.WriteLine("Pool failed to delete: {0}", e);
            }
        }
    }
}
