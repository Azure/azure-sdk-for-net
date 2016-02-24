using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using Microsoft.Azure.Test;
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

        [Fact]
        public void GetSessionTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<Session> sessions = null;

            raClient = GetClient();

            sessions = raClient.Collection.SessionList(collectionName, groupName).Value;

            Assert.NotNull(sessions);
            foreach (Session session in sessions)
            {
                Assert.NotNull(session.UserUpn);
            }
        }

        [Fact]
        public void LogOffSessionTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<Session> sessions = null;

            raClient = GetClient();

            raClient.Collection.SessionLogOff(collectionName, userUpn, groupName);

            sessions = raClient.Collection.SessionList(collectionName, groupName).Value;

            Assert.NotNull(sessions);
            foreach (Session session in sessions)
            {
                Assert.NotNull(session.UserUpn);
            }
        }

        [Fact]
        public void DisconnectSessionTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<Session> sessions = null;

            raClient = GetClient();

            raClient.Collection.SessionDisconnect(collectionName, userUpn, groupName);

            sessions = raClient.Collection.SessionList(collectionName, groupName).Value;

            Assert.NotNull(sessions);
            foreach (Session session in sessions)
            {
                Assert.NotNull(session.UserUpn);
            }
        }

        [Fact]
        public void MessageSessionTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<Session> sessions = null;

            raClient = GetClient();

            SessionSendMessageCommandParameter param = new SessionSendMessageCommandParameter();
            param.Message = "hello";

            raClient.Collection.SessionSendMessage(param, collectionName, userUpn, groupName);

            sessions = raClient.Collection.SessionList(collectionName, groupName).Value;

            Assert.NotNull(sessions);
            foreach (Session session in sessions)
            {
                Assert.NotNull(session.UserUpn);
            }
        }
    }
}
