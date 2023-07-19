// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ChangeAnalysis.Tests.Helpers;
using Microsoft.ChangeAnalysis;
using Microsoft.ChangeAnalysis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Microsoft.Azure.Management.ChangeAnalysis.Tests.BasicTests
{
    public class GetChangesTest : TestBase
    {
        [Fact]
        public void GetResourceChangesTest()
        {
            var expectedChangesResponse = new List<Change>
            {
                new Change("/subscriptions/4d962866-1e3f-47f2-bd18-450c08f914c1/resourceGroups/MyResourceGroup/providers/Microsoft.Web/sites/mysite/providers/Microsoft.ChangeAnalysis/resourceChanges/ARG_23fa00fd-dda0-4268-b482-2076825cf165_970d8c6d-6b78-4270-92ef-88d5aa2b5f0b_132316363294700000_132316498613900000",
                    "ARG_23fa00fd-dda0-4268-b482-2076825cf165_970d8c6d-6b78-4270-92ef-88d5aa2b5f0b_132316363294700000_132316498613900000",
                    "Microsoft.ChangeAnalysis/resourceChanges",
                    new ChangeProperties
                    {
                        ResourceId = "/subscriptions/4d962866-1e3f-47f2-bd18-450c08f914c1/resourceGroups/MyResourceGroup/providers/Microsoft.Web/sites/mysite",
                        TimeStamp = DateTime.Parse("2021-04-26T02:17:41.39Z", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                        InitiatedByList = new List<string>() { "ellen@contoso.com" },
                        ChangeType = ChangeType.Update,
                        PropertyChanges = new List<PropertyChange>()
                        {
                            new PropertyChange
                            {
                                ChangeType = ChangeType.Update,
                                ChangeCategory = ChangeCategory.User,
                                JsonPath = "value[1].properties.thumbprint",
                                DisplayName = "publicCertificates[\"AppCert\"].properties.thumbprint",
                                Level = Level.Important,
                                Description = "The thumbprint of the certificate",
                                OldValue = "21D0482F-E91E-4C14-8078-65BFDCDBCA64",
                                NewValue = "3F2DF554-B063-4383-8BD3-4970BCF20A7E",
                                IsDataMasked = false
                            }
                        }
                    })
            };

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", JsonConvert.SerializeObject(expectedChangesResponse), "}"))
            };

            var handler = new RecordedDelegatingHandler(response);
            var changeAnalysisClient = GetChangeAnalysisManagementClient(handler);

            var actualChanges = changeAnalysisClient.ResourceChanges.List("resourceId", DateTime.Now - TimeSpan.FromHours(24), DateTime.Now);

            AreEqualChangeList(expectedChangesResponse, actualChanges.ToList());
        }

        [Fact]
        public void GetChangesBySubscriptionTest()
        {
            var expectedChangesResponse = new List<Change>
            {
                new Change("/subscriptions/4d962866-1e3f-47f2-bd18-450c08f914c1",
                    "ARG_23fa00fd-dda0-4268-b482-2076825cf165_970d8c6d-6b78-4270-92ef-88d5aa2b5f0b_132316363294700000_132316498613900000",
                    "Microsoft.ChangeAnalysis/changes",
                    new ChangeProperties
                    {
                        ResourceId = "/subscriptions/4d962866-1e3f-47f2-bd18-450c08f914c1",
                        TimeStamp = DateTime.Parse("2021-04-26T02:17:41.39Z", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                        InitiatedByList = new List<string>() { "ellen@contoso.com" },
                        ChangeType = ChangeType.Update,
                        PropertyChanges = new List<PropertyChange>()
                        {
                            new PropertyChange
                            {
                                ChangeType = ChangeType.Update,
                                ChangeCategory = ChangeCategory.User,
                                JsonPath = "tags.subscripitonTag",
                                DisplayName = "tags.subscripitonTag",
                                Level = Level.Important,
                                Description = "The tag of the resource",
                                OldValue = "old tag value",
                                NewValue = "new tag value",
                                IsDataMasked = false
                            }
                        }
                    })
            };

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", JsonConvert.SerializeObject(expectedChangesResponse), "}"))
            };

            var handler = new RecordedDelegatingHandler(response);
            var changeAnalysisClient = GetChangeAnalysisManagementClient(handler);

            var actualChanges = changeAnalysisClient.ResourceChanges.List("resourceId", DateTime.Now - TimeSpan.FromHours(24), DateTime.Now);

            AreEqualChangeList(expectedChangesResponse, actualChanges.ToList());
        }

        [Fact]
        public void GetChangesByResourceGroupTest()
        {
            var expectedChangesResponse = new List<Change>
            {
                new Change("/subscriptions/4d962866-1e3f-47f2-bd18-450c08f914c1/resourceGroups/MyResourceGroup",
                    "ARG_23fa00fd-dda0-4268-b482-2076825cf165_970d8c6d-6b78-4270-92ef-88d5aa2b5f0b_132316363294700000_132316498613900000",
                    "Microsoft.ChangeAnalysis/changes",
                    new ChangeProperties
                    {
                        ResourceId = "/subscriptions/4d962866-1e3f-47f2-bd18-450c08f914c1/resourceGroups/MyResourceGroup",
                        TimeStamp = DateTime.Parse("2021-04-26T02:17:41.39Z", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                        InitiatedByList = new List<string>() { "ellen@contoso.com" },
                        ChangeType = ChangeType.Update,
                        PropertyChanges = new List<PropertyChange>()
                        {
                            new PropertyChange
                            {
                                ChangeType = ChangeType.Update,
                                ChangeCategory = ChangeCategory.User,
                                JsonPath = "tags.subscripitonTag",
                                DisplayName = "tags.subscripitonTag",
                                Level = Level.Important,
                                Description = "The tag of the resource",
                                OldValue = "old tag value",
                                NewValue = "new tag value",
                                IsDataMasked = false
                            }
                        }
                    })
            };

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", JsonConvert.SerializeObject(expectedChangesResponse), "}"))
            };

            var handler = new RecordedDelegatingHandler(response);
            var changeAnalysisClient = GetChangeAnalysisManagementClient(handler);

            var actualChanges = changeAnalysisClient.ResourceChanges.List("resourceId", DateTime.Now - TimeSpan.FromHours(24), DateTime.Now);

            AreEqualChangeList(expectedChangesResponse, actualChanges.ToList());
        }

        private void AreEqualChangeList(IList<Change> exp, IList<Change> act)
        {
            if (exp == null)
            {
                Assert.Null(act);
                return;
            }

            for (int i = 0; i < exp.Count; i++)
            {
                AreEqualChange(exp[i], act[i]);
            }
        }

        private static void AreEqualChange(Change exp, Change act)
        {
            if (exp == null)
            {
                Assert.Null(act);
                return;
            }

            Assert.Equal(exp.Id, act.Id);
            Assert.Equal(exp.Name, act.Name);
            Assert.Equal(exp.Type, act.Type);

            Assert.Equal(exp.Properties.ChangeType, act.Properties.ChangeType);
            Assert.Equal(exp.Properties.ResourceId, act.Properties.ResourceId);
            Assert.Equal(exp.Properties.TimeStamp, act.Properties.TimeStamp);
            Assert.Equal(exp.Properties.InitiatedByList.Count, act.Properties.InitiatedByList.Count);
            for (var i = 0; i < exp.Properties.InitiatedByList.Count; i++)
            {
                Assert.Equal(exp.Properties.InitiatedByList[i], act.Properties.InitiatedByList[i]);
            }

            Assert.Equal(exp.Properties.PropertyChanges.Count, act.Properties.PropertyChanges.Count);
            for (var i = 0; i < exp.Properties.PropertyChanges.Count; i++)
            {
                AreEqualChangeProperty(exp.Properties.PropertyChanges[i], act.Properties.PropertyChanges[i]);
            }
        }

        private static void AreEqualChangeProperty(PropertyChange exp, PropertyChange act)
        {
            if (exp == null)
            {
                Assert.Null(act);
                return;
            }

            Assert.Equal(exp.ChangeCategory, act.ChangeCategory);
            Assert.Equal(exp.ChangeType, act.ChangeType);
            Assert.Equal(exp.Description, act.Description);
            Assert.Equal(exp.DisplayName, act.DisplayName);
            Assert.Equal(exp.IsDataMasked, act.IsDataMasked);
            Assert.Equal(exp.JsonPath, act.JsonPath);
            Assert.Equal(exp.Level, act.Level);
            Assert.Equal(exp.OldValue, act.OldValue);
            Assert.Equal(exp.NewValue, act.NewValue);
        }
    }
}
