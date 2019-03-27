// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using ManagedServices.Tests.Helpers;
using Microsoft.Azure.Management.ManagedServices;
using Microsoft.Azure.Management.ManagedServices.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net;
using System.Threading;
using Authorization = Microsoft.Azure.Management.ManagedServices.Models.Authorization;

namespace ManagedServices.Tests.Helpers
{
    public static class ManagedServicesTestUtilities
    {

        public static string registratonDefinitionId = "0cb6fbd6-90df-4923-9d92-c266f6c27bba",
                registrationAssignmentId = "46c2a6a8-3dda-49ae-bc99-ecc5d28dd98a",
                subscriptionId = "45062c92-741a-4e9b-acc4-f0afbfce9c7a",
                apiVersion = "2018-06-01-preview",
                scope = string.Format("subscriptions/{0}", subscriptionId),
                planName = "planName",
                publisher = "publisher",
                product = "product",
                version = "1.0.0",
                defintionDesctiption = "Registration Defintion Description",
                principalId = "1445e20d-2d4f-4616-9c19-564f4a963499",
                roleDefinitionId = "acdd72a7-3385-48ef-bd42-f606fba81ae7",
                registrationDefinitionName = "registrationDefinitionName",
                managedByTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";

        public static RegistrationDefinition GetRegistrationDefintion()
        {
            return new RegistrationDefinition(
                properties: ManagedServicesTestUtilities.GetRegistrationDefinitionProperties(),
                plan: ManagedServicesTestUtilities.GetPlan());
        }
 
        public static RegistrationDefinitionProperties GetRegistrationDefinitionProperties()
        {
            return new RegistrationDefinitionProperties(
                description: defintionDesctiption,
                authorizations: ManagedServicesTestUtilities.GetAuthorizations(),
                registrationDefinitionName: registrationDefinitionName,
                managedByTenantId: managedByTenantId);
        }

        public static Plan GetPlan()
        {
            return new Plan(
                name: planName,
                publisher: publisher,
                product: product,
                version: version);
        }

        public static Authorization[] GetAuthorizations()
        {
            return new Authorization[]
            {
                new Authorization(
                    principalId: principalId,
                    roleDefinitionId: roleDefinitionId)                
            };
        }

        public static RegistrationAssignment GetRegistrationAssignment()
        {
            return new RegistrationAssignment()
            {                
                Properties = ManagedServicesTestUtilities.GetRegistrationAssignmentProperties()
            };
        }

        public static RegistrationAssignmentProperties GetRegistrationAssignmentProperties()
        {
            return new RegistrationAssignmentProperties()
            {
                RegistrationDefinitionId = string.Format("{0}/providers/Microsoft.ManagedServices/registrationdefinitions/{1}", ManagedServicesTestUtilities.scope, ManagedServicesTestUtilities.registratonDefinitionId)
            };
        }
    }
}