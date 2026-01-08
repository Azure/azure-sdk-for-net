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
        private string _budgetName;
        private ConsumptionBudgetResource _budget;

        public ConsumptionBudgetTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _consumptionBudgetCollection = Client.GetConsumptionBudgets(scope: _resourceGroup.Id);
            _budgetName = Recording.GenerateAssetName("budget");
            _budget = await CreateBudget(_budgetName);
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
        public void CreateOrUpdate()
        {
            ValidateConsumptionBudget(_budget.Data);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _consumptionBudgetCollection.ExistsAsync(_budgetName);
            Assert.That((bool)flag, Is.True);
        }

        [RecordedTest]
        public async Task Get()
        {
            var budget = await _consumptionBudgetCollection.GetAsync(_budgetName);
            ValidateConsumptionBudget(budget.Value.Data);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _consumptionBudgetCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            ValidateConsumptionBudget(list.FirstOrDefault().Data);
        }

        [RecordedTest]
        public async Task Delete()
        {
            var flag = await _consumptionBudgetCollection.ExistsAsync(_budgetName);
            Assert.That((bool)flag, Is.True);

            await _budget.DeleteAsync(WaitUntil.Completed);
            flag = await _consumptionBudgetCollection.ExistsAsync(_budgetName);
            Assert.That((bool)flag, Is.False);
        }

        private void ValidateConsumptionBudget(ConsumptionBudgetData budget)
        {
            Assert.Multiple(() =>
            {
                Assert.That(budget, Is.Not.Null);
                Assert.That((string)budget.Id, Is.Not.Empty);
            });
            Assert.That(budget.Name, Is.EqualTo(_budgetName));
            Assert.That(budget.Amount, Is.EqualTo(100));
            Assert.That(budget.TimeGrain, Is.EqualTo(BudgetTimeGrainType.Monthly));
            Assert.That(budget.Category, Is.EqualTo(BudgetCategory.Cost));
        }
    }
}
