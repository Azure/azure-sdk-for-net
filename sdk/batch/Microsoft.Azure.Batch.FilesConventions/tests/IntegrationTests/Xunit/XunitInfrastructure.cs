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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Xunit
{
    // Allows a Xunit class fixture to intercept events by implementing IReceiveMessages.
    // This allows a fixture to change class-level behavior based on the progress or
    // outcome of tests.

    public class ExtendedXunitTestFrameworkExecutor : XunitTestFrameworkExecutor
    {
        public ExtendedXunitTestFrameworkExecutor(AssemblyName assemblyName, ISourceInformationProvider sourceInformationProvider, IMessageSink diagnosticMessageSink)
            : base(assemblyName, sourceInformationProvider, diagnosticMessageSink)
        {
        }

        protected override async void RunTestCases(IEnumerable<IXunitTestCase> testCases, IMessageSink executionMessageSink, ITestFrameworkExecutionOptions executionOptions)
        {
            using (
                var assemblyRunner = new ExtendedXunitTestAssemblyRunner(TestAssembly, testCases, DiagnosticMessageSink, executionMessageSink, executionOptions)
                )
            {
                await assemblyRunner.RunAsync();
            }
        }
    }

    public class ExtendedXunitTestAssemblyRunner : XunitTestAssemblyRunner
    {
        public ExtendedXunitTestAssemblyRunner(ITestAssembly testAssembly, IEnumerable<IXunitTestCase> testCases, IMessageSink diagnosticMessageSink, IMessageSink executionMessageSink, ITestFrameworkExecutionOptions executionOptions) : base(testAssembly, testCases, diagnosticMessageSink, executionMessageSink, executionOptions)
        {
        }

        protected override Task<RunSummary> RunTestCollectionAsync(IMessageBus messageBus, ITestCollection testCollection, IEnumerable<IXunitTestCase> testCases, CancellationTokenSource cancellationTokenSource)
        {
            return new ExtendedXunitTestCollectionRunner(testCollection, testCases, DiagnosticMessageSink, messageBus, TestCaseOrderer, new ExceptionAggregator(Aggregator), cancellationTokenSource).RunAsync();
        }
    }

    public class ExtendedXunitTestCollectionRunner : XunitTestCollectionRunner
    {
        private readonly IMessageSink diagnosticMessageSink;

        public ExtendedXunitTestCollectionRunner(ITestCollection testCollection, IEnumerable<IXunitTestCase> testCases, IMessageSink diagnosticMessageSink, IMessageBus messageBus, ITestCaseOrderer testCaseOrderer, ExceptionAggregator aggregator, CancellationTokenSource cancellationTokenSource)
            : base(testCollection, testCases, diagnosticMessageSink, messageBus, testCaseOrderer, aggregator, cancellationTokenSource)
        {
            this.diagnosticMessageSink = diagnosticMessageSink;
        }

        protected override Task<RunSummary> RunTestClassAsync(ITestClass testClass, IReflectionTypeInfo @class, IEnumerable<IXunitTestCase> testCases)
        {
            return new ExtendedXunitTestClassRunner(testClass, @class, testCases, this.diagnosticMessageSink, MessageBus, TestCaseOrderer, new ExceptionAggregator(Aggregator), CancellationTokenSource, CollectionFixtureMappings).RunAsync();
        }
    }

    public class ExtendedXunitTestClassRunner : XunitTestClassRunner
    {
        private List<IReceiveMessages> _receivers = new List<IReceiveMessages>();
        private HookableSink _hookableSink;

        public ExtendedXunitTestClassRunner(ITestClass testClass, IReflectionTypeInfo @class, IEnumerable<IXunitTestCase> testCases, IMessageSink diagnosticMessageSink, IMessageBus messageBus, ITestCaseOrderer testCaseOrderer, ExceptionAggregator aggregator, CancellationTokenSource cancellationTokenSource, IDictionary<Type, object> collectionFixtureMappings)
            : base(testClass, @class, testCases, diagnosticMessageSink, CreateHookableMessageBus(messageBus), testCaseOrderer, aggregator, cancellationTokenSource, collectionFixtureMappings)
        {
            _hookableSink = (HookableSink)this.MessageBus;
            _hookableSink.OnMessageHandler = OnMessage;
        }

        private static IMessageBus CreateHookableMessageBus(IMessageBus parent)
        {
            return new HookableSink(parent);
        }

        private void OnMessage(IMessageSinkMessage obj)
        {
            var testCaseFinishedMessage = obj as ITestCaseFinished;
            if (testCaseFinishedMessage != null)
            {
                _receivers.ForEach(receiver => receiver.OnTestCaseFinished(testCaseFinishedMessage));
            }
        }

        protected override object[] CreateTestClassConstructorArguments()
        {
            _receivers.Clear();

            var constructorParams = base.CreateTestClassConstructorArguments();
            if (constructorParams != null)
            {
                _receivers.AddRange(constructorParams.OfType<IReceiveMessages>());
            }

            return constructorParams;
        }
    }

    public class HookableSink : IMessageBus
    {
        private readonly IMessageBus _parent;

        public HookableSink(IMessageBus parent)
        {
            _parent = parent;
        }

        public Action<IMessageSinkMessage> OnMessageHandler
        {
            get;
            set;
        }

        public void Dispose()
        {
            _parent.Dispose();
        }

        public bool QueueMessage(IMessageSinkMessage message)
        {
            if (this.OnMessageHandler != null)
            {
                this.OnMessageHandler(message);
            }

            return _parent.QueueMessage(message);
        }
    }

    public class ExtendedTestFramework : XunitTestFramework
    {
        public ExtendedTestFramework(IMessageSink messageSink) : base(messageSink)
        {
        }

        protected override ITestFrameworkExecutor CreateExecutor(AssemblyName assemblyName)
        {
            return new ExtendedXunitTestFrameworkExecutor(assemblyName, SourceInformationProvider, DiagnosticMessageSink);
        }
    }

    public interface IReceiveMessages
    {
        void OnTestCaseFinished(ITestCaseFinished testCaseFinishedMessage);
    }
}
