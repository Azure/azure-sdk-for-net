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

        [Fact(Skip = "Manual Only test: cannot be run in automation because it needs user input.")]
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

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageWebAppWithTrafficManagerTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageWebAppWithTrafficManager.Program.RunSample,
                Path.Combine("..", "Common"));
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageLinuxWebAppBasicTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageLinuxWebAppBasic.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageLinuxWebAppSourceControlTest()
        {
            RunSampleAsTest(
               this.GetType().FullName,
               ManageLinuxWebAppSourceControl.Program.RunSample,
               Path.Combine("..", "Common"));
        }

        [Fact(Skip ="Manual only test: Requires user interaction.")]
        [Trait("Samples", "AppService")]
        public void ManageLinuxWebAppSqlConnectionTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageLinuxWebAppSqlConnection.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageLinuxWebAppStorageAccountConnectionTest()
        {
            RunSampleAsTest(
               this.GetType().FullName,
               ManageLinuxWebAppStorageAccountConnection.Program.RunSample,
               Path.Combine("..", "Common"));
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageLinuxWebAppWithDomainSslTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageLinuxWebAppWithDomainSsl.Program.RunSample,
                Path.Combine("..", "Common"));
        }
        
        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageLinuxWebAppWithTrafficManagerTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageLinuxWebAppWithTrafficManager.Program.RunSample,
                Path.Combine("..", "Common"));
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageFunctionAppBasicTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageFunctionAppBasic.Program.RunSample);
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageFunctionAppSourceControlTest()
        {
            RunSampleAsTest(
               this.GetType().FullName,
               ManageFunctionAppSourceControl.Program.RunSample,
               Path.Combine("..", "Common"));
        }

        [Fact(Skip = "Need to call function app api to get function key")]
        [Trait("Samples", "AppService")]
        public void ManageFunctionAppWithAuthenticationTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageFunctionAppWithAuthentication.Program.RunSample,
                Path.Combine("..", "Common"));
        }

        [Fact]
        [Trait("Samples", "AppService")]
        public void ManageFunctionAppWithDomainSslTest()
        {
            RunSampleAsTest(
                this.GetType().FullName,
                ManageFunctionAppWithDomainSsl.Program.RunSample,
                Path.Combine("..", "Common"));
        }
    }
}
