// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.DocumentTranslation
{
    [CodeGenModel("TargetInput")]
    public partial class TranslationTarget
    {
        [CodeGenMember("StorageSource")]
        internal string StorageSource { get; set; }

        /// <summary> Location of the folder / container with your documents. </summary>
        [CodeGenMember("TargetUrl")]
        public Uri TargetUri { get; }

        /// <summary> Target Language. </summary>
        [CodeGenMember("Language")]
        public string LanguageCode { get; }
    }
}
