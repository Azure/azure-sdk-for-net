// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterSubscriptionResource
    {
        private ClientDiagnostics _mdeOnboardingsClientDiagnostics;
        private MdeOnboardings _mdeOnboardingsRestClient;

        private ClientDiagnostics MdeOnboardingsClientDiagnostics => _mdeOnboardingsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private MdeOnboardings MdeOnboardingsRestClient => _mdeOnboardingsRestClient ??= new MdeOnboardings(MdeOnboardingsClientDiagnostics, Pipeline, Endpoint, "2021-10-01-preview");

        /// <summary> Gets security center pricings for this subscription. </summary>
        public virtual SecurityCenterPricingCollection GetSecurityCenterPricings()
            => Client.GetSecurityCenterPricings(Id);

        /// <summary> Gets a security center pricing for this subscription. </summary>
        public virtual Response<SecurityCenterPricingResource> GetSecurityCenterPricing(string pricingName, CancellationToken cancellationToken = default)
            => Client.GetSecurityCenterPricing(Id, pricingName, cancellationToken);

        /// <summary> Gets a security center pricing for this subscription. </summary>
        public virtual Task<Response<SecurityCenterPricingResource>> GetSecurityCenterPricingAsync(string pricingName, CancellationToken cancellationToken = default)
            => Client.GetSecurityCenterPricingAsync(Id, pricingName, cancellationToken);

        /// <summary> Gets subscription governance rules for this subscription. </summary>
        public virtual SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules()
            => new SubscriptionGovernanceRuleCollection(Client, Id);

        /// <summary> Gets the configuration or data needed to onboard machines to MDE. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MdeOnboarding> GetMdeOnboardingsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new SecurityCenterCompatibilityAsyncPageable<MdeOnboarding>(
                Pipeline,
                MdeOnboardingsClientDiagnostics,
                context,
                "SubscriptionResource.GetMdeOnboardings",
                (nextLink, requestContext) => MdeOnboardingsRestClient.CreateGetMdeOnboardingsRequest(Guid.Parse(Id.SubscriptionId), requestContext),
                ParseMdeOnboardingList);
        }

        /// <summary> Gets the configuration or data needed to onboard machines to MDE. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<MdeOnboarding> GetMdeOnboardings(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new SecurityCenterCompatibilityPageable<MdeOnboarding>(
                Pipeline,
                MdeOnboardingsClientDiagnostics,
                context,
                "SubscriptionResource.GetMdeOnboardings",
                (nextLink, requestContext) => MdeOnboardingsRestClient.CreateGetMdeOnboardingsRequest(Guid.Parse(Id.SubscriptionId), requestContext),
                ParseMdeOnboardingList);
        }

        /// <summary> Gets the default configuration or data needed to onboard machines to MDE. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MdeOnboarding>> GetMdeOnboardingAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = MdeOnboardingsClientDiagnostics.CreateScope("SubscriptionResource.GetMdeOnboarding");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MdeOnboardingsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(ToMdeOnboarding(MdeOnboardingData.FromResponse(response)), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the default configuration or data needed to onboard machines to MDE. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MdeOnboarding> GetMdeOnboarding(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = MdeOnboardingsClientDiagnostics.CreateScope("SubscriptionResource.GetMdeOnboarding");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = MdeOnboardingsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(ToMdeOnboarding(MdeOnboardingData.FromResponse(response)), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static (IReadOnlyList<MdeOnboarding> Values, string NextLink) ParseMdeOnboardingList(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            List<MdeOnboarding> values = new List<MdeOnboarding>();
            string nextLink = null;
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        values.Add(ToMdeOnboarding(MdeOnboardingData.DeserializeMdeOnboardingData(item, ModelSerializationExtensions.WireOptions)));
                    }
                }
                else if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                }
            }
            return (values, nextLink);
        }

        private static MdeOnboarding ToMdeOnboarding(MdeOnboardingData data)
        {
            return new MdeOnboarding
            {
                OnboardingPackageLinux = data?.OnboardingPackageLinux?.ToArray(),
                OnboardingPackageWindows = data?.OnboardingPackageWindows?.ToArray()
            };
        }
    }
}
