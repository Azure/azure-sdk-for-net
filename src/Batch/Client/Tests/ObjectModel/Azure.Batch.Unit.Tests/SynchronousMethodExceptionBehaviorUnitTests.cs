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
