// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
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

        /// <summary> Link to assessment in Azure Portal. </summary>
        public Uri AzurePortalUri => LinksAzurePortalUri is null ? null : new Uri(LinksAzurePortalUri);

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
