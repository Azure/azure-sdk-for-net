// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.AppService.Fluent.Models;

namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for AppServicePricingTier.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuQXBwU2VydmljZVByaWNpbmdUaWVy
    public partial class AppServicePricingTier
    {
        public static readonly AppServicePricingTier Free_F1 = new AppServicePricingTier("Free", "F1");
        public static readonly AppServicePricingTier Shared_D1 = new AppServicePricingTier("Shared", "D1");
        public static readonly AppServicePricingTier Basic_B1 = new AppServicePricingTier("Basic", "B1");
        public static readonly AppServicePricingTier Basic_B2 = new AppServicePricingTier("Basic", "B2");
        public static readonly AppServicePricingTier Basic_B3 = new AppServicePricingTier("Basic", "B3");
        public static readonly AppServicePricingTier Standard_S1 = new AppServicePricingTier("Standard", "S1");
        public static readonly AppServicePricingTier Standard_S2 = new AppServicePricingTier("Standard", "S2");
        public static readonly AppServicePricingTier Standard_S3 = new AppServicePricingTier("Standard", "S3");
        public static readonly AppServicePricingTier Premium_P1 = new AppServicePricingTier("Premium", "P1");
        public static readonly AppServicePricingTier Premium_P2 = new AppServicePricingTier("Premium", "P2");
        public static readonly AppServicePricingTier Premium_P3 = new AppServicePricingTier("Premium", "P3");

        public SkuDescription SkuDescription { get; private set; }

        private AppServicePricingTier()
        {
        }

        /// <summary>
        /// Creates a custom value for AppServicePricingTier.
        /// </summary>
        /// <param name="tier">the tier name</param>
        /// <param name="size">the size of the plan</param>
        public AppServicePricingTier(string tier, string size)
        {
            this.SkuDescription = new SkuDescription
            {
                Name = size,
                Tier = tier,
                Size = size
            };
        }

        ///GENMHASH:9E6C2387B371ABFFE71039FB9CDF745F:6AEFB2B6DB5E36DFCB741BB94BD67ECA
        public override string ToString()
        {
            return SkuDescription.Tier + "_" + SkuDescription.Size;
        }

        ///GENMHASH:86E56D83C59D665A2120AFEA8D89804D:2997034F6A828592A426C244FB4206B1
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

        ///GENMHASH:0A2A1204F2A167AF288B2FBF2A490437:7FC4781967AC76067191B349FD8FAFC4
        public override int GetHashCode()
        {
            return SkuDescription.GetHashCode();
        }

        ///GENMHASH:3E41C75F291566718F049BE8298BE8DC:A12B779940ABC1017C310E5DAEB47E21
        public static AppServicePricingTier FromSkuDescription(SkuDescription skuDescription)
        {
            return new AppServicePricingTier()
            {
                SkuDescription = skuDescription
            };
        }
    }
}
