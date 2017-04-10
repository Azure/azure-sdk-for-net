// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class AppService : Samples.Tests.TestBase
    {
        public AppService(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageWebAppBasicTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageWebAppBasic.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageWebAppSourceControlTest()
        {
            RunSampleAsTest(
               this.GetType().FullName,
               ManageWebAppSourceControl.Program.RunSample,
               Path.Combine("..", "Common"));
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageWebAppSourceControlAsyncTest()
        {
            RunSampleAsTest(
               this.GetType().FullName,
               (azure) => ManageWebAppSourceControlAsync.Program.RunSampleAsync(azure)
                            .GetAwaiter()
                            .GetResult(),
               Path.Combine("..", "Common"));
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageWebAppSlotsTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageWebAppSlots.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageWebAppSqlConnectionTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageWebAppSqlConnection.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageWebAppStorageAccountConnectionTest()
        {
            RunSampleAsTest(
               this.GetType().FullName,
               ManageWebAppStorageAccountConnection.Program.RunSample,
               Path.Combine("..", "Common"));
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageWebAppWithDomainSslTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageWebAppWithDomainSsl.Program.RunSample,
                Path.Combine("..", "Common"));
        }

        [Fact(Skip = "TODO: Investigate and fix the failure in the product")]
        [Trait("Samples", "AppService")]
        public void ManageWebAppWithTrafficManagerTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageWebAppWithTrafficManager.Program.RunSample,
                Path.Combine("..", "Common"));
        }
    }
}
