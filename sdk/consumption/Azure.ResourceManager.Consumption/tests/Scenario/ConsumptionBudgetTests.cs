// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Consumption.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Consumption.Tests
{
    internal class ConsumptionBudgetTests : ConsumptionManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ConsumptionBudgetCollection _consumptionBudgetCollection;

        public ConsumptionBudgetTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _consumptionBudgetCollection = Client.GetConsumptionBudgets(scope: _resourceGroup.Id);
        }

        private async Task<ConsumptionBudgetResource> CreateBudget(string budgetName)
        {
            var startOn = new DateTimeOffset(Recording.Now.Year, Recording.Now.Month, 1, 0, 0, 0, new TimeSpan(0, 0, 0));
            var data = new ConsumptionBudgetData()
            {
                Amount = 100,
                TimeGrain = BudgetTimeGrainType.Monthly,
                TimePeriod = new BudgetTimePeriod(startOn)
                {
                    EndOn = startOn.AddYears(1)
                },
                Category = BudgetCategory.Cost,
            };
            var budget = await _consumptionBudgetCollection.CreateOrUpdateAsync(WaitUntil.Completed, budgetName, data);
            return budget.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string budgetName = Recording.GenerateAssetName("budget");
            var budget = await CreateBudget(budgetName);
            ValidateConsumptionBudget(budget.Data, budgetName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string budgetName = Recording.GenerateAssetName("budget");
            await CreateBudget(budgetName);
            var flag = await _consumptionBudgetCollection.ExistsAsync(budgetName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string budgetName = Recording.GenerateAssetName("budget");
            await CreateBudget(budgetName);
            var budget = await _consumptionBudgetCollection.GetAsync(budgetName);
            ValidateConsumptionBudget(budget.Value.Data, budgetName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string budgetName = Recording.GenerateAssetName("budget");
            await CreateBudget(budgetName);
            var list = await _consumptionBudgetCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateConsumptionBudget(list.FirstOrDefault().Data, budgetName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string budgetName = Recording.GenerateAssetName("budget");
            var budget = await CreateBudget(budgetName);
            var flag = await _consumptionBudgetCollection.ExistsAsync(budgetName);
            Assert.IsTrue(flag);

            await budget.DeleteAsync(WaitUntil.Completed);
            flag = await _consumptionBudgetCollection.ExistsAsync(budgetName);
            Assert.IsFalse(flag);
        }

        private void ValidateConsumptionBudget(ConsumptionBudgetData budget, string budgetName)
        {
            Assert.IsNotNull(budget);
            Assert.IsNotEmpty(budget.Id);
            Assert.AreEqual(budgetName, budget.Name);
            Assert.AreEqual(100, budget.Amount);
            Assert.AreEqual(BudgetTimeGrainType.Monthly, budget.TimeGrain);
            Assert.AreEqual(BudgetCategory.Cost, budget.Category);
        }
    }
}
