using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.CognitiveServices.Personalizer
{
    public partial class PersonalizerClient
    {
        partial void CustomInitialize()
        {
            SerializationSettings.ContractResolver = new DefaultContractResolver();
            DeserializationSettings.ContractResolver = new DefaultContractResolver();
        }
    }
}
