// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core;
using Moq;
using NUnit.Framework;

#pragma warning disable SA1400

namespace Azure.AI.TextAnalytics.Protocol.Tests
{
    public class JsonDataSnippets
    {
        public void TestSnippets()
        {
            {
#region Snippet:DefaultConstructor
                var obj = new JsonData();
                Console.WriteLine(obj.Kind == JsonValueKind.Object); // prints True
                Console.WriteLine(obj.Properties.Count() == 0); // prints True
#endregion
            }

            {
#region Snippet:PrimitiveConstructor
                var trueValue = new JsonData(true); // represents the document: true
                var stringValue = new JsonData("Hello, JsonData"); // represents the document: "Hello, JsonData"
#endregion
            }

            {
#region Snippet:ArrayConstructor
                var arr = new JsonData(new[] {1, 2, 3}); // represents the document: [1, 2, 3]
#endregion
            }

            {
#region Snippet:ObjectConstructor
                var doc = new JsonData(new { message = "Hello, JsonData" }); // represents the document: { "message": "Hello, JsonData" }
#endregion
            }

            {
#region Snippet:FromXYZ
                var docFromString = JsonData.FromString(File.ReadAllText("<path-to-utf8-json-file>"));
                var docFromBytes = JsonData.FromBytes(File.ReadAllBytes("<path-to-utf8-json-file>"));
#endregion
            }

            {
#region Snippet:ModifyObjects
                var doc = new JsonData() ;// represents the document: {}
                doc["message"] = "Hello, JsonData"; // doc now represents the document { "message": "Hello, JsonData" }
                doc.Set("message", "This works, too!"); // doc now represents the document { "message": "This works, too!" }
#endregion
            }

            {
#region Snippet:SetEmpty
                var doc = new JsonData(); // represents the document: {}
                var wrapped = doc.SetEmptyObject("wrapped"); // doc now represents the document { "wrapped": { } }
                wrapped["message"] = "Hello, JsonData!"; // doc now represents the document { "wrapped": { "message": "This works, too!" } }
#endregion
            }

            {
#region Snippet:ArraySetIndexer
                var doc = new JsonData(new[] { "Hello, JsonData!" }); // represents the document [ "Hello, JsonData!" ]
                doc[0] = "This works!"; // represents the document [ "This works!" ]
#endregion
            }

            {
#region Snippet:ArrayAdd
                var doc = new JsonData(new string[] {}); // represents the document [ ]
                doc.Add("This works!"); // represents the document [ "This works!" ]
#endregion
            }

            {
#region Snippet:AddEmpty
                var doc = new JsonData(new object[] {}); // represents the document: [ ]
                var wrapped = doc.AddEmptyObject(); // doc now represents the document [ { } ]
                wrapped["message"] = "Hello, JsonData!"; // doc now represents the document [ { "message": "This works, too!" } ]
#endregion
            }

            {
#region Snippet:CLRCasts
                var oneDoc = new JsonData(1);           // represents the document: 1
                int oneValue = (int)oneDoc;             // works, oneValue is 1

                var stringDoc = new JsonData("hello");  // represents the document: "hello"
                string stringValue = (string)stringDoc;     // works, stringValue is the string "hello"
#endregion
            }

            {
#region Snippet:PropertiesProperty
                var objectDoc = new JsonData(new { key1 = "one", key2 = "two" }); // represents the document: { "key1": "one", "key2": "two" }
                // the loop prints
                // key1
                // key2
                foreach (string propertyName in objectDoc.Properties)
                {
                    Console.WriteLine(propertyName);
                }
#endregion
            }

            {
#region Snippet:GetPropertyIndexer
                var objectDoc = new JsonData(new { key1 = "one", key2 = "two" });
                Console.WriteLine(objectDoc["key1"]); // prints "one"
#endregion
            }
            {
#region Snippet:GetPropertyWithGet
                var objectDoc = new JsonData(new { key1 = "one", key2 = "two" }); // represents the document: { "key1": "one", "key2": "two" }
                Console.WriteLine(objectDoc.Get("key1"));               // prints "one"
                Console.WriteLine(objectDoc.Get("missingKey") == null); // prints "true"
                Console.WriteLine(objectDoc["missingKey"]);              // throws InvalidOperationException.
#endregion
            }

            {
#region Snippet:ArrayIndexer
                var arrayDoc = new JsonData(new[] { "Hello", "JsonData" }); // represents the document: [ "Hello", "JsonData" ]
                Console.WriteLine(arrayDoc[0]);   // prints "Hello"
                Console.WriteLine(arrayDoc[1]);   // prints "JsonData"
#endregion
            }

            {
#region Snippet:ItemsProperty
                var arrayDoc = new JsonData(new[] { "Hello", "JsonData" }); // represents the document: [ "Hello", "JsonData" ]
                foreach (JsonData item in arrayDoc.Items)
                {
                    Console.WriteLine((string)item);
                }
#endregion
            }

            JsonData sampleData = new JsonData(new
            {
                students = new[] {
                    new {
                        name = "Matt",
                        address = new[] { "1 Microsoft Way", "Building 18", "Redmond, WA, 98034" }
                    },
                    new {
                        name = "Bill",
                        address = new[] { "1 Microsoft Way", "Building 34", "Redmond, WA, 98034" }
                    }
                }
            });
            {
                #region Snippet:DOMAccess
                /*@@*/ JsonData doc = sampleData;
                //@@ JsonData doc = JsonData.FromString(/* a string representing the above document */);
                Console.WriteLine(doc["students"][0]["name"]); // prints "Matt"
                Console.WriteLine(doc["students"][1]["address"][1]); // prints "Building 34"
#endregion
            }
            {
                #region Snippet:Dynamic
                /*@@*/ dynamic doc = sampleData;
                //@@ dynamic doc = JsonData.FromString(/* a string representing the above document */);
                Console.WriteLine(doc.students[0].name); // prints "Matt"
                Console.WriteLine(doc.students[1].address[1]); // prints "Building 34"
#endregion
            }
            {
                #region Snippet:DynamicCast
                /*@@*/ dynamic doc = sampleData;
                //@@ dynamic doc = JsonData.FromString(/* a string representing the above document */);
                string name = (string)doc.students[0].name; // name is set to the string "Matt"
                string address = (string) doc.students[1].address[1]; // address is set to the string "Building 34"
#endregion
            }

            {
                #region Snippet:ConvertToModel
                /*@@*/ JsonData doc = sampleData;
                //@@ JsonData doc = JsonData.FromString(/* a string representing the above document */);
                /*@@*/ ModelsWithBadNames.Student[] students = doc["students"].To<ModelsWithBadNames.Student[]>();
                //@@ Student[] students = doc["students"].To<Student[]>();
                Console.WriteLine(students.Length); // prints 2
                Console.WriteLine(students[0].name); // prints "Matt"
#endregion
            }

            {
#region Snippet:ConvertToModelWithPropertyNames
                /*@@*/ JsonData doc = sampleData;
                //@@ JsonData doc = JsonData.FromString(/* a string representing the above document */);
                /*@@*/ ModelsWithGoodNames.Student[] students = doc["students"].To<ModelsWithGoodNames.Student[]>();
                //@@ Student[] students = doc["students"].To<Student[]>();
                Console.WriteLine(students.Length); // prints 2
                Console.WriteLine(students[0].Name); // prints "Matt"
#endregion
            }

            {
                MockClient client = new MockClient();

                #region Snippet:DynamicRequestAndResponse
                JsonData body = new JsonData();
                JsonData documents = body.SetEmptyArray("documents");
                JsonData document = documents.AddEmptyObject();
                document["language"] = "en";
                document["id"] = "1";
                document["text"] = "Great atmosphere. Close to plenty of restaurants, hotels, and transit! Staff are friendly and helpful.";

                Response res = client.GetSentiment(RequestContent.Create(body));

                if (res.Status != 200 /*OK*/)
                {
                    // The call failed for some reason, log a message
                    Console.Error.WriteLine($"Requested Failed with status {res.Status}: ${res.Content}");
                }
                else
                {
                    JsonData responseBody = JsonData.FromBytes(res.Content.ToMemory());
                    Console.WriteLine($"Sentiment of document is {(string)responseBody["documents"][0]["sentiment"]}");
                }
#endregion
            }

            {
#region Snippet:DetectLanguagesSample
                TextAnalyticsClient client = new TextAnalyticsClient(new Uri("<endpoint-from-portal>"), new AzureKeyCredential("<api-key-from-portal>"));
                dynamic body = new JsonData();

                body.documents = new JsonData[3];
                body.documents[0] = new JsonData();
                body.documents[0].countryHint = "US";
                body.documents[0].id = "1";
                body.documents[0].text = "Hello world";

                body.documents[1] = new JsonData();
                body.documents[1].id = "2";
                body.documents[1].text = "Bonjour tout le monde";

                body.documents[2] = new JsonData();
                body.documents[2].id = "3";
                body.documents[2].text = "La carretera estaba atascada. Había mucho tráfico el día de ayer.";

                Response res = client.GetLanguages(RequestContent.Create(body));

                Console.WriteLine($"Status is {res.Status} and the body of the response is: {res.Content})");
#endregion
            }

            {
#region Snippet:JsonDataToString
                Console.WriteLine(new JsonData(1)); // prints 1
                Console.WriteLine(new JsonData(true)); // prints True
                Console.WriteLine(new JsonData(null)); // prints <null>
                Console.WriteLine(new JsonData("Hello, JsonData")); // prints Hello, JsonData
#endregion
#region Snippet:JsonDataToJsonString
                Console.WriteLine(new JsonData(1).ToJsonString()); // prints 1
                Console.WriteLine(new JsonData(true).ToJsonString()); // prints true
                Console.WriteLine(new JsonData(null).ToJsonString()); // prints null
                Console.WriteLine(new JsonData("Hello, JsonData").ToJsonString()); // prints "Hello, JsonData"
#endregion
            }
        }

        public class MockClient
        {
            public Response GetSentiment(RequestContent body)
            {
                return Mock.Of<Response>();
            }
        }

        public class ModelsWithBadNames
        {
            #region  Snippet:ModelTypeDefinition
            public class Student
            {
                public string name { get; }
                public string address { get; }
            }
            #endregion
        }
        public class ModelsWithGoodNames
        {
            #region  Snippet:ModelTypeDefinitionWithPropertyNames
            public class Student
            {
                [JsonPropertyName("name")]
                public string Name { get; }

                [JsonPropertyName("address")]
                public string Address { get; }
            }
            #endregion
        }
    }
}
