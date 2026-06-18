// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    [CodeGenSuppress("SecuritySubAssessmentData")]
    [CodeGenSuppress("AdditionalData")]
    [CodeGenSuppress("ResourceDetails")]
    [CodeGenSuppress("Status")]
    public partial class SecuritySubAssessmentData
    {
        private bool _isAdditionalDataDefined;
        private SecuritySubAssessmentAdditionalInfo _additionalData;
        private bool _isResourceDetailsDefined;
        private SecurityCenterResourceDetails _resourceDetails;
        private bool _isStatusDefined;
        private SubAssessmentStatus _status;

        /// <summary> Initializes a new instance of <see cref="SecuritySubAssessmentData"/>. </summary>
        public SecuritySubAssessmentData()
        {
        }

        /// <summary> The date and time the sub-assessment was generated. </summary>
        public DateTimeOffset? GeneratedOn => TimeGenerated;

        /// <summary> Details of the sub-assessment. </summary>
        public SecuritySubAssessmentAdditionalInfo AdditionalData
        {
            get => _isAdditionalDataDefined ? _additionalData : Properties is null ? default : Properties.AdditionalData;
            set
            {
                _additionalData = value;
                _isAdditionalDataDefined = true;
            }
        }

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

        /// <summary> Status of the sub-assessment. </summary>
        public SubAssessmentStatus Status
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
