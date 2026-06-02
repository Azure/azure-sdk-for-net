// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.LambdaTestHyperExecute.Models
{
    public static partial class ArmLambdaTestHyperExecuteModelFactory
    {
        /// <summary>
        /// [Obsolete] Backward-compatibility shim for the previous factory signature where
        /// <c>partnerLicensesSubscribed</c> was nullable. Forwards to the new factory using the
        /// renamed, non-nullable <c>partnerLicensesCount</c> parameter (<c>null</c> becomes <c>0</c>).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LambdaTestHyperExecuteOrganizationProperties LambdaTestHyperExecuteOrganizationProperties(
            LambdaTestHyperExecuteMarketplaceDetails marketplace,
            LambdaTestHyperExecuteUserDetails user,
            LambdaTestHyperExecuteOfferProvisioningState? provisioningState,
            int? partnerLicensesSubscribed,
            LambdaTestHyperExecuteSingleSignOnPropertiesV2 singleSignOnProperties)
            => LambdaTestHyperExecuteOrganizationProperties(
                marketplace,
                user,
                provisioningState,
                partnerLicensesSubscribed.GetValueOrDefault(),
                singleSignOnProperties);

        // Workaround: The generator has a bug that when an overload is created in customized code with the same parameter list, but the nullability of some parameters is different,
        // the generator somehow treat the overload as a duplicated method, and the generated overload with different nullability will no longer be generated.
        /// <param name="marketplace"> Marketplace details of the resource. </param>
        /// <param name="user"> Details of the user. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="partnerLicensesSubscribed"> The number of licenses subscribed. </param>
        /// <param name="singleSignOnProperties"> Single sign-on properties. </param>
        /// <returns> A new <see cref="Models.LambdaTestHyperExecuteOrganizationProperties"/> instance for mocking. </returns>
        public static LambdaTestHyperExecuteOrganizationProperties LambdaTestHyperExecuteOrganizationProperties(
            LambdaTestHyperExecuteMarketplaceDetails marketplace = default,
            LambdaTestHyperExecuteUserDetails user = default,
            LambdaTestHyperExecuteOfferProvisioningState? provisioningState = default,
            int partnerLicensesSubscribed = default,
            LambdaTestHyperExecuteSingleSignOnPropertiesV2 singleSignOnProperties = default)
        {
            return new LambdaTestHyperExecuteOrganizationProperties(
                marketplace,
                user,
                provisioningState,
                new LambdaTestHyperExecuteOfferPartnerProperties(partnerLicensesSubscribed, null),
                singleSignOnProperties,
                additionalBinaryDataProperties: null);
        }
    }
}
