// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Data.Tables;
using Azure.Data.Tables.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    [AsyncOnly]
    [ClientTestFixture(null, new object[]{ true, false })]
    public class TablesLiveTestBase : RecordedTestBase<TablesTestEnvironment>
    {
        private readonly bool _createTable;
        protected const string TableNameExpression = "%Table%";
        protected const string PartitionKey = "PK";
        protected const string RowKey = "RK";
        private readonly Random _random = new();
        protected string TableName;
        protected TableServiceClient ServiceClient;
        protected TableClient TableClient;

        protected bool UseCosmos { get; }

        protected TablesLiveTestBase(bool isAsync, bool useCosmos, bool createTable = true): base(isAsync: isAsync)
        {
            UseCosmos = useCosmos;
            _createTable = createTable;
            // https://github.com/Azure/azure-sdk-tools/issues/2448
            Sanitizer.BodyRegexSanitizers.Add(new BodyRegexSanitizer("(batch|changeset)_[\\w\\d-]+", "multipart_boundary"));
            // https://github.com/Azure/azure-sdk-tools/issues/2453
            Sanitizer.BodyRegexSanitizers.Add(
                new BodyRegexSanitizer(
                    "[^\\r](?<break>\\n)",
                    "\r\n")
                {
                    GroupForReplace = "break"
                });
        }

        public override async Task StartTestRecordingAsync()
        {
            await base.StartTestRecordingAsync();

            TableName = GetRandomTableName();

            ServiceClient = InstrumentClient(
                new TableServiceClient(
                    UseCosmos ? TestEnvironment.CosmosConnectionString : TestEnvironment.StorageConnectionString,
                    InstrumentClientOptions(new TableClientOptions())));

            TableClient = ServiceClient.GetTableClient(TableName);
            if (_createTable)
            {
                await TableClient.CreateAsync();
            }
        }

        [TearDown]
        public async Task TearDown()
        {
            try
            {
                await TableClient.DeleteAsync();
            }
            catch
            { }
        }

        protected void DefaultConfigure(HostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration(builder =>
            {
                builder.AddInMemoryCollection(new Dictionary<string, string>()
                {
                    {"Table", TableName},
                    {"AzureWebJobsStorage", UseCosmos ? TestEnvironment.CosmosConnectionString : TestEnvironment.StorageConnectionString}
                });
            });
        }

        protected async Task<T> CallAsync<T>(string methodName = null, object arguments = null, Action<HostBuilder> configure = null)
        {
            var instance = Activator.CreateInstance<T>();
            var (host, jobHost) = CreateHost(typeof(T), configure, instance);

            MethodInfo methodInfo;
            if (methodName != null)
            {
                methodInfo = typeof(T).GetMethod(methodName);
            }
            else
            {
                methodInfo = typeof(T).GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                    .Single(mi => !mi.IsSpecialName);
            }

            await jobHost.CallAsync(methodInfo, arguments);

            return instance;
        }

        protected (IHost Host, JobHost JobHost) CreateHost(Type programType, Action<HostBuilder> configure = null, object instance = null)
        {
            var hostBuilder = new HostBuilder();
            hostBuilder.ConfigureDefaultTestHost(builder =>
            {
                if (instance != null)
                {
                    builder.Services.AddSingleton<IJobActivator>(new FakeActivator(instance));
                    if (Mode != RecordedTestMode.Live)
                    {
                        builder.Services.AddSingleton<TablesAccountProvider, InstrumentedTableClientProvider>();
                        builder.Services.AddSingleton<RecordedTestBase>(this);
                    }
                }

                builder.AddAzureTables();
            }, programType);

            (configure ?? DefaultConfigure).Invoke(hostBuilder);
            var host = hostBuilder
                .Build();
            var jobHost = host.Services.GetService<IJobHost>() as JobHost;

            return (host, jobHost);
        }

        private class FakeActivator : IJobActivator
        {
            private readonly Dictionary<Type, object> _instances = new();
            public FakeActivator(params object[] objs)
            {
                foreach (var obj in objs)
                {
                    _instances[obj.GetType()] = obj;
                }
            }
            public T CreateInstance<T>()
            {
                return (T)_instances[typeof(T)];
            }
        }

        protected Task<bool> TableExistsAsync(string name)
        {
            return TableExistsAsync(ServiceClient.GetTableClient(name));
        }
        protected static async Task<bool> TableExistsAsync(TableClient client)
        {
            try
            {
                await client.QueryAsync<TableEntity>().ToEnumerableAsync();
                return true;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return false;
            }
        }

        protected string GetRandomTableName()
        {
            return Recording.GenerateAlphaNumericId("testtable");
        }

        private class InstrumentedTableClientProvider : TablesAccountProvider
        {
            private readonly RecordedTestBase _recording;

            public InstrumentedTableClientProvider(RecordedTestBase recording, IConfiguration configuration, AzureComponentFactory componentFactory, AzureEventSourceLogForwarder logForwarder, ILogger<TableServiceClient> logger) : base(configuration, componentFactory, logForwarder, logger)
            {
                _recording = recording;
            }

            protected override TableClientOptions CreateClientOptions(IConfiguration configuration)
            {
                return _recording.InstrumentClientOptions(base.CreateClientOptions(configuration));
            }
        }
    }
}