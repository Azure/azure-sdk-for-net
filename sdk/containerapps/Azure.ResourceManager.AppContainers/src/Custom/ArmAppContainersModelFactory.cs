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
    [CodeGenSuppress("ContainerAppConfiguration", typeof(IEnumerable<ContainerAppWritableSecret>), typeof(ContainerAppActiveRevisionsMode?), typeof(string), typeof(ContainerAppIngressConfiguration), typeof(IEnumerable<ContainerAppRegistryCredentials>), typeof(ContainerAppDaprConfiguration), typeof(bool?), typeof(ContainerAppRuntimeJavaAgent), typeof(bool?), typeof(int?), typeof(int?), typeof(string), typeof(IEnumerable<ContainerAppIdentitySettings>))]
    public static partial class ArmAppContainersModelFactory
    {
        /// <param name="secrets"> Collection of secrets used by a Container app. </param>
        /// <param name="activeRevisionsMode"> Controls how active revisions are handled for the Container app. </param>
        /// <param name="targetLabel"> Required in labels revisions mode. Label to apply to newly created revision. </param>
        /// <param name="ingress"> Ingress configurations. </param>
        /// <param name="registries"> Collection of private container registry credentials for containers used by the Container app. </param>
        /// <param name="dapr"> Dapr configuration for the Container App. </param>
        /// <param name="enableMetrics"> Enable jmx core metrics for the java app. </param>
        /// <param name="maxInactiveRevisions"> Optional. Max inactive revisions a Container App can have. </param>
        /// <param name="revisionTransitionThreshold"> Optional. The percent of the total number of replicas that must be brought up before revision transition occurs. Defaults to 100 when none is given. Value must be greater than 0 and less than or equal to 100. </param>
        /// <param name="serviceType"> Dev ContainerApp service type. </param>
        /// <param name="identitySettings"> Optional settings for Managed Identities that are assigned to the Container App. If a Managed Identity is not specified here, default settings will be used. </param>
        /// <returns> A new <see cref="Models.ContainerAppConfiguration"/> instance for mocking. </returns>
        public static ContainerAppConfiguration ContainerAppConfiguration(IEnumerable<ContainerAppWritableSecret> secrets = default, ContainerAppActiveRevisionsMode? activeRevisionsMode = default, string targetLabel = default, ContainerAppIngressConfiguration ingress = default, IEnumerable<ContainerAppRegistryCredentials> registries = default, ContainerAppDaprConfiguration dapr = default, bool? enableMetrics = default, int? maxInactiveRevisions = default, int? revisionTransitionThreshold = default, string serviceType = default, IEnumerable<ContainerAppIdentitySettings> identitySettings = default)
        {
            ContainerAppConfiguration configuration = new ContainerAppConfiguration
            {
                ActiveRevisionsMode = activeRevisionsMode,
                TargetLabel = targetLabel,
                Ingress = ingress,
                Dapr = dapr,
                EnableMetrics = enableMetrics,
                MaxInactiveRevisions = maxInactiveRevisions,
                RevisionTransitionThreshold = revisionTransitionThreshold,
                ServiceType = serviceType
            };

            foreach (ContainerAppWritableSecret secret in secrets ?? Array.Empty<ContainerAppWritableSecret>())
            {
                configuration.Secrets.Add(secret);
            }
            foreach (ContainerAppRegistryCredentials registry in registries ?? Array.Empty<ContainerAppRegistryCredentials>())
            {
                configuration.Registries.Add(registry);
            }
            foreach (ContainerAppIdentitySettings identitySetting in identitySettings ?? Array.Empty<ContainerAppIdentitySettings>())
            {
                configuration.IdentitySettings.Add(identitySetting);
            }

            return configuration;
        }

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
                additionalPortMappings: additionalPortMappings,
                targetPortHttpScheme: default);
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
                additionalPortMappings: default,
                targetPortHttpScheme: default);
        }
    }
}
