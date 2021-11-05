namespace Purview.Tests.ScenarioTests
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Purview;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public abstract class ScenarioTestBase<T>
    {
        private const string ResourceGroupNamePrefix = "dotnetsdkrg";
        protected const string AccountNamePrefix = "dotnetsdkaccount";
        protected const string AccountLocation = "westus";
        protected static Type Type = typeof(T);

        protected string ResourceGroupName { get; private set; }
        protected string AccountName { get; private set; }
        protected PurviewManagementClient Client { get; private set; }

        protected async Task RunTest(
            Func<PurviewManagementClient, Task> initialAction,
            Func<PurviewManagementClient, Task> finallyAction,
            [CallerMemberName] string methodName = "")
        {
            const string modeEnvironmentVariableName = "AZURE_TEST_MODE";
            const string playback = "Playback";

            using (MockContext mockContext = MockContext.Start(Type, methodName))
            {
                string mode = Environment.GetEnvironmentVariable(modeEnvironmentVariableName);

                if (mode != null && mode.Equals(playback, StringComparison.OrdinalIgnoreCase))
                {
                    HttpMockServer.Mode = HttpRecorderMode.Playback;
                }

                this.ResourceGroupName =
                    TestUtilities.GenerateName(ScenarioTestBase<T>.ResourceGroupNamePrefix);
                this.AccountName = TestUtilities.GenerateName(ScenarioTestBase<T>.AccountNamePrefix);

                this.Client =
                    mockContext.GetServiceClient<PurviewManagementClient>(
                        TestEnvironmentFactory.GetTestEnvironment());

                ResourceManagementClient resourceManagementClient =
                    mockContext.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());

                resourceManagementClient.ResourceGroups.CreateOrUpdate(
                    this.ResourceGroupName,
                    new ResourceGroup() { Location = ScenarioTestBase<T>.AccountLocation });

                await initialAction(this.Client);

                if (finallyAction != null)
                {
                    await finallyAction(this.Client);
                }

                resourceManagementClient.ResourceGroups.Delete(this.ResourceGroupName);
            }
        }
    }
}
