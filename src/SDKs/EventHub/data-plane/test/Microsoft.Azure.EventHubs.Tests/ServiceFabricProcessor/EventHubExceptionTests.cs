// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.ServiceFabricProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.ServiceFabricProcessor;
    using Xunit;

    public class EventHubExceptionTests
    {
        [Fact]
        [DisplayTestMethodName]
        void SoftTransientClientCreationFailure()
        {
            SoftTransientFailures("ClientCreation", EHErrorLocation.EventHubClientCreation);
        }

        [Fact]
        [DisplayTestMethodName]
        void SoftTransientGetRuntimeInfoFailure()
        {
            SoftTransientFailures("GetRuntimeInfo", EHErrorLocation.GetRuntimeInformation);
        }

        [Fact]
        [DisplayTestMethodName]
        void SoftTransientReceiverCreationFailure()
        {
            SoftTransientFailures("ReceiverCreation", EHErrorLocation.CreateReceiver);
        }

        [Fact]
        [DisplayTestMethodName]
        void SoftTransientReceiverClosingFailure()
        {
            SoftTransientFailures("ReceiverClosing", EHErrorLocation.ReceiverClosing);
        }

        [Fact]
        [DisplayTestMethodName]
        void SoftTransientEventHubClientClosingFailure()
        {
            SoftTransientFailures("EventHubClientClosing", EHErrorLocation.EventHubClientClosing);
        }

        private void SoftTransientFailures(string name, EHErrorLocation location)
        {
            EventHubsException injectee = new EventHubsException(true, "ErrorInjector");
            OnceEHErrorInjector injector = new OnceEHErrorInjector(location, injectee);
            NoFailures("SoftTransient" + name + "Failure", injector);
        }

        private void NoFailures(string name, EHErrorInjector injector)
        { 
            TestState state = new TestState();
            state.Initialize(name, 1, 0);

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
            sfp.EventHubClientFactory = new InjectorEventHubClientFactoryMock(1, injector);

            state.PrepareToRun();
            state.StartRun(sfp);

            state.RunForNBatches(20, 10);

            // EXPECTED RESULT: Processing should happen normally with no errors reported.
            //
            // 1) The error is transient, so it should be retried, and for "soft" errors the
            // test harness only throws on the first call, so the retry will succeed.
            //
            // 2) Errors during shutdown are traced but ignored.
            state.WaitRun();

            Assert.True(state.Processor.TotalBatches >= 20, $"Run ended at {state.Processor.TotalBatches} batches");
            Assert.True(state.Processor.TotalErrors == 0, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);
        }

        [Fact]
        [DisplayTestMethodName]
        void HardTransientClientCreationFailure()
        {
            HardTransientStartupFailure("ClientCreation", EHErrorLocation.EventHubClientCreation);
        }

        [Fact]
        [DisplayTestMethodName]
        void HardTransientGetRuntimeInfoFailure()
        {
            HardTransientStartupFailure("GetRuntimeInfo", EHErrorLocation.GetRuntimeInformation);
        }

        [Fact]
        [DisplayTestMethodName]
        void HardTransientReceiverCreationFailure()
        {
            HardTransientStartupFailure("ReceiverCreation", EHErrorLocation.CreateReceiver);
        }

        [Fact]
        [DisplayTestMethodName]
        void HardTransientReceiverClosingFailure()
        {
            EventHubsException injectee = new EventHubsException(true, "ErrorInjector");
            AlwaysEHErrorInjector injector = new AlwaysEHErrorInjector(EHErrorLocation.ReceiverClosing, injectee);
            NoFailures("HardTransientReceiverClosingFailure", injector);
        }

        [Fact]
        [DisplayTestMethodName]
        void HardTransientEventHubClientClosingFailure()
        {
            EventHubsException injectee = new EventHubsException(true, "ErrorInjector");
            AlwaysEHErrorInjector injector = new AlwaysEHErrorInjector(EHErrorLocation.EventHubClientClosing, injectee);
            NoFailures("HardTransientEventHubClientClosingFailure", injector);
        }

        private void HardTransientStartupFailure(string name, EHErrorLocation location)
        {
            TestState state = new TestState();
            state.Initialize("HardTransient" + name + "Failure", 1, 0);

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
            EventHubsException injectee = new EventHubsException(true, "ErrorInjector");
            AlwaysEHErrorInjector injector = new AlwaysEHErrorInjector(location, injectee);
            sfp.EventHubClientFactory = new InjectorEventHubClientFactoryMock(1, injector);

            state.PrepareToRun();
            state.StartRun(sfp);

            // EXPECTED RESULT: RunAsync will throw (Task completed exceptionally) during startup
            // after running out of retries on an EH operation.
            // The Wait call bundles the exception into an AggregateException and rethrows.
            state.OuterTask.Wait();
            try
            {
                state.SFPTask.Wait();
            }
            catch (AggregateException ae)
            {
                Assert.True(ae.InnerExceptions.Count == 1, $"Unexpected number of errors {ae.InnerExceptions.Count}");
                Exception inner1 = ae.InnerExceptions[0];
                Assert.True(inner1 is Exception, $"Unexpected inner exception type {inner1.GetType().Name}");
                Assert.StartsWith("Out of retries ", inner1.Message);
                Assert.NotNull(inner1.InnerException);
                Exception inner2 = inner1.InnerException;
                Assert.True(inner2 is EventHubsException, $"Unexpected inner exception type {inner2.GetType().Name}");
                Assert.True(((EventHubsException)inner2).IsTransient, "Inner exception is not transient");
                Assert.Equal("ErrorInjector", inner2.Message);
            }
        }

        [Fact]
        [DisplayTestMethodName]
        void NontransientClientCreationFailure()
        {
            GeneralStartupFailure("NontransientClientCreationFailure", EHErrorLocation.EventHubClientCreation, true);
        }

        [Fact]
        [DisplayTestMethodName]
        void HardClientCreationFailure()
        {
            GeneralStartupFailure("HardClientCreationFailure", EHErrorLocation.EventHubClientCreation, false);
        }

        [Fact]
        [DisplayTestMethodName]
        void NontransientGetRuntimeInfoFailure()
        {
            GeneralStartupFailure("NontransientGetRuntimeInfoFailure", EHErrorLocation.GetRuntimeInformation, true);
        }

        [Fact]
        [DisplayTestMethodName]
        void HardGetRuntimeInfoFailure()
        {
            GeneralStartupFailure("HardGetRuntimeInfoFailure", EHErrorLocation.GetRuntimeInformation, false);
        }

        [Fact]
        [DisplayTestMethodName]
        void NontransientReceiverCreationFailure()
        {
            GeneralStartupFailure("NontransientReceiverCreationFailure", EHErrorLocation.CreateReceiver, true);
        }

        [Fact]
        [DisplayTestMethodName]
        void HardReceiverCreationFailure()
        {
            GeneralStartupFailure("HardReceiverCreationFailure", EHErrorLocation.CreateReceiver, false);
        }

        [Fact]
        [DisplayTestMethodName]
        void NontransientReceiverClosingFailure()
        {
            EventHubsException injectee = new EventHubsException(false, "ErrorInjector");
            AlwaysEHErrorInjector injector = new AlwaysEHErrorInjector(EHErrorLocation.ReceiverClosing, injectee);
            NoFailures("NontransientReceiverClosingFailure", injector);
        }

        [Fact]
        [DisplayTestMethodName]
        void HardReceiverClosingFailure()
        {
            Exception injectee = new Exception("ErrorInjector");
            AlwaysEHErrorInjector injector = new AlwaysEHErrorInjector(EHErrorLocation.ReceiverClosing, injectee);
            NoFailures("HardReceiverClosingFailure", injector);
        }

        [Fact]
        [DisplayTestMethodName]
        void NontransientEventHubClientClosingFailure()
        {
            EventHubsException injectee = new EventHubsException(false, "ErrorInjector");
            AlwaysEHErrorInjector injector = new AlwaysEHErrorInjector(EHErrorLocation.EventHubClientClosing, injectee);
            NoFailures("NontransientEventHubClientClosingFailure", injector);
        }

        [Fact]
        [DisplayTestMethodName]
        void HardEventHubClientClosingFailure()
        {
            Exception injectee = new Exception("ErrorInjector");
            AlwaysEHErrorInjector injector = new AlwaysEHErrorInjector(EHErrorLocation.EventHubClientClosing, injectee);
            NoFailures("HardEventHubClientClosingFailure", injector);
        }

        private void GeneralStartupFailure(string name, EHErrorLocation location, bool isEventHubsException)
        {
            TestState state = new TestState();
            state.Initialize(name, 1, 0);

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
            Exception injectee = isEventHubsException ? new EventHubsException(false, "ErrorInjector") :
                new Exception("ErrorInjector");
            OnceEHErrorInjector injector = new OnceEHErrorInjector(location, injectee);
            sfp.EventHubClientFactory = new InjectorEventHubClientFactoryMock(1, injector);

            state.PrepareToRun();
            state.StartRun(sfp);

            // EXPECTED RESULT: RunAsync will throw (Task completed exceptionally) during startup
            // due to nontransient EventHubsException or other exception type from EH operation.
            // The Wait call bundles the exception into an AggregateException and rethrows.
            state.OuterTask.Wait();
            try
            {
                state.SFPTask.Wait();
            }
            catch (AggregateException ae)
            {
                Assert.True(ae.InnerExceptions.Count == 1, $"Unexpected number of errors {ae.InnerExceptions.Count}");
                Exception inner = ae.InnerExceptions[0];
                if (isEventHubsException)
                {
                    Assert.True(inner is EventHubsException, $"Unexpected inner exception type {inner.GetType().Name}");
                    Assert.False(((EventHubsException)inner).IsTransient, "Inner exception is transient");
                }
                else
                {
                    Assert.True(inner is Exception, $"Unexpected inner exception type {inner.GetType().Name}");
                }
                Assert.Contains("ErrorInjector", inner.Message);
            }
        }

        [Fact]
        [DisplayTestMethodName]
        void TransientEventHubReceiveFailure()
        {
            TestState state = new TestState();
            state.Initialize("TransientEventHubReceiveFailure", 1, 0);

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
            EventHubsException error = new EventHubsException(true, "ErrorInjector");
            NeverEHErrorInjector injector = new NeverEHErrorInjector(EHErrorLocation.Receiving, error);
            sfp.EventHubClientFactory = new InjectorEventHubClientFactoryMock(1, injector);

            state.PrepareToRun();
            state.StartRun(sfp);
            state.VerifyNormalStartup(10);

            int batchesAlreadyDone = state.CountNBatches(20, 10);

            Assert.True(EventHubMocks.PartitionReceiverMock.receivers.ContainsKey(InjectorEventHubClientFactoryMock.Tag),
                "Cannot find receiver");
            InjectorPartitionReceiverMock testReceiver = (InjectorPartitionReceiverMock)
                EventHubMocks.PartitionReceiverMock.receivers[InjectorEventHubClientFactoryMock.Tag];
            const int errorCount = 10;
            for (int i = 0; i < errorCount; i++)
            {
                testReceiver.ForceReceiveError(error);
                Thread.Sleep(100);
            }

            state.CountNBatches(batchesAlreadyDone * 2, 10);

            state.DoNormalShutdown(10);
            state.WaitRun();

            // EXPECTED RESULT: Processing should happen normally but errors reported.
            Assert.True(state.Processor.TotalBatches >= 20, $"Run ended at {state.Processor.TotalBatches} batches");
            Assert.True(state.Processor.TotalErrors == errorCount, $"Errors found {state.Processor.TotalErrors}");
            Assert.Null(state.ShutdownException);
        }

        [Fact]
        [DisplayTestMethodName]
        void NonTransientEventHubReceiveFailure()
        {
            // ReceiverDisconnectedException is a nontransient EventHubsException of particular interest because
            // it occurs when an epoch receiver has been force-disconnected by a new epoch receiver with a higher epoch.
            // If this exception occurs, we want SFP to shut down!
            EventHubReceiveFailure("NonTransient", new ReceiverDisconnectedException("ErrorInjector"), true);
        }

        [Fact]
        [DisplayTestMethodName]
        void HardEventHubReceiveFailure()
        {
            EventHubReceiveFailure("Hard", new Exception("ErrorInjector"), false);
        }

        void EventHubReceiveFailure(string name, Exception error, bool isEventHubsException)
        { 
            TestState state = new TestState();
            state.Initialize(name + "EventHubReceiveFailure", 1, 0);

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
            NeverEHErrorInjector injector = new NeverEHErrorInjector(EHErrorLocation.Receiving, error);
            sfp.EventHubClientFactory = new InjectorEventHubClientFactoryMock(1, injector);

            state.PrepareToRun();
            state.StartRun(sfp);
            state.VerifyNormalStartup(10);

            state.CountNBatches(20, 10);

            Assert.True(EventHubMocks.PartitionReceiverMock.receivers.ContainsKey(InjectorEventHubClientFactoryMock.Tag),
                "Cannot find receiver");
            InjectorPartitionReceiverMock testReceiver = (InjectorPartitionReceiverMock)
                EventHubMocks.PartitionReceiverMock.receivers[InjectorEventHubClientFactoryMock.Tag];
            testReceiver.ForceReceiveError(error);

            // EXPECTED RESULT: RunAsync will throw (Task completed exceptionally) 
            // due to nontransient EventHubsException or other exception type from EH operation.
            // The Wait call bundles the exception into an AggregateException and rethrows.
            state.OuterTask.Wait();
            try
            {
                state.SFPTask.Wait();
            }
            catch (AggregateException ae)
            {
                Assert.True(ae.InnerExceptions.Count == 1, $"Unexpected number of errors {ae.InnerExceptions.Count}");
                Exception inner = ae.InnerExceptions[0];
                if (isEventHubsException)
                {
                    Assert.True(inner is EventHubsException, $"Unexpected inner exception type {inner.GetType().Name}");
                    Assert.False(((EventHubsException)inner).IsTransient, "Inner exception is transient");
                }
                else
                {
                    Assert.True(inner is Exception, $"Unexpected inner exception type {inner.GetType().Name}");
                }
                Assert.Contains("ErrorInjector", inner.Message);
            }
        }

        private class InjectorPartitionReceiverMock : EventHubMocks.PartitionReceiverMock
        {
            private readonly EHErrorInjector injector;

            public InjectorPartitionReceiverMock(string partitionId, long sequenceNumber, CancellationToken token,
                TimeSpan pumpTimeout, ReceiverOptions options, EHErrorInjector injector) :
                base(partitionId, sequenceNumber, token, pumpTimeout, options, InjectorEventHubClientFactoryMock.Tag)
            {
                this.injector = injector;
            }

            public override Task CloseAsync()
            {
                return this.injector.InjectTask(EHErrorLocation.ReceiverClosing);
            }

            public void ForceReceiveError(Exception error)
            {
                this.outerHandler.ProcessErrorAsync(error).Wait();
            }
        }

        private class InjectorEventHubClientMock : EventHubMocks.EventHubClientMock
        {
            private readonly EHErrorInjector injector;

            public InjectorEventHubClientMock(int partitionCount, EventHubsConnectionStringBuilder csb, EHErrorInjector injector) :
                base(partitionCount, csb, InjectorEventHubClientFactoryMock.Tag)
            {
                this.injector = injector;
            }

            public override Task<EventHubRuntimeInformation> GetRuntimeInformationAsync()
            {
                return this.injector.InjectTask<EventHubRuntimeInformation>(EHErrorLocation.GetRuntimeInformation,
                    base.GetRuntimeInformationAsync());
            }

            public override EventHubWrappers.IPartitionReceiver CreateEpochReceiver(string consumerGroupName, string partitionId,
                EventPosition eventPosition, long epoch, ReceiverOptions receiverOptions)
            {
                this.injector.Inject(EHErrorLocation.CreateReceiver);
                long startSeq = CalculateStartSeq(eventPosition);
                return new InjectorPartitionReceiverMock(partitionId, startSeq, this.token, this.csb.OperationTimeout,
                    receiverOptions, this.injector);
            }
        }

        private class InjectorEventHubClientFactoryMock : EventHubMocks.EventHubClientFactoryMock
        {
            private readonly EHErrorInjector injector;

            public static readonly string Tag = "inj";

            public InjectorEventHubClientFactoryMock(int partitionCount, EHErrorInjector injector) : base(partitionCount,
                InjectorEventHubClientFactoryMock.Tag)
            {
                this.injector = injector;
            }

            public override EventHubWrappers.IEventHubClient Create(string connectionString, TimeSpan receiveTimeout)
            {
                this.injector.Inject(EHErrorLocation.EventHubClientCreation);
                EventHubsConnectionStringBuilder csb = new EventHubsConnectionStringBuilder(connectionString);
                csb.OperationTimeout = receiveTimeout;
                return new InjectorEventHubClientMock(this.partitionCount, csb, this.injector);
            }
        }

        private enum EHErrorLocation { EventHubClientCreation, GetRuntimeInformation, CreateReceiver, Receiving,
            ReceiverClosing, EventHubClientClosing };

        private abstract class EHErrorInjector
        {
            protected readonly EHErrorLocation location;
            protected readonly Exception error;

            internal EHErrorInjector(EHErrorLocation errorAt, Exception error)
            {
                this.location = errorAt;
                this.error = error;
            }

            internal abstract bool ShouldInject(EHErrorLocation location);

            internal void Inject(EHErrorLocation location)
            {
                if (ShouldInject(location))
                {
                    throw this.error;
                }
            }

            internal Task<T> InjectTask<T>(EHErrorLocation location, Task<T> validResult)
            {
                if (ShouldInject(location))
                {
                    return Task.FromException<T>(this.error);
                }
                return validResult;
            }

            internal Task InjectTask(EHErrorLocation location)
            {
                if (ShouldInject(location))
                {
                    return Task.FromException(this.error);
                }
                return Task.CompletedTask;
            }
        }

        private class OnceEHErrorInjector : EHErrorInjector
        {
            private bool first = true;

            internal OnceEHErrorInjector(EHErrorLocation errorAt, Exception error) : base(errorAt, error)
            {
            }

            internal override bool ShouldInject(EHErrorLocation location)
            {
                if (this.location == location)
                {
                    bool retval = this.first;
                    this.first = false;
                    return retval;
                }
                return false;
            }
        }

        private class AlwaysEHErrorInjector : EHErrorInjector
        {
            internal AlwaysEHErrorInjector(EHErrorLocation errorAt, Exception error) : base(errorAt, error)
            {
            }

            internal override bool ShouldInject(EHErrorLocation location)
            {
                return this.location == location;
            }
        }

        private class NeverEHErrorInjector : EHErrorInjector
        {
            internal NeverEHErrorInjector(EHErrorLocation errorAt, Exception error) : base(errorAt, error)
            {
            }

            internal override bool ShouldInject(EHErrorLocation location)
            {
                return false;
            }
        }
    }
}
