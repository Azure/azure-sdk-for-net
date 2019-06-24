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
                subscriptionId = "38bd4bef-41ff-45b5-b3af-d03e55a4ca15",
                apiVersion = "2019-06-01",
                scope = string.Format("subscriptions/{0}", subscriptionId),
                planName = "planName",
                publisher = "publisher",
                product = "product",
                version = "1.0.0",
                defintionDescription = "Registration Defintion Description",
                principalId = "d6f6c88a-5b7a-455e-ba40-ce146d4d3671",
                roleDefinitionId = "acdd72a7-3385-48ef-bd42-f606fba81ae7",
                registrationDefinitionName = "registrationDefinitionName",
                managedByTenantId = "bab3375b-6197-4a15-a44b-16c41faa91d7";

        public static RegistrationDefinition GetRegistrationDefintion()
        {
            return new RegistrationDefinition(
                properties: ManagedServicesTestUtilities.GetRegistrationDefinitionProperties());
        }
 
        public static RegistrationDefinitionProperties GetRegistrationDefinitionProperties()
        {
            return new RegistrationDefinitionProperties(
                description: defintionDescription,
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