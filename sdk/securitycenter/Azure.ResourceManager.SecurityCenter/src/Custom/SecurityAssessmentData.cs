// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // TypeSpec separates the assessment input resource from the response resource. MPG generates
    // SecurityAssessmentData from the response model, with an internal constructor and read-only
    // flattened properties. These custom members restore GA aliases and settable flattened members.
    [CodeGenSuppress("SecurityAssessmentData")]
    [CodeGenSuppress("ResourceDetails")]
    [CodeGenSuppress("Metadata")]
    [CodeGenSuppress("PartnersData")]
    [CodeGenSuppress("Status")]
    public partial class SecurityAssessmentData
    {
        private bool _isResourceDetailsDefined;
        private SecurityCenterResourceDetails _resourceDetails;
        private bool _isMetadataDefined;
        private SecurityAssessmentMetadataProperties _metadata;
        private bool _isPartnersDataDefined;
        private SecurityAssessmentPartner _partnersData;
        private bool _isStatusDefined;
        private SecurityAssessmentStatusResult _status;

        /// <summary> Initializes a new instance of <see cref="SecurityAssessmentData"/>. </summary>
        public SecurityAssessmentData()
        {
        }

        // GA exposed this as a Uri alias over the generated string LinksAzurePortalUri.
        /// <summary> Link to assessment in Azure Portal. </summary>
        public Uri AzurePortalUri => LinksAzurePortalUri is null ? null : new Uri(LinksAzurePortalUri);

        // GA exposed this flattened property as settable; generated response data is read-only.
        /// <summary> Details of the resource that was assessed. </summary>
        public SecurityCenterResourceDetails ResourceDetails
        {
            get => _isResourceDetailsDefined ? _resourceDetails : Properties is null ? default : Properties.ResourceDetails;
            set
            {
                _resourceDetails = value;
                _isResourceDetailsDefined = true;
            }
        }

        // GA exposed this flattened property as settable; generated response data is read-only.
        /// <summary> Describes properties of an assessment metadata. </summary>
        public SecurityAssessmentMetadataProperties Metadata
        {
            get => _isMetadataDefined ? _metadata : Properties is null ? default : Properties.Metadata;
            set
            {
                _metadata = value;
                _isMetadataDefined = true;
            }
        }

        // GA exposed SecurityAssessmentPartner, while TypeSpec response data uses the internal
        // partner-data shape from the response property bag.
        /// <summary> Data regarding 3rd party partner integration. </summary>
        public SecurityAssessmentPartner PartnersData
        {
            get
            {
                if (_isPartnersDataDefined)
                {
                    return _partnersData;
                }

                return Properties?.PartnersData is null
                    ? default
                    : new SecurityAssessmentPartner(Properties.PartnersData.PartnerName, Properties.PartnersData.Secret);
            }

            set
            {
                _partnersData = value;
                _isPartnersDataDefined = true;
            }
        }

        // GA exposed this flattened property as settable; generated response data is read-only.
        /// <summary> The result of the assessment. </summary>
        public SecurityAssessmentStatusResult Status
        {
            get => _isStatusDefined ? _status : Properties is null ? default : Properties.Status;
            set
            {
                _status = value;
                _isStatusDefined = true;
            }
        }
    }
}
