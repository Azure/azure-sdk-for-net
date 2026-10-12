// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppContainers.Models
{
    // TODO: Remove this suppression when https://github.com/Azure/azure-sdk-for-net/issues/57525 is fixed.
    // The TypeSpec model uses an intentionally empty LogicAppProperties envelope. The generator keeps that
    // empty envelope internal, so suppress the public model-factory overload that would expose the internal type.
    [CodeGenSuppress("LogicAppData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(ContainerAppLogicAppConfiguration))]
    public static partial class ArmAppContainersModelFactory
    {
        // The generated affinity type changed, so preserve the shipped model-factory overload and convert to the new type.
        /// <summary> Initializes a new instance of <see cref="Models.ContainerAppIngressConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future version. Use the overload accepting StickySessionAffinity instead.", false)]
        public static ContainerAppIngressConfiguration ContainerAppIngressConfiguration(string fqdn = default, bool? external = default, int? targetPort = default, int? exposedPort = default, ContainerAppIngressTransportMethod? transport = default, IEnumerable<ContainerAppRevisionTrafficWeight> traffic = default, IEnumerable<ContainerAppCustomDomain> customDomains = default, bool? allowInsecure = default, IEnumerable<ContainerAppIPSecurityRestrictionRule> ipSecurityRestrictions = default, Affinity? stickySessionsAffinity = default, ContainerAppIngressClientCertificateMode? clientCertificateMode = default, ContainerAppCorsPolicy corsPolicy = default, IEnumerable<IngressPortMapping> additionalPortMappings = default)
        {
            return ContainerAppIngressConfiguration(
                fqdn: fqdn,
                external: external,
                targetPort: targetPort,
                exposedPort: exposedPort,
                transport: transport,
                traffic: traffic,
                customDomains: customDomains,
                allowInsecure: allowInsecure,
                ipSecurityRestrictions: ipSecurityRestrictions,
                stickySessionAffinity: stickySessionsAffinity.HasValue ? new StickySessionAffinity(stickySessionsAffinity.Value.ToString()) : null,
                clientCertificateMode: clientCertificateMode,
                corsPolicy: corsPolicy,
                additionalPortMappings: additionalPortMappings);
        }

        // The generated affinity type changed, so preserve the older shipped model-factory overload and convert to the new type.
        /// <summary> Initializes a new instance of <see cref="Models.ContainerAppIngressConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future version. Use the overload accepting StickySessionAffinity instead.", false)]
        public static ContainerAppIngressConfiguration ContainerAppIngressConfiguration(string fqdn, bool? external, int? targetPort, int? exposedPort, ContainerAppIngressTransportMethod? transport, IEnumerable<ContainerAppRevisionTrafficWeight> traffic, IEnumerable<ContainerAppCustomDomain> customDomains, bool? allowInsecure, IEnumerable<ContainerAppIPSecurityRestrictionRule> ipSecurityRestrictions, Affinity? stickySessionsAffinity, ContainerAppIngressClientCertificateMode? clientCertificateMode, ContainerAppCorsPolicy corsPolicy)
        {
            return ContainerAppIngressConfiguration(
                fqdn: fqdn,
                external: external,
                targetPort: targetPort,
                exposedPort: exposedPort,
                transport: transport,
                traffic: traffic,
                customDomains: customDomains,
                allowInsecure: allowInsecure,
                ipSecurityRestrictions: ipSecurityRestrictions,
                stickySessionAffinity: stickySessionsAffinity.HasValue ? new StickySessionAffinity(stickySessionsAffinity.Value.ToString()) : null,
                clientCertificateMode: clientCertificateMode,
                corsPolicy: corsPolicy,
                additionalPortMappings: default);
        }
    }
}
