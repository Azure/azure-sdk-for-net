// -----------------------------------------------------------------------------------------
// <copyright file="SampleTest.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage
{
    [TestClass]
    public class SampleTest : BlobTestBase
    {
        private CloudBlobContainer testContainer;

        [TestInitialize]
        public async Task TestInitialize()
        {
            this.testContainer = GetRandomContainerReference();
            await this.testContainer.CreateAsync();
        }

        [TestMethod]
        public async Task SampleFetchTest()
        {
            await this.testContainer.FetchAttributesAsync();
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            await this.testContainer.DeleteIfExistsAsync();
        }
    }
}
