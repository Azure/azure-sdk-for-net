﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TablesLiveTestBase : LiveTestBase<TablesTestEnvironment>
    {
        protected const string TableNameExpression = "%Table%";
        protected const string PartitionKey = "PK";
        protected const string RowKey = "RK";
        private readonly Random _random = new();
        protected string TableName;
        protected TableServiceClient ServiceClient;
        protected TableClient TableClient;

        [SetUp]
        public async Task SetUp()
        {
            TableName = GetRandomTableName();

            ServiceClient = new TableServiceClient(TestEnvironment.StorageConnectionString);
            TableClient = ServiceClient.GetTableClient(TableName);
            await TableClient.CreateAsync();
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
                    }
                    builder.AddAzureTables();
                }, programType)
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"Table", TableName},
                        {"AzureWebJobsStorage", TestEnvironment.StorageConnectionString}
                    });
                });

            configure?.Invoke(hostBuilder);
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
            return "testtable" + _random.Next();
        }
    }
}