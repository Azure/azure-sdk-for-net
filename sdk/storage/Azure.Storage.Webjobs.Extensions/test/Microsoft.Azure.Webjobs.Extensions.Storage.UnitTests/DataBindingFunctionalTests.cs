// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Bindings.Data
{
    public class DataBindingFunctionalTests
    {
        [Fact]
        public async Task BindStringableParameter_CanInvoke()
        {
            // Arrange
            var builder = new HostBuilder()
                .ConfigureDefaultTestHost<TestFunctions>(b =>
                {
                    b.UseFakeStorage();
                });
                

            var host = builder.Build().GetJobHost<TestFunctions>();

            MethodInfo method = typeof(TestFunctions).GetMethod("BindStringableParameter");
            Assert.NotNull(method); // Guard
            Guid guid = Guid.NewGuid();
            string expectedGuidValue = guid.ToString("D");
            string message = JsonConvert.SerializeObject(new MessageWithStringableProperty { GuidValue = guid });

            try
            {
                // Act
                await host.CallAsync(method, new { message = message });

                // Assert
                Assert.Equal(expectedGuidValue, TestFunctions.Result);
            }
            finally
            {
                TestFunctions.Result = null;
            }
        }             

        private class MessageWithStringableProperty
        {
            public Guid GuidValue { get; set; }
        }

        private class TestFunctions
        {
            public static string Result { get; set; }

            public static void BindStringableParameter([QueueTrigger("ignore")] MessageWithStringableProperty message,
                string guidValue)
            {
                Result = guidValue;
            }
        }
    }
}
