// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.AppService.Fluent.Models;

namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for AppServicePricingTier.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuQXBwU2VydmljZVByaWNpbmdUaWVy
    public partial class PricingTier
    {
        public static readonly PricingTier FreeF1 = new PricingTier("Free", "F1");
        public static readonly PricingTier SharedD1 = new PricingTier("Shared", "D1");
        public static readonly PricingTier BasicB1 = new PricingTier("Basic", "B1");
        public static readonly PricingTier BasicB2 = new PricingTier("Basic", "B2");
        public static readonly PricingTier BasicB3 = new PricingTier("Basic", "B3");
        public static readonly PricingTier StandardS1 = new PricingTier("Standard", "S1");
        public static readonly PricingTier StandardS2 = new PricingTier("Standard", "S2");
        public static readonly PricingTier StandardS3 = new PricingTier("Standard", "S3");
        public static readonly PricingTier PremiumP1 = new PricingTier("Premium", "P1");
        public static readonly PricingTier PremiumP2 = new PricingTier("Premium", "P2");
        public static readonly PricingTier PremiumP3 = new PricingTier("Premium", "P3");

        ///GENMHASH:B9CFE16F1B01DA31969DCEB63534EB1A:B18BAF7D223AB29E75CD572030AABDBC
        public SkuDescription SkuDescription { get; private set; }

        ///GENMHASH:577161D2DAB431E91C429EBDA0A3812F:48ACBDFB047C8D6CF117E277F4C203CC
        private PricingTier()
        {
        }

        /// <summary>
        /// Creates a custom value for AppServicePricingTier.
        /// </summary>
        /// <param name="tier">the tier name</param>
        /// <param name="size">the size of the plan</param>
        public PricingTier(string tier, string size)
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
            if (!(obj is PricingTier))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            PricingTier rhs = (PricingTier)obj;
            return ToString().Equals(rhs.ToString());
        }

        ///GENMHASH:0A2A1204F2A167AF288B2FBF2A490437:7FC4781967AC76067191B349FD8FAFC4
        public override int GetHashCode()
        {
            return SkuDescription.GetHashCode();
        }

        ///GENMHASH:3E41C75F291566718F049BE8298BE8DC:A12B779940ABC1017C310E5DAEB47E21
        public static PricingTier FromSkuDescription(SkuDescription skuDescription)
        {
            return new PricingTier()
            {
                SkuDescription = skuDescription
            };
        }

    }
}
