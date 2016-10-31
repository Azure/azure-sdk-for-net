// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using Microsoft.AzureStack.AzureConsistentStorage.Models;
using Xunit;

namespace Microsoft.AzureStack.AzureConsistentStorage.Tests
{
    internal class EventQueryResultValidator
    {
        internal static void ValidateGetEventQueryResult(EventQuery eventQuery)
        {
            Assert.Equal("startTime eq 2015-05-10T18:02:00Z and endTime eq 2015-05-28T18:02:00Z", eventQuery.FilterUri);
            Assert.Equal("http://localhost", eventQuery.TableEndpoint);
            Assert.Equal(2, eventQuery.TableInfos.Count);
            Assert.Equal(new DateTime(2015, 5, 15, 18, 2, 0, DateTimeKind.Utc), eventQuery.TableInfos[0].StartTime);
            Assert.Equal(new DateTime(2015, 5, 25, 18, 2, 0, DateTimeKind.Utc), eventQuery.TableInfos[0].EndTime);
            Assert.Equal("WDEvent20150515", eventQuery.TableInfos[0].TableName);
            Assert.Equal("sv=2014-02-14&sr=b&st=2015-01-02T01%3A40%3A51Z&se=2015-01-02T02%3A00%3A51Z&sp=r",
                eventQuery.TableInfos[0].SasToken);
        }

    }
}
