#if NET46
namespace Microsoft.Azure.ServiceBus.UnitTests.API
{
    using System.Runtime.CompilerServices;
    using ApprovalTests;
    using ApprovalTests.Reporters;
    using PublicApiGenerator;
    using Xunit;

    public class ApiApprovals
    {
        [Fact]
        [MethodImpl(MethodImplOptions.NoInlining)]
        [UseReporter(typeof(DiffReporter))]
        public void ApproveAzureServiceBus()
        {
            //Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
            var publicApi = ApiGenerator.GeneratePublicApi(typeof(Message).Assembly);
            Approvals.Verify(publicApi);
        }
    }
}
#endif