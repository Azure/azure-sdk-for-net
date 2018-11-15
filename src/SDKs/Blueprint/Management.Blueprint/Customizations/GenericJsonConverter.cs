namespace Microsoft.Azure.Management.Blueprint
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;

    /// <summary>
    /// Json converter for generic types we didn't model using swagger discriminator.
    /// Not a full implementation of JsonConverter, so add this converter to list of converters doesn't work.
    /// Have to attribute with [JsonConverter(typeof(...))]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericJsonConverter<T> : JsonConverter
    {
        protected abstract T TypeInference(JObject jObject);

        public override bool CanWrite
        {
            // not trying to take over other converter's job.
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            // .net standard 1.4 which this project is target to doesn't support Type.IsAssignableFrom()
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            // peek the object and infrence the type.
            T target = TypeInference(jObject);

            // fill in the properties.
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
