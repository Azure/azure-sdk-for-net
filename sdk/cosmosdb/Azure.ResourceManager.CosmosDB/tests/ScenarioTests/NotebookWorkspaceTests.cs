// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if false
// enable this after notebook is back online
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    // TODO: re-enable the test when Notebook is restored
    [Ignore("Disable since the backend service is offline due to security incident.")]
    public class NotebookWorkspaceTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private CosmosDBAccountResource _databaseAccount;

        private const string WorkspaceName = "default";

        public NotebookWorkspaceTests(bool isAsync) : base(isAsync)
        {
        }

        protected NotebookWorkspaceCollection NotebookWorkspaceCollection { get => _databaseAccount.GetNotebookWorkspaces(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB)).Id;
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public virtual void GlobalTeardown()
        {
            if (_databaseAccountIdentifier != null)
            {
                ArmClient.GetDatabaseAccount(_databaseAccountIdentifier).Delete();
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            _databaseAccount = await ArmClient.GetDatabaseAccount(_databaseAccountIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            NotebookWorkspace workspace = await NotebookWorkspaceCollection.GetIfExistsAsync(WorkspaceName);
            if (workspace != null)
            {
                await workspace.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task NotebookWorkspaceCreateAndUpdate()
        {
            var workspace = await CreateNotebookWorkspace();
            Assert.AreEqual(WorkspaceName, workspace.Data.Name);

            bool ifExists = await NotebookWorkspaceCollection.CheckIfExistsAsync(WorkspaceName);
            Assert.True(ifExists);

            NotebookWorkspace workspace2 = await NotebookWorkspaceCollection.GetAsync(WorkspaceName);
            Assert.AreEqual(WorkspaceName, workspace2.Data.Name);

            VerifyNotebookWorkspaces(workspace, workspace2);

            workspace = await (await NotebookWorkspaceCollection.CreateOrUpdateAsync(WorkspaceName, new NotebookWorkspaceCreateUpdateParameters())).WaitForCompletionAsync();
            Assert.AreEqual(WorkspaceName, workspace.Data.Name);
            workspace2 = await NotebookWorkspaceCollection.GetAsync(WorkspaceName);
            VerifyNotebookWorkspaces(workspace, workspace2);
        }

        [Test]
        [RecordedTest]
        public async Task NotebookWorkspaceList()
        {
            var workspace = await CreateNotebookWorkspace();

            var workspaces = await NotebookWorkspaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(workspaces, Has.Count.EqualTo(1));
            Assert.AreEqual(workspace.Data.Name, workspaces[0].Data.Name);

            VerifyNotebookWorkspaces(workspaces[0], workspace);
        }

        [Test]
        [RecordedTest]
        public async Task NotebookWorkspaceGetConnectionInfo()
        {
            var workspace = await CreateNotebookWorkspace();
            NotebookWorkspaceConnectionInfo info = await workspace.GetConnectionInfoAsync();

            Assert.IsNotEmpty(info.AuthToken);
            Assert.IsNotEmpty(info.NotebookServerEndpoint);
        }

        [Test]
        [RecordedTest]
        public async Task NotebookWorkspaceRegenerateAuthToken()
        {
            var workspace = await CreateNotebookWorkspace();
            NotebookWorkspaceConnectionInfo info = await workspace.GetConnectionInfoAsync();

            Assert.IsNotEmpty(info.AuthToken);
            Assert.IsNotEmpty(info.NotebookServerEndpoint);

            await workspace.RegenerateAuthTokenAsync();

            NotebookWorkspaceConnectionInfo info2 = await workspace.GetConnectionInfoAsync();
            Assert.IsNotEmpty(info2.AuthToken);
            Assert.IsNotEmpty(info2.NotebookServerEndpoint);

            if (Mode != RecordedTestMode.Record)
            {
                Assert.AreNotEqual(info.AuthToken, info2.AuthToken);
            }
        }

        [Test]
        [RecordedTest]
        public async Task NotebookWorkspaceStart()
        {
            var workspace = await CreateNotebookWorkspace();

            await workspace.StartAsync();
        }

        [Test]
        [RecordedTest]
        public async Task NotebookWorkspaceDelete()
        {
            var workspace = await CreateNotebookWorkspace();
            await workspace.DeleteAsync();

            workspace = await NotebookWorkspaceCollection.GetIfExistsAsync(WorkspaceName);
            Assert.Null(workspace);
        }

        protected async Task<NotebookWorkspace> CreateNotebookWorkspace()
        {
            return await NotebookWorkspaceCollection.CreateOrUpdate(WorkspaceName, new NotebookWorkspaceCreateUpdateParameters()).WaitForCompletionAsync();
        }

        private void VerifyNotebookWorkspaces(NotebookWorkspace expectedValue, NotebookWorkspace actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Status, actualValue.Data.Status);
            Assert.AreEqual(expectedValue.Data.NotebookServerEndpoint, actualValue.Data.NotebookServerEndpoint);
        }
    }
}
#endif
