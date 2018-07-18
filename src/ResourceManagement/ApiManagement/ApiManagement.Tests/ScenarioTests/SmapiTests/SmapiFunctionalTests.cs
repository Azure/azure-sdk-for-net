//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.SmapiTests
{
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests : TestBase, IUseFixture<SmapiTestsFixture>
    {
        private SmapiTestsFixture _smapiTestsFixture;

        private ApiManagementClient _apiManagementClient;

        public string Location
        {
            get { return _smapiTestsFixture.Location; }
        }

        public string ResourceGroupName
        {
            get { return _smapiTestsFixture.ResourceGroupName; }
        }

        public string ApiManagementServiceName
        {
            get { return _smapiTestsFixture.ApiManagementServiceName; }
        }

        public ApiManagementClient ApiManagementClient
        {
            get { return _apiManagementClient ?? (_apiManagementClient = _smapiTestsFixture.ApiManagementClient); }
        }

        public void SetFixture(SmapiTestsFixture testsFixture)
        {
            _smapiTestsFixture = testsFixture;
        }
    }
}