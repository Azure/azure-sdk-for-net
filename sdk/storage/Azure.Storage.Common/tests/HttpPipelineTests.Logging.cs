// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Test
{
    internal partial class HttpPipelineTests
    {
        /*
        [Test]
        [NonParallelizable]
        public async Task Logging_Shared_Key_Redact()
        {
            var sourceSwitch = new SourceSwitch("sourceSwitch") { Level = SourceLevels.All };

            using (var textWriter = new StringWriter())
            using (var textWriterListener = new TextWriterTraceListener(textWriter))
            {
                var httpRequest = new HttpRequestMessage();
                httpRequest.Headers.Authorization = AuthenticationHeaderValue.Parse("auth");
                var serviceCollection =
                    new ServiceCollection()
                    .AddLogging(
                        builder =>
                        builder
                        .AddTraceSource(sourceSwitch, textWriterListener)
                        .AddFilter(level => true) // do not filter by level
                        );

                await Logging_TextWriterTestImpl(textWriter, serviceCollection, httpRequest, () =>
                {
                    Assert.IsFalse(textWriter.ToString().Contains("auth"));
                });
            }
        }

        [Test]
        [NonParallelizable]
        public async Task Logging_SAS_Redact()
        {
            var sourceSwitch = new SourceSwitch("sourceSwitch") { Level = SourceLevels.All };

            using (var textWriter = new StringWriter())
            using (var textWriterListener = new TextWriterTraceListener(textWriter))
            {
                var httpRequest = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://dev.blob.core.windows.net/test-container/test-blob?sv=2018-03-29&ss=f&srt=s&st=2018-10-30T20%3A45%3A11Z&se=2019-10-29T22%3A45%3A11Z&sp=rw&sig=urlSignature&comp=incrementalcopy")
                };
                httpRequest.Headers.Add(Constants.CopySource, "http://dev.blob.core.windows.net/test-container/test-blob?snapshot=2018-10-30T19:19:22.1016437Z&sv=2018-03-28&ss=b&srt=co&st=2018-10-29T20:45:11Z&se=2018-10-29T22:45:11Z&sp=rwdlac&sig=copySourceSignature");
                var serviceCollection =
                    new ServiceCollection()
                    .AddLogging(
                        builder =>
                        builder
                        .AddTraceSource(sourceSwitch, textWriterListener)
                        .AddFilter(level => true) // do not filter by level
                        );

                await Logging_TextWriterTestImpl(textWriter, serviceCollection, httpRequest, () =>
                {
                    Assert.IsFalse(textWriter.ToString().Contains("urlSignature"));
                    Assert.IsFalse(textWriter.ToString().Contains("copySourceSignature"));
                });
            }
        }

        [Test]
        [Ignore("Needs permissions")]
        [NonParallelizable]
        public async Task Logging_EventLog()
        {
            var serviceCollection =
                new ServiceCollection()
                .AddLogging(
                    builder =>
                    builder
                    .AddEventLog(new EventLogSettings { LogName = "Test", SourceName = typeof(HttpPipelineTests).FullName + "#" + nameof(EventLog) })
                    .AddFilter(level => true) // do not filter by level
                    );

            await Logging_TestImpl(serviceCollection);
        }

        [Test]
        [NonParallelizable]
        public async Task Logging_ConsoleLog()
        {
            using (var textWriter = new StringWriter())
            {
                Console.SetOut(textWriter);

                var serviceCollection =
                    new ServiceCollection()
                    .AddLogging(
                        builder =>
                        builder
                        .AddConsole(options => options.IncludeScopes = true)
                        .AddFilter(level => true) // do not filter by level
                        );

                await Logging_TextWriterTestImpl(textWriter, serviceCollection);
            }
        }

        [Test]
        [NonParallelizable]
        public async Task Logging_TraceLog()
        {
            var sourceSwitch = new SourceSwitch("sourceSwitch") { Level = SourceLevels.All };

            using (var textWriter = new StringWriter())
            using (var textWriterListener = new TextWriterTraceListener(textWriter))
            using (var consoleListener = new TextWriterTraceListener(Console.Out))
            {
                var serviceCollection =
                    new ServiceCollection()
                    .AddLogging(
                        builder =>
                        builder
                        .AddTraceSource(sourceSwitch, textWriterListener)
                        .AddTraceSource(sourceSwitch, consoleListener)
                        .AddFilter(level => true) // do not filter by level
                        );

                await Logging_TextWriterTestImpl(textWriter, serviceCollection);
            }
        }

        static async Task Logging_TextWriterTestImpl(StringWriter textWriter, IServiceCollection serviceCollection, HttpRequestMessage httpRequest = null, Action action = null)
        {
            Assert.IsTrue(String.IsNullOrWhiteSpace(textWriter.ToString()));

            await Logging_TestImpl(serviceCollection, httpRequest);

            Assert.IsFalse(String.IsNullOrWhiteSpace(textWriter.ToString()), $"{nameof(textWriter)} did not receive any Log messages");
            action?.Invoke();
        }

        static async Task Logging_TestImpl(IServiceCollection serviceCollection, HttpRequestMessage httpRequest = null)
        {
            using (var loggerFactory = serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>())
            {
                var logger = loggerFactory.CreateLogger("logger");

                foreach (var level in new[] { LogLevel.Critical, LogLevel.Debug, LogLevel.Error, LogLevel.Information, LogLevel.Trace, LogLevel.Warning })
                {
                    if (!logger.IsEnabled(level))
                    {
                        Assert.Inconclusive($"{nameof(logger)} not enabled for LogLevel {level}");
                    }
                }

                var pipeline = new Pipeline(
                    new PipelineOptions { Logger = logger },
                    new IPipelinePolicyFactory[] { }
                    );

                try
                {
                    await pipeline.SendAsync(httpRequest ?? new HttpRequestMessage(), cancellationToken: CancellationToken.None, default);
                }
                catch (InvalidOperationException e) when (e.Message.StartsWith("An invalid request URI was provided."))
                {
                    // expected: we passed a bad request
                }
            }
        }
        */
    }
}
