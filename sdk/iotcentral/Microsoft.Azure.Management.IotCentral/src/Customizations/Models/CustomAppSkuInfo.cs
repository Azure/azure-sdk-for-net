namespace Microsoft.Azure.Management.IotCentral.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;
    public partial class CustomAppSkuInfo: AppSkuInfo
    {
        public override void Validate()
        {
            string[] skuNames = { AppSku.S1, AppSku.ST0, AppSku.ST1, AppSku.ST2 };
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            else if (!skuNames.Any(Name.ToUpper().Contains))
            {
                throw new ValidationException($"Sku parameter invalid. It can only be {string.Join(",", skuNames)}");
            }
        }
    }
}
