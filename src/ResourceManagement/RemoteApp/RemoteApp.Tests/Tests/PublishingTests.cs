using Microsoft.Azure.Management.RemoteApp.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;


namespace Microsoft.Azure.Management.RemoteApp.Tests
{
    public class PublishingTests : RemoteAppTestBase
    {
        string location = "West US";
        string groupName = "Default-RemoteApp-WestUS";
        string collectionName = "ybtest";
        string remoteAppType = "microsoft.remoteapp/collections";

        [Fact]
        public void GetStartMenuListTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<StartMenuApplication> startMenuList = null;

            //using (UndoContext undoContext = UndoContext.Current)
            {
                //undoContext.Start();
                raClient = GetClient();

                startMenuList = raClient.Collection.ListStartMenuApps(collectionName, groupName).Value;

                Assert.NotNull(startMenuList);

                foreach (StartMenuApplication sa in startMenuList)
                {
                    Assert.Equal(remoteAppType, sa.Type);
                    Assert.Equal(location, sa.Location);
                    Assert.Equal(collectionName, sa.Name);
                    Assert.NotNull(sa.Id);
                    Assert.NotNull(sa.StartMenuApplicationName);
                    Assert.NotNull(sa.StartMenuApplicationId);
                    Assert.NotNull(sa.VirtualPath);
                }
            }
        }

        [Fact]
        public void GetStartMenuTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<StartMenuApplication> startMenuList = null;
            StartMenuApplication startMenu = null;
            string appId = null;

