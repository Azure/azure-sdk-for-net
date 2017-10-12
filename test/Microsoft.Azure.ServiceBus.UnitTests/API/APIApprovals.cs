#if NET461
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
        [UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]
        public void ApproveAzureServiceBus()
        {
            var publicApi = ApiGenerator.GeneratePublicApi(typeof(Message).Assembly);
            Approvals.Verify(publicApi);
        }
    }
}
#endif