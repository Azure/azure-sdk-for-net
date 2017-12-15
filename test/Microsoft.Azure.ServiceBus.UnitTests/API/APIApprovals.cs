namespace Microsoft.Azure.ServiceBus.UnitTests.API
{
    using System;
    using System.Linq;
    using ApprovalTests;
    using Xunit;

    public class ApiApprovals
    {
        [Fact]
        public void ApproveAzureServiceBus()
        {
            var assembly = typeof(Message).Assembly;
            var publicApi = Filter(PublicApiGenerator.ApiGenerator.GeneratePublicApi(assembly, whitelistedNamespacePrefixes: new[] { "Microsoft.Azure.ServiceBus." }));
            Approvals.Verify(publicApi);
        }

        string Filter(string text)
        {
            return string.Join(Environment.NewLine, text.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .Where(l => !l.StartsWith("[assembly: System.Runtime.Versioning.TargetFrameworkAttribute"))
            );
        }
    }
}