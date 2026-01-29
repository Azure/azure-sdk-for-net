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
    public partial class Sample_ResourceRecommendationBaseResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetRecommendationDetail()
        {
            // Generated from example definition: specification/advisor/resource-manager/Microsoft.Advisor/stable/2020-01-01/examples/GetRecommendationDetail.json
            // this example is just showing the usage of "Recommendations_Get" operation, for the dependent resources, they will have to be created separately.

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

            // invoke the operation
            AdvisorRecommendationResource result = await resourceRecommendationBase.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            AdvisorRecommendationData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
