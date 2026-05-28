// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Assistants;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Assistants.Tests;

public abstract partial class AssistantsTestBase : RecordedTestBase<OpenAITestEnvironment>
{
    protected static readonly string s_testMetadataKey = "aoai_net_sdk_test_run_id";
    private static readonly string s_testMetadataValue = Guid.NewGuid().ToString();
    protected string TestMetadataValue
        => Recording?.Mode == RecordedTestMode.Playback ? "RecordedMetadataValue" : s_testMetadataValue;
    protected KeyValuePair<string, string> TestMetadataPair => new(s_testMetadataKey, TestMetadataValue);

    private static readonly string s_placeholderAzureResourceUrl = "https://my-resource.openai.azure.com";
    protected string AzureResourceUrl
        => Recording?.Mode == RecordedTestMode.Record || Recording?.Mode == RecordedTestMode.Live
            ? TestEnvironment.AzureOpenAIResourceUri
            : s_placeholderAzureResourceUrl;

    private static readonly string s_placeholderApiKey = "placeholder";
    protected string NonAzureApiKey
        => Recording?.Mode == RecordedTestMode.Record || Recording?.Mode == RecordedTestMode.Live
            ? TestEnvironment.NonAzureOpenAIApiKey
            : s_placeholderApiKey;
    protected AzureKeyCredential AzureApiKeyCredential
        => Recording?.Mode == RecordedTestMode.Record || Recording?.Mode == RecordedTestMode.Live
            ? new(TestEnvironment.AzureOpenAIApiKey)
            : new(s_placeholderApiKey);
    protected TimeSpan RunPollingInterval
        => Recording?.Mode == RecordedTestMode.Playback
            ? TimeSpan.FromMilliseconds(10)
            : TimeSpan.FromMilliseconds(500);

    public List<(AssistantsClient, string)> EnsuredFileDeletions = new();
    public List<(AssistantsClient, string)> EnsuredThreadDeletions = new();

    protected AssistantsTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
    {
        BodyRegexSanitizers.Add(new BodyRegexSanitizer(TestMetadataValue) { Value = "RecordedMetadataValue" });
        BodyRegexSanitizers.Add(new BodyRegexSanitizer("sig=[^\"]*") { Value = "sig=Sanitized" });
        BodyRegexSanitizers.Add(new BodyRegexSanitizer("(\"key\" *: *\")[^ \n\"]*(\")") { Value = "$1placeholder$2" });
        HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("api-key") { Value = "***********" });
        UriRegexSanitizers.Add(new UriRegexSanitizer("sig=[^\"]*") { Value = "sig=Sanitized" });
        UriRegexSanitizers.Add(new(TestEnvironment.AzureOpenAIResourceUri ?? s_placeholderAzureResourceUrl) { Value = s_placeholderAzureResourceUrl });
        UriRegexSanitizers.Add(new("files/[^/\\?]*") { Value = "files/placeholder-file-id" });
        SanitizedQueryParameters.Add("sig");
    }

    [OneTimeTearDown]
    protected async Task ModuleCleanup()
    {
        if (Recording.Mode != RecordedTestMode.Playback)
        {
            foreach (OpenAIClientServiceTarget serviceTarget in new OpenAIClientServiceTarget[]
            {
                OpenAIClientServiceTarget.Azure,
                OpenAIClientServiceTarget.NonAzure,
            })
            {
                try
                {
                    // Best effort attempt to find items with the metadata key/value this run added and remove them
                    // -- or to remove older runs' entries with the key and a different value.
                    AssistantsClient client = GetTestClient(serviceTarget);

                    Response<PageableList<Assistant>> assistantListResponse = await client.GetAssistantsAsync();

                    IEnumerable<Assistant> assistantsToDelete = assistantListResponse.Value.Data
                        .Where(assistant =>
                        {
                            bool hasMetadataKey = assistant.Metadata?.ContainsKey(s_testMetadataKey) == true;
                            bool hasCurrentMetadataValue = hasMetadataKey && assistant.Metadata[s_testMetadataKey] == s_testMetadataValue;
                            bool isOldEnoughToDeleteAnyway = assistant.CreatedAt < DateTime.Now - TimeSpan.FromHours(2);
                            return hasCurrentMetadataValue || isOldEnoughToDeleteAnyway;
                        });
                    foreach (Assistant assistant in assistantsToDelete)
                    {
                        try
                        {
                            _ = await client.DeleteAssistantAsync(assistant.Id);
                        }
                        catch (Exception)
                        { }
                    }
                }
                catch (Exception)
                { }
            }
        }
    }

    [TearDown]
    protected async Task TestCleanup()
    {
        if (Recording.Mode != RecordedTestMode.Playback)
        {
            foreach ((AssistantsClient client, string fileId) in EnsuredFileDeletions)
            {
                try
                {
                    await client.DeleteFileAsync(fileId);
                }
                catch (Exception)
                { }
            }
            foreach ((AssistantsClient client, string threadId) in EnsuredThreadDeletions)
            {
                try
                {
                    await client.DeleteThreadAsync(threadId);
                }
                catch (Exception)
                { }
            }
        }
    }

    protected void AssertSuccessfulResponse<T>(Response<T> response, bool enforceMetadata = true)
    {
        Assert.That(response, Is.Not.Null);

        Response rawResponse = response.GetRawResponse();
        Assert.That(rawResponse, Is.Not.Null);
        Assert.That(rawResponse.Status, Is.EqualTo(200));

        string rawResponseContent = rawResponse.Content.ToString();
        Assert.That(rawResponseContent, Is.Not.Null.Or.Empty);

        Assert.That(response.Value, Is.InstanceOf<T>());

        if (response is Response<bool> boolResponse)
        {
            // Revise if we'd ever *want* a false bool
            Assert.That(boolResponse.Value, Is.True);
        }

        Func<IReadOnlyDictionary<string,string>> GetMetadata = response switch
        {
            Response<Assistant> assistantResponse => () => assistantResponse.Value.Metadata,
            Response<AssistantThread> threadResponse => () => threadResponse.Value.Metadata,
            Response<ThreadMessage> messageResponse => () => messageResponse.Value.Metadata as IReadOnlyDictionary<string, string>,
            Response<ThreadRun> runResponse => () => runResponse.Value.Metadata,
            _ => null,
        };

        if (enforceMetadata && GetMetadata != null)
        {
            Assert.That(
                GetMetadata.Invoke()?.Contains(TestMetadataPair),
                Is.True,
                $"Could not find expected test metadata pair in response value item!");
        }
    }
}
