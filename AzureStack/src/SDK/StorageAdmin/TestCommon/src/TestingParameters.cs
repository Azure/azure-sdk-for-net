// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCommon
{
    /// <summary>
    /// Parameters are loaded from parameter file.
    /// </summary>
    public class TestingParameters
    {

        //public const string RelativeFileLocation = "..\\..\\Resources\\";
        public const string RelativeFileLocation = "..\\..\\..\\..\\..\\Resources\\";
        public const string Filename = "parameters.json";

        public string Username { get; set; }

        public string Password { get; set; }

        public Uri BaseUri { get; set; }

        public string ApplicationId { get; set; }

        public string ClientId { get; set; }

        public string TenantId { get; set; }

        public string Secret { get; set; }

        public string Resource { get; set; }

        public string SubscriptionId { get; set; }

        public string Location { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("{\n");

            Func<string,string,int> append = (string name, string value) => {
                if(value != null)
                {
                    sb.Append(String.Format("\t{0}: {1}\n", name, value));
                }
                return 0;
            };

            append(nameof(Username), Username);
            append(nameof(Password), Password);
            append(nameof(BaseUri), BaseUri.ToString());
            append(nameof(ApplicationId), ApplicationId);
            append(nameof(ClientId), ClientId);
            append(nameof(TenantId), TenantId);
            append(nameof(Secret), Secret);
            append(nameof(Resource), Resource);
            append(nameof(SubscriptionId), SubscriptionId);
            append(nameof(Location), Location);
            
            sb.Append("}");
            return "";
        }

        public static TestingParameters LoadFromFile(string configurationFile = RelativeFileLocation + Filename)
        {
            if(!System.IO.File.Exists(configurationFile)) {
                throw new System.IO.FileNotFoundException("File does not exist", configurationFile);
            }

            var reader = new Newtonsoft.Json.JsonTextReader(new System.IO.StreamReader(configurationFile));
            var serial = Newtonsoft.Json.JsonSerializer.Create();
            var parameters = serial.Deserialize<TestCommon.TestingParameters>(reader);

            return parameters;
        }
    }
}
