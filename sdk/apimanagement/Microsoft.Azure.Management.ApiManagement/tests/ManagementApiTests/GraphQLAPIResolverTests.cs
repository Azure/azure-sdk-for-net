// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class GraphQLAPIResolverTests : TestBase
    {
        const string basicSchema = @"
             type Family {
              id: Int!
              name: String!
              members: [Person]
            }

            type Person {
              id: Int!
              firstName: String!
              lastName: String!
              family: Family
            }

            type Query {
              allFamilies: [Family]
              familyById(id: Int!): Family
              allPeople: [Person]
              personById(id: Int!): Person
              familyMembers(familyId: Int!): [Person]
            }

            type Mutation {
              createFamily(id: Int!, name: String!): Family
              createPerson(
                id: Int!
                firstName: String!
                lastName: String!
                familyId: Int!
              ): Person
            }

            type Subscription {
              onFamilyCreated: Family!
              onPersonCreated: Person!
              onSpecificFamilyCreated(id: Int): Family!
              onSpecificFamilyCreatedMultiFilter(id: Int, name: String): Family!
              onFamilyGet: Family!
              onSpecificFamilyGet(id: Int!): Family!
              onFamiliesGet: [Family!]!
            }";

        const string resolverPolicy = @"
            <http-data-source>
	            <http-request>
		            <set-method>GET</set-method>
		            <set-url>https://apim-gql-test-cartoons.azurewebsites.net/api/family</set-url>
	            </http-request>
            </http-data-source>";

        [Fact]
        [Trait("owner", "shivk")]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // Ids              
                string newApiId = TestUtilities.GenerateName("apiid");
                string newSchemaId = "graphql";
                string newresolverId = TestUtilities.GenerateName("resolverid");

                try
                {
                    // add new api   
                    string newApiName = TestUtilities.GenerateName("apiname");
                    string newApiDescription = TestUtilities.GenerateName("apidescription");
                    string newApiPath = "newapiPath";
                    string newApiServiceUrl = "http://newechoapi.cloudapp.net/api";
                    string subscriptionKeyParametersHeader = TestUtilities.GenerateName("header");
                    string subscriptionKeyQueryStringParamName = TestUtilities.GenerateName("query");

                    var createdApiContract = testBase.client.Api.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        new ApiCreateOrUpdateParameter
                        {
                            ApiType = "graphql",
                            DisplayName = newApiName,
                            Description = newApiDescription,
                            Path = newApiPath,
                            ServiceUrl = newApiServiceUrl,
                            Protocols = new List<string> { Protocol.Https, Protocol.Http },
                            SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract
                            {
                                Header = subscriptionKeyParametersHeader,
                                Query = subscriptionKeyQueryStringParamName
                            }
                        });

                    // check api
                    var apiGetResponse = testBase.client.Api.Get(testBase.rgName, testBase.serviceName, newApiId);
                    Assert.NotNull(apiGetResponse);
                    Assert.Equal(newApiId, apiGetResponse.Name);

                    // add schema
                    var schemaContractParams = new SchemaContract()
                    {
                        ContentType = "application/vnd.ms-azure-apim.graphql.schema",
                        Value = basicSchema,
                    };


                    var schemaContract = await testBase.client.ApiSchema.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        schemaContractParams);

                    // schema check
                    Assert.NotNull(schemaContract);
                    Assert.Equal(schemaContractParams.ContentType, schemaContract.ContentType);


                    // add GraphQL Resolver
                    var resolverContractParams = new ResolverContract(
                        displayName: "resolver_test1",
                        path: "Query/allFamilies",
                        description: "some resolver1"
                        );

                    var createresolverResponse = testBase.client.GraphQLApiResolver.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newresolverId,
                        resolverContractParams);

                    Assert.NotNull(createresolverResponse);

                    // check GraphQL Resolver
                    var getresolverResponse = await testBase.client.GraphQLApiResolver.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newresolverId);

                    Assert.NotNull(getresolverResponse);
                    Assert.NotNull(getresolverResponse.Id);

                    // add GraphQL Resolver Policy
                    var policyDoc = XDocument.Parse(resolverPolicy);

                    var resolverPolicyContract = new PolicyContract()
                    {
                        Value = resolverPolicy.ToString(),
                        Format = "xml"
                    };

                    var resolverPolicyResponse = testBase.client.GraphQLApiResolverPolicy.CreateOrUpdate(
                            testBase.rgName,
                            testBase.serviceName,
                            newApiId,
                            newresolverId,
                            resolverPolicyContract);

                    Assert.NotNull(resolverPolicyResponse);

                    // check GraphQL resolver policy
                    var getresolverPolicyResponse = await testBase.client.GraphQLApiResolverPolicy.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newresolverId,
                        PolicyExportFormat.Xml);

                    Assert.NotNull(getresolverPolicyResponse);
                    Assert.NotNull(getresolverPolicyResponse.Value);

                    // get the policy etag
                    var resolverPolicyTag = await testBase.client.GraphQLApiResolverPolicy.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newresolverId);

                    Assert.NotNull(resolverPolicyTag);
                    Assert.NotNull(resolverPolicyTag.ETag);

                    // remove policy
                    testBase.client.GraphQLApiResolverPolicy.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newresolverId,
                        resolverPolicyTag.ETag);

                    // get policy to check it was removed
                    try
                    {
                        testBase.client.GraphQLApiResolverPolicy.Get(
                            testBase.rgName,
                            testBase.serviceName,
                            newApiId,
                            newresolverId);
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }

                    // get the etag for resolver 
                    var resolverTag = await testBase.client.GraphQLApiResolver.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newresolverId);
                    Assert.NotNull(resolverTag);
                    Assert.NotNull(resolverTag.ETag);

                    // delete the resolver
                    await testBase.client.GraphQLApiResolver.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newresolverId,
                        resolverTag.ETag);

                    // get the schema tag
                    var schemaTag = await testBase.client.ApiSchema.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId);
                    Assert.NotNull(schemaTag);
                    Assert.NotNull(schemaTag.ETag);

                    // delete the schema
                    await testBase.client.ApiSchema.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        schemaTag.ETag);
                    Assert.NotNull(schemaContract);
                    Assert.Equal(schemaContractParams.ContentType, schemaContract.ContentType);

                    // check the entity is deleted
                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.ApiSchema.Get(testBase.rgName, testBase.serviceName, newApiId, newSchemaId));

                    // delete the api
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        "*");

                    // get the deleted api to make sure it was deleted
                    try
                    {
                        testBase.client.Api.Get(testBase.rgName, testBase.serviceName, newApiId);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    //delete the resolver
                    await testBase.client.GraphQLApiResolver.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newresolverId,
                        "*");

                    // delete the apischema 
                    await testBase.client.ApiSchema.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        "*");

                    // delete the api
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        "*");
                }
            }
        }
    }
}
