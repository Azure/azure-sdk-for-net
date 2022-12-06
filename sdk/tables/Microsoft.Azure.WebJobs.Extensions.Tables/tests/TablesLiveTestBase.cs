// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        protected string TableName;
        protected TableServiceClient ServiceClient;
        protected TableClient TableClient;

        protected bool UseCosmos { get; }

        protected TablesLiveTestBase(bool isAsync, bool useCosmos, bool createTable = true) : base(isAsync: isAsync)
        {
            UseCosmos = useCosmos;
            _createTable = createTable;
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

        protected async Task ClearTableAsync()
        {
            var entities = TableClient.QueryAsync<TableEntity>();
            await foreach (var entity in entities)
            {
                await TableClient.DeleteEntityAsync(entity.PartitionKey, entity.RowKey);
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
            return (T)await CallAsync(typeof(T), methodName, arguments, configure);
        }

        protected async Task<object> CallAsync(Type funcType, string methodName = null, object arguments = null, Action<HostBuilder> configure = null)
        {
            var instance = Activator.CreateInstance(funcType);
            using var host = CreateHost(funcType, configure, instance);

            MethodInfo methodInfo;
            if (methodName != null)
            {
                methodInfo = funcType.GetMethod(methodName);
            }
            else
            {
                methodInfo = funcType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                    .Single(mi => !mi.IsSpecialName);
            }

            await host.GetJobHost().CallAsync(methodInfo, arguments);

            return instance;
        }

        private IHost CreateHost(Type programType, Action<HostBuilder> configure = null, object instance = null)
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

                builder.AddTables();
            }, programType);

            (configure ?? DefaultConfigure).Invoke(hostBuilder);
            return hostBuilder.Build();
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

            public override TableServiceClient Get(string name)
            {
                var serviceClient = base.Get(name);
                return new InstrumentedTableServiceClient(serviceClient, _recording.Recording);
            }
        }

        private class InstrumentedTableServiceClient : TableServiceClient
        {
            private readonly TableServiceClient _client;
            private readonly TestRecording _recording;

            public InstrumentedTableServiceClient(TableServiceClient serviceClient, TestRecording recording)
            {
                _client = serviceClient;
                _recording = recording;
            }

            public override TableClient GetTableClient(string tableName)
            {
                var client = _client.GetTableClient(tableName);
                client.SetBatchGuids(_recording.Random.NewGuid(), _recording.Random.NewGuid());
                return client;
            }

            public override string AccountName => _client.AccountName;
        }
    }
}