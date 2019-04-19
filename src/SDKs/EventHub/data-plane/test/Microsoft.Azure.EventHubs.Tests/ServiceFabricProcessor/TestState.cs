// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.ServiceFabricProcessor
{
    using System;
    using System.Fabric;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.ServiceFabricProcessor;
    using Microsoft.ServiceFabric.Data;
    using Xunit;

    class TestState
    {
        public Uri ServiceUri { get; private set; }

        public Guid ServicePartitionId { get; private set; }

        public IReliableStateManager StateManager { get; private set; }

        public IStatefulServicePartition StatefulServicePartition { get; private set; }

        public string ConnectionString { get; private set; }

        public EventProcessorOptions Options { get; private set; }

        public TestProcessor Processor { get; set; }

        public IFabricPartitionLister PartitionLister { get; private set; }

        public bool HasShutDown { get; private set; }

        public Exception ShutdownException { get; private set; }

        public CancellationTokenSource TokenSource { get; private set; }

        public Task OuterTask { get; private set; }

        public Task SFPTask { get; private set; }

        public void Initialize(string testName, int servicePartitionCount, int servicePartitionOrdinal)
        {
            this.ServiceUri = new Uri($"fabric:/ServiceFabricProcessor/tests/CITs/{testName}");
            this.ServicePartitionId = Guid.NewGuid();
            this.StateManager = new MockReliableStateManager();
            this.StatefulServicePartition = new MockStatefulServicePartition();
            this.ConnectionString = "Endpoint=sb://NOTREAL.servicebus.windows.net/;SharedAccessKeyName=blah;SharedAccessKey=bloo;EntityPath=testhub";

            this.Options = new EventProcessorOptions();
            this.Options.OnShutdown = OnShutdown;

            this.Processor = new TestProcessor(this.Options);
            this.PartitionLister = new MockPartitionLister(servicePartitionCount, servicePartitionOrdinal);
        }

        public void PrepareToRun()
        {
            this.HasShutDown = false;
            this.ShutdownException = null;

            this.TokenSource = new CancellationTokenSource();
        }

        public void StartRun(Microsoft.Azure.EventHubs.ServiceFabricProcessor.ServiceFabricProcessor sfp)
        {
            this.SFPTask = null;
            this.OuterTask = Task.Run(() => { this.SFPTask = sfp.RunAsync(this.TokenSource.Token); });
        }

        public void WaitRun()
        {
            this.OuterTask.Wait();
            this.SFPTask.Wait();
        }

        public void RunForNBatches(int atLeastBatches, int maxRetries)
        {
            VerifyNormalStartup(maxRetries);

            CountNBatches(atLeastBatches, maxRetries);

            DoNormalShutdown(maxRetries);
        }

        public int CountNBatches(int atLeastBatches, int maxRetries)
        {
            int retries = 0;
            while ((this.Processor.TotalBatches < atLeastBatches) && !this.HasShutDown && (retries < maxRetries))
            {
                Thread.Sleep(1000);
                retries++;
            }
            Assert.False(this.HasShutDown, "Uncommanded shut down while processing");
            Assert.True(this.Processor.TotalBatches >= atLeastBatches,
                $"Unexpected loop exit at {this.Processor.TotalBatches} batches and {retries} seconds");
            return this.Processor.TotalBatches;
        }

        public void VerifyNormalStartup(int maxRetries)
        {
            int retries = 0;
            while (!this.Processor.IsOpened && !this.HasShutDown && (retries < maxRetries))
            {
                Thread.Sleep(1000);
                retries++;
            }
            Assert.False(this.HasShutDown, "Shut down before open");
            Assert.True(this.Processor.IsOpened, $"Open did not succeed after {retries} seconds");
        }

        public void DoNormalShutdown(int maxRetries)
        {
            int retries = 0;
            if (!this.HasShutDown)
            {
                this.TokenSource.Cancel();
                while (!this.Processor.IsClosed && (retries < maxRetries))
                {
                    Thread.Sleep(1000);
                    retries++;
                }
                Assert.True(this.Processor.IsClosed, $"Processor not closed after {retries} seconds");
            }

            retries = 0;
            while (!this.HasShutDown && (retries < maxRetries))
            {
                Thread.Sleep(1000);
                retries++;
            }
            Assert.True(this.HasShutDown, $"Shutdown notification did not occur after {retries} seconds");
        }

        private void OnShutdown(Exception e)
        {
            this.HasShutDown = true;
            this.ShutdownException = e;
        }
    }
}
