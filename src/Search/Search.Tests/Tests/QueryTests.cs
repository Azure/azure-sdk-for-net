// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Microsoft.Azure.Search.Tests.Utilities;

    public abstract class QueryTests : SearchTestBase<DocumentsFixture>
    {
        protected virtual SearchIndexClient GetClient()
        {
            return this.Data.GetSearchIndexClient();
        }

        protected virtual SearchIndexClient GetClientForQuery()
        {
            return this.Data.GetSearchIndexClientForQuery();
        }
    }
}
