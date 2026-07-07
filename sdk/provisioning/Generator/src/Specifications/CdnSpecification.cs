// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Cdn;
using Azure.ResourceManager.Cdn.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class CdnSpecification() :
    Specification("Cdn", typeof(CdnExtensions), serviceDirectory: "cdn")
{
    protected override void Customize()
    {
        CustomizeResource<ProfileResource>(r =>
        {
            r.Name = "CdnProfile";
        });

        // Resource name requirements (see issue #58181). Only resources with
        // validated constraints (Bicep API reference or Azure portal) are listed
        // here so that we don't pin down limits we haven't verified.
        AddNameRequirements<ProfileResource>(
            max: 260,
            min: 1,
            lower: true,
            upper: true,
            digits: true,
            hyphen: true,
            underscore: false,
            period: false,
            parens: false);
        AddNameRequirements<FrontDoorEndpointResource>(
            max: 46,
            min: 1,
            lower: true,
            upper: true,
            digits: true,
            hyphen: true,
            underscore: false,
            period: false,
            parens: false);
        AddNameRequirements<FrontDoorOriginGroupResource>(
            max: 90,
            min: 1,
            lower: true,
            upper: true,
            digits: true,
            hyphen: true,
            underscore: false,
            period: false,
            parens: false);
        AddNameRequirements<FrontDoorOriginResource>(
            max: 90,
            min: 1,
            lower: true,
            upper: true,
            digits: true,
            hyphen: true,
            underscore: false,
            period: false,
            parens: false);
        AddNameRequirements<FrontDoorRouteResource>(
            max: 90,
            min: 1,
            lower: true,
            upper: true,
            digits: true,
            hyphen: true,
            underscore: false,
            period: false,
            parens: false);

        // DeliveryRuleAction subtypes (discriminator: "name")
        CustomizeSimpleModel<DeliveryRuleCacheExpirationAction>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "CacheExpiration"; });
        CustomizeSimpleModel<DeliveryRuleCacheKeyQueryStringAction>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "CacheKeyQueryString"; });
        CustomizeSimpleModel<DeliveryRuleRequestHeaderAction>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "ModifyRequestHeader"; });
        CustomizeSimpleModel<DeliveryRuleResponseHeaderAction>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "ModifyResponseHeader"; });
        CustomizeSimpleModel<DeliveryRuleRouteConfigurationOverrideAction>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "RouteConfigurationOverride"; });
        CustomizeSimpleModel<OriginGroupOverrideAction>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "OriginGroupOverride"; });
        CustomizeSimpleModel<UriRedirectAction>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "UrlRedirect"; });
        CustomizeSimpleModel<UriRewriteAction>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "UrlRewrite"; });
        CustomizeSimpleModel<UriSigningAction>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "UrlSigning"; });

        // DeliveryRuleCondition subtypes (discriminator: "name")
        CustomizeSimpleModel<DeliveryRuleClientPortCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "ClientPort"; });
        CustomizeSimpleModel<DeliveryRuleCookiesCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "Cookies"; });
        CustomizeSimpleModel<DeliveryRuleHostNameCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "HostName"; });
        CustomizeSimpleModel<DeliveryRuleHttpVersionCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "HttpVersion"; });
        CustomizeSimpleModel<DeliveryRuleIsDeviceCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "IsDevice"; });
        CustomizeSimpleModel<DeliveryRulePostArgsCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "PostArgs"; });
        CustomizeSimpleModel<DeliveryRuleQueryStringCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "QueryString"; });
        CustomizeSimpleModel<DeliveryRuleRemoteAddressCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "RemoteAddress"; });
        CustomizeSimpleModel<DeliveryRuleRequestBodyCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "RequestBody"; });
        CustomizeSimpleModel<DeliveryRuleRequestHeaderCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "RequestHeader"; });
        CustomizeSimpleModel<DeliveryRuleRequestMethodCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "RequestMethod"; });
        CustomizeSimpleModel<DeliveryRuleRequestSchemeCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "RequestScheme"; });
        CustomizeSimpleModel<DeliveryRuleRequestUriCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "RequestUri"; });
        CustomizeSimpleModel<DeliveryRuleServerPortCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "ServerPort"; });
        CustomizeSimpleModel<DeliveryRuleSocketAddressCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "SocketAddr"; });
        CustomizeSimpleModel<DeliveryRuleSslProtocolCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "SslProtocol"; });
        CustomizeSimpleModel<DeliveryRuleUriFileExtensionCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "UrlFileExtension"; });
        CustomizeSimpleModel<DeliveryRuleUriFileNameCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "UrlFileName"; });
        CustomizeSimpleModel<DeliveryRuleUriPathCondition>(m => { m.DiscriminatorName = "name"; m.DiscriminatorValue = "UrlPath"; });

        // FrontDoorSecretProperties subtypes (discriminator: "type")
        CustomizeSimpleModel<AzureFirstPartyManagedCertificateProperties>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "AzureFirstPartyManagedCertificate"; });
        CustomizeSimpleModel<CustomerCertificateProperties>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "CustomerCertificate"; });
        CustomizeSimpleModel<ManagedCertificateProperties>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "ManagedCertificate"; });
        CustomizeSimpleModel<UriSigningKeyProperties>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "UrlSigningKey"; });

        // CustomDomainHttpsContent subtypes (discriminator: "certificateSource")
        CustomizeSimpleModel<CdnManagedHttpsContent>(m => { m.DiscriminatorName = "certificateSource"; m.DiscriminatorValue = "Cdn"; });
        CustomizeSimpleModel<UserManagedHttpsContent>(m => { m.DiscriminatorName = "certificateSource"; m.DiscriminatorValue = "AzureKeyVault"; });

        // SecurityPolicyProperties subtypes (discriminator: "type")
        CustomizeSimpleModel<SecurityPolicyWebApplicationFirewall>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "WebApplicationFirewall"; });
    }
}
