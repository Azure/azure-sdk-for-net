// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

namespace OpenTelemetry.Trace;

internal static class ResourceSemanticConventions
{
    public const string AttributeServiceName = "service.name";
    public const string AttributeServiceNamespace = "service.namespace";
    public const string AttributeServiceInstance = "service.instance.id";
    public const string AttributeServiceVersion = "service.version";

    public const string AttributeTelemetrySdkName = "telemetry.sdk.name";
    public const string AttributeTelemetrySdkLanguage = "telemetry.sdk.language";
    public const string AttributeTelemetrySdkVersion = "telemetry.sdk.version";

    public const string AttributeContainerName = "container.name";
    public const string AttributeContainerImage = "container.image.name";
    public const string AttributeContainerTag = "container.image.tag";

    public const string AttributeFaasName = "faas.name";
    public const string AttributeFaasId = "faas.id";
    public const string AttributeFaasVersion = "faas.version";
    public const string AttributeFaasInstance = "faas.instance";

    public const string AttributeK8sCluster = "k8s.cluster.name";
    public const string AttributeK8sNamespace = "k8s.namespace.name";
    public const string AttributeK8sPod = "k8s.pod.name";
    public const string AttributeK8sDeployment = "k8s.deployment.name";

    public const string AttributeHostHostname = "host.hostname";
    public const string AttributeHostId = "host.id";
    public const string AttributeHostName = "host.name";
    public const string AttributeHostType = "host.type";
    public const string AttributeHostImageName = "host.image.name";
    public const string AttributeHostImageId = "host.image.id";
    public const string AttributeHostImageVersion = "host.image.version";

    public const string AttributeProcessId = "process.id";
    public const string AttributeProcessExecutableName = "process.executable.name";
    public const string AttributeProcessExecutablePath = "process.executable.path";
    public const string AttributeProcessCommand = "process.command";
    public const string AttributeProcessCommandLine = "process.command_line";
    public const string AttributeProcessUsername = "process.username";

    public const string AttributeCloudAccount = "cloud.account.id";
    public const string AttributeCloudAvailabilityZone = "cloud.availability_zone";
    public const string AttributeCloudPlatform = "cloud.platform";
    public const string AttributeCloudProvider = "cloud.provider";
    public const string AttributeCloudRegion = "cloud.region";
    public const string AttributeCloudResourceId = "cloud.resource_id";
    public const string AttributeCloudZone = "cloud.zone";
    public const string AttributeComponent = "component";

    public const string AttributeOsType = "os.type";
    public const string AttributeOsVersion = "os.version";

    public const string AttributeDeploymentEnvironment = "deployment.environment";
}
