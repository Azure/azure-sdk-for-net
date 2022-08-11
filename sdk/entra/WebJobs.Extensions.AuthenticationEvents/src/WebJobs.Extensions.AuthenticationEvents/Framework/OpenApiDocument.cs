// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Object the represents the OpenApi structure with related request and response schemas.</summary>
    internal class OpenApiDocument
    {
        /// <summary>Gets or sets the document.</summary>
        /// <value>The document.</value>
        public AuthEventJsonElement Document { get; set; }
        /// <summary>Gets or sets the request schema.</summary>
        /// <value>The request schema.</value>
        public AuthEventJsonElement RequestSchema { get; set; }
        /// <summary>Gets or sets the response schema.</summary>
        /// <value>The response schema.</value>
        public AuthEventJsonElement ResponseSchema { get; set; }
        /// <summary>Gets or sets the event information.</summary>
        /// <value>The event information.</value>
        internal AuthEventMetadataAttribute EventMetadata { get; set; }

        /// <summary>Gets the event name space.</summary>
        public string EventNameSpace
        {
            get { return EventMetadata != null ? EventMetadata.EventNamespace : string.Empty; }
        }

        /// <summary>Loads the specified event via namespace path.</summary>
        /// <param name="eventNamespace">The event namespace.</param>
        /// <returns>A populated event or null if not found.</returns>
        public static OpenApiDocument Load(string eventNamespace)
        {
            foreach (EventDefinition eventDef in Enum.GetValues(typeof(EventDefinition)))
            {
                if (eventDef.GetAttribute<AuthEventMetadataAttribute>().EventNamespace.Equals(eventNamespace, StringComparison.OrdinalIgnoreCase))
                    return Load(eventDef);
            }

            return null;
        }

        /// <summary>Loads the specified event.</summary>
        /// <param name="eventDefinition">The event.</param>
        /// <returns>If the event schemas exist, a populated OpenApiDocument is returned.</returns>
        /// <exception cref="Exception">Missing Event.</exception>
        public static OpenApiDocument Load(EventDefinition eventDefinition)
        {
            var eventAttr = eventDefinition.GetAttribute<AuthEventMetadataAttribute>();
            AuthEventMetadata eventMetadata = AuthEventMetadataLoader.CreateEventMetadata(eventAttr);

            if (string.IsNullOrEmpty(eventMetadata.OpenApiDocument))
                throw new Exception(AuthEventResource.Ex_OpenApi_Missing);

            return new OpenApiDocument
            {
                Document = new AuthEventJsonElement(eventMetadata.OpenApiDocument),
                RequestSchema = new AuthEventJsonElement(eventMetadata.RequestSchema),
                ResponseSchema = new AuthEventJsonElement(eventMetadata.ResponseSchema),
                EventMetadata = eventAttr
            };
        }

        /// <summary>Merges the schemas and document to return one single OpenApiDocument.</summary>
        /// <returns>EventJsonElement representing the Json of the OpenApiDocument.</returns>
        /// <exception cref="Exception">No API Document body found.</exception>
        public AuthEventJsonElement EmbedReferences()
        {
            if (Document == null)
                throw new Exception(AuthEventResource.Ex_OpenApi_Missing);

            AuthEventJsonElement document = (AuthEventJsonElement)Document.Clone();
            AuthEventJsonElement request = (AuthEventJsonElement)RequestSchema.Clone();
            AuthEventJsonElement response = (AuthEventJsonElement)ResponseSchema.Clone();

            AuthEventJsonElement jComps = document.GetPropertyValue<AuthEventJsonElement>("components", "schemas");
            if (jComps != null)
            {
                var jDefs = FindDefinitions(request);
                jDefs.AddRange(FindDefinitions(response));
                foreach (var jDef in jDefs.Distinct())
                    jComps.Properties.Add(jDef.Key, jDef);
            }

            document.FindElementsNamed("schema").ForEach(schema =>
            {
                if (schema.Properties.ContainsKey("$ref"))
                {
                    if (schema.GetPropertyValue("$ref").Equals($"./{EventMetadata.RequestSchema}", StringComparison.OrdinalIgnoreCase))
                        schema.Elements.Add(request);

                    else if (schema.GetPropertyValue("$ref").Equals($"./{EventMetadata.ResponseSchema}", StringComparison.OrdinalIgnoreCase))
                        schema.Elements.Add(response);

                    schema.Properties.Remove("$ref");
                }
            });

            return document;
        }

        /// <summary>Merges the schemas and document to one single OpenApiDocument and write it to the file system.</summary>
        /// <param name="path">The path and filename to output to.</param>
        public void EmbedReferencesAndSave(string path)
        {
            WriteFile(path, EmbedReferences()?.ToString());
        }

        private static List<AuthEventJsonElement> FindDefinitions(AuthEventJsonElement jsonContainer)
        {
            try
            {
                string searchPattern = @"^#\/definitions\/";
                return jsonContainer.FindElementsByPropertyExpression(new Regex(searchPattern)).Select(t =>
                {
                    var comp = Regex.Replace(t.GetPropertyValue("$ref"), searchPattern, string.Empty);
                    t.Properties["$ref"] = string.Join("/", "#/components/schemas", comp);
                    return jsonContainer.GetPropertyValue<AuthEventJsonElement>("definitions", comp);
                }).ToList();
            }
            finally
            {
                jsonContainer.Properties.Remove("definitions");
            }
        }

        /// <summary>Writes the OpenApiDocument and related schemas to the file system, to a given path.</summary>
        /// <param name="path">The path to save the files to.</param>
        /// <returns>A dictionary with the document to path/filename relation.</returns>
        /// <exception cref="Exception">No API Document body found.</exception>
        /// <exception cref="DirectoryNotFoundException">If the output directory is not found.</exception>
        public Dictionary<OpenAPIDocumentType, string> Save(string path)
        {
            if (Document == null)
                throw new Exception(AuthEventResource.Ex_OpenApi_Missing);

            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException(path);

            foreach (string dir in EventMetadata.EventNamespace.Split('.'))
            {
                path = Path.Combine(path, dir);
                Directory.CreateDirectory(path);
            }

            Dictionary<OpenAPIDocumentType, string> result = new()
            {
                {OpenAPIDocumentType.OpenApiDocument, Path.Combine(path,EventMetadata.OpenApiDocument) },
                {OpenAPIDocumentType.RequestSchema, Path.Combine(path,EventMetadata.RequestSchema) },
                {OpenAPIDocumentType.ResponseSchema, Path.Combine(path,EventMetadata.ResponseSchema) }
            };

            WriteFile(result[OpenAPIDocumentType.OpenApiDocument], Document.ToString());
            WriteFile(result[OpenAPIDocumentType.RequestSchema], RequestSchema.ToString());
            WriteFile(result[OpenAPIDocumentType.ResponseSchema], ResponseSchema.ToString());

            return result;
        }

        private static void WriteFile(string file, string body)
        {
            if (File.Exists(file))
                throw new Exception(string.Format(CultureInfo.CurrentCulture, AuthEventResource.Ex_File_Exists, file));

            File.WriteAllText(file, body);
        }
    }
}
