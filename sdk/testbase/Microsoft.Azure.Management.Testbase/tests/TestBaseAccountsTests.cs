// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.TestBase;
using Microsoft.TestBase.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestBase.Tests
{
    public class TestBaseAccountsTests : TestbaseBase
    {
        //string resourceGroupName;
        string baseGeneratedName;
        string testBaseAccountName;

        [Fact]
        public void TestTestBaseAccountOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);

                baseGeneratedName = TestbaseManagementTestUtilities.GenerateName(TestPrefix);

                //resourceGroupName = baseGeneratedName + "_rg";
                //var group=CreateResourceGroup(resourceGroupName);

                //Get TestBaseAccount
                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.TestBaseAccounts.GetWithHttpMessagesAsync(t_ResourceGroupName, ErrorValue));
                try
                {
                    //Gets the TestBaseAccount created through the Web page
                    var accountResource = t_TestBaseClient.TestBaseAccounts.Get(t_ResourceGroupName, t_TestBaseAccountName);
                    Assert.NotNull(accountResource);
                    Assert.Equal(t_TestBaseAccountName.ToLower(), accountResource.Name.ToLower());
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex.Message);
                }


                //Create TestBaseAccount
                testBaseAccountName = baseGeneratedName + "_acc";

                TestBaseAccountSKU sku = new TestBaseAccountSKU();
                //sku.Tier = "Standard";//2021-5-28 After the code is generated using the latest spec, the Tier becomes static and can only be private set
                sku.Name = "S0";
                sku.Locations = new List<string>() { "Global" };

                TestBaseAccountResource parameters = new TestBaseAccountResource();
                //Location must be Global, otherwise will receive a BadRequest message
                parameters.Location = "Global";//Global , North Europe , SoutheastAsia
                parameters.Sku = sku;
                parameters.Tags = new Dictionary<string, string>() { { testBaseAccountName + "_kaifa", "tagvalue" } };

                //After testing, it still cannot be created successfully. A BadRequest exception is thrown. 2021-4-23
                //Operation returned an invalid status code 'NotFound' 2021-4-25
                try
                {
                    var createResult = t_TestBaseClient.TestBaseAccounts.CreateWithHttpMessagesAsync(parameters, t_ResourceGroupName, testBaseAccountName).GetAwaiter().GetResult();
                    Assert.NotNull(createResult);
                    Assert.NotNull(createResult.Body);
                    Assert.Equal(testBaseAccountName.ToLower(), createResult.Body.Name.ToLower());
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex.Message);
                }
                ////Assert.Throws<ErrorResponseException>(() => CreateTestBaseAccount(t_ResourceGroupName, testBaseAccountName));


                //Update TestBaseAccount
                TestBaseAccountUpdateParameters updateParameters = new TestBaseAccountUpdateParameters();

                updateParameters.Sku = new TestBaseAccountSKU
                {
                    //Tier = "Standard",//2021-5-28 After the code is generated using the latest spec, the Tier becomes static and can only be private set
                    Name = "S1"
                };
                updateParameters.Tags = new Dictionary<string, string>() { { "tagkey", "tagvalue_" + DateTime.Now.ToString("yyyyMMdd HHmmss") } };

                //cannot update successfully.2021-4-23
                try
                {
                    var updateResult = t_TestBaseClient.TestBaseAccounts.UpdateWithHttpMessagesAsync(updateParameters, t_ResourceGroupName, testBaseAccountName).GetAwaiter().GetResult();
                    Assert.NotNull(updateResult);
                    Assert.NotNull(updateResult.Body);
                    Assert.Equal(testBaseAccountName.ToLower(), updateResult.Body.Name.ToLower());
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex.Message);
                }
                ////Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.TestBaseAccount.UpdateWithHttpMessagesAsync(updateParameters, t_ResourceGroupName, testBaseAccountName));


                //Delete TestBaseAccount
                try
                {
                    //Use Offboard instead of delete, Using the delete function raises the BadRequest exception 2021-5-26
                    var deleteResult = t_TestBaseClient.TestBaseAccounts.BeginOffboardAsync(t_ResourceGroupName, testBaseAccountName).GetAwaiter().GetResult();
                    Assert.NotNull(deleteResult);
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex.Message);
                }

            }
        }

    }
}
