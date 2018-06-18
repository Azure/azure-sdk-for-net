namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    public class ModelClosedListsTests : BaseTest
    {
        private const string versionId = "0.1";

        [Fact]
        public void ListClosedLists()
        {
            UseClientFor(async client =>
            {
                var listId = await client.Model.AddClosedListAsync(appId, versionId, GetClosedListSample());
                var result = await client.Model.ListClosedListsAsync(appId, versionId);
                await client.Model.DeleteClosedListAsync(appId, versionId, listId);

                Assert.NotEmpty(result);
            });
        }

        [Fact]
        public void AddClosedList()
        {
            UseClientFor(async client =>
            {
                var listId = await client.Model.AddClosedListAsync(appId, versionId, GetClosedListSample());
                await client.Model.DeleteClosedListAsync(appId, versionId, listId);

                Assert.True(listId != Guid.Empty);
            });
        }

        [Fact]
        public void GetClosedList()
        {
            UseClientFor(async client =>
            {
                var listId = await client.Model.AddClosedListAsync(appId, versionId, GetClosedListSample());
                var list = await client.Model.GetClosedListAsync(appId, versionId, listId);
                await client.Model.DeleteClosedListAsync(appId, versionId, listId);

                // Assert
                Assert.Equal("States", list.Name);
                Assert.Equal(3, list.SubLists.Count);
            });
        }

        [Fact]
        public void UpdateClosedList()
        {
            UseClientFor(async client =>
            {
                var listId = await client.Model.AddClosedListAsync(appId, versionId, GetClosedListSample());
                var update = new ClosedListModelUpdateObject()
                {
                    Name = "New States",
                    SubLists = new List<WordListObject>()
                    {
                       new WordListObject()
                       {
                           CanonicalForm = "Texas",
                           List = new List<string>() { "tx", "texas" }
                       }
                    }
                };

                await client.Model.UpdateClosedListAsync(appId, versionId, listId, update);
                var updated = await client.Model.GetClosedListAsync(appId, versionId, listId);

                await client.Model.DeleteClosedListAsync(appId, versionId, listId);

                Assert.Equal("New States", updated.Name);
                Assert.Equal(1, updated.SubLists.Count);
                Assert.Equal("Texas", updated.SubLists[0].CanonicalForm);
            });
        }

        [Fact]
        public void DeleteClosedList()
        {
            UseClientFor(async client =>
            {
                var listId = await client.Model.AddClosedListAsync(appId, versionId, GetClosedListSample());
                await client.Model.DeleteClosedListAsync(appId, versionId, listId);

                var lists = await client.Model.ListClosedListsAsync(appId, versionId);

                Assert.DoesNotContain(lists, o => o.Id == listId);
            });
        }

        [Fact]
        public void PatchClosedList()
        {
            UseClientFor(async client =>
            {
                var listId = await client.Model.AddClosedListAsync(appId, versionId, GetClosedListSample());

                await client.Model.PatchClosedListAsync(appId, versionId, listId, new ClosedListModelPatchObject
                {
                    SubLists = new List<WordListObject>()
                    {
                        new WordListObject()
                        {
                            CanonicalForm = "Texas",
                            List = new List<string>() { "tx", "texas" }
                        },
                        new WordListObject()
                        {
                            CanonicalForm = "Florida",
                            List = new List<string>() { "fl", "florida" }
                        }
                    }
                });

                var list = await client.Model.GetClosedListAsync(appId, versionId, listId);
                await client.Model.DeleteClosedListAsync(appId, versionId, listId);

                Assert.Equal(5, list.SubLists.Count);
                Assert.Contains(list.SubLists, o => o.CanonicalForm == "Texas" && o.List.Contains("tx") && o.List.Contains("texas"));
                Assert.Contains(list.SubLists, o => o.CanonicalForm == "Florida" && o.List.Contains("fl") && o.List.Contains("florida"));
            });
        }

        [Fact]
        public void AddSubList()
        {
            UseClientFor(async client =>
            {
                var listId = await client.Model.AddClosedListAsync(appId, versionId, GetClosedListSample());

                var sublistId = await client.Model.AddSubListAsync(appId, versionId, listId, new WordListObject()
                {
                    CanonicalForm = "Texas",
                    List = new List<string>() { "tx", "texas" }
                });

                var list = await client.Model.GetClosedListAsync(appId, versionId, listId);
                await client.Model.DeleteClosedListAsync(appId, versionId, listId);

                Assert.Equal(4, list.SubLists.Count);
                Assert.Contains(list.SubLists, o => o.CanonicalForm == "Texas" && o.List.Contains("tx") && o.List.Contains("texas"));
            });
        }

        [Fact]
        public void DeleteSubList()
        {
            UseClientFor(async client =>
            {
                var listId = await client.Model.AddClosedListAsync(appId, versionId, GetClosedListSample());
                var sublistId = (await client.Model.GetClosedListAsync(appId, versionId, listId)).SubLists.Single(o => o.CanonicalForm == "New York").Id;

                await client.Model.DeleteSubListAsync(appId, versionId, listId, sublistId);

                var list = await client.Model.GetClosedListAsync(appId, versionId, listId);
                await client.Model.DeleteClosedListAsync(appId, versionId, listId);

                Assert.Equal(2, list.SubLists.Count);
                Assert.DoesNotContain(list.SubLists, o => o.CanonicalForm == "New York");
            });
        }

        [Fact]
        public void UpdateSubList()
        {
            UseClientFor(async client =>
            {
                var listId = await client.Model.AddClosedListAsync(appId, versionId, GetClosedListSample());
                var sublistId = (await client.Model.GetClosedListAsync(appId, versionId, listId)).SubLists.Single(o => o.CanonicalForm == "New York").Id;

                await client.Model.UpdateSubListAsync(appId, versionId, listId, sublistId, new WordListBaseUpdateObject()
                {
                    CanonicalForm = "New Yorkers",
                    List = new List<string>() { "NYC", "NY", "New York" },
                });

                var list = await client.Model.GetClosedListAsync(appId, versionId, listId);
                await client.Model.DeleteClosedListAsync(appId, versionId, listId);

                Assert.Equal(3, list.SubLists.Count);
                Assert.DoesNotContain(list.SubLists, o => o.CanonicalForm == "New York");
                Assert.Contains(list.SubLists, o => o.CanonicalForm == "New Yorkers" && o.List.Contains("NYC") && o.List.Contains("NY") && o.List.Contains("New York"));
            });
        }

        private static ClosedListModelCreateObject GetClosedListSample()
        {
            ////    {
            ////    	"name": "States",
            ////    	"sublists": 
            ////    	[
            ////    		{
            ////    			"canonicalForm": "New York",
            ////    			"list": [ "ny", "new york" ]
            ////    		},
            ////    		{
            ////    			"canonicalForm": "Washington",
            ////    			"list": [ "wa", "washington" ]
            ////    		},
            ////    		{
            ////    			"canonicalForm": "California",
            ////    			"list": [ "ca", "california", "calif.", "cal." ]
            ////    		}
            ////    	]
            ////    }

            return new ClosedListModelCreateObject
            {
                Name = "States",
                SubLists = new List<WordListObject>()
                {
                    new WordListObject(
                        "New York",
                        new List<string>() { "NY", "New York" }),

                    new WordListObject(
                        "Washington",
                        new List<string>() { "WA", "Washington" }),

                    new WordListObject(
                        "California",
                        new List<string>() { "CA", "California", "Calif.", "Cal." })
                }
            };
        }
    }
}
