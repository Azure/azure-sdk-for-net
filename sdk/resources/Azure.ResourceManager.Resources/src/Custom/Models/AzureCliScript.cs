// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class AzureCliScript : ArmDeploymentScriptData
    {
        /// <summary> Container group name, if not specified then the name will get auto-generated. Not specifying a 'containerGroupName' indicates the system to generate a unique name which might end up flagging an Azure Policy as non-compliant. Use 'containerGroupName' when you have an Azure Policy that expects a specific naming convention or when you want to fully control the name. 'containerGroupName' property must be between 1 and 63 characters long, must contain only lowercase letters, numbers, and dashes and it cannot start or end with a dash and consecutive dashes are not allowed. To specify a 'containerGroupName', add the following object to properties: { "containerSettings": { "containerGroupName": "contoso-container" } }. If you do not want to specify a 'containerGroupName' then do not add 'containerSettings' property. </summary>
        [WirePath("properties.containerSettings.containerGroupName")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ContainerGroupName
        {
            get => ContainerSettings is null ? default : ContainerSettings.ContainerGroupName;
            set
            {
                if (ContainerSettings is null)
                    ContainerSettings = new ScriptContainerConfiguration();
                ContainerSettings.ContainerGroupName = value;
            }
        }
    }
}
