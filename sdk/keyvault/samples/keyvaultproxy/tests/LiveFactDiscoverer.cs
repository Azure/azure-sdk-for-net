// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace AzureSamples.Security.KeyVault.Proxy
{
    public class LiveFactDiscoverer : IXunitTestCaseDiscoverer
    {
        private readonly IMessageSink _diagnosticMessageSink;

        public LiveFactDiscoverer(IMessageSink diagnosticMessageSink)
        {
            _diagnosticMessageSink = diagnosticMessageSink ?? throw new ArgumentNullException(nameof(diagnosticMessageSink));
        }

        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            Synchronicity options = factAttribute.GetNamedArgument<Synchronicity>(nameof(LiveFactAttribute.Synchronicity));

            if ((options & Synchronicity.Asynchronous) == 0)
            {
                yield return new LiveTestCase(_diagnosticMessageSink, discoveryOptions, testMethod, false);
            }

            if ((options & Synchronicity.Synchronous) == 0)
            {
                yield return new LiveTestCase(_diagnosticMessageSink, discoveryOptions, testMethod, true);
            }
        }

        private class LiveTestCase : XunitTestCase
        {
            [Obsolete]
            public LiveTestCase()
            {
            }

            public LiveTestCase(IMessageSink diagnosticMessageSink, ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, bool isAsync)
                : base(diagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod, new object[] { isAsync })
            {
                IsAsync = isAsync;
            }

            public bool IsAsync { get; private set; }

            public override async Task<RunSummary> RunAsync(IMessageSink diagnosticMessageSink, IMessageBus messageBus, object[] constructorArguments, ExceptionAggregator aggregator, CancellationTokenSource cancellationTokenSource)
            {
                // Clear the cache if SecretsFixture was passed to the test class constructor.
                if (constructorArguments is { } && constructorArguments.Length == 1 && constructorArguments[0] is SecretsFixture fixture)
                {
                    fixture.Reset();
                }
                else
                {
                    aggregator.Add(new InvalidOperationException($"A single test class constructor argument of type {nameof(SecretsFixture)} was expected."));
                }

                return await base.RunAsync(diagnosticMessageSink, messageBus, constructorArguments, aggregator, cancellationTokenSource).ConfigureAwait(false);
            }

            public override void Serialize(IXunitSerializationInfo data)
            {
                base.Serialize(data);

                data.AddValue(nameof(IsAsync), IsAsync);
            }

            public override void Deserialize(IXunitSerializationInfo data)
            {
                base.Deserialize(data);

                IsAsync = data.GetValue<bool>(nameof(IsAsync));
            }
        }
    }
}
