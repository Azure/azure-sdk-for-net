﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using Insights.Tests.Helpers;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Microsoft.Azure.Management.Insights;
using Microsoft.Rest;
using Xunit;

namespace Insights.Tests.BasicTests
{
    public class TestBase
    {
        protected InsightsClient GetInsightsClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var tokenProvider = new StringTokenProvider("granted", "SimpleString");
            var id = Guid.NewGuid().ToString();
            var token = new TokenCredentials(tokenProvider: tokenProvider, tenantId: id, callerId: id);
            var client = new InsightsClient(token, handler);
            token.InitializeServiceClient(client);
            client.SubscriptionId = id;
            
            return client;
        }

        protected InsightsManagementClient GetInsightsManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var tokenProvider = new StringTokenProvider("granted", "SimpleString");
            var id = Guid.NewGuid().ToString();
            var token = new TokenCredentials(tokenProvider: tokenProvider, tenantId: id, callerId: id);
            var client = new InsightsManagementClient(token, handler);
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
