// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.ResourceManager.Advisor.Samples
{
    public partial class Sample_SuppressionContractCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateOrUpdate_CreateSuppression()
        {
            // Generated from example definition: specification/advisor/resource-manager/Microsoft.Advisor/stable/2020-01-01/examples/CreateSuppression.json
            // this example is just showing the usage of "Suppressions_Create" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AdvisorRecommendationResource created on azure
            // for more information of creating AdvisorRecommendationResource, please refer to the document of AdvisorRecommendationResource
            string resourceUri = "resourceUri";
            string recommendationId = "recommendationId";
            ResourceIdentifier resourceRecommendationBaseResourceId = AdvisorRecommendationResource.CreateResourceIdentifier(resourceUri, recommendationId);
            AdvisorRecommendationResource resourceRecommendationBase = client.GetAdvisorRecommendationResource(resourceRecommendationBaseResourceId);

            // get the collection of this SuppressionContractResource
            AdvisorSuppressionContractCollection collection = resourceRecommendationBase.GetAdvisorSuppressionContracts();

            // invoke the operation
            string name = "suppressionName1";
            AdvisorSuppressionContractData data = new AdvisorSuppressionContractData
            {
                Ttl = "07:00:00:00",
            };
            ArmOperation<AdvisorSuppressionContractResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            AdvisorSuppressionContractResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AdvisorSuppressionContractData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetSuppressionDetail()
        {
            // Generated from example definition: specification/advisor/resource-manager/Microsoft.Advisor/stable/2020-01-01/examples/GetSuppressionDetail.json
            // this example is just showing the usage of "Suppressions_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AdvisorRecommendationResource created on azure
            // for more information of creating AdvisorRecommendationResource, please refer to the document of AdvisorRecommendationResource
            string resourceUri = "resourceUri";
            string recommendationId = "recommendationId";
            ResourceIdentifier resourceRecommendationBaseResourceId = AdvisorRecommendationResource.CreateResourceIdentifier(resourceUri, recommendationId);
            AdvisorRecommendationResource resourceRecommendationBase = client.GetAdvisorRecommendationResource(resourceRecommendationBaseResourceId);

            // get the collection of this SuppressionContractResource
            AdvisorSuppressionContractCollection collection = resourceRecommendationBase.GetAdvisorSuppressionContracts();

            // invoke the operation
            string name = "suppressionName1";
            AdvisorSuppressionContractResource result = await collection.GetAsync(name);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AdvisorSuppressionContractData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_GetSuppressionDetail()
        {
            // Generated from example definition: specification/advisor/resource-manager/Microsoft.Advisor/stable/2020-01-01/examples/GetSuppressionDetail.json
            // this example is just showing the usage of "Suppressions_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AdvisorRecommendationResource created on azure
            // for more information of creating AdvisorRecommendationResource, please refer to the document of AdvisorRecommendationResource
            string resourceUri = "resourceUri";
            string recommendationId = "recommendationId";
            ResourceIdentifier resourceRecommendationBaseResourceId = AdvisorRecommendationResource.CreateResourceIdentifier(resourceUri, recommendationId);
            AdvisorRecommendationResource resourceRecommendationBase = client.GetAdvisorRecommendationResource(resourceRecommendationBaseResourceId);

            // get the collection of this SuppressionContractResource
            AdvisorSuppressionContractCollection collection = resourceRecommendationBase.GetAdvisorSuppressionContracts();

            // invoke the operation
            string name = "suppressionName1";
            bool result = await collection.ExistsAsync(name);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_GetSuppressionDetail()
        {
            // Generated from example definition: specification/advisor/resource-manager/Microsoft.Advisor/stable/2020-01-01/examples/GetSuppressionDetail.json
            // this example is just showing the usage of "Suppressions_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this AdvisorRecommendationResource created on azure
            // for more information of creating AdvisorRecommendationResource, please refer to the document of AdvisorRecommendationResource
            string resourceUri = "resourceUri";
            string recommendationId = "recommendationId";
            ResourceIdentifier resourceRecommendationBaseResourceId = AdvisorRecommendationResource.CreateResourceIdentifier(resourceUri, recommendationId);
            AdvisorRecommendationResource resourceRecommendationBase = client.GetAdvisorRecommendationResource(resourceRecommendationBaseResourceId);

            // get the collection of this SuppressionContractResource
            AdvisorSuppressionContractCollection collection = resourceRecommendationBase.GetAdvisorSuppressionContracts();

            // invoke the operation
            string name = "suppressionName1";
            NullableResponse<AdvisorSuppressionContractResource> response = await collection.GetIfExistsAsync(name);
            AdvisorSuppressionContractResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                AdvisorSuppressionContractData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
