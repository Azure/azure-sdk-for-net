using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests
{
    internal class DebugTest
    {
        [TestCase]
        public void CaptureActualOutput()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            
            var constructor = resourceProvider!.Constructors.FirstOrDefault(c => c.Signature.Parameters.Any(p => p.Name == "id"));
            Assert.NotNull(constructor);
            
            var bodyStatements = constructor!.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            
            Console.WriteLine("ACTUAL OUTPUT:");
            Console.WriteLine(bodyStatements);
            Console.WriteLine("END OUTPUT");
            
            // This will fail, but we'll capture the output
            Assert.AreEqual("PLACEHOLDER", bodyStatements);
        }
    }
}
