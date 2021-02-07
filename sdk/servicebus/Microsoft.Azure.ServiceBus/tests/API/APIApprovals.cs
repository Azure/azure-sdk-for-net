// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.API
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using ApprovalTests;
    using PublicApiGenerator;
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
#if !NET5_0 // We don't ship a NET5 specific target of the library and PublicApiGenerator have a problem with API generation when running netcoreapp5.0
        [Fact]
        public void ApproveAzureServiceBus()
        {
            var assembly = typeof(Message).Assembly;
            var publicApi = Filter(assembly.GeneratePublicApi(new ApiGeneratorOptions { WhitelistedNamespacePrefixes = new[] { "Microsoft.Azure.ServiceBus." } }));

            try
            {
                Approvals.Verify(publicApi);
            }
            finally
            {
                // The ApprovalTests library does not clean up its temporary files on failure.  Force cleanup.
                CleanApprovalsTempFiles(ApprovalUtilities.Utilities.PathUtilities.GetDirectoryForCaller());
            }
        }
#endif

        string Filter(string text)
        {
            return string.Join(Environment.NewLine, text.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .Where(l => !l.StartsWith("[assembly: System.Runtime.Versioning.TargetFramework"))
            );
        }

        /// <remarks>
        ///     Failures during clean-up will not be considered critical; they will be reported, but otherwise ignored as not to
        ///     influence test results.  These assets are assumed to be cleaned during the build process and should only be
        ///     a concern for local runs.
        /// </remarks>
        ///
        void CleanApprovalsTempFiles(string approvalsWorkingdDirectory)
        {
            foreach (var file in Directory.EnumerateFiles(approvalsWorkingdDirectory, $"{ nameof(ApiApprovals) }.*received.txt", SearchOption.AllDirectories))
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {
                    // Avoid using the TestUtility class here, as it has a static dependency on the connection string environment variable, but this is
                    // not a Live test.
                    var message = $"Unable to remove the test asset [{ file }].  This non-critical but may leave remnants for a local run.";
                    Debug.WriteLine(message);
                    Console.WriteLine(message);
                }
            }
        }
    }
}