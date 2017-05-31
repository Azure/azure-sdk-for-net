#if NET46

using System.IO;
using System.Reflection;
using ApprovalTests;
using ApprovalTests.Namers;

namespace ApiApprover
{
    public static class PublicApiApprover
    {
        public static void ApprovePublicApi(Assembly assembly)
        {
            var publicApi = PublicApiGenerator.ApiGenerator.GeneratePublicApi(assembly);
            var writer = new ApprovalTextWriter(publicApi, "cs");
            var approvalNamer = new AssemblyPathNamer(assembly.Location);
            Approvals.Verify(writer, approvalNamer, Approvals.GetReporter());
        }

        private class AssemblyPathNamer : UnitTestFrameworkNamer
        {
            private readonly string name;

            public AssemblyPathNamer(string assemblyPath)
            {
                name = Path.GetFileNameWithoutExtension(assemblyPath);
            }

            public override string Name
            {
                get { return name; }
            }
        }
    }
}

#endif