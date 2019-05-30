namespace Microsoft.Azure.Management.Blueprint
{
    using Models;
    using Newtonsoft.Json.Linq;

    public class ParameterValueJsonConverter : GenericJsonConverter<ParameterValueBase>
    {
        protected override ParameterValueBase TypeInference(JObject jObject)
        {
            var referenceProperty = jObject["reference"];
            if (null != referenceProperty)
            {
                return new SecretReferenceParameterValue();
            }
            else
            {
                return new ParameterValue();
            }
        }
    }
}
