//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.Management.DataFactories.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.Management.DataFactories.Conversion
{
    internal class PolymorphicTypeConverter<T> : JsonConverter
    {
        protected static IDictionary<string, Type> ReservedTypes
        {
            get
            {
                return ReservedTypesList.Value;
            }
        }

        private static Lazy<Dictionary<string, Type>> ReservedTypesList { get; set; }

        static PolymorphicTypeConverter()
        {
            // Delay evaluation until the user needs to do local type registration or conversion
            ReservedTypesList = new Lazy<Dictionary<string, Type>>(GetReservedTypes);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            JToken token;
            if (!obj.TryGetTypeProperty(out token))
            {
                throw new InvalidOperationException(string.Format(
                        CultureInfo.InvariantCulture,
                        "Could not find a string property '{0}' for the following JSON: {1}",
                        DataFactoryConstants.KeyPolymorphicType,
                        obj));
            }

            Type type;
            if (!ReservedTypes.TryGetValue(token.ToString(), out type))
            {
                throw new InvalidOperationException(string.Format(
                        CultureInfo.InvariantCulture,
                        "There is no type available with the name '{0}'.",
                        token));
            }

            T target = (T)Activator.CreateInstance(type);
            serializer.Populate(obj.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject obj = JObject.FromObject(
                value,
                new JsonSerializer()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });

            string typeName = value.GetType().Name;
            obj.Add(DataFactoryConstants.KeyPolymorphicType, new JValue(typeName));

            writer.WriteToken(obj.CreateReader());
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        private static Dictionary<string, Type> GetReservedTypes()
        {
            Type rootType = typeof(T);
            return rootType.Assembly.GetTypes().Where(rootType.IsAssignableFrom).ToDictionary(GetTypeName);
        }

        /// <summary>
        /// Get a name to use during serialization of a type. 
        /// </summary>
        /// <param name="type">The type to get a name for.</param>
        /// <returns>The name to use during serialization for <paramref name="type"/>.</returns>
        private static string GetTypeName(Type type)
        {
            object typeNameAttribute = type.GetCustomAttributes(typeof(AdfTypeNameAttribute), true).FirstOrDefault();
            if (typeNameAttribute != null)
            {
                return ((AdfTypeNameAttribute)typeNameAttribute).TypeName;
            }

            return type.Name;
        }
    }
}
