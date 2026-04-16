// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable SA1402 // File may only contain a single type

//TODO: Remove this file once emitter fixes issue with generating client with KnowledgeBaseRetrievalClientOptions instead of SearchClientOptions
// We have to manually hide the model and override BindCore otherwise there are compilation failures when changing to SearchClientOptions.
namespace Azure.Search.Documents.KnowledgeBases
{
    [CodeGenType("KnowledgeBaseRetrievalClientSettings")]
    internal partial class InternalKnowledgeBaseRetrievalClientSettings : ClientSettings
    {
        /// <summary> Binds configuration values from the given section. </summary>
        /// <param name="section"> The configuration section. </param>
        protected override void BindCore(IConfigurationSection section)
        {
            if (Uri.TryCreate(section["Endpoint"], UriKind.Absolute, out Uri endpoint))
            {
                Endpoint = endpoint;
            }
            string knowledgeBaseName = section["KnowledgeBaseName"];
            if (!string.IsNullOrEmpty(knowledgeBaseName))
            {
                KnowledgeBaseName = knowledgeBaseName;
            }
            IConfigurationSection optionsSection = section.GetSection("Options");
            if (optionsSection.Exists())
            {
                Options = new KnowledgeBaseRetrievalClientOptions(optionsSection);
            }
        }
    }

    /// <summary> Represents the settings used to configure a <see cref="KnowledgeBaseRetrievalClient"/> that can be loaded from an <see cref="IConfigurationSection"/>. </summary>
    [Experimental("SCME0002")]
    public partial class KnowledgeBaseRetrievalClientSettings : ClientSettings
    {
        /// <summary> Gets or sets the Endpoint. </summary>
        public Uri Endpoint { get; set; }

        /// <summary> Gets or sets the KnowledgeBaseName. </summary>
        public string KnowledgeBaseName { get; set; }

        /// <summary> Gets or sets the Options. </summary>
        [CodeGenMember("Options")]
        public SearchClientOptions Options { get; set; }

        /// <summary> Binds configuration values from the given section. </summary>
        /// <param name="section"> The configuration section. </param>
        protected override void BindCore(IConfigurationSection section)
        {
            if (Uri.TryCreate(section["Endpoint"], UriKind.Absolute, out Uri endpoint))
            {
                Endpoint = endpoint;
            }
            string knowledgeBaseName = section["KnowledgeBaseName"];
            if (!string.IsNullOrEmpty(knowledgeBaseName))
            {
                KnowledgeBaseName = knowledgeBaseName;
            }
            IConfigurationSection optionsSection = section.GetSection("Options");
            if (optionsSection.Exists())
            {
                Options = new SearchClientOptions(optionsSection);
            }
        }
    }
}
