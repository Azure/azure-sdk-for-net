using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using RemoteApp.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Management.RemoteApp.Tests
{
    public class SessionTests : RemoteAppTestBase
    {
        const string groupName = "Default-RemoteApp-WestUS";
        const string collectionName = "ybtest";
        const string userUpn = "test";

        [Fact(Skip = "TODO, 6983662: Bring tests up to date with sdk")]
        public void GetSessionTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<Session> sessions = null;

            RemoteAppDelegatingHandler handler = new RemoteAppDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                raClient = GetClient(context, handler);

                sessions = raClient.Collection.ListSessions(collectionName, groupName).Value;
            }

            Assert.NotNull(sessions);
            foreach (Session session in sessions)
            {
                Assert.NotNull(session.UserUpn);
            }
        }

        [Fact(Skip = "TODO, 6983662: Bring tests up to date with sdk")]
        public void LogOffSessionTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<Session> sessions = null;

            RemoteAppDelegatingHandler handler = new RemoteAppDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                raClient = GetClient(context, handler);

                raClient.Collection.SessionLogOff(collectionName, userUpn, groupName);

                sessions = raClient.Collection.ListSessions(collectionName, groupName).Value;
            }

            Assert.NotNull(sessions);
            foreach (Session session in sessions)
            {
                Assert.NotNull(session.UserUpn);
            }
        }

        [Fact(Skip = "TODO, 6983662: Bring tests up to date with sdk")]
        public void DisconnectSessionTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<Session> sessions = null;

            RemoteAppDelegatingHandler handler = new RemoteAppDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                raClient = GetClient(context, handler);

                raClient.Collection.SessionDisconnect(collectionName, userUpn, groupName);

                sessions = raClient.Collection.ListSessions(collectionName, groupName).Value;
            }

            Assert.NotNull(sessions);
            foreach (Session session in sessions)
            {
                Assert.NotNull(session.UserUpn);
            }
        }

        [Fact(Skip = "TODO, 6983662: Bring tests up to date with sdk")]
        public void MessageSessionTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<Session> sessions = null;

            RemoteAppDelegatingHandler handler = new RemoteAppDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                raClient = GetClient(context, handler);

                SessionSendMessageCommandParameter param = new SessionSendMessageCommandParameter();
                param.Message = "hello";

                raClient.Collection.SessionSendMessage(param, collectionName, userUpn, groupName);

                sessions = raClient.Collection.ListSessions(collectionName, groupName).Value;
            }

            Assert.NotNull(sessions);
            foreach (Session session in sessions)
            {
                Assert.NotNull(session.UserUpn);
            }
        }
    }
}
