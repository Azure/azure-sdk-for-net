﻿namespace Microsoft.Azure.ServiceBus.UnitTests.API
{
    using System;
    using System.Linq;
    using ApprovalTests;
    using Xunit;

    public class ApiApprovals
    {
        /// <remarks>
        ///   The output of the API generation is compared to the file tests/Microsoft.Azure.ServiceBus.Tests/API/ApiApprovals.ApproveAzureServiceBus.approved.txt,  
        ///   which is an implicit assumption of the ApprovalTests framework.  
        ///   
        ///   If the expected assembly output from generation changes, that file will need to be updated with the new expectation in order for this test 
        ///   to pass.
        /// </remarks>
        /// 
        #if WINDOWS
        [Fact]
        #else
        [Fact(Skip ="This test is only relevant on Windows due to non-deterministic behavior of a third-party library. The ApiGenerator output differs by platform.  The generated code is semantically equivilent, but line ordering is inconsistent.  Skipping for this platform.")] 
        #endif
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