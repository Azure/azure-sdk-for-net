// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Xunit;
    using Xunit.Abstractions;

    public class ConcurrentChangeTrackedListUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public ConcurrentChangeTrackedListUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void Bug1910530_ConcurrentChangeTrackedListThreadsafeTest()
        {
            const string testName = "Bug1910530_ConcurrentChangeTrackedListThreadsafeTest";

            using(BatchClient batchCli = ClientUnitTestCommon.CreateDummyClient())
            {
                JobScheduleOperations jobScheduleOperations = batchCli.JobScheduleOperations;
                
                string jobScheduleId = Microsoft.Azure.Batch.Constants.DefaultConveniencePrefix + "-" + testName;

                //
                //Unbound job schedule properties
                //
                this.testOutputHelper.WriteLine("Creating job schedule {0}", jobScheduleId);
                CloudJobSchedule unboundJobSchedule = jobScheduleOperations.CreateJobSchedule(jobScheduleId, null, null);

                //Create a new threadsafe collection
                unboundJobSchedule.Metadata = new List<MetadataItem>();

                //Now it should be magically threadsafe
                Action addAction = () =>
                {
                    this.testOutputHelper.WriteLine("Adding an item");
                    unboundJobSchedule.Metadata.Add(new MetadataItem("test", "test"));
                };

                Action removeAction = () =>
                {
                    this.testOutputHelper.WriteLine("Removing an item");
                    try
                    {
                        unboundJobSchedule.Metadata.RemoveAt(0);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                };

                Random rand = new Random();
                object randLock = new object();

                Parallel.For(0, 100, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, (i) =>
                {
                    int randomInt;
                    lock (randLock)
                    {
                        randomInt = rand.Next(0, 2);
                    }

                    if (randomInt == 0)
                    {
                        addAction();
                    }
                    else
                    {
                        removeAction();
                    }
                });
            }
            
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ConcurrentChangeTrackedListBasicListFunctionality()
        {
            const string item1 = "test";
            const string item2 = "test2";

            ConcurrentChangeTrackedList<string> list = new ConcurrentChangeTrackedList<string>();
            Assert.Equal(0, list.Count);
            Assert.False(list.HasBeenModified);

            list.Add(item1);
            Assert.Equal(1, list.Count);
            
            list.Add(item2);
            Assert.Equal(2, list.Count);

            Assert.Contains(item1, list);
            Assert.Equal(0, list.IndexOf(item1));
            Assert.True(list.HasBeenModified);

            list.Remove(item1);
            Assert.Equal(1, list.Count);

            list.Clear();
            Assert.Equal(0, list.Count);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ConcurrentChangeTrackedSimpleTypeListReadOnly()
        {
            const string item1 = "Foo";
            var list = new ConcurrentChangeTrackedList<string>();

            list.IsReadOnly = true;
            Assert.Throws<InvalidOperationException>(() => list.Add(item1));
            Assert.False(list.HasBeenModified);
        }


        private class DummyComplexType : IPropertyMetadata
        {
            public bool HasBeenModified { get; set; }
            public bool IsReadOnly { get; set; }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ConcurrentChangeTrackedComplexTypeListReadOnly()
        {
            var list = new ConcurrentChangeTrackedModifiableList<DummyComplexType>(new List<DummyComplexType> { new DummyComplexType() });

            list.IsReadOnly = true;
            Assert.Throws<InvalidOperationException>(() => list.Add(new DummyComplexType()));
            Assert.False(list.HasBeenModified);
            Assert.True(list.First().IsReadOnly);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ConcurrentChangeTrackedComplexTypeListReadOnlyWithNull()
        {
            var list = new ConcurrentChangeTrackedModifiableList<DummyComplexType>(new List<DummyComplexType> { null });

            list.IsReadOnly = true;
            Assert.Throws<InvalidOperationException>(() => list.Add(new DummyComplexType()));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ConcurrentChangeTrackedComplexTypeListHasBeenModifiedWithNull()
        {
            var list = new ConcurrentChangeTrackedModifiableList<DummyComplexType>(new List<DummyComplexType> { null });

            list.Add(null);
            Assert.True(list.HasBeenModified);
        }
        
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ModifiableItemChangedUpdatesList()
        {
            var list = new ConcurrentChangeTrackedModifiableList<DummyComplexType>(
                new List<DummyComplexType> { new DummyComplexType() });
            Assert.Equal(1, list.Count);
            Assert.False(list.HasBeenModified);

            list.First().HasBeenModified = true;
            Assert.True(list.HasBeenModified);
        }
    }
}
