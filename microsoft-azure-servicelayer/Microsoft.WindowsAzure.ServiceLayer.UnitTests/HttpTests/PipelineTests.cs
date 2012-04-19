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
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;
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
            Assert.Throws<ArgumentException>(() => new HttpRequest("", validUri));
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
            Assert.Throws<ArgumentOutOfRangeException>(() => new HttpResponse(validRequest, -5));
        }

        /// <summary>
        /// Tests passing invalid arguments into constructors of public HTTP
        /// handlers.
        /// </summary>
        [Fact]
        public void InvalidArgsInHandlers()
        {
            IHttpHandler validHandler = new HttpDefaultHandler();
            Assert.Throws<ArgumentNullException>(() => new WrapAuthenticationHandler(null, "user", "password", validHandler));
            Assert.Throws<ArgumentException>(() => new WrapAuthenticationHandler("", "user", "password", validHandler));
            Assert.Throws<ArgumentException>(() => new WrapAuthenticationHandler(" ", "user", "password", validHandler));
            Assert.Throws<ArgumentNullException>(() => new WrapAuthenticationHandler("namespace", null, "password", validHandler));
            Assert.Throws<ArgumentException>(() => new WrapAuthenticationHandler("namespace", "", "password", validHandler));
            Assert.Throws<ArgumentException>(() => new WrapAuthenticationHandler("namespace", " ", "password", validHandler));
            Assert.Throws<ArgumentNullException>(() => new WrapAuthenticationHandler("namespace", "user", null, validHandler));
            Assert.Throws<ArgumentNullException>(() => new WrapAuthenticationHandler("namespace", "user", "password", null));
        }

        /// <summary>
        /// Tests passing invalid argument into AssignHandler method.
        /// </summary>
        [Fact]
        public void InvalidArgsInAssignHandler()
        {
            Assert.Throws<ArgumentNullException>(() => Configuration.ServiceBus.AssignHandler(null));
        }

        /// <summary>
        /// Tests specifying pipeline handlers.
        /// </summary>
        [Fact]
        public void PipelineHandlers()
        {
            TestHttpHandler handler1 = new TestHttpHandler(Configuration.ServiceBus.HttpHandler);
            TestHttpHandler handler2 = new TestHttpHandler(handler1);
            ServiceBusClient serviceBus = Configuration.ServiceBus.AssignHandler(handler1);

            serviceBus.ListQueuesAsync().AsTask().Wait();
            Assert.Equal(handler1.BeforeCount, 1);
            Assert.Equal(handler1.AfterCount, 1);

            serviceBus = serviceBus.AssignHandler(handler2);
            serviceBus.ListQueuesAsync().AsTask().Wait();
            Assert.Equal(handler1.BeforeCount, 2);
            Assert.Equal(handler1.AfterCount, 2);

            Assert.Equal(handler2.BeforeCount, 1);
            Assert.Equal(handler2.AfterCount, 1);
        }
    }
}
