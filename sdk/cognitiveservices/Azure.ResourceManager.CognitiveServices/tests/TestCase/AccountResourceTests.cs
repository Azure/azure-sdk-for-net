// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class AccountResourceTests : CognitiveServicesManagementTestBase
    {
        public AccountResourceTests(bool Async)
            : base(Async)//, RecordedTestMode.Record)
        {
        }
        private async Task<CognitiveServicesAccountResource> CreateAccountResourceAsync(string accountName)
        {
            var container = (await CreateResourceGroupAsync()).GetCognitiveServicesAccounts();
            var input = ResourceDataHelper.GetBasicAccountData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task AccountResourceApiTests()
        {
            //1.Get
            var accountName = Recording.GenerateAssetName("testAccount-");
            var account1 = await CreateAccountResourceAsync(accountName);
            CognitiveServicesAccountResource account2 = await account1.GetAsync();

            ResourceDataHelper.AssertAccount(account1.Data, account2.Data);
            //2.Delete
            await account1.DeleteAsync(WaitUntil.Completed);
        }

        [TestFixture]
        public class CognitiveServicesRequestTests
        {
            private const string SubscriptionId = "11111111-1111-1111-1111-111111111111";
            private static readonly ResourceIdentifier AccountId = CognitiveServicesAccountResource.CreateResourceIdentifier(SubscriptionId, "test-rg", "test-account");

            [TestCase(false)]
            [TestCase(true)]
            public async Task EvaluateDeploymentPoliciesSendsRequestAndDeserializesResponse(bool isAsync)
            {
                var response = new MockResponse(200);
                response.SetContent("""
                    {
                      "results": {
                        "test-deployment": {
                          "evaluationOutcome": "Error",
                          "errorMessage": "Policy evaluation failed.",
                          "nonCompliantAssignments": []
                        }
                      }
                    }
                    """);
                var transport = new MockTransport(response);
                var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
                var account = client.GetCognitiveServicesAccountResource(AccountId);
                var model = new CognitiveServicesAccountDeploymentModel
                {
                    Format = "OpenAI",
                    Name = "gpt-4o",
                    Version = "2024-08-06"
                };
                var properties = new EvaluateDeploymentPoliciesDeploymentProperties(model) { RaiPolicyName = "test-policy" };
                var content = new EvaluateDeploymentPoliciesContent(new[] { new EvaluateDeploymentPoliciesDeployment("test-deployment", properties) });

                Response<EvaluateDeploymentPoliciesResult> result = isAsync
                    ? await account.EvaluateDeploymentPoliciesAsync(content)
                    : account.EvaluateDeploymentPolicies(content);

                var request = transport.SingleRequest;
                Assert.AreEqual(RequestMethod.Post, request.Method);
                Assert.AreEqual($"https://management.azure.com{AccountId}/evaluateDeploymentPolicies?api-version=2026-09-15-preview", request.Uri.ToString());
                AssertHeader(request, "Content-Type", "application/json");
                using var stream = new MemoryStream();
                request.Content.WriteTo(stream, CancellationToken.None);
                using var document = JsonDocument.Parse(stream.ToArray());
                var deployments = document.RootElement.GetProperty("deployments");
                Assert.AreEqual(1, deployments.GetArrayLength());
                Assert.AreEqual("test-deployment", deployments[0].GetProperty("name").GetString());
                var deploymentProperties = deployments[0].GetProperty("properties");
                Assert.AreEqual("test-policy", deploymentProperties.GetProperty("raiPolicyName").GetString());
                var deploymentModel = deploymentProperties.GetProperty("model");
                Assert.AreEqual("OpenAI", deploymentModel.GetProperty("format").GetString());
                Assert.AreEqual("gpt-4o", deploymentModel.GetProperty("name").GetString());
                Assert.AreEqual("2024-08-06", deploymentModel.GetProperty("version").GetString());
                Assert.AreEqual(1, result.Value.Results.Count);
                var evaluation = result.Value.Results["test-deployment"];
                Assert.AreEqual(DeploymentPolicyEvaluationOutcome.Error, evaluation.EvaluationOutcome);
                Assert.AreEqual("Policy evaluation failed.", evaluation.ErrorMessage);
                Assert.IsEmpty(evaluation.NonCompliantAssignments);
            }

            [TestCase(false, null, null)]
            [TestCase(true, null, null)]
            [TestCase(false, "\"current-etag\"", null)]
            [TestCase(true, "\"current-etag\"", null)]
            [TestCase(false, null, "*")]
            [TestCase(true, null, "*")]
            [TestCase(false, "\"current-etag\"", "\"other-etag\"")]
            [TestCase(true, "\"current-etag\"", "\"other-etag\"")]
            public async Task RaiPolicyCreateOrUpdateSendsConditionalHeaders(bool isAsync, string ifMatch, string ifNoneMatch)
            {
                var response = new MockResponse(200);
                response.SetContent($$"""
                    {
                      "id": "{{AccountId}}/raiPolicies/test-policy",
                      "name": "test-policy",
                      "type": "Microsoft.CognitiveServices/accounts/raiPolicies",
                      "properties": { "basePolicyName": "Microsoft.Default" }
                    }
                    """);
                                var transport = new MockTransport(response);
                var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
                var policies = client.GetCognitiveServicesAccountResource(AccountId).GetRaiPolicies();
                MatchConditions conditions = ifMatch == null && ifNoneMatch == null ? null : new MatchConditions
                {
                    IfMatch = ifMatch == null ? null : new ETag(ifMatch),
                    IfNoneMatch = ifNoneMatch == null ? null : new ETag(ifNoneMatch)
                };
                var data = new RaiPolicyData { Properties = new RaiPolicyProperties { BasePolicyName = "Microsoft.Default" } };

                ArmOperation<RaiPolicyResource> operation = isAsync
                    ? await policies.CreateOrUpdateAsync(WaitUntil.Completed, "test-policy", data, conditions)
                    : policies.CreateOrUpdate(WaitUntil.Completed, "test-policy", data, conditions);

                var request = transport.SingleRequest;
                Assert.AreEqual(RequestMethod.Put, request.Method);
                Assert.AreEqual($"https://management.azure.com{AccountId}/raiPolicies/test-policy?api-version=2026-09-15-preview", request.Uri.ToString());
                AssertHeader(request, "If-Match", ifMatch);
                AssertHeader(request, "If-None-Match", ifNoneMatch);
                Assert.AreEqual("test-policy", operation.Value.Data.Name);
            }

            private static void AssertHeader(Request request, string name, string expected)
            {
                bool present = request.Headers.TryGetValue(name, out string actual);
                Assert.AreEqual(expected != null, present, name);
                if (expected != null)
                {
                    Assert.AreEqual(expected, actual, name);
                }
            }
        }
    }
}
