// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.Management.AzureStack.Tests
{
    using Microsoft.Azure.Management.AzureStack;
    using Microsoft.Azure.Management.AzureStack.Models;
    using Xunit;

    public class RegistrationTests : AzureStackTestBase
    {
        private const string TestLocation = "global";
        private const string TestResourceGroupName = "AzsGroup";
        private const string TestRegistrationName = "TestRegistration";
        private const string TestRegistrationToken = @"eyJjbG91ZElkIjoiY2xvdWQxIiwib2JqZWN0SWQiOiJjZmNhZWYxNS1iYjI3LTRiNmUtOTc1Mi1jMzMyNTMyYTg4MDIiLCJiaWxsaW5nTW9kZWwiOiJEZXZlbG9wbWVudCIsImhhcmR3YXJlSW5mbyI6W3sibmFtZSI6ImJmYmQ4MmE5NzQ2YTQ3MGNhNTc4NGQ0ODJmNzE1MDRiIiwidXVpZCI6IjU3MDBmZWExLWRkNWMtNGI0Yy05YjRhLWRkZjY0MzY3OWIxYSIsIm51bUNvcmVzIjotMTE5MTgyMjEyMywiYmlvcyI6WyJjZWUwMzhhMDAyNWE0MmJlYjQ3NjM3M2ZjMzM0ZjU4NyIsIjBlOTRlYTk5NzQ4NTRjYTI5N2Q0NGJmNWI4NGEwN2Q3Il0sIm5pYyI6WyIxNGIzNDdlYjUwNjU0ZDM1YTdkYTY2Y2YxMTI1YjExMiIsIjU1YjM4ZTMwMmU0NDQzY2RhZjA4NWFkZWU3MjU0YTQ2Il0sImNwdSI6WyJhMjhlZTM3ZmUxMTU0ZmZkOTQ1YWNkZjI2YmYzM2ZmNyIsImFhYTE4ODU2MzlmMjQ3NjdhZTg4NWI4OTVmODUzYmExIl0sImRpc2siOlsiYWRiOTFhM2Q1ZTg2NDQyNGI1ZWViNWJjM2FkOTY0MjEiLCJkODUzNDBiNWYzMTI0ZDEzYjQwMGJkMWZhYWU0MTA2YSJdLCJtZW1vcnkiOlsiZDIyYzdmODJhMGM5NGMwNGI2ODdlMjgzZDRiNmVmMTIiLCJlOTFjNTExODgzN2I0ZTM2OTY2ODQyMzdlY2ViMjk0ZiJdfV0sInJlZ2lvbk5hbWVzIjpbInVzd2VzdCIsInVzZWFzdCJdLCJhZ3JlZW1lbnROdW1iZXIiOiJhZ3JlZW1lbnQxIiwidXNhZ2VSZXBvcnRpbmdFbmFibGVkIjp0cnVlLCJtYXJrZXRwbGFjZVN5bmRpY2F0aW9uRW5hYmxlZCI6dHJ1ZSwiaXNzdWVyIjoiaXNzdWVyMSIsInZlcnNpb24iOiIxLjAifQ==";

        private void ValidateRegistration(Registration subscription)
        {
            Assert.NotNull(subscription);
            Assert.NotEmpty(subscription.Id);
            Assert.NotEmpty(subscription.ObjectId);
            Assert.NotEmpty(subscription.CloudId);
            Assert.NotEmpty(subscription.BillingModel);
        }

        private void AssertSame(Registration expected, Registration given)
        {
            Assert.Equal(expected.Id, given.Id);
            Assert.Equal(expected.ObjectId, given.ObjectId);
            Assert.Equal(expected.CloudId, given.CloudId);
            Assert.Equal(expected.BillingModel, given.BillingModel);
        }

        [Fact]
        public void TestListRegistrations()
        {
            RunTest((client) =>
            {
                var registrations = client.Registrations.List(TestResourceGroupName);

                foreach (var registration in registrations)
                {
                    ValidateRegistration(registration);
                }
            });
        }

        [Fact]
        public void TestGetRegistration()
        {
            RunTest((client) =>
            {
                var registrations = client.Registrations.List(TestResourceGroupName);
                foreach (var registration in registrations)
                {
                    var registrationResult = client.Registrations.Get(TestResourceGroupName, registration.Name);
                    ValidateRegistration(registrationResult);
                    AssertSame(registration, registrationResult);
                }
            });
        }

        [Fact]
        public void TestGetActivationKey()
        {
            RunTest((client) =>
            {
                var registrations = client.Registrations.List(TestResourceGroupName);
                foreach (var registration in registrations)
                {
                    var keyResult = client.Registrations.GetActivationKey(TestResourceGroupName, registration.Name);
                    Assert.NotEmpty(keyResult.ActivationKey);
                }
            });
        }

        [Fact]
        public void TestCreateUpdateAndDeleteRegistration()
        {
            RunTest((client) =>
            {
                RegistrationParameter testParameter = new RegistrationParameter(TestRegistrationToken, TestLocation);
                var createdRegistration = client.Registrations.CreateOrUpdate(TestResourceGroupName, TestRegistrationName, testParameter);
                ValidateRegistration(createdRegistration);

                var updatedRegistration = client.Registrations.Update(TestResourceGroupName, TestRegistrationName, testParameter);
                AssertSame(createdRegistration, updatedRegistration);

                client.Registrations.Delete(TestResourceGroupName, TestRegistrationName);
                client.Registrations.Delete(TestResourceGroupName, TestRegistrationName);

                var expectedException = Assert.Throws<ErrorResponseException>(() => client.Registrations.Get(TestResourceGroupName, TestRegistrationName));
                Assert.Equal("ResourceNotFound", expectedException.Body.Error.Code);
            });
        }
    }
}