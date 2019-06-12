// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Xunit;

    public class WorkflowRunActionRepetitionsRequestHistoriesInMemoryTests : InMemoryTestsBase
    {
        private StringContent RequestHistory { get; set; }

        private StringContent RequestHistoryListResponse { get; set; }

        public WorkflowRunActionRepetitionsRequestHistoriesInMemoryTests()
        {
            var requestHistory = @"{
            'properties': {
                'startTime': '2018-10-25T18:36:51.9206732Z',
                'endTime': '2018-10-25T18:36:52.1863033Z',
                'request': {
                    'headers': {
                        'Accept-Language': 'en-US',
                        'User-Agent': 'azure-logic-apps/1.0,(workflow 80244732be3648f59d2084fd979cdd56; version 08586611142904036539)',
                        'x-ms-execution-location': 'brazilsouth',
                        'x-ms-workflow-id': '80244732be3648f59d2084fd979cdd56',
                        'x-ms-workflow-version': '08586611142904036539',
                        'x-ms-workflow-name': 'test-workflow',
                        'x-ms-workflow-system-id': '/locations/brazilsouth/scaleunits/prod-17/workflows/80244732be3648f59d2084fd979cdd56',
                        'x-ms-workflow-run-id': '08586611142736787787412824395CU21',
                        'x-ms-workflow-run-tracking-id': 'b4cd2e77-f949-4d8c-8753-791407aebde8',
                        'x-ms-workflow-operation-name': 'HTTP_Webhook',
                        'x-ms-workflow-subscription-id': '34adfa4f-cedf-4dc0-ba29-b6d1a69ab345',
                        'x-ms-workflow-resourcegroup-name': 'test-resource-group',
                        'x-ms-workflow-subscription-capacity': 'Large',
                        'x-ms-tracking-id': 'ad484925-4148-4dd0-9488-07aed418b256',
                        'x-ms-correlation-id': 'ad484925-4148-4dd0-9488-07aed418b256',
                        'x-ms-client-request-id': 'ad484925-4148-4dd0-9488-07aed418b256',
                        'x-ms-client-tracking-id': '08586611142736787787412824395CU21',
                        'x-ms-action-tracking-id': 'ad27f634-6523-492f-924e-9a75e28619c8'
                    },
                'uri': 'http://tempuri.org',
                'method': 'GET'
                },
                'response': {
                    'headers': {
                        'Cache-Control': 'private',
                        'Date': 'Thu, 25 Oct 2018 18:36:51 GMT',
                        'Location': 'http://www.bing.com/',
                        'Server': 'Microsoft-IIS/10.0',
                        'X-AspNet-Version': '4.0.30319',
                        'X-Powered-By': 'ASP.NET'
                    },
                    'statusCode': 302,
                    'bodyLink': {
                        'uri': 'https://tempuri.org',
                        'contentVersion': '2LOOAR8Eh2pd7AvRHXUhRg==',
                        'contentSize': 137,
                        'contentHash': {
                        'algorithm': 'md5',
                        'value': '2LOOAR8Eh2pd7AvRHXUhRg=='
                        }
                    }
                }
            },
            'id': '/subscriptions/34adfa4f-cedf-4dc0-ba29-b6d1a69ab345/resourceGroups/test-resource-group/providers/Microsoft.Logic/workflows/test-workflow/runs/08586611142736787787412824395CU21/actions/HTTP_Webhook/requestHistories/08586611142732800686',
            'name': '08586611142732800686',
            'type': 'Microsoft.Logic/workflows/runs/actions/requestHistories'
            }";

            var runActionListResponseFormat = @"{{ 'value': [ {0} ] }}";

            this.RequestHistory = new StringContent(requestHistory);
            this.RequestHistoryListResponse = new StringContent(string.Format(runActionListResponseFormat, requestHistory));
        }

        [Fact]
        public void WorkflowRunActionRepetitionsRequestHistories_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.RequestHistory
            };

            var requestHistory = client.WorkflowRunActionRepetitionsRequestHistories.Get("rgName", "wfName", "rName", "actName", "repName", "reqName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateRequestHistory(requestHistory);
        }

        [Fact]
        public void WorkflowRunActionRepetitionsRequestHistories_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRunActionRepetitionsRequestHistories.Get(null, "wfName", "rName", "actName", "repName", "reqName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActionRepetitionsRequestHistories.Get("rgName", null, "rName", "actName", "repName", "reqName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActionRepetitionsRequestHistories.Get("rgName", "wfName", null, "actName", "repName", "reqName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActionRepetitionsRequestHistories.Get("rgName", "wfName", "rName", null, "repName", "reqName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActionRepetitionsRequestHistories.Get("rgName", "wfName", "rName", "actName", null, "reqName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActionRepetitionsRequestHistories.Get("rgName", "wfName", "rName", "actName", "repName", null));
            Assert.Throws<ErrorResponseException>(() => client.WorkflowRunActionRepetitionsRequestHistories.Get("rgName", "wfName", "rName", "actName", "repName", "reqName"));
        }

        [Fact]
        public void WorkflowRunActionRepetitionsRequestHistories_List_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.RequestHistoryListResponse
            };

            var requestHistory = client.WorkflowRunActionRepetitionsRequestHistories.List("rgName", "wfName", "rName", "actName", "repName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateRequestHistoryListResponse(requestHistory);
        }

        [Fact]
        public void WorkflowRunActionRepetitionsRequestHistories_List_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRunActionRepetitionsRequestHistories.List(null, "wfName", "rName", "actName", "repName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActionRepetitionsRequestHistories.List("rgName", null, "rName", "actName", "repName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActionRepetitionsRequestHistories.List("rgName", "wfName", null, "actName", "repName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActionRepetitionsRequestHistories.List("rgName", "wfName", "rName", null, "repName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActionRepetitionsRequestHistories.List("rgName", "wfName", "rName", "actName", null));
            Assert.Throws<ErrorResponseException>(() => client.WorkflowRunActionRepetitionsRequestHistories.List("rgName", "wfName", "rName", "actName", "repName"));
        }

        private void ValidateRequestHistory(RequestHistory requestHistory)
        {
            Assert.Equal(2018, requestHistory.Properties.StartTime.Value.Year);
            Assert.Equal(10, requestHistory.Properties.StartTime.Value.Month);
            Assert.Equal(25, requestHistory.Properties.StartTime.Value.Day);
            Assert.Equal(18, requestHistory.Properties.StartTime.Value.Hour);
            Assert.Equal(36, requestHistory.Properties.StartTime.Value.Minute);
            Assert.Equal(51, requestHistory.Properties.StartTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, requestHistory.Properties.StartTime.Value.Kind);

            Assert.Equal(2018, requestHistory.Properties.EndTime.Value.Year);
            Assert.Equal(10, requestHistory.Properties.EndTime.Value.Month);
            Assert.Equal(25, requestHistory.Properties.EndTime.Value.Day);
            Assert.Equal(18, requestHistory.Properties.EndTime.Value.Hour);
            Assert.Equal(36, requestHistory.Properties.EndTime.Value.Minute);
            Assert.Equal(52, requestHistory.Properties.EndTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, requestHistory.Properties.EndTime.Value.Kind);

            Assert.Equal("GET", requestHistory.Properties.Request.Method);
            Assert.Equal("http://tempuri.org", requestHistory.Properties.Request.Uri);
            Assert.Equal("80244732be3648f59d2084fd979cdd56", ((JObject)requestHistory.Properties.Request.Headers)["x-ms-workflow-id"]);

            Assert.Equal(HttpStatusCode.Found, (HttpStatusCode)requestHistory.Properties.Response.StatusCode);
            Assert.Equal("http://www.bing.com/", ((JObject)requestHistory.Properties.Response.Headers)["Location"]);

            Assert.Equal("https://tempuri.org", requestHistory.Properties.Response.BodyLink.Uri);
            Assert.Equal(137, requestHistory.Properties.Response.BodyLink.ContentSize);
            Assert.Equal("2LOOAR8Eh2pd7AvRHXUhRg==", requestHistory.Properties.Response.BodyLink.ContentVersion);
        }

        private void ValidateRequestHistoryListResponse(IPage<RequestHistory> page)
        {
            Assert.Single(page);
            this.ValidateRequestHistory(page.First());
        }
    }
}