            //using (UndoContext undoContext = UndoContext.Current)
            {
                //undoContext.Start();
                raClient = GetClient();

                startMenuList = raClient.Collection.ListStartMenuApps(collectionName, groupName).Value;
                appId = startMenuList[0].StartMenuApplicationId;

                startMenu = raClient.Collection.GetStartMenuApp(appId, collectionName, groupName);

                Assert.Equal(remoteAppType, startMenu.Type);
                Assert.Equal(location, startMenu.Location);
                Assert.Equal(collectionName, startMenu.Name);
                Assert.NotNull(startMenu.Id);
                Assert.NotNull(startMenu);
                Assert.Equal(startMenuList[0].StartMenuApplicationName, startMenu.StartMenuApplicationName);
                Assert.Equal(startMenuList[0].StartMenuApplicationId, startMenu.StartMenuApplicationId);
                Assert.Equal(startMenuList[0].VirtualPath, startMenu.VirtualPath);
            }
        }


        [Fact]
        public void GetPublishedAppListTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<PublishedApplicationDetails> pubApps = null;

            //using (UndoContext undoContext = UndoContext.Current)
            {
                //undoContext.Start();
                raClient = GetClient();

                pubApps = raClient.Collection.ListPublishedApp(collectionName, groupName).Value;

                Assert.NotNull(pubApps);

                foreach (PublishedApplicationDetails app in pubApps)
                {
                    Assert.Equal(remoteAppType, app.Type);
                    Assert.Equal(location, app.Location);
                    Assert.Equal(collectionName, app.Name);
                    Assert.NotNull(app.Id);
                    Assert.NotNull(app);
                    Assert.NotNull(app.DisplayName);
                    Assert.NotNull(app.ApplicationAlias);
                    Assert.NotNull(app.VirtualPath);
                    Assert.Equal(AppPublishingStatus.Published, app.Status);
                }
            }
        }


        [Fact]
        public void GetPublishedAppTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<PublishedApplicationDetails> pubApps = null;
            PublishedApplicationDetails pubApp = null;
            string alias = null;

           // using (UndoContext undoContext = UndoContext.Current)
            {
               // undoContext.Start();
                raClient = GetClient();

                pubApps = raClient.Collection.ListPublishedApp(collectionName, groupName).Value;
                alias = pubApps[0].ApplicationAlias;

                pubApp = raClient.Collection.GetPublishedApp(collectionName, alias, groupName);

                Assert.NotNull(pubApp);
                Assert.Equal(remoteAppType, pubApp.Type);
                Assert.Equal(location, pubApp.Location);
                Assert.Equal(collectionName, pubApp.Name);
                Assert.NotNull(pubApp.Id);
                Assert.NotNull(pubApp);
                Assert.NotNull(pubApp.DisplayName);
                Assert.NotNull(pubApp.ApplicationAlias);
                Assert.NotNull(pubApp.VirtualPath);
                Assert.Equal(AppPublishingStatus.Published, pubApp.Status);
            }
        }

        [Fact]
        public void PublishStartMenuAppTest()
        {
            RemoteAppManagementClient raClient = null;
            PublishingOperationResult pubAppResult = null;
            IList<StartMenuApplication> startMenuList = null;
            StartMenuApplication appToPublish = null;
            PublishedApplicationDetails publishedApp = null;
            PublishingOperationResult unPubApp = null;
            ApplicationDetails details = null;

           // using (UndoContext undoContext = UndoContext.Current)
            {
               // undoContext.Start();
                raClient = GetClient();
                startMenuList = raClient.Collection.ListStartMenuApps(collectionName, groupName).Value;
                Assert.NotNull(startMenuList);
                appToPublish = startMenuList.Last();

                details = new ApplicationDetails()
                {
                    ApplicationAlias = appToPublish.StartMenuApplicationId,
                    DisplayName = appToPublish.StartMenuApplicationName,
                    VirtualPath = appToPublish.VirtualPath,
                    AvailableToUsers = true,
                    IconPngUris = appToPublish.IconPngUris
                };

                pubAppResult = raClient.Collection.PublishOrUpdateApplication(details, collectionName, details.ApplicationAlias, groupName);

                Assert.NotNull(pubAppResult);
                Assert.NotNull(pubAppResult.ApplicationAlias);
                Assert.Equal(details.VirtualPath, pubAppResult.ApplicationVirtualPath);
                Assert.Null(pubAppResult.ErrorMessage);
                Assert.True(pubAppResult.Success.Value);

                publishedApp = GetPublishedApplication(raClient, collectionName, pubAppResult.ApplicationAlias, AppPublishingStatus.Published);

                Assert.Equal(pubAppResult.ApplicationAlias, publishedApp.ApplicationAlias);


                unPubApp = raClient.Collection.Unpublish(collectionName, pubAppResult.ApplicationAlias, groupName);
                Assert.NotNull(unPubApp);
            }
        }


        [Fact]
        public void ModifyAppTest()
        {
            RemoteAppManagementClient raClient = null;
            PublishingOperationResult modifyApp = null;
            PublishedApplicationDetails pubApp = null;
            IList<PublishedApplicationDetails> pubApps = null;
            PublishedApplicationDetails appToModifiy = null;
            ApplicationDetails details = null;
            string arguments = null;

           // using (UndoContext undoContext = UndoContext.Current)
            {
                //undoContext.Start();
                raClient = GetClient();
                pubApps = raClient.Collection.ListPublishedApp(collectionName, groupName).Value;
                Assert.NotNull(pubApps);
                appToModifiy = pubApps.First();
                arguments = appToModifiy.CommandLineArguments;

                details = new ApplicationDetails()
                {
                    ApplicationAlias = appToModifiy.ApplicationAlias,
                    DisplayName = appToModifiy.DisplayName,
                    VirtualPath = appToModifiy.VirtualPath,
                    AvailableToUsers = appToModifiy.AvailableToUsers,
                    IconPngUris = appToModifiy.IconPngUris,
                    CommandLineArguments = "Arg1, Arg2, Arg3, Arg4, Arg5",
                    Status = appToModifiy.Status
                };

                modifyApp = raClient.Collection.PublishOrUpdateApplication(details, collectionName, details.ApplicationAlias, groupName);

                Assert.NotNull(modifyApp);

                Assert.Equal(details.ApplicationAlias, modifyApp.ApplicationAlias);
                Assert.Equal(details.VirtualPath, modifyApp.ApplicationVirtualPath);
                Assert.Null(modifyApp.ErrorMessage);
                Assert.True(modifyApp.Success.Value);

                pubApp = GetPublishedApplication(raClient, collectionName, modifyApp.ApplicationAlias, AppPublishingStatus.Published);

                Assert.Equal(details.ApplicationAlias, pubApp.ApplicationAlias);
                Assert.Equal(details.CommandLineArguments, pubApp.CommandLineArguments);

                details.CommandLineArguments = arguments;
                raClient.Collection.PublishOrUpdateApplication(details, collectionName, appToModifiy.ApplicationAlias, groupName);
            }
        }

        [Fact]
        public void DeleteAppTest()
        {
            RemoteAppManagementClient raClient = null;
            IList<StartMenuApplication> startMenuList = null;
            StartMenuApplication appToPublish = null;
            PublishingOperationResult unPubApp = null;
            ApplicationDetails details = null;
            PublishingOperationResult pubAppResult = null;

          //  using (UndoContext undoContext = UndoContext.Current)
            {
              //  undoContext.Start();
                raClient = GetClient();
                startMenuList = raClient.Collection.ListStartMenuApps(collectionName, groupName).Value;
                Assert.NotNull(startMenuList);
                appToPublish = startMenuList.First();

                details = new ApplicationDetails()
                {
                    ApplicationAlias = appToPublish.StartMenuApplicationId,
                    DisplayName = appToPublish.StartMenuApplicationName,
                    VirtualPath = appToPublish.VirtualPath,
                    AvailableToUsers = true,
                    IconPngUris = appToPublish.IconPngUris
                };

                pubAppResult = raClient.Collection.PublishOrUpdateApplication(details, collectionName, details.ApplicationAlias, groupName);
                Assert.NotNull(pubAppResult);
                WaitForAppStatus(raClient, collectionName, details.ApplicationAlias, AppPublishingStatus.Published);

                unPubApp = raClient.Collection.Unpublish(collectionName, details.ApplicationAlias, groupName);

                Assert.NotNull(unPubApp);
                Assert.Null(unPubApp.ErrorMessage);
                Assert.True(unPubApp.Success.Value);
               
            }
        }

        private PublishedApplicationDetails GetPublishedApplication(RemoteAppManagementClient raClient, string collectionName, string appAlias, AppPublishingStatus status)
        {
            PublishedApplicationDetails pubApp = null;

            pubApp = WaitForAppStatus(raClient, collectionName, appAlias, status);
            Assert.NotNull(pubApp);
            return pubApp;
        }

        private PublishedApplicationDetails WaitForAppStatus(RemoteAppManagementClient raClient, string collectionName, string appAlias, AppPublishingStatus status)
        {
            // Wait for application status to change to "Published"
            //const int AppPublihingStatusCheckIntervalSeconds = 10;
            const int AppPublihingStatusCheckMaxRetries = 12;
            PublishedApplicationDetails publishedAppResult = null;
            int retryCount = 0;


            do
            {
                // Need not wait in Mock environment
                if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                {
                    //TestUtilities.Wait(AppPublihingStatusCheckIntervalSeconds * 1000);
                }

                publishedAppResult = raClient.Collection.GetPublishedApp(collectionName, appAlias, groupName);
                Assert.NotNull(publishedAppResult);
                retryCount++;
            }
            while (retryCount < AppPublihingStatusCheckMaxRetries &&
                     publishedAppResult.Status != status);

            Assert.True(retryCount < AppPublihingStatusCheckMaxRetries);

            return publishedAppResult;
        }
    }
}
