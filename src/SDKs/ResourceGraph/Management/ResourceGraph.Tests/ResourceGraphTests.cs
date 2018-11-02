// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;

using Microsoft.Azure.Management.ResourceGraph.Models;
using Microsoft.Azure.Management.ResourceGraph.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.ResourceGraph.Tests
{
    using System.Collections.Generic;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// ResourceGraph tests
    /// </summary>
    /// <seealso cref="Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestBase" />
    public class ResourceGraphTests : TestBase
    {
        /// <summary>
        /// Gets or sets the test environment.
        /// </summary>
        private static TestEnvironment TestEnvironment { get; set; }

        /// <summary>
        /// Gets the resource graph client.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static ResourceGraphClient GetResourceGraphClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var policyInsightsClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<ResourceGraphClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<ResourceGraphClient>(handlers: handler);

            return policyInsightsClient;
        }

        /// <summary>
        /// Resources basic query test.
        /// </summary>
        [Fact]
        public void ResourcesBasicQueryTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourceGraphClient = GetResourceGraphClient(context);
                var query = new QueryRequest
                    {
                        Subscriptions = new List<string> { "00000000-0000-0000-0000-000000000000" },
                        Query = "project id, tags, properties | limit 2"
                    };

                var queryResponse = resourceGraphClient.Resources(query);
                
                // Top-level response fields
                Assert.Equal(2, queryResponse.Count);
                Assert.Equal(2, queryResponse.TotalRecords);
                Assert.Null(queryResponse.SkipToken);
                Assert.Equal(ResultTruncated.False, queryResponse.ResultTruncated);
                Assert.NotNull(queryResponse.Data);
                Assert.NotNull(queryResponse.Facets);
                Assert.Empty(queryResponse.Facets);

                // Data columns
                Assert.NotNull(queryResponse.Data.Columns);
                Assert.Equal(3, queryResponse.Data.Columns.Count);
                Assert.NotNull(queryResponse.Data.Columns[0].Name);
                Assert.NotNull(queryResponse.Data.Columns[1].Name);
                Assert.NotNull(queryResponse.Data.Columns[2].Name);
                Assert.Equal(ColumnDataType.String, queryResponse.Data.Columns[0].Type);
                Assert.Equal(ColumnDataType.Object, queryResponse.Data.Columns[1].Type);
                Assert.Equal(ColumnDataType.Object, queryResponse.Data.Columns[2].Type);

                // Data rows
                Assert.NotNull(queryResponse.Data.Rows);
                Assert.Equal(2, queryResponse.Data.Rows.Count);
                Assert.Equal(3, queryResponse.Data.Rows[0].Count);
                Assert.IsType<string>(queryResponse.Data.Rows[0][0]);
                Assert.IsType<JObject>(queryResponse.Data.Rows[0][1]);
                Assert.IsType<JObject>(queryResponse.Data.Rows[0][2]);
            }
        }
        
        [Fact]
        public void ResourcesQueryOptionsTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourceGraphClient = GetResourceGraphClient(context);
                var query = new QueryRequest
                {
                    Subscriptions = new List<string> { "00000000-0000-0000-0000-000000000000" },
                    Query = "project id",
                    Options = new QueryRequestOptions
                    {
                        SkipToken = "82aw3vQlArEastJ24LABY8oPgQLesIyAyzYs2g6/aOOOmJHSYFj39fODurJV5e2tTFFebWcfxn7n5edicA8u6HgSJe1GCEk5HjxwLkeJiye2LVZDC7TaValkJbsk9JqY4yv5c7iRiLqgO34RbHEeVfLJpa56u4RZu0K+GpQvnBRPyAhy3KbwhZWpU5Nnqnud2whGb5WKdlL8xF7wnQaUnUN2lns8WwqwM4rc0VK4BbQt/WfWWcYJivSAyB3m4Z5g73df1KiU4C+K8auvUMpLPYVxxnKC/YZz42YslVAWXXUmuGOaM2SfLHRO6o4O9DgXlUgYjeFWqIbAkmMiVEqU",
                        Top = 4,
                        Skip = 8
                    }
                };

                var queryResponse = resourceGraphClient.Resources(query);
                
                // Top-level response fields
                Assert.Equal(4, queryResponse.Count);
                Assert.Equal(743, queryResponse.TotalRecords);
                Assert.NotNull(queryResponse.SkipToken);
                Assert.Equal(ResultTruncated.False, queryResponse.ResultTruncated);
                Assert.NotNull(queryResponse.Data);
                Assert.NotNull(queryResponse.Facets);
                Assert.Empty(queryResponse.Facets);

                // Data columns
                Assert.NotNull(queryResponse.Data.Columns);
                Assert.Single(queryResponse.Data.Columns);
                Assert.NotNull(queryResponse.Data.Columns[0].Name);
                Assert.Equal(ColumnDataType.String, queryResponse.Data.Columns[0].Type);

                // Data rows
                Assert.NotNull(queryResponse.Data.Rows);
                Assert.Equal(4, queryResponse.Data.Rows.Count);
                Assert.Single(queryResponse.Data.Rows[0]);
                Assert.IsType<string>(queryResponse.Data.Rows[0][0]);
            }
        }
        
        [Fact]
        public void ResourcesFacetQueryTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourceGraphClient = GetResourceGraphClient(context);

                var validExpression = "location";
                var invalidExpression = "nonExistingColumn";
                var query = new QueryRequest
                {
                    Subscriptions = new List<string> { "00000000-0000-0000-0000-000000000000" },
                    Query = "project id, location | limit 10",
                    Facets = new List<FacetRequest>
                    {
                        new FacetRequest
                        {
                            Expression = validExpression,
                            Options = new FacetRequestOptions
                            {
                                SortOrder = FacetSortOrder.Desc,
                                Top = 4
                            }
                        },
                        new FacetRequest
                        {
                            Expression = invalidExpression,
                            Options = new FacetRequestOptions
                            {
                                SortOrder = FacetSortOrder.Desc,
                                Top = 4
                            }
                        }
                    }
                };

                var queryResponse = resourceGraphClient.Resources(query);
                
                // Top-level response fields
                Assert.Equal(10, queryResponse.Count);
                Assert.Equal(10, queryResponse.TotalRecords);
                Assert.Null(queryResponse.SkipToken);
                Assert.Equal(ResultTruncated.False, queryResponse.ResultTruncated);
                Assert.NotNull(queryResponse.Data);
                Assert.NotNull(queryResponse.Facets);
                Assert.Equal(2, queryResponse.Facets.Count);

                // Valid facet fields
                var validFacet = queryResponse.Facets[0] as FacetResult;
                Assert.NotNull(validFacet);
                Assert.Equal(validExpression, validFacet.Expression);
                Assert.Equal(4, validFacet.TotalRecords);
                Assert.Equal(4, validFacet.Count);
                
                // Valid facet columns
                Assert.NotNull(validFacet.Data.Columns);
                Assert.Equal(2, validFacet.Data.Columns.Count);
                Assert.NotNull(validFacet.Data.Columns[0].Name);
                Assert.NotNull(validFacet.Data.Columns[1].Name);
                Assert.Equal(ColumnDataType.String, validFacet.Data.Columns[0].Type);
                Assert.Equal(ColumnDataType.Integer, validFacet.Data.Columns[1].Type);

                // Valid facet rows
                Assert.NotNull(validFacet.Data.Rows);
                Assert.Equal(4, validFacet.Data.Rows.Count);
                Assert.Equal(2, validFacet.Data.Rows[0].Count);
                Assert.IsType<string>(validFacet.Data.Rows[0][0]);
                Assert.IsType<long>(validFacet.Data.Rows[0][1]);

                // Invalid facet
                var invalidFacet = queryResponse.Facets[1] as FacetError;
                Assert.NotNull(invalidFacet);
                Assert.Equal(invalidExpression, invalidFacet.Expression);
                Assert.NotNull(invalidFacet.Errors);
                Assert.InRange(invalidFacet.Errors.Count, 1, int.MaxValue);
                Assert.NotNull(invalidFacet.Errors[0].Code);
                Assert.NotNull(invalidFacet.Errors[1].Code);
            }
        }

        [Fact]
        public void ResourcesMalformedQueryTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourceGraphClient = GetResourceGraphClient(context);
                var query = new QueryRequest
                {
                    Subscriptions = new List<string> { "00000000-0000-0000-0000-000000000000" },
                    Query = "project id, location | where where"
                };

                var exception =
                    Assert.Throws<ErrorResponseException>(
                        () => resourceGraphClient.Resources(query));

                var error = exception.Body.Error;
                Assert.NotNull(error.Code);
                Assert.NotNull(error.Message);
                Assert.NotNull(error.Details);
                Assert.InRange(error.Details.Count, 1, int.MaxValue);
                Assert.NotNull(error.Details[0].Code);
                Assert.NotNull(error.Details[0].Message);
                Assert.NotNull(error.Details[0].AdditionalProperties);
                Assert.Equal(4, error.Details[0].AdditionalProperties.Count);
            }
        }
    }
}
