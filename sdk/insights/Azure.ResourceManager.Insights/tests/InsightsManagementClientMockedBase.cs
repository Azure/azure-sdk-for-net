// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Insights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests
{
    public class InsightsManagementClientMockedBase : InsightsManagementClientBase
    {
        protected InsightsManagementClientMockedBase(bool isAsync) : base(isAsync) { }

        public InsightsManagementClient GetInsightsManagementClient(HttpPipelineTransport transport)
        {
            InsightsManagementClientOptions options = new InsightsManagementClientOptions();
            options.Transport = transport;

            return CreateClient<InsightsManagementClient>(
                TestEnvironment.SubscriptionId,
                new TestCredential(), options);
        }
        protected static void AreEqual(IList<string> exp, IList<string> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.AreEqual(exp[i], act[i]);
                }
            }
        }

        protected static void AreEqual(IList<LocalizableString> exp, IList<LocalizableString> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.AreEqual(exp[i].LocalizedValue, act[i].LocalizedValue);
                    Assert.AreEqual(exp[i].Value, act[i].Value);
                }
            }
        }

        protected static void AreEqual(IList<int> exp, IList<int> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.AreEqual(exp[i], act[i]);
                }
            }
        }

        protected static void AreEqual(LocalizableString exp, LocalizableString act)
        {
            if (exp != null)
            {
                Assert.AreEqual(exp.LocalizedValue, act.LocalizedValue);
                Assert.AreEqual(exp.Value, act.Value);
            }
        }

        protected static void AreEqual(IDictionary<string, string> exp, IDictionary<string, string> act)
        {
            if (exp != null)
            {
                foreach (var key in exp.Keys)
                {
                    Assert.AreEqual(exp[key], act[key]);
                }
            }
        }
    }
}
