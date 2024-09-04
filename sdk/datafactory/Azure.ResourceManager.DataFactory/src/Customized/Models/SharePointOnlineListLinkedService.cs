// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> SharePoint Online List linked service. </summary>
    public partial class SharePointOnlineListLinkedService : DataFactoryLinkedServiceProperties
    {
        /// <summary> Initializes a new instance of <see cref="SharePointOnlineListLinkedService"/>. </summary>
        /// <param name="siteUri"> The URL of the SharePoint Online site. For example, https://contoso.sharepoint.com/sites/siteName. Type: string (or Expression with resultType string). </param>
        /// <param name="tenantId"> The tenant ID under which your application resides. You can find it from Azure portal Active Directory overview page. Type: string (or Expression with resultType string). </param>
        /// <param name="servicePrincipalId"> The application (client) ID of your application registered in Azure Active Directory. Make sure to grant SharePoint site permission to this application. Type: string (or Expression with resultType string). </param>
        /// <param name="servicePrincipalKey"> The client secret of your application registered in Azure Active Directory. Type: string (or Expression with resultType string). </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteUri"/>, <paramref name="tenantId"/>, <paramref name="servicePrincipalId"/> or <paramref name="servicePrincipalKey"/> is null. </exception>
        public SharePointOnlineListLinkedService(DataFactoryElement<string> siteUri, DataFactoryElement<string> tenantId, DataFactoryElement<string> servicePrincipalId, Core.Expressions.DataFactory.DataFactorySecret servicePrincipalKey)
        {
            Argument.AssertNotNull(siteUri, nameof(siteUri));
            Argument.AssertNotNull(tenantId, nameof(tenantId));
            Argument.AssertNotNull(servicePrincipalId, nameof(servicePrincipalId));
            Argument.AssertNotNull(servicePrincipalKey, nameof(servicePrincipalKey));

            SiteUri = siteUri;
            TenantId = tenantId;
            ServicePrincipalId = servicePrincipalId;
            ServicePrincipalKey = servicePrincipalKey;
            LinkedServiceType = "SharePointOnlineList";
        }
    }
}
