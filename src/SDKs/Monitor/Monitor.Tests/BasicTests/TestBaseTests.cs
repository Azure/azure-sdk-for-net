﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Rest;
using Xunit;

namespace Monitor.Tests.BasicTests
{
    public class TestBase
    {
        protected MonitorClient GetMonitorClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var tokenProvider = new StringTokenProvider("granted", "SimpleString");
            var id = Guid.NewGuid().ToString();
            var token = new TokenCredentials(tokenProvider: tokenProvider, tenantId: id, callerId: id);
            var client = new MonitorClient(token, handler);
            token.InitializeServiceClient(client);
            client.SubscriptionId = id;
            
            return client;
        }

        protected MonitorManagementClient GetMonitorManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var tokenProvider = new StringTokenProvider("granted", "SimpleString");
            var id = Guid.NewGuid().ToString();
            var token = new TokenCredentials(tokenProvider: tokenProvider, tenantId: id, callerId: id);
            var client = new MonitorManagementClient(token, handler);
            token.InitializeServiceClient(client);
            client.SubscriptionId = id;

            return client;
        }

        protected static void AreEqual(IList<string> exp, IList<string> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.Equal(exp[i], act[i]);
                }
            }
        }

        protected static void AreEqual(IList<LocalizableString> exp, IList<LocalizableString> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.Equal(exp[i].LocalizedValue, act[i].LocalizedValue);
                    Assert.Equal(exp[i].Value, act[i].Value);
                }
            }
        }

        protected static void AreEqual(IList<int> exp, IList<int> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.Equal(exp[i], act[i]);
                }
            }
        }

        protected static void AreEqual(LocalizableString exp, LocalizableString act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.LocalizedValue, act.LocalizedValue);
                Assert.Equal(exp.Value, act.Value);
            }
        }

        protected static void AreEqual(IDictionary<string, string> exp, IDictionary<string, string> act)
        {
            if (exp != null)
            {
                foreach (var key in exp.Keys)
                {
                    Assert.Equal(exp[key], act[key]);
                }
            }
        }
    }
}
