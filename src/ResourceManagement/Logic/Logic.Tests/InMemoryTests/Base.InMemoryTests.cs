//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Test.Azure.Management.Logic
{
    using System.Net.Http;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Rest;

    public class BaseInMemoryTests
    {
        protected StringContent Empty = new StringContent(string.Empty);

        protected ILogicManagementClient CreateLogicManagementClient(RecordedDelegatingHandler handler)
        {
            var client = new LogicManagementClient(new TokenCredentials("token"), handler);
            client.SubscriptionId = "66666666-6666-6666-6666-666666666666";

            return client;
        }
    }
}
