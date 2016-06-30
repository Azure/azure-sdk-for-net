namespace BatchProxyIntegrationTests
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
