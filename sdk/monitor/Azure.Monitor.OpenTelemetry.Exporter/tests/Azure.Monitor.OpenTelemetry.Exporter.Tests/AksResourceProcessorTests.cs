// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests;

public class AksResourceProcessorTests
{
    public static TheoryData<KeyValuePair<string, object>> K8sAttributesData
    {
        get
        {
            var data = new TheoryData<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(SemanticConventions.AttributeK8sCronJob, "cronjobname"),
                new KeyValuePair<string, object>(SemanticConventions.AttributeK8sDaemonSet, "daemonsetname"),
                new KeyValuePair<string, object>(SemanticConventions.AttributeK8sDeployment, "deploymentname"),
                new KeyValuePair<string, object>(SemanticConventions.AttributeK8sJob, "jobname"),
                new KeyValuePair<string, object>(SemanticConventions.AttributeK8sPod, "podname"),
                new KeyValuePair<string, object>(SemanticConventions.AttributeK8sReplicaSet, "replicasetname"),
                new KeyValuePair<string, object>(SemanticConventions.AttributeK8sStatefulSet, "statefulsetname")
            };

            return data;
        }
    }

    [Theory]
    [MemberData(nameof(K8sAttributesData))]
    public void AksResourceProcessor_MapsAttributeToProperty(KeyValuePair<string, object> attribute)
    {
        // Arrange
        var aksResourceProcessor = new AksResourceProcessor();

        // Act
        aksResourceProcessor.MapAttributeToProperty(attribute);

        // Assert
        switch (attribute.Key)
        {
            case "k8s.deployment.name":
                Assert.Equal(attribute.Value, aksResourceProcessor.K8sDeploymentName);
                break;
            case "k8s.replicaset.name":
                Assert.Equal(attribute.Value, aksResourceProcessor.K8sReplicaSetName);
                break;
            case "k8s.statefulset.name":
                Assert.Equal(attribute.Value, aksResourceProcessor.K8sStatefulSetName);
                break;
            case "k8s.job.name":
                Assert.Equal(attribute.Value, aksResourceProcessor.K8sJobName);
                break;
            case "k8s.cronjob.name":
                Assert.Equal(attribute.Value, aksResourceProcessor.K8sCronjobName);
                break;
            case "k8s.daemonset.name":
                Assert.Equal(attribute.Value, aksResourceProcessor.K8sDaemonSetName);
                break;
            case "k8s.pod.name":
                Assert.Equal(attribute.Value, aksResourceProcessor.K8sPodName);
                break;
        }
    }

    public static TheoryData<string?, string?, string?, string?, string?, string?, string?> RoleNameTestData()
    {
        var data = new TheoryData<string?, string?, string?, string?, string?, string?, string?>
        {
            { "my-deployment", null, null, null, null, null, "my-deployment" },
            { null, "my-replicaset", null, null, null, null, "my-replicaset" },
            { null, null, "my-statefulset", null, null, null, "my-statefulset" },
            { null, null, null, "my-job", null, null, "my-job" },
            { null, null, null, null, "my-cronjob", null, "my-cronjob" },
            { null, null, null, null, null, "my-daemonset", "my-daemonset" },
            { "my-deployment", "my-replicaset", null, null, null, null, "my-deployment" },
            { null, null, "my-statefulset", "my-job", null, null, "my-statefulset" },
            { null, null, null, null, "my-cronjob", "my-daemonset", "my-cronjob" },
            { "my-deployment", "my-replicaset", "my-statefulset", null, "my-cronjob", "my-daemonset", "my-deployment" },
            { null, null, null, null, null, null, null },
            { "", "", "", "", "", "", null },
            { "", "my-replicaset", "", "my-job", "my-cronjob", "", "my-replicaset" },
            { "my-deployment", "", "", "", "my-cronjob", "my-daemonset", "my-deployment" }
        };

        return data;
    }

    [Theory]
    [MemberData(nameof(RoleNameTestData))]
    public void GetRoleName_ReturnsExpectedValue(string deployment, string replicaSet, string statefulSet, string job, string cronjob, string daemonSet, string expectedRoleName)
    {
        // Arrange
        var aksResourceProcessor = new AksResourceProcessor();
        aksResourceProcessor.K8sDeploymentName = deployment;
        aksResourceProcessor.K8sReplicaSetName = replicaSet;
        aksResourceProcessor.K8sStatefulSetName = statefulSet;
        aksResourceProcessor.K8sJobName = job;
        aksResourceProcessor.K8sCronjobName = cronjob;
        aksResourceProcessor.K8sDaemonSetName = daemonSet;

        // Act
        var roleName = aksResourceProcessor.GetRoleName();

        // Assert
        Assert.Equal(expectedRoleName, roleName);
    }

    public static TheoryData<string?, string?> RoleInstanceTestData()
    {
        var data = new TheoryData<string?, string?>
        {
            { "my-pod", "my-pod" },
            { null, null },
            { string.Empty, null }
        };

        return data;
    }

    [Theory]
    [MemberData(nameof(RoleInstanceTestData))]
    public void GetRoleInstance_ReturnsExpectedValue(string podName, string expectedRoleInstance)
    {
        // Arrange
        var aksResourceProcessor = new AksResourceProcessor();
        aksResourceProcessor.K8sPodName = podName;

        // Act
        var roleInstance = aksResourceProcessor.GetRoleInstance();

        // Assert
        Assert.Equal(expectedRoleInstance, roleInstance);
    }
}
