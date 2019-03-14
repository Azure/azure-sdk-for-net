// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information4

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    ///   Serves as a test case for the XUnit framework which may be automatically retried
    ///   by the test runner.
    /// </summary
    /// 
    /// <remarks>
    ///   Based on the XUnit Sample:
    ///   https://github.com/xunit/samples.xunit/tree/master/RetryFactExample
    /// </remarks>
    /// 
    [Serializable]
    public class RetriableTheoryTestCase : XunitTheoryTestCase
    {
        private int maxAttempts;
        private int retryDelayMilliseconds;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Called by the de-serializer", true)]
        public RetriableTheoryTestCase() { }

        public RetriableTheoryTestCase(IMessageSink diagnosticMessageSink,
                                  TestMethodDisplay defaultMethodDisplay, 
                                  TestMethodDisplayOptions defaultMethodDisplayOptions, 
                                  ITestMethod testMethod, 
                                  int maxAttempts,
                                  int retryDelayMilliseconds) 
            : base(diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testMethod)
        {
            this.maxAttempts = maxAttempts;
            this.retryDelayMilliseconds = retryDelayMilliseconds;
        }

        public override async Task<RunSummary> RunAsync(IMessageSink diagnosticMessageSink, 
                                                        IMessageBus messageBus, 
                                                        object[] constructorArguments, 
                                                        ExceptionAggregator aggregator, 
                                                        CancellationTokenSource cancellationTokenSource)
        {
            var attemptCount = 0;

            while (true)
            {
                // Capture and delay messages (which will contain run status) until the final result
                var delayedMessageBus = new TestCaseDelayedMessageBus(messageBus);

                var summary = await base.RunAsync(diagnosticMessageSink, delayedMessageBus, constructorArguments, aggregator, cancellationTokenSource);
                
                if (aggregator.HasExceptions || summary.Failed == 0 || ++attemptCount >= this.maxAttempts)
                {
                    delayedMessageBus.Dispose();  // Sends all the delayed messages
                    return summary;
                }

                diagnosticMessageSink.OnMessage(new DiagnosticMessage("Execution of '{0}' failed (attempt #{1}), retrying...", DisplayName, attemptCount));

                // If a delay between retries was requested, honor it.
                if (this.retryDelayMilliseconds > 0)
                {
                    await Task.Delay(this.retryDelayMilliseconds);
                }
            }
        }

        public override void Serialize(IXunitSerializationInfo data)
        {
            base.Serialize(data);
            data.AddValue(nameof(this.maxAttempts), this.maxAttempts);
            data.AddValue(nameof(this.retryDelayMilliseconds), this.retryDelayMilliseconds);
        }

        public override void Deserialize(IXunitSerializationInfo data)
        {
            base.Deserialize(data);
            this.maxAttempts = data.GetValue<int>(nameof(this.maxAttempts));
            this.retryDelayMilliseconds = data.GetValue<int>(nameof(this.retryDelayMilliseconds));
        }
    }
}
