// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.AppService.Fluent.Models;

namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for AppServicePricingTier.
    /// </summary>
    public partial class AppServicePricingTier
    {
        public static readonly AppServicePricingTier FREE_F1 = new AppServicePricingTier("Free", "F1");
        public static readonly AppServicePricingTier SHARED_D1 = new AppServicePricingTier("Shared", "D1");
        public static readonly AppServicePricingTier BASIC_B1 = new AppServicePricingTier("Basic", "B1");
        public static readonly AppServicePricingTier BASIC_B2 = new AppServicePricingTier("Basic", "B2");
        public static readonly AppServicePricingTier BASIC_B3 = new AppServicePricingTier("Basic", "B3");
        public static readonly AppServicePricingTier STANDARD_S1 = new AppServicePricingTier("Standard", "S1");
        public static readonly AppServicePricingTier STANDARD_S2 = new AppServicePricingTier("Standard", "S2");
        public static readonly AppServicePricingTier STANDARD_S3 = new AppServicePricingTier("Standard", "S3");
        public static readonly AppServicePricingTier PREMIUM_P1 = new AppServicePricingTier("Premium", "P1");
        public static readonly AppServicePricingTier PREMIUM_P2 = new AppServicePricingTier("Premium", "P2");
        public static readonly AppServicePricingTier PREMIUM_P3 = new AppServicePricingTier("Premium", "P3");

        private SkuDescription skuDescription;

        /// <summary>
        /// Creates a custom value for AppServicePricingTier.
        /// </summary>
        /// <param name="tier">the tier name</param>
        /// <param name="size">the size of the plan</param>
        public AppServicePricingTier(string tier, string size)
        {
            this.skuDescription = new SkuDescription
            {
                Name = size,
                Tier = tier,
                Size = size
            };
        }

        public override string ToString()
        {
            return skuDescription.Tier + "_" + skuDescription.Size;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is AppServicePricingTier))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            AppServicePricingTier rhs = (AppServicePricingTier)obj;
            return ToString().Equals(rhs.ToString());
        }

        public override int GetHashCode()
        {
            return skuDescription.GetHashCode();
        }
    }
}
