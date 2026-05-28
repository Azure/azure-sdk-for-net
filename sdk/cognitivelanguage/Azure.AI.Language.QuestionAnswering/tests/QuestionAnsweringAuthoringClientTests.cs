// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using Azure.AI.Language.QuestionAnswering.Authoring;
using Azure.Core.TestFramework;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class QuestionAnsweringAuthoringClientTests
    {
        public Uri Endpoint => new("https://leithyta-sdktesting.cognitiveservices.azure.com", UriKind.Absolute);

        public QuestionAnsweringAuthoringClient Client => new(Endpoint, new AzureKeyCredential("5d757e79a27f40f896d1dc0c04fb3d09"));

        // private string SampleProjectName = "sampleProjectName";

        // private string SampleDeploymentName = "sampleDeploymentName";

        [Test]
        public void QuestionAnsweringAuthoringClientEndpointNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(
                () => new QuestionAnsweringAuthoringClient(null, (AzureKeyCredential)null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void QuestionAnsweringAuthoringClientCredentialNull()
        {
            Uri endpoint = new Uri("https://test.api.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentException ex = Assert.Throws<ArgumentNullException>(
                () => new QuestionAnsweringAuthoringClient(endpoint, (AzureKeyCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
        }

        [Test]
        public void QuestionAnsweringAuthoringClientEndpointNullUsingTokenCredential()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new QuestionAnsweringClient(null, (TokenCredential)null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void QuestionAnsweringAuthoringClientCredentialNullUsingTokenCredential()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new QuestionAnsweringClient(endpoint, (TokenCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
        }

        [Test]
        public void GetDeploymentsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetDeployments(null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetDeploymentsAsync(null).ToEnumerableAsync());
            Assert.AreEqual("projectName", ex.ParamName);
        }

        [Test]
        public void GetSynonymsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetSynonyms(null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetSynonymsAsync(null).ToEnumerableAsync());
            Assert.AreEqual("projectName", ex.ParamName);
        }

        [Test]
        public void GetSourcesNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetSources(null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetSourcesAsync(null).ToEnumerableAsync());
            Assert.AreEqual("projectName", ex.ParamName);
        }

        [Test]
        public void GetQnasNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetQnas(null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetQnasAsync(null).ToEnumerableAsync());
            Assert.AreEqual("projectName", ex.ParamName);
        }

        // TODO: These tests should be activated once the bug with the validation generation is fixed. https://github.com/Azure/azure-sdk-for-net/issues/26291

        /*
        [Test]
        public void GetProjectDetailsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetProjectDetails(null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetProjectDetailsAsync(null));
            Assert.AreEqual("projectName", ex.ParamName);
        }

        [Test]
        public void CreateProjectNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.CreateProject(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.CreateProjectAsync(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.CreateProject(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.CreateProjectAsync(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);
        }

        [Test]
        public void DeleteProjectNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.DeleteProject(null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.DeleteProjectAsync(null));
            Assert.AreEqual("projectName", ex.ParamName);
        }

        [Test]
        public void GetDeleteStatusNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetDeleteStatus(null));
            Assert.AreEqual("jobId", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetDeleteStatusAsync(null));
            Assert.AreEqual("jobId", ex.ParamName);
        }

        [Test]
        public void GetExportStatusNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetExportStatus(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetExportStatusAsync(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.GetExportStatus(SampleProjectName, null));
            Assert.AreEqual("jobId", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetExportStatusAsync(SampleProjectName, null));
            Assert.AreEqual("jobId", ex.ParamName);
        }

        [Test]
        public void GetImportStatusNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetImportStatus(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetImportStatusAsync(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.GetImportStatus(SampleProjectName, null));
            Assert.AreEqual("jobId", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetImportStatusAsync(SampleProjectName, null));
            Assert.AreEqual("jobId", ex.ParamName);
        }

        [Test]
        public void GetDeployStatusNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetDeployStatus(null, null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetDeployStatusAsync(null, null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.GetDeployStatus(SampleProjectName, null, null));
            Assert.AreEqual("deploymentName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetDeployStatusAsync(SampleProjectName, null, null));
            Assert.AreEqual("deploymentName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.GetDeployStatus(SampleProjectName, SampleDeploymentName, null));
            Assert.AreEqual("jobId", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetDeployStatusAsync(SampleProjectName, SampleDeploymentName, null));
            Assert.AreEqual("jobId", ex.ParamName);
        }

        [Test]
        public void UpdateSynonymsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.UpdateSynonyms(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.UpdateSynonymsAsync(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.UpdateSynonyms(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.UpdateSynonymsAsync(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);
        }

        [Test]
        public void GetUpdateSourcesStatusNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetUpdateSourcesStatus(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetUpdateSourcesStatusAsync(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.GetUpdateSourcesStatus(SampleProjectName, null));
            Assert.AreEqual("jobId", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetUpdateSourcesStatusAsync(SampleProjectName, null));
            Assert.AreEqual("jobId", ex.ParamName);
        }

        [Test]
        public void GetUpdateQnasStatusNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetUpdateQnasStatus(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetUpdateQnasStatusAsync(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.GetUpdateQnasStatus(SampleProjectName, null));
            Assert.AreEqual("jobId", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetUpdateQnasStatusAsync(SampleProjectName, null));
            Assert.AreEqual("jobId", ex.ParamName);
        }

        [Test]
        public void AddFeedbackNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.AddFeedback(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.AddFeedbackAsync(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.AddFeedback(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.AddFeedbackAsync(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);
        }

        [Test]
        public void ExportNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.Export(null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.ExportAsync(null));
            Assert.AreEqual("projectName", ex.ParamName);
        }

        [Test]
        public void ImportNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.Import(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.ImportAsync(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.Import(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.ImportAsync(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);
        }

        [Test]
        public void DeployProjectNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.DeployProject(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.DeployProjectAsync(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.DeployProject(SampleProjectName, null));
            Assert.AreEqual("deploymentName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.DeployProjectAsync(SampleProjectName, null));
            Assert.AreEqual("deploymentName", ex.ParamName);
        }

        [Test]
        public void UpdateSourcesNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.UpdateSources(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.UpdateSourcesAsync(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.UpdateSources(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.UpdateSourcesAsync(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);
        }

        [Test]
        public void UpdateQnasNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.UpdateQnas(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.UpdateQnasAsync(null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.UpdateQnas(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.UpdateQnasAsync(SampleProjectName, null));
            Assert.AreEqual("content", ex.ParamName);
        }
        */
    }
}
