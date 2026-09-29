// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ApplicationInsights.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApplicationInsights
{
    // The read data model and the ApplicationInsightsWorkbookTemplatePatch both flatten
    // the same shared WorkbookTemplateProperties.localized. The shipped GA (1.1.0) SDK
    // exposes it as LocalizedGalleries on the read data but keeps Localized on the patch,
    // which a single client-name rename cannot express. So the generated (default) name
    // Localized is kept for the patch, and here we rename it to LocalizedGalleries only
    // on the read data model to match GA.
    [CodeGenSuppress("Localized")]
    public partial class ApplicationInsightsWorkbookTemplateData
    {
        /// <summary> Key value pair of localized gallery. Each key is the locale code of languages supported by the Azure portal. </summary>
        [WirePath("properties.localized")]
        public IDictionary<string, IList<WorkbookTemplateLocalizedGallery>> LocalizedGalleries
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new WorkbookTemplateProperties();
                }
                return Properties.Localized;
            }
        }
    }
}
