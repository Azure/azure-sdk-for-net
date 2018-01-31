// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Consumption.Tests.Helpers;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.Azure.OData;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Consumption.Tests.ScenarioTests
{
    public class BudgetTests : TestBase
    {
        protected const int NumberOfItems = 10;
        protected const string subscriptionId = "1caaa5a3-2b66-438e-8ab4-bce37d518c5d";
        protected const string billingPeriodName = "201710";
        protected const string budgetName = "NETSDKTestBudget";

        [Fact]
        public void BudgetCreateOrUpdateTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                consumptionMgmtClient.SubscriptionId = subscriptionId;
                consumptionMgmtClient.BudgetName = budgetName;

                var timePeriod = new BudgetTimePeriod
                {
                    StartDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1),
                    EndDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month + 10, 1),
                };
                var budget = new Budget("Cost", 60, "Monthly", timePeriod) { ETag = "\"1d39ae594114419\"" };

                var budgetResponse = consumptionMgmtClient.Budgets.CreateOrUpdate(budget);

                ValidateProperties(budgetResponse);

                Assert.Equal(budget.Amount, budgetResponse.Amount);
                Assert.Equal(budget.Category, budgetResponse.Category);
                Assert.Equal(budget.TimeGrain, budgetResponse.TimeGrain);
                Assert.Equal(budget.TimePeriod.StartDate, budgetResponse.TimePeriod.StartDate);
                Assert.Equal(budget.TimePeriod.EndDate, budgetResponse.TimePeriod.EndDate);
            }
        }

        [Fact]
        public void BudgetDeleteTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                consumptionMgmtClient.SubscriptionId = subscriptionId;
                consumptionMgmtClient.BudgetName = "SDKTestBudget";

                consumptionMgmtClient.Budgets.Delete();
            }
        }

        [Fact]
        public void BudgetGetTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                consumptionMgmtClient.SubscriptionId = subscriptionId;
                consumptionMgmtClient.BudgetName = budgetName;

                var budget = consumptionMgmtClient.Budgets.Get();

                ValidateProperties(budget, true);
            }
        }

        [Fact]
        public void BudgetListTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                consumptionMgmtClient.SubscriptionId = subscriptionId;

                var budgets = consumptionMgmtClient.Budgets.List();

                Assert.NotNull(budgets);
                Assert.True(budgets.Any());
                foreach (var b in budgets)
                {
                    ValidateProperties(b, true);
                }
            }
        }

        private static void ValidateProperties(Budget item, bool validateCurrentSpend = false)
        {
            Assert.NotNull(item);
            Assert.NotNull(item.Id);
            Assert.NotNull(item.Name);
            Assert.NotNull(item.Type);
            Assert.NotNull(item.Category);
            Assert.NotNull(item.ETag);
            Assert.NotNull(item.TimeGrain);
            Assert.NotNull(item.TimePeriod);
            if (validateCurrentSpend)
            {
                Assert.NotNull(item.CurrentSpend);
            }
        }
    }
}
