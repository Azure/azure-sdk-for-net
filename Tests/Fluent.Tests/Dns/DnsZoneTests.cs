// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Fluent.Tests.Dns
{
    public class Zone
    {
        [Fact]
        public void CanCreateWithDefaultETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgdnschash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var dnsZone = azure.DnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .WithETagCheck()
                        .Create();
                    Assert.NotNull(dnsZone.ETag);
                    EnsureETagExceptionIsThrown(() =>
                    {
                        azure.DnsZones.Define(topLevelDomain)
                            .WithNewResourceGroup(groupName, region)
                            .WithETagCheck()
                            .Create();
                    });
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanUpdateWithExplicitETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgdnschash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var dnsZone = azure.DnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .WithETagCheck()
                        .Create();

                    Assert.NotNull(dnsZone.ETag);
                    EnsureETagExceptionIsThrown(() =>
                    {
                        dnsZone.Update()
                            .WithETagCheck(dnsZone.ETag + "-foo")
                            .Apply();
                    });

                    dnsZone.Update()
                        .WithETagCheck(dnsZone.ETag)
                        .Apply();
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanDeleteWithExplicitETag()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgdnschash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();
                try
                {
                    var dnsZone = azure.DnsZones.Define(topLevelDomain)
                        .WithNewResourceGroup(groupName, region)
                        .WithETagCheck()
                        .Create();

                    Assert.NotNull(dnsZone.ETag);
                    EnsureETagExceptionIsThrown(() =>
                    {
                        azure.DnsZones.DeleteById(dnsZone.Id, dnsZone.ETag + "-foo");
                    });
                    azure.DnsZones.DeleteById(dnsZone.Id, dnsZone.ETag);
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        private void EnsureETagExceptionIsThrown(Action action)
        {
            var isCloudExceptionThrown = false;
            var isCloudErrorSet = false;
            var isCodeSet = false;
            var isPreconditionFailedCodeSet = false;
            try
            {
                action();
            }
            catch (CloudException exception)
            {
                isCloudExceptionThrown = true;
                CloudError cloudError = exception.Body;
                if (cloudError != null)
                {
                    isCloudErrorSet = true;
                    isCodeSet = cloudError.Code != null;
                    if (isCodeSet)
                    {
                        isPreconditionFailedCodeSet = cloudError.Code.Contains("PreconditionFailed");
                    }
                }
            }
            Assert.True(isCloudExceptionThrown, "Expected CloudException is not thrown");
            Assert.True(isCloudErrorSet, "Expected CloudError property is not set in CloudException");
            Assert.True(isCodeSet, "Expected CloudError.Code property is not set");
            Assert.True(isPreconditionFailedCodeSet, "Expected PreconditionFailed code is not set indicating ETag concurrency check failure");
        }
    }
}
