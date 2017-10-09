#if NET461

namespace Microsoft.Azure.ServiceBus.UnitTests.API
{
    using System.Runtime.CompilerServices;
    using ApprovalTests;
    using ApprovalTests.Reporters;
    using Xunit;

    public class ApiApprovals
    {
        [Fact]
        [MethodImpl(MethodImplOptions.NoInlining)]
        [UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]
        public void ApproveAzureServiceBus()
        {
            var assembly = typeof(Message).Assembly;
            var publicApi = PublicApiGenerator.ApiGenerator.GeneratePublicApi(assembly);
            Approvals.Verify(publicApi);
        }
    }
}
#endif