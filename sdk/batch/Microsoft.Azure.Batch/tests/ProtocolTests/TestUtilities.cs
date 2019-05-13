// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchProxyIntegrationTests
{
    using System;
    using System.Linq;
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
            catch (BatchErrorException e)
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
            catch (BatchErrorException e)
            {
                output.WriteLine("Pool failed to delete: {0}", e);
            }
        }
    }
}
