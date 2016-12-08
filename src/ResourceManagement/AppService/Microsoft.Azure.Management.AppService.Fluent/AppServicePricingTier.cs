// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;

    /// <summary>
    /// Defines App service pricing tiers.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuQXBwU2VydmljZVByaWNpbmdUaWVy
    internal partial class AppServicePricingTier  :
        object
    {
        public AppServicePricingTier FREE_F1;
        public AppServicePricingTier SHARED_D1;
        public AppServicePricingTier BASIC_B1;
        public AppServicePricingTier BASIC_B2;
        public AppServicePricingTier BASIC_B3;
        public AppServicePricingTier STANDARD_S1;
        public AppServicePricingTier STANDARD_S2;
        public AppServicePricingTier STANDARD_S3;
        public AppServicePricingTier PREMIUM_P1;
        public AppServicePricingTier PREMIUM_P2;
        public AppServicePricingTier PREMIUM_P3;
        private SkuDescription skuDescription;
        ///GENMHASH:B9CFE16F1B01DA31969DCEB63534EB1A:B18BAF7D223AB29E75CD572030AABDBC
        public SkuDescription ToSkuDescription()
        {
            //$ return this.skuDescription;

            return null;
        }

        ///GENMHASH:86E56D83C59D665A2120AFEA8D89804D:2997034F6A828592A426C244FB4206B1
        public bool Equals(object obj)
        {
            //$ if (!(obj instanceof AppServicePricingTier)) {
            //$ return false;
            //$ }
            //$ if (obj == this) {
            //$ return true;
            //$ }
            //$ AppServicePricingTier rhs = (AppServicePricingTier) obj;
            //$ return toString().EqualsIgnoreCase(rhs.ToString());

            return false;
        }

        /// <summary>
        /// Creates a custom app service pricing tier.
        /// </summary>
        /// <param name="tier">The tier name.</param>
        ///GENMHASH:577161D2DAB431E91C429EBDA0A3812F:48ACBDFB047C8D6CF117E277F4C203CC
        public  AppServicePricingTier(string tier, string size)
        {
            //$ this.skuDescription = new SkuDescription()
            //$ .WithName(size)
            //$ .WithTier(tier)
            //$ .WithSize(size);
            //$ }

        }

        ///GENMHASH:0A2A1204F2A167AF288B2FBF2A490437:7FC4781967AC76067191B349FD8FAFC4
        public int HashCode()
        {
            //$ return skuDescription.HashCode();

            return 0;
        }

        ///GENMHASH:9E6C2387B371ABFFE71039FB9CDF745F:6AEFB2B6DB5E36DFCB741BB94BD67ECA
        public string ToString()
        {
            //$ return skuDescription.Tier() + "_" + skuDescription.Size();

            return null;
        }

        /// <summary>
        /// Parses a serialized value to an AppServicePricingTier instance.
        /// </summary>
        /// <param name="skuDescription">The serialized value to parse.</param>
        ///GENMHASH:3E41C75F291566718F049BE8298BE8DC:A12B779940ABC1017C310E5DAEB47E21
        public static AppServicePricingTier FromSkuDescription(SkuDescription skuDescription)
        {
            //$ if (skuDescription == null) {
            //$ return null;
            //$ }
            //$ return new AppServicePricingTier(skuDescription.Tier(), skuDescription.Size());
            //$ }

            return this;
        }
    }
}