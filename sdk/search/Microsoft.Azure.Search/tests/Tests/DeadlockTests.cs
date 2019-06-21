// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Linq;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Xunit;

    // Tests that the customized methods of the data plane SDK aren't missing any ConfigureAwait(false) calls.
    //
    // NOTE: Due to the way the Test Framwork works, these tests can't fail in Playback mode. They are here
    // mostly for regression coverage when adding new custom methods to the SDK or changing existing methods, where
    // it would be necessary to run these tests in Record mode anyway.
    public sealed class DeadlockTests : SearchTestBase<DocumentsFixture>
    {
        [Fact]
        public void AutocompleteWillNotDeadlock()
        {
            Run(() =>
            {
                void TestAutocomplete(bool useHttpGet)
                {
                    SearchIndexClient client = Data.GetSearchIndexClientForQuery(useHttpGet: useHttpGet);
                    SearchAssert.DoesNotUseSynchronizationContext(() => client.Documents.Autocomplete("mo", "sg"));
                }

                TestAutocomplete(true);
                TestAutocomplete(false);
            });
        }

        [Fact]
        public void ContinueSearchWillNotDeadlock()
        {
            Run(() =>
            {
                void TestContinueSearch(bool useHttpGet)
                {
                    SearchIndexClient client = Data.GetSearchIndexClient(useHttpGet: useHttpGet);
                    Data.IndexDocuments(client, 2001);

                    var searchParameters = new SearchParameters() { Top = 3000 };
                    DocumentSearchResult<Document> response = client.Documents.Search("*", searchParameters);

                    SearchAssert.DoesNotUseSynchronizationContext(() => client.Documents.ContinueSearch(response.ContinuationToken));
                }

                TestContinueSearch(true);
                TestContinueSearch(false);
            });
        }

        [Fact]
        public void CountWillNotDeadlock()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();
                SearchAssert.DoesNotUseSynchronizationContext(() => client.Documents.Count());
            });
        }

        [Fact]
        public void GetWillNotDeadlock()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();
                var batch = IndexBatch.Upload(new[] { new Hotel() { HotelId = "1" } });

                client.Documents.Index(batch);

                SearchAssert.DoesNotUseSynchronizationContext(() => client.Documents.Get("1"));
            });
        }

        [Fact]
        public void IndexingWillNotDeadlock()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();
                var batch = IndexBatch.Upload(new[] { new Hotel() { HotelId = "12" } });

                SearchAssert.DoesNotUseSynchronizationContext(() => client.Documents.Index(batch));
            });
        }

        [Fact]
        public void SearchWillNotDeadlock()
        {
            Run(() =>
            {
                void TestSearch(bool useHttpGet)
                {
                    SearchIndexClient client = Data.GetSearchIndexClientForQuery(useHttpGet: useHttpGet);
                    SearchAssert.DoesNotUseSynchronizationContext(() => client.Documents.Search("*"));
                }

                TestSearch(true);
                TestSearch(false);
            });
        }

        [Fact]
        public void SuggestWillNotDeadlock()
        {
            Run(() =>
            {
                void TestSuggest(bool useHttpGet)
                {
                    SearchIndexClient client = Data.GetSearchIndexClientForQuery(useHttpGet: useHttpGet);
                    SearchAssert.DoesNotUseSynchronizationContext(() => client.Documents.Suggest("best", "sg"));
                }

                TestSuggest(true);
                TestSuggest(false);
            });
        }
    }
}
