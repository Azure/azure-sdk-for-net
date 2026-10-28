// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.PlatformValidation.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PlatformValidation.Tests
{
    public class PlatformValidationLifecycleTests : PlatformValidationManagementTestBase
    {
        public PlatformValidationLifecycleTests(bool isAsync) : base(isAsync)
        {
            Condition subscriptionList = new()
            {
                UriRegex = @"(?i)/subscriptions/[^/]+/providers/Microsoft.PlatformValidation/cloudValidations(?:\?|$)"
            };
            foreach ((string pattern, string replacement) in new[]
            {
                (@"/resourceGroups/(?!dotnetpv)[^/""\\]+", "/resourceGroups/other-group"),
                (@"/cloudValidations/(?!dotnetcv)[^/""\\?]+", "/cloudValidations/other-cloud-validation"),
                (@"""name""\s*:\s*""(?!dotnetcv)[^""]*""", @"""name"":""other-cloud-validation"""),
                (@"""description""\s*:\s*""(?:\\.|[^""\\])*""", @"""description"":""Sanitized"""),
                (@"""tags""\s*:\s*\{(?:\s*""(?:\\.|[^""\\])*""\s*:\s*""(?:\\.|[^""\\])*""\s*,?)*\s*\}", @"""tags"":{}")
            })
            {
                BodyRegexSanitizers.Add(new BodyRegexSanitizer(pattern)
                {
                    Value = replacement,
                    Condition = subscriptionList
                });
            }
        }

        [RecordedTest]
        public Task ManageCloudValidation() => ExerciseLifecycleAsync(execute: false);

        [RecordedTest]
        public Task ExecuteBootValidation() => ExerciseLifecycleAsync(execute: true);

        private async Task ExerciseLifecycleAsync(bool execute)
        {
            string source = execute ? TestEnvironment.SourceVhdUri : null;
            if (execute)
            {
                Assert.That(Uri.TryCreate(source, UriKind.Absolute, out Uri image) && image.Scheme == "https",
                    Is.True, "An approved HTTPS source VHD is required.");
            }

            string cvName = Recording.GenerateAssetName("dotnetcv").ToLowerInvariant();
            string groupName = Recording.GenerateAssetName("dotnetpv").ToLowerInvariant();
            string planName = Recording.GenerateAssetName("dotnetplan").ToLowerInvariant();
            string runName = Recording.GenerateAssetName("dotnetrun").ToLowerInvariant();
            OperationStatusCapture capture = new();
            ArmClientOptions options = new();
            options.AddPolicy(capture, HttpPipelinePosition.PerCall);
            ArmClient client = GetArmClient(options);
            SubscriptionResource subscription = client.GetSubscriptionResource(DefaultSubscription.Id);
            ResourceGroupCollection groups = subscription.GetResourceGroups();
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(30));
            CancellationToken token = timeout.Token;
            Assert.That((await groups.ExistsAsync(groupName, token)).Value, Is.False);
            ResourceGroupData groupData = new(AzureLocation.EastUS)
            {
                Tags = { ["sdk-test"] = cvName }
            };
            ResourceGroupResource group = (await groups.CreateOrUpdateAsync(
                WaitUntil.Completed, groupName, groupData, token)).Value;

            // The framework must not cascade-delete a parent if a workload or child cleanup fails.
            while (ResourceGroupCleanupPolicy.ResourceGroupsCreated.Remove(groupName))
            {
            }

            OwnedResources owned = new(group, cvName, planName, runName);
            TestContext.Progress.WriteLine($"Owned .NET resources: group={groupName}; cv={cvName}; plan={planName}; run={runName}");
            try
            {
                CloudValidationCollection validations = group.GetCloudValidations();
                Assert.That((await validations.ExistsAsync(cvName, token)).Value, Is.False);
                Assert.That((await groups.ExistsAsync(owned.ManagedGroupName, token)).Value, Is.False,
                    "Refusing to adopt an existing managed resource group.");
                owned.CloudValidationAttempted = true;
                CloudValidationData data = new(new AzureLocation(TestEnvironment.ValidationLocation))
                {
                    Tags = { ["sdk-test"] = cvName },
                    Properties = new CloudValidationProperties { Description = "SDK owned cloud validation" }
                };
                CloudValidationResource cv = await CompleteMutationAsync(owned,
                    () => validations.CreateOrUpdateAsync(WaitUntil.Started, cvName, data, token), token);
                Assert.That(cv.Data.Properties.ProvisioningState, Is.EqualTo(ProvisioningState.Succeeded));
                Assert.That(cv.Data.Tags["sdk-test"], Is.EqualTo(cvName));
                Assert.That((await cv.GetAsync(token)).Value.Id, Is.EqualTo(cv.Id));
                Assert.That((await validations.GetAsync(cvName, token)).Value.Id, Is.EqualTo(cv.Id));
                Assert.That((await validations.GetIfExistsAsync(cvName, token)).HasValue, Is.True);
                Assert.That((await validations.ExistsAsync(cvName, token)).Value, Is.True);
                ResourceGroupResource managed = (await groups.GetAsync(owned.ManagedGroupName, token)).Value;
                Assert.That(managed.Data.ManagedBy?.ToString(), Is.EqualTo(cv.Id.ToString()).IgnoreCase);

                int groupMatches = 0;
                await foreach (CloudValidationResource entry in validations.GetAllAsync(cancellationToken: token))
                {
                    groupMatches += entry.Id == cv.Id ? 1 : 0;
                }
                Assert.That(groupMatches, Is.EqualTo(1));
                int subscriptionMatches = 0;
                await foreach (CloudValidationResource entry in subscription.GetCloudValidationsAsync(cancellationToken: token))
                {
                    subscriptionMatches += entry.Id == cv.Id ? 1 : 0;
                }
                Assert.That(subscriptionMatches, Is.EqualTo(1));

                CloudValidationPatch update = new()
                {
                    CloudValidationUpdateDescription = "SDK updated cloud validation",
                    Tags = { ["sdk-test"] = cvName, ["phase"] = "updated" }
                };
                cv = await CompleteMutationAsync(owned, () => cv.UpdateAsync(WaitUntil.Started, update, token), token);
                cv = (await cv.GetAsync(token)).Value;
                Assert.That(cv.Data.Properties.Description, Is.EqualTo(update.CloudValidationUpdateDescription));
                Assert.That(cv.Data.Tags["sdk-test"], Is.EqualTo(cvName));
                Assert.That(cv.Data.Tags["phase"], Is.EqualTo("updated"));
                if (execute)
                {
                    await ExecutePlanAsync(owned, cv, subscription, capture, source, token);
                }
            }
            catch (RequestFailedException error)
            {
                throw ServiceFailure("Lifecycle", error);
            }
            finally
            {
                if (owned.MutationInProgress)
                {
                    TestContext.Error.WriteLine($"Retaining {group.Id}: a mutating operation did not reach confirmed completion.");
                }
                else
                {
                    try
                    {
                        using CancellationTokenSource cleanupTimeout = new(TimeSpan.FromMinutes(15));
                        await CleanupAsync(owned, subscription, cleanupTimeout.Token);
                    }
                    catch (RequestFailedException error)
                    {
                        throw ServiceFailure($"Cleanup retained {group.Id}", error);
                    }
                }
            }
        }

        private async Task ExecutePlanAsync(OwnedResources owned, CloudValidationResource cv,
            SubscriptionResource subscription, OperationStatusCapture capture, string source, CancellationToken token)
        {
            ValidationExecutionPlanCollection plans = cv.GetValidationExecutionPlans();
            Assert.That((await plans.ExistsAsync(owned.PlanName, token)).Value, Is.False);
            ValidationExecutionPlanData data = new(new AzureLocation(TestEnvironment.ValidationLocation))
            {
                Tags = { ["sdk-test"] = owned.CloudValidationName },
                Properties = new ValidationExecutionPlanProperties
                {
                    Description = "SDK boot plan",
                    PlanConfigurationJson = CreateConfiguration(owned.PlanName, source)
                }
            };
            ValidationExecutionPlanResource plan = await CompleteMutationAsync(owned,
                () => plans.CreateOrUpdateAsync(WaitUntil.Started, owned.PlanName, data, token), token);
            Assert.That(plan.Data.Properties.ProvisioningState, Is.EqualTo(ValidationExecutionPlanProvisioningState.Succeeded));
            Assert.That((await plans.GetAsync(owned.PlanName, token)).Value.Id, Is.EqualTo(plan.Id));
            Assert.That((await plan.GetAsync(token)).Value.Id, Is.EqualTo(plan.Id));
            Assert.That((await plans.GetIfExistsAsync(owned.PlanName, token)).HasValue, Is.True);
            List<ValidationExecutionPlanResource> listedPlans = await CollectAsync(plans.GetAllAsync(cancellationToken: token));
            Assert.That(listedPlans.Select(entry => entry.Id), Is.EquivalentTo(new[] { plan.Id }));

            capture.Reset();
            ValidationExecutionPlanPatch patch = new()
            {
                Tags = { ["sdk-test"] = owned.CloudValidationName, ["phase"] = "updated" }
            };
            plan = await CompleteMutationAsync(owned, () => plan.UpdateAsync(WaitUntil.Started, patch, token), token);
            plan = (await plan.GetAsync(token)).Value;
            Assert.That(plan.Data.Tags["sdk-test"], Is.EqualTo(owned.CloudValidationName));
            Assert.That(plan.Data.Tags["phase"], Is.EqualTo("updated"));
            Assert.That(plan.Data.Properties.Description, Is.EqualTo("SDK boot plan"));
            using (JsonDocument configuration = JsonDocument.Parse(plan.Data.Properties.PlanConfigurationJson))
            {
                string returnedSource = configuration.RootElement.GetProperty("parameters")
                    .GetProperty("certificationPackageReference").GetProperty("storageProfile")
                    .GetProperty("osDiskImage").GetProperty("sourceVhdUri").GetString();
                Assert.That(returnedSource == source, Is.True, "Plan PATCH must preserve the configured VHD.");
            }
            Assert.That(capture.OperationId, Is.Not.Null, "Plan PATCH did not expose a supported operation-status URL.");
            var status = await subscription.GetAsync(capture.Location, capture.OperationId, token);
            Assert.That(status.Value.Status, Is.EqualTo("Succeeded"));

            ExecutionPlanRunCollection runs = plan.GetExecutionPlanRuns();
            Assert.That((await runs.ExistsAsync(owned.RunName, token)).Value, Is.False);
            ExecutionPlanRunData runData = new()
            {
                Properties = new ExecutionPlanRunProperties { Description = owned.RunDescription }
            };
            ExecutionPlanRunResource run = await CompleteMutationAsync(owned,
                () => runs.CreateOrUpdateAsync(WaitUntil.Started, owned.RunName, runData, token), token);
            for (int attempt = 0; !IsTerminal(run.Data.Properties.Status?.ToString()) && attempt < 180; attempt++)
            {
                Assert.That(run.Data.Properties.ProvisioningState?.ToString(), Is.Not.EqualTo("Failed"));
                await PauseAsync(TimeSpan.FromSeconds(10), token);
                run = (await run.GetAsync(token)).Value;
            }
            Assert.That(run.Data.Properties.Status, Is.EqualTo(ExecutionPlanRunStatus.Succeeded),
                "The workload did not finish successfully; nonterminal resources are retained.");
            Assert.That(run.Data.Properties.ProvisioningState, Is.EqualTo(ExecutionPlanRunProvisioningState.Succeeded));
            Assert.That(run.Data.Properties.Error, Is.Null);
            Assert.That(run.Data.Properties.Description, Is.EqualTo(owned.RunDescription));
            Assert.That(run.Data.Properties.StartedOn, Is.Not.Null);
            Assert.That(run.Data.Properties.CompletedOn, Is.GreaterThanOrEqualTo(run.Data.Properties.StartedOn));
            TestRunSummary summary = run.Data.Properties.TestRunSummary;
            Assert.That(summary, Is.Not.Null);
            Assert.That(summary.OverallResult, Is.EqualTo(TestRunOverallResult.Passed));
            Assert.That(summary.TotalTests, Is.EqualTo(1));
            Assert.That(summary.PassedTests, Is.EqualTo(1));
            Assert.That(summary.FailedTests, Is.EqualTo(0));
            Assert.That(summary.SkippedTests, Is.EqualTo(0));
            Assert.That((await runs.GetAsync(owned.RunName, token)).Value.Id, Is.EqualTo(run.Id));
            Assert.That((await runs.GetIfExistsAsync(owned.RunName, token)).HasValue, Is.True);
            List<ExecutionPlanRunResource> listedRuns = await CollectAsync(runs.GetAllAsync(cancellationToken: token));
            Assert.That(listedRuns.Select(entry => entry.Id), Is.EquivalentTo(new[] { run.Id }));
            List<ValidationTestRunResource> tests = await CollectAsync(run.GetValidationTestRuns().GetAllAsync(cancellationToken: token));
            Assert.That(tests, Has.Count.EqualTo(1));
            ValidationTestRunResource test = (await run.GetValidationTestRuns().GetAsync(tests[0].Data.Name, token)).Value;
            Assert.That((await test.GetAsync(token)).Value.Id, Is.EqualTo(test.Id));
            Assert.That(test.Data.Properties.Status, Is.EqualTo(ValidationTestRunStatus.Completed));
            Assert.That(test.Data.Properties.ProvisioningState, Is.EqualTo(ValidationTestRunProvisioningState.Succeeded));
            Assert.That(test.Data.Properties.Error, Is.Null);
            Assert.That(test.Data.Properties.PassDetails, Is.Not.Empty);
            Assert.That(test.Data.Properties.FailureDetails, Is.Empty);
            Assert.That(test.Data.Properties.TestId.ToString(),
                Is.EqualTo("/providers/Microsoft.PlatformValidation/validationTests/compute-vmimagevalidation-vm-boot-test"));
        }

        private async Task CleanupAsync(OwnedResources owned, SubscriptionResource subscription, CancellationToken token)
        {
            CloudValidationCollection validations = owned.Group.GetCloudValidations();
            if (owned.CloudValidationAttempted)
            {
                NullableResponse<CloudValidationResource> response = await validations.GetIfExistsAsync(owned.CloudValidationName, token);
                if (response.HasValue)
                {
                    CloudValidationResource cv = response.Value;
                    Assert.That(cv.Data.Tags["sdk-test"], Is.EqualTo(owned.CloudValidationName), "Refusing cleanup of an unowned CV.");
                    Assert.That(IsTerminalProvisioning(cv.Data.Properties.ProvisioningState?.ToString()), Is.True);
                    ValidationExecutionPlanCollection plans = cv.GetValidationExecutionPlans();
                    foreach (ValidationExecutionPlanResource plan in await CollectAsync(plans.GetAllAsync(cancellationToken: token)))
                    {
                        Assert.That(plan.Data.Name, Is.EqualTo(owned.PlanName), "Unexpected plan; refusing parent cascade.");
                        Assert.That(plan.Data.Tags["sdk-test"], Is.EqualTo(owned.CloudValidationName));
                        Assert.That(IsTerminalProvisioning(plan.Data.Properties.ProvisioningState?.ToString()), Is.True);
                        ExecutionPlanRunCollection runs = plan.GetExecutionPlanRuns();
                        foreach (ExecutionPlanRunResource run in await CollectAsync(runs.GetAllAsync(cancellationToken: token)))
                        {
                            Assert.That(run.Data.Name, Is.EqualTo(owned.RunName), "Unexpected run; refusing parent cascade.");
                            Assert.That(run.Data.Properties.Description, Is.EqualTo(owned.RunDescription));
                            Assert.That(IsTerminalProvisioning(run.Data.Properties.ProvisioningState?.ToString()), Is.True);
                            Assert.That(IsTerminal(run.Data.Properties.Status?.ToString()), Is.True, "Active workload; retaining its parents.");
                            List<ValidationTestRunResource> tests = await CollectAsync(run.GetValidationTestRuns().GetAllAsync(cancellationToken: token));
                            await InstrumentClient(run).DeleteAsync(WaitUntil.Completed, token);
                            Assert.That((await runs.ExistsAsync(owned.RunName, token)).Value, Is.False);
                            AssertMissing(() => run.GetAsync(token));
                            foreach (ValidationTestRunResource test in tests)
                            {
                                AssertMissing(() => test.GetAsync(token));
                            }
                        }
                        Assert.That(await CollectAsync(runs.GetAllAsync(cancellationToken: token)), Is.Empty);
                        await InstrumentClient(plan).DeleteAsync(WaitUntil.Completed, token);
                        Assert.That((await plans.ExistsAsync(owned.PlanName, token)).Value, Is.False);
                        AssertMissing(() => plan.GetAsync(token));
                    }
                    for (int attempt = 0; ; attempt++)
                    {
                        Assert.That(await CollectAsync(plans.GetAllAsync(cancellationToken: token)), Is.Empty);
                        try
                        {
                            await InstrumentClient(cv).DeleteAsync(WaitUntil.Completed, token);
                            break;
                        }
                        catch (RequestFailedException error) when (error.Status == 409
                            && error.ErrorCode == "CannotDeleteResource" && attempt < 29)
                        {
                            TestContext.Progress.WriteLine($"CV deletion still reports nested resources; retry {attempt + 1}/30.");
                            await PauseAsync(TimeSpan.FromSeconds(10), token);
                        }
                    }
                    Assert.That((await validations.ExistsAsync(owned.CloudValidationName, token)).Value, Is.False);
                    AssertMissing(() => cv.GetAsync(token));
                }

                int absent = 0;
                for (int attempt = 0; attempt < 60 && absent < 3; attempt++)
                {
                    absent = (await subscription.GetResourceGroups().ExistsAsync(owned.ManagedGroupName, token)).Value ? 0 : absent + 1;
                    if (absent < 3)
                    {
                        await PauseAsync(TimeSpan.FromSeconds(10), token);
                    }
                }
                Assert.That(absent, Is.EqualTo(3), "Service-managed MRG cleanup was not confirmed; no explicit MRG deletion attempted.");
            }

            ResourceGroupResource group = (await owned.Group.GetAsync(token)).Value;
            Assert.That(group.Data.Tags["sdk-test"], Is.EqualTo(owned.CloudValidationName));
            await foreach (GenericResource remaining in group.GetGenericResourcesAsync(cancellationToken: token))
            {
                Assert.That(remaining.Id, Is.EqualTo(CloudValidationResource.CreateResourceIdentifier(
                    subscription.Id.SubscriptionId, group.Data.Name, owned.CloudValidationName)),
                    "Unexpected remaining resource; refusing resource-group cascade.");
                Assert.That((await validations.ExistsAsync(owned.CloudValidationName, token)).Value, Is.False);
            }
            await InstrumentClient(group).DeleteAsync(WaitUntil.Completed, cancellationToken: token);
            Assert.That((await subscription.GetResourceGroups().ExistsAsync(group.Data.Name, token)).Value, Is.False);
            TestContext.Progress.WriteLine($"Confirmed deletion of owned group {group.Data.Name} and service-managed MRG {owned.ManagedGroupName}.");
        }

        private async Task<T> CompleteMutationAsync<T>(OwnedResources owned,
            Func<Task<ArmOperation<T>>> begin, CancellationToken token)
        {
            owned.MutationInProgress = true;
            ArmOperation<T> operation = await begin();
            Response<T> response = await operation.WaitForCompletionAsync(TimeSpan.FromSeconds(5), token);
            owned.MutationInProgress = false;
            return response.Value;
        }

        private Task PauseAsync(TimeSpan duration, CancellationToken token) =>
            Mode == RecordedTestMode.Playback ? Task.CompletedTask : Task.Delay(duration, token);

        private static bool IsTerminalProvisioning(string state) => state is "Succeeded" or "Failed" or "Canceled";

        private static bool IsTerminal(string state) => state is "Succeeded" or "Completed" or "Failed"
            or "Canceled" or "Cancelled" or "TimedOut";

        private static void AssertMissing(Func<Task> get)
        {
            RequestFailedException error = Assert.ThrowsAsync<RequestFailedException>(async () => await get());
            Assert.That(error.Status, Is.EqualTo(404));
        }

        private static AssertionException ServiceFailure(string phase, RequestFailedException error) =>
            new($"{phase}: HTTP {error.Status}; code={error.ErrorCode}. Service body omitted to protect signed image input.");

        private static async Task<List<T>> CollectAsync<T>(IAsyncEnumerable<T> entries)
        {
            List<T> values = new();
            await foreach (T entry in entries)
            {
                values.Add(entry);
            }
            return values;
        }

        private static string CreateConfiguration(string name, string source) => JsonSerializer.Serialize(new
        {
            apiVersion = "microsoft.validate/executionPlan.v0",
            kind = "ExecutionPlan",
            metadata = new { name },
            parameters = new
            {
                certificationPackageReference = new
                {
                    osType = "Linux",
                    vmGenerationType = "V1",
                    architectureType = "X64",
                    recommendedVMSizes = new[] { "Standard_D4s_v3" },
                    storageProfile = new
                    {
                        osDiskImage = new { sourceVhdUri = source },
                        dataDiskImages = Array.Empty<object>()
                    },
                    additionalProperties = new { }
                }
            },
            authoring = new
            {
                steps = new[]
                {
                    new
                    {
                        name = "vm-boot-test",
                        type = "test",
                        testRef = "/providers/Microsoft.PlatformValidation/validationTests/compute-vmimagevalidation-vm-boot-test"
                    }
                }
            }
        });

        private sealed class OwnedResources
        {
            public OwnedResources(ResourceGroupResource group, string cvName, string planName, string runName)
            {
                Group = group;
                CloudValidationName = cvName;
                PlanName = planName;
                RunName = runName;
            }

            public ResourceGroupResource Group { get; }
            public string CloudValidationName { get; }
            public string PlanName { get; }
            public string RunName { get; }
            public string RunDescription => $"SDK owned execution {RunName}";
            public string ManagedGroupName => $"{CloudValidationName}-mrg";
            public bool CloudValidationAttempted { get; set; }
            public bool MutationInProgress { get; set; }
        }

        private sealed class OperationStatusCapture : HttpPipelineSynchronousPolicy
        {
            public string OperationId { get; private set; }
            public AzureLocation Location { get; private set; }

            public void Reset() => OperationId = null;

            public override void OnReceivedResponse(HttpMessage message)
            {
                if (message.Request.Method != RequestMethod.Patch)
                {
                    return;
                }
                if (!message.Response.Headers.TryGetValue("Azure-AsyncOperation", out string target)
                    && !message.Response.Headers.TryGetValue("Operation-Location", out target))
                {
                    return;
                }
                if (!Uri.TryCreate(target, UriKind.Absolute, out Uri uri))
                {
                    return;
                }
                string[] segments = uri.AbsolutePath.Trim('/').Split('/');
                int location = Array.FindIndex(segments, value => value.Equals("locations", StringComparison.OrdinalIgnoreCase));
                if (location >= 0 && location + 1 < segments.Length && segments.Length >= 2
                    && segments[^2].Equals("operationStatuses", StringComparison.OrdinalIgnoreCase))
                {
                    Location = new AzureLocation(segments[location + 1]);
                    OperationId = segments[^1];
                }
            }
        }
    }
}
