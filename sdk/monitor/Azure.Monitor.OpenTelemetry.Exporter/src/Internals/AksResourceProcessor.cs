// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals;

internal sealed class AksResourceProcessor
{
    private static readonly Dictionary<string, Action<AksResourceProcessor, string>> s_propertySetters = new(7)
    {
        { SemanticConventions.AttributeK8sCronJob, (parser, value) => parser.K8sCronjobName = value },
        { SemanticConventions.AttributeK8sDaemonSet, (parser, value) => parser.K8sDaemonSetName = value },
        { SemanticConventions.AttributeK8sDeployment, (parser, value) => parser.K8sDeploymentName = value },
        { SemanticConventions.AttributeK8sJob, (parser, value) => parser.K8sJobName = value },
        { SemanticConventions.AttributeK8sPod, (parser, value) => parser.K8sPodName = value },
        { SemanticConventions.AttributeK8sReplicaSet, (parser, value) => parser.K8sReplicaSetName = value },
        { SemanticConventions.AttributeK8sStatefulSet, (parser, value) => parser.K8sStatefulSetName = value }
    };

    public string? K8sCronjobName { get; set; } = null;

    public string? K8sDaemonSetName { get; set; } = null;

    public string? K8sDeploymentName { get; set; } = null;

    public string? K8sJobName { get; set; } = null;

    public string? K8sPodName { get; set; } = null;

    public string? K8sReplicaSetName { get; set; } = null;

    public string? K8sStatefulSetName { get; set; } = null;

     public string? GetRoleName()
    {
        if (!string.IsNullOrEmpty(K8sDeploymentName))
        {
            return K8sDeploymentName;
        }
        else if (!string.IsNullOrEmpty(K8sReplicaSetName))
        {
            return K8sReplicaSetName;
        }
        else if (!string.IsNullOrEmpty(K8sStatefulSetName))
        {
            return K8sStatefulSetName;
        }
        else if (!string.IsNullOrEmpty(K8sJobName))
        {
            return K8sJobName;
        }
        else if (!string.IsNullOrEmpty(K8sCronjobName))
        {
            return K8sCronjobName;
        }
        else if (!string.IsNullOrEmpty(K8sDaemonSetName))
        {
            return K8sDaemonSetName;
        }

        return null;
    }

    public string? GetRoleInstance()
    {
        return string.IsNullOrEmpty(K8sPodName) ? null : K8sPodName;
    }

    public void MapAttributeToProperty(KeyValuePair<string, object> aksAttribute)
    {
        if (s_propertySetters.TryGetValue(aksAttribute.Key, out var setter))
        {
            if (aksAttribute.Value is string value)
            {
                setter(this, value);
            }
        }
    }
}
