// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using Microsoft.Azure.Search.Tests.Utilities;

namespace Microsoft.Azure.Search.Tests
{
    public abstract class QueryTests : SearchTestBase<DocumentsFixture>
    {
        protected virtual SearchIndexClient GetClient()
        {
            return Data.GetSearchIndexClient();
        }

        protected virtual SearchIndexClient GetClientForQuery()
        {
            return Data.GetSearchIndexClientForQuery();
        }
    }
}
