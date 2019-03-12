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

        public static string registratonDefinitionId = Guid.NewGuid().ToString(),
                registrationAssignmentId = Guid.NewGuid().ToString(),
                subscriptionId = Guid.NewGuid().ToString(),
                apiVersion = "2018-06-01-preview",
                scope = string.Format("subscriptions/{0}", subscriptionId),
                planName = "planName",
                publisher = "publisher",
                product = "product",
                version = "1.0.0",
                defintionDesctiption = "Registration Defintion Description",
                principalId = Guid.NewGuid().ToString(),
                roleDefinitionId = "acdd72a7-3385-48ef-bd42-f606fba81ae7",
                registrationDefinitionName = "registrationDefinitionName",
                managedByTenantId = Guid.NewGuid().ToString();

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