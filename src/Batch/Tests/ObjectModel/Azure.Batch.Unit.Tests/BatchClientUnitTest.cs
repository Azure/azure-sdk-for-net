namespace Azure.Batch.Unit.Tests
{
    using System;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Xunit;

    public class BatchClientUnitTest
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestBatchClientThrowsAfterDispose()
        {
            BatchClient batchCli;

            // test dispose calls close
            using (batchCli = ClientUnitTestCommon.CreateDummyClient())
            {
            }

            TestBatchClientIsClosed(batchCli);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestBatchClientThrowsAfterClose()
        {
            // test explicit close
            BatchClient batchCli = ClientUnitTestCommon.CreateDummyClient();

            // close client and test
            batchCli.Close();

            TestBatchClientIsClosed(batchCli);
        }

        private static void TestBatchClientIsClosed(BatchClient batchCli)
        {
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.CustomBehaviors; });
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.CertificateOperations; });
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.JobOperations; });
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.JobScheduleOperations; });
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.PoolOperations; });
            Assert.Throws<InvalidOperationException>(() => { var foo = batchCli.Utilities; });
        }
    }
}
