// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Common properties for the deployment script. </summary>
    [CodeGenSuppress("ContainerGroupName")]
    internal partial class ArmDeploymentScriptPropertiesBase
    {
        /// <summary> Container group name, if not specified then the name will get auto-generated. Not specifying a &apos;containerGroupName&apos; indicates the system to generate a unique name which might end up flagging an Azure Policy as non-compliant. Use &apos;containerGroupName&apos; when you have an Azure Policy that expects a specific naming convention or when you want to fully control the name. &apos;containerGroupName&apos; property must be between 1 and 63 characters long, must contain only lowercase letters, numbers, and dashes and it cannot start or end with a dash and consecutive dashes are not allowed. To specify a &apos;containerGroupName&apos;, add the following object to properties: { &quot;containerSettings&quot;: { &quot;containerGroupName&quot;: &quot;contoso-container&quot; } }. If you do not want to specify a &apos;containerGroupName&apos; then do not add &apos;containerSettings&apos; property. </summary>
        public string ContainerGroupName
        {
            get => ContainerSettings?.ContainerGroupName;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => ContainerSettings.ContainerGroupName = value;
        }
    }
}
