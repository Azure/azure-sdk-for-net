// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Intune.Models;

namespace Microsoft.Azure.Management.Intune.Tests.Helpers
{
    /// <summary>
    /// Types of Links to Intune Policies
    /// </summary>
    public enum LinkType{
        AppType,
        GroupType
    }

    /// <summary>
    /// Prepares payload for link requests of type:group/app for an Intune policy
    /// </summary>
    public class AppOrGroupPayloadMaker
    {
        public static string AppUriFormat = "https://{0}/providers/Microsoft.Intune/locations/{1}/apps/{2}";
        public static string GroupUriFormat = "https://{0}/providers/Microsoft.Intune/locations/{1}/groups/{2}";

        public static MAMPolicyAppIdOrGroupIdPayload PrepareMAMPolicyPayload(IIntuneResourceManagementClient client, LinkType type, string name)
        {
            string uriFormat = LinkType.AppType == type ? AppUriFormat : GroupUriFormat;            
            string uri = string.Format(uriFormat, client.BaseUri.Host, IntuneClientHelper.AsuHostName, name);
            var payload = new MAMPolicyAppIdOrGroupIdPayload();
            payload.Properties = new MAMPolicyAppOrGroupIdProperties()
            {
                Url = uri
            };

            return payload;
        }
    }
}
