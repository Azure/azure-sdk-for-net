//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.Http;
using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.HttpTests
{
    /// <summary>
    /// HTTP pipeline tests.
    /// </summary>
    public class PipelineTests
    {
        /// <summary>
        /// Tests passing invalid arguments in the request's constructor.
        /// </summary>
        [Fact]
        public void InvalidArgsInRequestConstructor()
        {
            Uri validUri = new Uri("http://microsoft.com");
            Assert.Throws<ArgumentNullException>(() => new HttpRequest(null, validUri));
            Assert.Throws<ArgumentNullException>(() => new HttpRequest("PUT", null));
        }

        /// <summary>
        /// Tests passing invalid arguments in the response's constructor.
        /// </summary>
        [Fact]
        public void InvalidArgsInResponseConstructor()
        {
            HttpRequest validRequest = new HttpRequest("PUT", new Uri("http://microsoft.com"));
            Assert.Throws<ArgumentNullException>(() => new HttpResponse(null, 200));
        }
    }
}
