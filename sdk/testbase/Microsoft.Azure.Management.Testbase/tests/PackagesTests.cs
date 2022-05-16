// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.TestBase.Models;
using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.WindowsAzure.Storage.Blob;

namespace TestBase.Tests
{
    public class PackagesTests : TestbaseBase
    {
        string baseGeneratedName;
        string packageName;
        string packageNameVer;
        string version = "1.0.0";
        string nextPageLink = null;
        string uploadUrl = "";
        string blobPath = "https://tbwestusppesa.blob.core.windows.net/c0097881-16f2-4c2a-b6f1-1e2c7d7cb8e7/staging/dbf7c815-da6b-45e7-9114-137eae16831b/7afedd46-74c0-4642-9562-f02987871c9c/1/test.zip";

        string FeatureUpdate = "Feature updates";
        string SecurityUpdate = "Security updates";


        [Fact]
        public void TestPackageOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientInitialized(context);
                baseGeneratedName = TestbaseManagementTestUtilities.GenerateName(TestPrefix);

                //Get Package List
                try
                {
                    AzureOperationResponse<IPage<PackageResource>> packageResources = t_TestBaseClient.Packages.ListByTestBaseAccountWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName).GetAwaiter().GetResult();
                    Assert.NotNull(packageResources);
                    Assert.NotNull(packageResources.Body);

                }
                catch (Exception ex)
                {
                    Assert.Null(ex.Message);
                }

                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.Packages.ListByTestBaseAccountNextWithHttpMessagesAsync(nextPageLink));

                //Get a Package that does not exist
                Assert.ThrowsAsync<ErrorResponseException>(() => t_TestBaseClient.Packages.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, ErrorValue));

                //Gets the Package uploaded via the Web page
                try
                {
                    var packageResponse = t_TestBaseClient.Packages.GetWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, t_PackageName).GetAwaiter().GetResult();
                    Assert.NotNull(packageResponse);
                    Assert.NotNull(packageResponse.Body);
                    Assert.Equal(t_PackageName, packageResponse.Body.Name);
                }
                catch (Exception ex)
                {
                    Assert.Null(ex.Message);
                }


                //Create Package
                #region Create Package
                packageName = baseGeneratedName + "_pkg";
                packageNameVer = packageName +"-"+ version;
                PackageResource packageResource = new PackageResource();
                packageResource.Location = "global";
                packageResource.Tags = new Dictionary<string, string>()
                {
                    { "test","test"}
                };
                packageResource.ApplicationName = packageName;
                packageResource.Version = version;
                packageResource.TargetOSList = new List<TargetOSInfo>()
                {
                    new TargetOSInfo(
                        FeatureUpdate,new List<string>()//The Name property of availableOS,not resourceName
                        {
                            "Windows 10 20H2"
                        }),
                    new TargetOSInfo(
                        SecurityUpdate,new List<string>()
                        {
                            "Windows 10 21H1",
                            "Windows 10 20H2",
                            "Windows 10 2004",
                            "Windows 10 1909",
                            "All Future OS Updates",
                            "Windows Server 2019",
                            "Windows Server 2019 - Server Core",
                            "Windows Server 2016",
                            "Windows Server 2016 - Server Core"
                        })
                };
                packageResource.FlightingRing = "Insider Beta Channel";
                try
                {
                    //Upload the package and get the URL
                    var uploadUrlResponse = t_TestBaseClient.TestBaseAccounts.GetFileUploadUrlWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, "test.zip").GetAwaiter().GetResult();
                    uploadUrl = uploadUrlResponse.Body.UploadUrl;
                    var cloudBlockBlob = new CloudBlockBlob(new Uri(uploadUrl));
                    string basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;

                    cloudBlockBlob.UploadFromFileAsync(basePath + "\\Resources\\test.zip").GetAwaiter().GetResult();
                    blobPath = uploadUrl.ToLower().Split(".zip")[0] + ".zip";
                }
                catch (Exception ex)
                {
                    Assert.Null(ex.Message);
                }
                packageResource.BlobPath = blobPath;
                packageResource.Tests = new List<Test>()
                {
                    new Test()
                    {
                        TestType="OutOfBoxTest",
                        IsActive=true,
                        Commands=new List<Command>()
                        {
                            new Command()
                            {
                                Name="install",//Lower case first letter
                                Action="Install",//Capitalize the first letter
                                ContentType="Path",
                                Content="test/scripts/install/job.ps1",
                                RunElevated=false,
                                RestartAfter=true,
                                MaxRunTime=1800,
                                RunAsInteractive=true,
                                AlwaysRun=true,
                                ApplyUpdateBefore=false
                            },
                            new Command()
                            {
                                Name="launch",
                                Action="Launch",
                                ContentType="Path",
                                Content="test/scripts/launch/job.ps1",
                                RunElevated=true,
                                RestartAfter=false,
                                MaxRunTime=1800,
                                RunAsInteractive=true,
                                AlwaysRun=false,
                                ApplyUpdateBefore=true
                            },
                            new Command()
                            {
                                Name="close",
                                Action="Close",
                                ContentType="Path",
                                Content="test/scripts/close/job.ps1",
                                RunElevated=true,
                                RestartAfter=false,
                                MaxRunTime=1800,
                                RunAsInteractive=true,
                                AlwaysRun=false,
                                ApplyUpdateBefore=false
                            },
                            new Command()
                            {
                                Name="uninstall",
                                Action="Uninstall",
                                ContentType="Path",
                                Content="test/scripts/uninstall/job.ps1",
                                RunElevated=true,
                                RestartAfter=false,
                                MaxRunTime=1800,
                                RunAsInteractive=true,
                                AlwaysRun=true,
                                ApplyUpdateBefore=false
                            }
                        }
                    }
                };
                try
                {
                    var createResult = t_TestBaseClient.Packages.CreateWithHttpMessagesAsync(packageResource, t_ResourceGroupName, t_TestBaseAccountName, packageNameVer).GetAwaiter().GetResult();
                    Assert.NotNull(createResult);
                    Assert.NotNull(createResult.Body);
                }
                catch (Exception ex)
                {
                    Assert.Null(ex.Message);
                }
                #endregion


                //Update Package
                Dictionary<string, string> tags = new Dictionary<string, string>();
                tags.Add("tagkey", "tagvalue_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                PackageUpdateParameters packageUpdateParameters = new PackageUpdateParameters();
                packageUpdateParameters.Tags = tags;

                try
                {
                    var updateResult = t_TestBaseClient.Packages.UpdateWithHttpMessagesAsync(packageUpdateParameters, t_ResourceGroupName, t_TestBaseAccountName, packageNameVer).GetAwaiter().GetResult();

                    Assert.NotNull(updateResult);
                    Assert.NotNull(updateResult.Body);
                }
                catch (Exception ex)
                {
                    Assert.Null(ex.Message);
                }


                //Delete Package
                try
                {
                    //Unable to delete successfully
                    var deleteResponse = t_TestBaseClient.Packages.DeleteWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, packageNameVer).GetAwaiter().GetResult();
                }
                catch(Exception ex)
                {
                    Assert.NotNull(ex.Message);//BadRequest,Unable to delete successfully, Use BeginHardDelete instead of Delete
                }

                try
                {
                    //Package can be successfully deleted through BeginHardDeleteWithHttpMessagesAsync.2021-5-28
                    var deleteResponse = t_TestBaseClient.Packages.BeginHardDeleteWithHttpMessagesAsync(t_ResourceGroupName, t_TestBaseAccountName, packageNameVer).GetAwaiter().GetResult();
                    Assert.NotNull(deleteResponse);
                }
                catch (Exception ex)
                {
                    Assert.Null(ex.Message);
                }
            }
        }
    }
}
