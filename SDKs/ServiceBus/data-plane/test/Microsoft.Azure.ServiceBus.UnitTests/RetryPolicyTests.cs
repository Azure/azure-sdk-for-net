namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Threading.Tasks;
    using System.Transactions;
    using Xunit;

    public class RetryPolicyTests
    {
        [Fact]
        [DisplayTestMethodName]
        public async Task Should_retry_when_throttled_and_no_ambient_transaction_is_detected()
        {
            var retryPolicy = RetryPolicy.Default;

            var numberOfExecutions = 0;

            await retryPolicy.RunOperation(() =>
            {
                if (numberOfExecutions > 1)
                {
                    return Task.CompletedTask;
                }

                numberOfExecutions++;

                throw new ServerBusyException("Rico KABOOM!");
            }, TimeSpan.FromSeconds(30));

            Assert.Equal(2, numberOfExecutions);
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task Should_not_retry_when_throttled_and_ambient_transaction_is_detected()
        {
            var retryPolicy = RetryPolicy.Default;
            var numberOfExecutions = 0;

            using (var tx = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled))
            {
                await Assert.ThrowsAsync<ServerBusyException>(() =>
                    retryPolicy.RunOperation(() =>
                    {
                        if (numberOfExecutions > 1)
                        {
                            return Task.CompletedTask;
                        }

                        numberOfExecutions++;

                        throw new ServerBusyException("Rico KABOOM!");
                    }, TimeSpan.FromSeconds(30)));
            }

            Assert.Equal(1, numberOfExecutions);
        }
    }
}