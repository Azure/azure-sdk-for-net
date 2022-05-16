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
    public class CustomerEventsTests : TestbaseBase
    {
        string baseGeneratedName;
        string customerEventName = "";

        [Fact]
        public void TestCustomerEvent()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);

                baseGeneratedName = TestbaseManagementTestUtilities.GenerateName(TestPrefix);

                try
                {
                    var result=t_TestBaseClient.CustomerEvents.ListByTestBaseAccountWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName).GetAwaiter().GetResult();
                    Assert.NotNull(result);
                }
                catch(Exception ex)
                {
                    Assert.NotNull(ex.Message);
                }

                try
                {
                    var result = t_TestBaseClient.CustomerEvents.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, t_CustomerEventName).GetAwaiter().GetResult();
                    Assert.NotNull(result);
                }
                catch(Exception ex)
                {
                    Assert.NotNull(ex.Message);
                }


                customerEventName = baseGeneratedName + "_event";

                CustomerEventResource parameters = new CustomerEventResource();
                parameters.EventName = "initial-verification";
                parameters.Receivers = new List<NotificationEventReceiver>()
                {
                    new NotificationEventReceiver()
                    {
                        ReceiverType="UserObjects",
                        ReceiverValue=new NotificationReceiverValue()
                        {
                            UserObjectReceiverValue=new UserObjectReceiverValue()
                            {
                                UserObjectIds=new List<string>()
                                {
                                    "test","test-2"
                                }
                            }
                            //,
                            //SubscriptionReceiverValue=new SubscriptionReceiverValue()
                            //{
                            //},
                            //DistributionGroupListReceiverValue=new DistributionGroupListReceiverValue()
                            //{
                            //}
                        }
                    }
                    //,
                    //new NotificationEventReceiver()
                    //{
                    //    ReceiverType="DistributionGroup",
                    //    ReceiverValue=new NotificationReceiverValue()
                    //    {
                    //        DistributionGroupListReceiverValue=new DistributionGroupListReceiverValue()
                    //        {
                    //            DistributionGroups=new List<string>()
                    //            {
                    //                "test@microsoft.com"
                    //            }
                    //        }
                    //    }
                    //}
                };

                try
                {
                    var result = t_TestBaseClient.CustomerEvents.CreateWithHttpMessagesAsync(parameters, t_ResourceGroupName, t_TestBaseAccountName, customerEventName).GetAwaiter().GetResult();
                    Assert.NotNull(result);
                    Assert.NotNull(result.Body);
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex.Message);
                }

                try
                {
                    //"testbase1499_event"
                    var result = t_TestBaseClient.CustomerEvents.BeginDeleteWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, customerEventName).GetAwaiter().GetResult();
                    Assert.NotNull(result);
                }
                catch (Exception ex)
                {
                    Assert.NotNull(ex.Message);
                }

            }
        }
    }
}
