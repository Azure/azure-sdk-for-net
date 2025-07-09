// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.CognitiveServices;
using Azure.ResourceManager.CognitiveServices.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class CognitiveServicesSpecification() :
    Specification("CognitiveServices", typeof(CognitiveServicesExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<ServiceAccountEncryptionProperties>("KeyName");
        RemoveProperty<ServiceAccountEncryptionProperties>("KeyVersion");
        RemoveProperty<ServiceAccountEncryptionProperties>("KeyVaultUri");
        RemoveProperty<ServiceAccountEncryptionProperties>("IdentityClientId");
        RemoveProperty<CognitiveServicesPrivateEndpointConnectionData>("ResourceType");

        // Patch models
        CustomizeProperty<ServiceAccountApiKeys>("Key1", p => p.IsSecure = true);
        CustomizeProperty<ServiceAccountApiKeys>("Key2", p => p.IsSecure = true);
        OrderEnum<ModelLifecycleStatus>("GenerallyAvailable", "Preview");

        // Naming requirements
        AddNameRequirements<CognitiveServicesAccountResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true);

        // Roles
        Roles.Add(new Role("AzureAIDeveloper", "64702f94-c441-49e6-a78b-ef80e0188fee", "Can perform all actions within an Azure AI resource besides managing the resource itself."));
        Roles.Add(new Role("AzureAIEnterpriseNetworkConnectionApprover", "b556d68e-0be0-4f35-a333-ad7ee1ce17ea", "Can approve private endpoint connections to Azure AI common dependency resources"));
        Roles.Add(new Role("AzureAIInferenceDeploymentOperator", "3afb7f49-54cb-416e-8c09-6dc049efa503", "Can perform all actions required to create a resource deployment within a resource group."));
        Roles.Add(new Role("CognitiveServicesContributor", "25fbc0a9-bd7c-42a3-aa1a-3b75d497ee68", "Lets you create, read, update, delete and manage keys of Cognitive Services."));
        Roles.Add(new Role("CognitiveServicesCustomVisionContributor", "c1ff6cc2-c111-46fe-8896-e0ef812ad9f3", "Full access to the project, including the ability to view, create, edit, or delete projects."));
        Roles.Add(new Role("CognitiveServicesCustomVisionDeployment", "5c4089e1-6d96-4d2f-b296-c1bc7137275f", "Publish, unpublish or export models. Deployment can view the project but can't update."));
        Roles.Add(new Role("CognitiveServicesCustomVisionLabeler", "88424f51-ebe7-446f-bc41-7fa16989e96c", "View, edit training images and create, add, remove, or delete the image tags. Labelers can view the project but can't update anything other than training images and tags."));
        Roles.Add(new Role("CognitiveServicesCustomVisionReader", "93586559-c37d-4a6b-ba08-b9f0940c2d73", "Read-only actions in the project. Readers can't create or update the project."));
        Roles.Add(new Role("CognitiveServicesCustomVisionTrainer", "0a5ae4ab-0d65-4eeb-be61-29fc9b54394b", "View, edit projects and train the models, including the ability to publish, unpublish, export the models. Trainers can't create or delete the project."));
        Roles.Add(new Role("CognitiveServicesDataReader", "b59867f0-fa02-499b-be73-45a86b5b3e1c", "Lets you read Cognitive Services data."));
        Roles.Add(new Role("CognitiveServicesFaceRecognizer", "9894cab4-e18a-44aa-828b-cb588cd6f2d7", "Lets you perform detect, verify, identify, group, and find similar operations on Face API. This role does not allow create or delete operations, which makes it well suited for endpoints that only need inferencing capabilities, following 'least privilege' best practices."));
        Roles.Add(new Role("CognitiveServicesMetricsAdvisorAdministrator", "cb43c632-a144-4ec5-977c-e80c4affc34a", "Full access to the project, including the system level configuration."));
        Roles.Add(new Role("CognitiveServicesOpenAIContributor", "a001fd3d-188f-4b5d-821b-7da978bf7442", "Full access including the ability to fine-tune, deploy and generate text"));
        Roles.Add(new Role("CognitiveServicesOpenAIUser", "5e0bd9bd-7b93-4f28-af87-19fc36ad61bd", "Read access to view files, models, deployments. The ability to create completion and embedding calls."));
        Roles.Add(new Role("CognitiveServicesQnAMakerEditor", "f4cc2bf9-21be-47a1-bdf1-5c5804381025", "Let's you create, edit, import and export a KB. You cannot publish or delete a KB."));
        Roles.Add(new Role("CognitiveServicesQnAMakerReader", "466ccd10-b268-4a11-b098-b4849f024126", "Let's you read and test a KB only."));
        Roles.Add(new Role("CognitiveServicesUsagesReader", "bba48692-92b0-4667-a9ad-c31c7b334ac2", "Minimal permission to view Cognitive Services usages."));
        Roles.Add(new Role("CognitiveServicesUser", "a97b65f3-24c7-4388-baec-2e87135dc908", "Lets you read and list keys of Cognitive Services."));

        // Assign Roles
        CustomizeResource<CognitiveServicesAccountResource>(r => r.GenerateRoleAssignment = true);
    }
}
