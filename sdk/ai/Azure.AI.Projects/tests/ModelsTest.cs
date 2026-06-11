// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class ModelsTest : ProjectsClientTestBase
{
    public ModelsTest(bool isAsync) : base(isAsync)
    {
    }

    private static readonly string MODEL_NAME = "cs-model-name09";
    private static readonly string MODEL_VERSION = "1";

    public async Task<Uri> MakeBlob(AIProjectClient projectClient, string name, string version)
    {
        DirectoryInfo dataFolder = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "sample-model"));
        File.WriteAllBytes(Path.Combine(dataFolder.FullName, "weights.bin"), BinaryData.FromString("hello-foundry-model").ToArray());
        File.WriteAllText(Path.Combine(dataFolder.FullName, "config.json"), "{\"sample\": true}");
        Uri dataUri;
        try
        {
            dataUri = await projectClient.Models.UploadModelAsync(path: dataFolder.FullName, name: name, version: version);
            Assert.That(dataUri, Is.Not.Null);
        }
        finally
        {
            Directory.Delete(dataFolder.FullName, true);
        }
        return dataUri;
    }

    [LiveOnly] // We cannot record the blob upload and cannot save the uploaded BLOB from previous session.
    [RecordedTest]
    public async Task TestModelDeployment()
    {
        // Run TestUploadData to get the MODEL_WEIGHTS_URI. set model names a
        AIProjectClient projectClient = GetTestProjectClient();
        Uri blob = await MakeBlob(projectClient, $"{MODEL_NAME}1", MODEL_VERSION);
        ModelVersion modelVersionObj = new(blob)
        {
            WeightType = FoundryModelWeightType.FullWeight,
            Description = "Model description",
        };
        modelVersionObj.Tags["test"] = "test value";
        // Create
        CreateAsyncResponse createResponse = await projectClient.Models.CreateModelVersionRequestAsync(
            name: $"{MODEL_NAME}1",
            version: MODEL_VERSION,
            modelVersion: modelVersionObj);
        Assert.That(createResponse.Location, Is.Not.Null);
        // Get
        ModelVersion retrievedModel = await WaitForModel(projectClient, $"{MODEL_NAME}1", MODEL_VERSION);
        Assert.That(retrievedModel.Name, Is.EqualTo($"{MODEL_NAME}1"));
        Assert.That(retrievedModel.Version, Is.EqualTo(MODEL_VERSION));
        Assert.That(retrievedModel.Description, Is.EqualTo("Model description"));
        Assert.That(retrievedModel.Tags, Does.ContainKey("test"));
        Assert.That(retrievedModel.Tags["test"], Is.EqualTo("test value"));
        Assert.That(retrievedModel.Tags, Has.Count.EqualTo(1));
        // Update
        UpdateModelVersionOptions updateOptions = new()
        {
            Description = "Updated model description."
        };
        updateOptions.Tags["test1"] = "test1 value";
        ModelVersion updatedModel = await projectClient.Models.UpdateModelVersionAsync(
            name: retrievedModel.Name,
            version: retrievedModel.Version,
            updateOptions: updateOptions
        );
        Assert.That(updatedModel, Is.Not.Null);
        Assert.That(updatedModel.Name, Is.EqualTo($"{MODEL_NAME}1"));
        Assert.That(updatedModel.Version, Is.EqualTo(MODEL_VERSION));
        Assert.That(updatedModel.Description, Is.EqualTo("Updated model description."));
        Assert.That(updatedModel.Tags, Does.ContainKey("test"));
        Assert.That(updatedModel.Tags["test"], Is.EqualTo("test value"));
        Assert.That(updatedModel.Tags, Does.ContainKey("test1"));
        Assert.That(updatedModel.Tags["test1"], Is.EqualTo("test1 value"));
        Assert.That(updatedModel.Tags, Has.Count.EqualTo(2));
        // Get credentials
        ModelCredentialRequest credentialRequest = new(blob);
        DatasetCredential modelCredential = await projectClient.Models.GetModelCredentialsAsync(name: retrievedModel.Name, version: retrievedModel.Version, credentialRequest: credentialRequest);
        Assert.That(modelCredential.BlobReference.Credential.SasUri, Is.Not.Null);
        // List
        // The rest is commented, because of issue 5317570.
        // Create two more models
        //await projectClient.Models.CreateModelVersionRequestAsync(
        //    name: $"{MODEL_NAME}1",
        //    version: "2",
        //    modelVersion: new(await MakeBlob(projectClient, $"{MODEL_NAME}1", "2")));
        //await WaitForModel(projectClient, $"{MODEL_NAME}1", "2");
        //await projectClient.Models.CreateModelVersionRequestAsync(
        //    name: $"{MODEL_NAME}2",
        //    version: "1",
        //    modelVersion: new(await MakeBlob(projectClient, $"{MODEL_NAME}2", "1")));
        //await WaitForModel(projectClient, $"{MODEL_NAME}2", "1");
        //// The delay to make lists available
        //await Delay(5000);
        //// List versions
        //List<ModelVersion> versions = await projectClient.Models.GetModelVersionsAsync(name: $"{MODEL_NAME}1").ToListAsync();
        //Assert.That(versions, Has.Count.EqualTo(2));
        //HashSet<string> versionStrings = [.. versions.Select(x => x.Version)];
        //Assert.That(versionStrings, Does.Contain("1"));
        //Assert.That(versionStrings, Does.Contain("2"));
        //Assert.That(versions.All(x => string.Equals(x.Name, $"{MODEL_NAME}1")), Is.True);
        ////  List latest versions.
        //List<ModelVersion> models = await projectClient.Models.GetLatestModelVersionsAsync().ToListAsync();
        //Assert.That(models, Has.Count.EqualTo(2));
        //ModelVersion first = string.Equals(models[0].Name, $"{MODEL_NAME}1") ? models[0] : models[1];
        //ModelVersion second = string.Equals(models[0].Name, $"{MODEL_NAME}2") ? models[0] : models[1];
        //Assert.That(first.Name, Is.EqualTo($"{MODEL_NAME}1"));
        //Assert.That(first.Version, Is.EqualTo("2"));
        //Assert.That(second.Name, Is.EqualTo($"{MODEL_NAME}2"));
        //Assert.That(second.Version, Is.EqualTo("1"));
        //// Delete
        //await projectClient.Models.DeleteModelVersionAsync($"{MODEL_NAME}1", "2");
        //versions = await projectClient.Models.GetModelVersionsAsync(name: $"{MODEL_NAME}1").ToListAsync();
        //Assert.That(versions, Has.Count.EqualTo(1));
        //Assert.That(versions[0].Version, Is.EqualTo("1"));

        //models = await projectClient.Models.GetLatestModelVersionsAsync().ToListAsync();
        //Assert.That(models, Has.Count.EqualTo(2));
        //first = string.Equals(models[0].Name, $"{MODEL_NAME}1") ? models[0] : models[1];
        //second = string.Equals(models[0].Name, $"{MODEL_NAME}2") ? models[0] : models[1];
        //Assert.That(first.Name, Is.EqualTo($"{MODEL_NAME}1"));
        //Assert.That(first.Version, Is.EqualTo("1"));
        //Assert.That(second.Name, Is.EqualTo($"{MODEL_NAME}2"));
        //Assert.That(first.Version, Is.EqualTo("1"));
        //await projectClient.Models.DeleteModelVersionAsync($"{MODEL_NAME}2", "1");
        //models = await projectClient.Models.GetLatestModelVersionsAsync().ToListAsync();
        //Assert.That(models, Has.Count.EqualTo(1));
        //Assert.That(models[0].Name, Is.EqualTo($"{MODEL_NAME}1"));
        //Assert.That(models[0].Version, Is.EqualTo("1"));
    }

    #region Helpers
    private async Task<ModelVersion> WaitForModel(AIProjectClient projectClient, string name, string version)
    {
        ModelVersion retrievedModel = null;
        DateTime deadline = DateTime.UtcNow + new TimeSpan(hours: 0, minutes: 1, seconds: 0);
        while (DateTime.UtcNow < deadline)
        {
            await Delay(500);
            try
            {
                retrievedModel = await projectClient.Models.GetModelVersionAsync(name, version);
                break;
            }
            catch (ClientResultException e)
            {
                if (e.Status != 404)
                {
                    throw;
                }
            }
        }
        Assert.That(retrievedModel, Is.Not.Null);
        return retrievedModel;
    }
    #endregion
    #region Cleanup
    [TearDown]
    public virtual async Task Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        await Delay(5000);
        Uri connectionString = new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT);
        AIProjectClient projectClient = new(connectionString, TestEnvironment.Credential);
        List<string> modelNames = await projectClient.Models.GetLatestModelVersionsAsync().Where(x => x.Name.StartsWith("cs-model-name")).Select(x => x.Name).ToListAsync();
        foreach (string modelName in modelNames)
        {
            List<string> modelVersions = await projectClient.Models.GetModelVersionsAsync(name: modelName).Select(x => x.Version).ToListAsync();
            foreach (string modelVersion in modelVersions)
            {
                await projectClient.Models.DeleteModelVersionAsync(modelName, modelVersion);
            }
        }
    }
    #endregion
}
