namespace Microsoft.Rest.ClientRuntime.Tests
{
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class SerializeDeserializeTests
    {
        private JsonSerializerSettings GetStdSerializedSettings()
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };

            return settings;
        }

        private JsonSerializerSettings GetStdDeserializationSettings()
        {
            var DeserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };

            return DeserializationSettings;
        }


        [Fact]
        public void SerializeNullDictionary()
        {
            UpdateIdentities ui = new UpdateIdentities();
            ui.RequestType = "PUT";
            ui.Identities = null;

            var identJson = SafeJsonConvert.SerializeObject(ui, GetStdSerializedSettings());
            Assert.NotNull(identJson);
        }

        [Fact]
        public void SerializeEmptyDictionary()
        {
            UpdateIdentities ui = new UpdateIdentities();
            ui.RequestType = "PUT";

            Dictionary<string, UserAssignedIdentity> users = new Dictionary<string, UserAssignedIdentity>();
            users.Add("New", new UserAssignedIdentity());
            users.Add("Remove", null);

            ui.Identities = users;

            var identJson = SafeJsonConvert.SerializeObject(ui, GetStdSerializedSettings());
            Assert.NotNull(identJson);
        }

        [Fact]
        public void SerializeAndParse()
        {
            UpdateIdentities ui = new UpdateIdentities();
            ui.RequestType = "PUT";

            Dictionary<string, UserAssignedIdentity> users = new Dictionary<string, UserAssignedIdentity>();
            users.Add("New", new UserAssignedIdentity());
            users.Add("Remove", null);

            ui.Identities = users;

            var identJson = SafeJsonConvert.SerializeObject(ui, GetStdSerializedSettings());
            Assert.NotNull(identJson);

            JObject body = JObject.Parse(identJson);

            UpdateIdentities deserializedUI = body.ToObject<UpdateIdentities>(JsonSerializer.Create(GetStdDeserializationSettings()));
        }
    }


    public partial class UpdateIdentities
    {
        /*        */

        [JsonProperty("requesttype")]
        public string RequestType { get; set; }

        [JsonProperty("identities")]
        public IDictionary<string, UserAssignedIdentity> Identities { get; set; }
    }

    public partial class UserAssignedIdentity
    {
        [JsonProperty("principalid")]
        public string PrincipalId { get; set; }

        [JsonProperty("clientid")]
        public string ClientId { get; set; }

        public UserAssignedIdentity()
        {
            //PrincipalId = string.Empty;
            //ClientId = string.Empty;
        }
    }



}
