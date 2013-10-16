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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.WebSites;

namespace Microsoft.WindowsAzure.Testing
{
    [TestClass]
    public class BasicTests : WebSiteTestBase
    {
        [TestMethod]
        public void WebSites_ParseException()
        {
            using (var client = GetWebSiteManagementClient())
            {
                try
                {
                    client.WebSpaces.Get("doesnotexist");
                    Assert.Fail("Expected exception.");
                }
                catch (WebSiteCloudException ex)
                {
                    Assert.AreEqual("NotFound", ex.ErrorCode);
                    Assert.AreEqual("Cannot find WebSpace with name doesnotexist.", ex.ErrorMessage);
                    Assert.AreEqual("51004", ex.ExtendedErrorCode);
                    Assert.AreEqual("Cannot find {0} with name {1}.", ex.ErrorMessageFormat);
                    Assert.AreEqual(2, ex.ErrorMessageArguments.Count);
                    Assert.AreEqual("WebSpace", ex.ErrorMessageArguments[0]);
                    Assert.AreEqual("doesnotexist", ex.ErrorMessageArguments[1]);
                    Assert.AreEqual("NotFound (51004): Cannot find WebSpace with name doesnotexist.", ex.Message);
                }
                catch (CloudException ex)
                {
                    Assert.Fail("Expected WebSiteCloudException, not " + ex.ToString());
                }
                catch (Exception ex)
                {
                    Assert.Fail("Expected WebSiteCloudException, not " + ex.ToString());
                }
            }
        }

        [TestMethod]
        public void Basic_UserAgent()
        {
            using (var client = GetWebSiteManagementClient())
            {
                // Default user agent
                string defaultUserAgent = client.UserAgent.ToString();
                Assert.AreEqual(
                    "Microsoft.WindowsAzure.Management.WebSites.WebSiteManagementClient/" + client.GetAssemblyVersion(),
                    defaultUserAgent);

                // Add to the user agent
                client.UserAgent.Add(new ProductInfoHeaderValue("foo", "2.0"));
                Assert.AreEqual(defaultUserAgent + " foo/2.0", client.UserAgent.ToString());
            }
        }

        public class TestHandler :
            DelegatingHandler
        {
            public string HandlerId { get; set; }
            public Action<string> SendAction { get; set; }

            public TestHandler(string id, Action<string> sendAction)
            {
                HandlerId = id;
                SendAction = sendAction;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                SendAction(HandlerId);
                return base.SendAsync(request, cancellationToken);
            }

            public override string ToString()
            {
                return "TestHandler: " + HandlerId;
            }
        }

        [TestMethod]
        public void Basic_WithHandler()
        {
            List<string> handlers = new List<string>();
            Action<string> sendAction = id => handlers.Add(id);

            using (var client = GetWebSiteManagementClient())
            using (var c2 = client.WithHandler(new TestHandler("a", sendAction)))
            {
                using (var c3 = c2.WithHandler(new TestHandler("b", sendAction)))
                using (var c4 = c3.WithHandler(new TestHandler("c", sendAction)))
                {
                    // Ensure nesting works
                    c4.WebSpaces.ListGeoRegions();

                    CollectionAssert.Contains(handlers, "a", "c2 was not fired!");
                    CollectionAssert.Contains(handlers, "b", "c3 was not fired!");
                    CollectionAssert.Contains(handlers, "c", "c4 was not fired!");
                }

                // Ensure disposing related pipelines does not break
                handlers.Clear();
                c2.WebSpaces.ListGeoRegions();
                CollectionAssert.Contains(handlers, "a", "c2 was not fired!");
                Assert.AreEqual(1, handlers.Count());

                // Add one more for good measure
                using (var c5 = c2.WithHandler(new TestHandler("d", sendAction)))
                {
                    handlers.Clear();
                    c5.WebSpaces.ListGeoRegions();
                    CollectionAssert.Contains(handlers, "a", "c2 was not fired");
                    CollectionAssert.Contains(handlers, "d", "c5 was not fired");
                }
            }
        }

        [TestMethod]
        public void Basic_AddHandlerToPipeline()
        {
            List<string> handlers = new List<string>();
            Action<string> sendAction = id => handlers.Add(id);

            using (var client = GetWebSiteManagementClient())
            {
                client.AddHandlerToPipeline(new TestHandler("a", sendAction));
                client.AddHandlerToPipeline(new TestHandler("b", sendAction));
                client.AddHandlerToPipeline(new TestHandler("c", sendAction));
                
                client.WebSpaces.ListGeoRegions();
                CollectionAssert.Contains(handlers, "a");
                CollectionAssert.Contains(handlers, "b");
                CollectionAssert.Contains(handlers, "c");

                // Use along side WithHandler
                using (var c2 = client.WithHandler(new TestHandler("d", sendAction)))
                {
                    handlers.Clear();
                    c2.WebSpaces.ListGeoRegions();
                    CollectionAssert.Contains(handlers, "a");
                    CollectionAssert.Contains(handlers, "b");
                    CollectionAssert.Contains(handlers, "c");
                    CollectionAssert.Contains(handlers, "d");
                    Assert.AreEqual(4, handlers.Count);
                }

                // Try again after the new handler was disposed
                handlers.Clear();
                client.WebSpaces.ListGeoRegions();
                CollectionAssert.Contains(handlers, "a");
                CollectionAssert.Contains(handlers, "b");
                CollectionAssert.Contains(handlers, "c");
                Assert.AreEqual(3, handlers.Count);
            }
        }
    }
}
