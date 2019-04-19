// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.ServiceFabricProcessor
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.EventHubs.ServiceFabricProcessor;
    using Xunit;

    public class UserExceptionTests
    {
        [Fact]
        [DisplayTestMethodName]
        void OpenException()
        {
            TestState state = new TestState();
            state.Initialize("OpenException", 1, 0);

            ServiceFabricProcessor sfp = new ServiceFabricProcessor(
                    state.ServiceUri,
                    state.ServicePartitionId,
                    state.StateManager,
                    state.StatefulServicePartition,
                    state.Processor,
                    state.ConnectionString,
                    "$Default",
                    state.Options);
            sfp.MockMode = state.PartitionLister;
            sfp.EventHubClientFactory = new EventHubMocks.EventHubClientFactoryMock(1);

            state.PrepareToRun();
            state.Processor.Injector =
                new TestProcessor.ErrorInjector(TestProcessor.ErrorLocation.OnOpen, new NotImplementedException("ErrorInjector"));
            state.StartRun(sfp);

            // EXPECTED RESULT: Failure during startup, Task returned by SFP.RunAsync completed exceptionally.
            state.OuterTask.Wait();
            try
            {
                state.SFPTask.Wait();
                Assert.True(false, "No exception thrown");
            }
            catch (AggregateException ae)
            {
                Assert.True(ae.InnerExceptions.Count == 1, $"Unexpected number of errors {ae.InnerExceptions.Count}");
                Exception inner = ae.InnerExceptions[0];
                Assert.True(inner is NotImplementedException, $"Unexpected inner exception type {inner.GetType().Name}");
                Assert.Equal("ErrorInjector", inner.Message);
            }
        }

        [Fact]
        [DisplayTestMethodName]
        void CloseException()
        {
            TestState state = new TestState();
            state.Initialize("CloseException", 1, 0);

            ServiceFabricProcessor sfp = new ServiceFabricProcessor(
                    state.ServiceUri,
                    state.ServicePartitionId,
                    state.StateManager,
                    state.StatefulServicePartition,
                    state.Processor,
                    state.ConnectionString,
                    "$Default",
                    state.Options);
            sfp.MockMode = state.PartitionLister;
            sfp.EventHubClientFactory = new EventHubMocks.EventHubClientFactoryMock(1);

            state.PrepareToRun();
            state.Processor.Injector =
                new TestProcessor.ErrorInjector(TestProcessor.ErrorLocation.OnClose, new NotImplementedException("ErrorInjector"));
            state.StartRun(sfp);

            state.VerifyNormalStartup(10);
            state.CountNBatches(20, 10);
            state.TokenSource.Cancel();

            // EXPECTED RESULT: Failure is traced but otherwise ignored.
            state.WaitRun();

            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);
        }

        [Fact]
        [DisplayTestMethodName]
        void EventException()
        {
            TestState state = new TestState();
            state.Initialize("EventException", 1, 0);

            ServiceFabricProcessor sfp = new ServiceFabricProcessor(
                    state.ServiceUri,
                    state.ServicePartitionId,
                    state.StateManager,
                    state.StatefulServicePartition,
                    state.Processor,
                    state.ConnectionString,
                    "$Default",
                    state.Options);
            sfp.MockMode = state.PartitionLister;
            sfp.EventHubClientFactory = new EventHubMocks.EventHubClientFactoryMock(1);

            state.PrepareToRun();
            state.Processor.Injector =
                new TestProcessor.ErrorInjector(TestProcessor.ErrorLocation.OnEvents, new NotImplementedException("ErrorInjector"));
            state.StartRun(sfp);

            state.RunForNBatches(20, 10);

            // EXPECTED RESULT: Errors are reported to IEventProcessor.ProcessErrorsAsync but processing
            // continues normally. There should be one error per batch.
            state.WaitRun();

            Assert.True(state.Processor.TotalErrors == state.Processor.TotalBatches,
                $"Unexpected error count {state.Processor.TotalErrors}");
            Assert.True(state.Processor.LastError is NotImplementedException,
                $"Unexpected exception type {state.Processor.LastError.GetType().Name}");
            Assert.Null(state.ShutdownException);
        }

        [Fact]
        [DisplayTestMethodName]
        void ErrorException()
        {
            TestState state = new TestState();
            state.Initialize("EventException", 1, 0);

            ServiceFabricProcessor sfp = new ServiceFabricProcessor(
                    state.ServiceUri,
                    state.ServicePartitionId,
                    state.StateManager,
                    state.StatefulServicePartition,
                    state.Processor,
                    state.ConnectionString,
                    "$Default",
                    state.Options);
            sfp.MockMode = state.PartitionLister;
            sfp.EventHubClientFactory = new EventHubMocks.EventHubClientFactoryMock(1);

            state.PrepareToRun();
            // have to inject errors in events to cause error handler to be called
            List<TestProcessor.ErrorLocation> locations =
                new List<TestProcessor.ErrorLocation>() { TestProcessor.ErrorLocation.OnEvents, TestProcessor.ErrorLocation.OnError };
            state.Processor.Injector = new TestProcessor.ErrorInjector(locations, new NotImplementedException("ErrorInjector"));
            state.StartRun(sfp);

            state.RunForNBatches(20, 10);

            // EXPECTED RESULT: Errors from ProcessEventsAsync are reported to ProcessErrorsAsync, but the
            // errors in ProcessErrorsAsync are ignored. The test implementation of ProcessErrorsAsync increments
            // the error count before throwing, so we can verify that ProcessErrorsAsync was called.
            state.WaitRun();

            Assert.True(state.Processor.TotalErrors == state.Processor.TotalBatches,
                $"Unexpected error count got {state.Processor.TotalErrors} expected {state.Processor.TotalBatches}");
            Assert.True(state.Processor.LastError is NotImplementedException,
                $"Unexpected exception type {state.Processor.LastError.GetType().Name}");
            Assert.Null(state.ShutdownException);
        }
    }
}
