// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> Script block of scripts. </summary>
    public partial class ScriptActivityScriptBlock
    {
        /// <summary> Initializes a new instance of <see cref="ScriptActivityScriptBlock"/>. </summary>
        /// <param name="text"> The query text. Type: string (or Expression with resultType string). </param>
        /// <param name="scriptType"> The type of the query. Type: string. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        public ScriptActivityScriptBlock(DataFactoryElement<string> text, DataFactoryScriptType scriptType)
        {
            Argument.AssertNotNull(text, nameof(text));

            Text = text;
            QueryType = DataFactoryElement<string>.FromLiteral(scriptType.ToString());
            Parameters = new ChangeTrackingList<ScriptActivityParameter>();
        }

        /// <summary> The type of the query. Type: string. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataFactoryScriptType ScriptType { get; set; }
    }
}
