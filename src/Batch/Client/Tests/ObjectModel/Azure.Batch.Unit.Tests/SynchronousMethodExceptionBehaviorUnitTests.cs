﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Protocol;
    using Xunit;

    public class SynchronousMethodExceptionBehaviorUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void SynchronousMethodsPreserveProtocolLayerExceptions()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                const string dummyJobId = "Foo";
                batchClient.CustomBehaviors.Add(new RequestInterceptor(req =>
                    {
                        throw new ArgumentException();
                    }));

                Assert.Throws<ArgumentException>(() => batchClient.JobOperations.GetJob(dummyJobId));
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void SynchronousMethodsPreserveProtocolLayerAggregateExceptions()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                const string dummyJobId = "Foo";
                batchClient.CustomBehaviors.Add(new RequestInterceptor(req =>
                    {
                        throw new AggregateException(new []
                            {
                                new ArgumentException(),
                                new ArgumentNullException()
                            });
                    }));

                Assert.Throws<AggregateException>(() => batchClient.JobOperations.GetJob(dummyJobId));
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void SynchronousMethodsCompatibilityHandlerThrowsAggregate()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                const string dummyJobId = "Foo";
                batchClient.CustomBehaviors.Add(new RequestInterceptor(req =>
                {
                    throw new ArgumentException();
                }));
                batchClient.CustomBehaviors.Add(SynchronousMethodExceptionBehavior.ThrowAggregateException);

                AggregateException aggregate = Assert.Throws<AggregateException>(() => batchClient.JobOperations.GetJob(dummyJobId));
                Assert.IsAssignableFrom<ArgumentException>(aggregate.InnerException);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void SynchronousMethodsCompatibilityHandlerThrownAggregateIsWrapped()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                const string dummyJobId = "Foo";
                batchClient.CustomBehaviors.Add(new RequestInterceptor(req =>
                {
                    throw new AggregateException(new[]
                            {
                                new ArgumentException(),
                                new ArgumentNullException()
                            });
                }));
                batchClient.CustomBehaviors.Add(SynchronousMethodExceptionBehavior.ThrowAggregateException);

                AggregateException outerAggregate = Assert.Throws<AggregateException>(() => batchClient.JobOperations.GetJob(dummyJobId));
                Assert.Equal(1, outerAggregate.InnerExceptions.Count);
                
                AggregateException innerAggregate = outerAggregate.InnerException as AggregateException;
                Assert.NotNull(innerAggregate);
                Assert.Equal(2, innerAggregate.InnerExceptions.Count);
            }
        }
    }
}
