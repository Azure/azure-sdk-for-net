// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    internal class AssetPlaceholderToInstanceResolver
    {
        static readonly Regex _jobInputExpression = new Regex(@"^JobInputAsset\((\d+)\)$", RegexOptions.Compiled | RegexOptions.Singleline);
        static readonly Regex _jobOutputExpression = new Regex(@"^JobOutputAsset\((\d+)\)$", RegexOptions.Compiled | RegexOptions.Singleline);
        static readonly Regex _temporaryExpression = new Regex(@"^TemporaryAsset\((\d+)\)$", RegexOptions.Compiled | RegexOptions.Singleline);

        enum TemplateAssetType
        {
            JobTemplateInput,
            Temporary,
            JobOutput
        }

        private readonly List<IAsset> _inputAssets = new List<IAsset>();
        private readonly List<IAsset> _temporaryAssets = new List<IAsset>();
        private readonly List<IAsset> _outputAssets = new List<IAsset>();

        /// <summary>
        /// Take assetName and determine the assettype and the index of the asset. For e.g. JobInputAsset(0) assettType = JobTemplateInput and index = 0
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="assetType"></param>
        /// <param name="assetIndex"></param>
        private static void ParseAssetName(string assetName, out TemplateAssetType assetType, out int assetIndex)
        {
            Match match = _jobInputExpression.Match(assetName);

            if (match.Success)
            {
                assetType = TemplateAssetType.JobTemplateInput;
            }
            else
            {
                match = _jobOutputExpression.Match(assetName);

                if (match.Success)
                {
                    assetType = TemplateAssetType.JobOutput;
                }
                else
                {
                    match = _temporaryExpression.Match(assetName);

                    if (!match.Success)
                    {
                        throw new InvalidDataException(StringTable.ErrorTaskBodyMalformed);
                    }

                    assetType = TemplateAssetType.Temporary;
                }
            }

            assetIndex = Int32.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
        }

        private static T EnsureSizeAndGetElement<T>(List<T> list, int size, Func<T> creator) where T : class
        {
            if (list.Count < size)
            {
                for (int i = list.Count; i < size; i++)
                {
                    list.Add(null);
                }
            }

            T returnValue = list[size - 1];
            if (returnValue == null)
            {
                returnValue = list[size - 1] = creator();
            }
            return returnValue;
        }

        private static object EnsureInListsAndFindAsset(
            List<IAsset> inputAssets,
            List<IAsset> temporaryAssets,
            List<IAsset> outputAssets,
            string assetName)
        {
            TemplateAssetType assetType;
            int assetIndex;
            ParseAssetName(assetName, out assetType, out assetIndex);

            switch (assetType)
            {
               case TemplateAssetType.Temporary:
                    return EnsureSizeAndGetElement(temporaryAssets, assetIndex + 1, () => new OutputAsset() { IsTemporary = true, Name = assetName });
                case TemplateAssetType.JobOutput:
                    return EnsureSizeAndGetElement(outputAssets, assetIndex + 1, () => new OutputAsset() { Name = assetName });
            }

            return null;
        }

        public IAsset CreateOrGetInputAsset(string assetName)
        {
            IAsset inputAsset =
                EnsureInListsAndFindAsset(_inputAssets, _temporaryAssets, _outputAssets, assetName) as IAsset;

            if (inputAsset == null)
            {
                throw new InvalidDataException(StringTable.ErrorCannotParseInput);
            }

            return inputAsset;
        }

        public IAsset CreateOrGetOutputAsset(string assetName)
        {
            IAsset outputAsset =
                EnsureInListsAndFindAsset(_inputAssets, _temporaryAssets, _outputAssets, assetName) as IAsset;

            if (outputAsset == null)
            {
                throw new InvalidDataException(StringTable.ErrorCannotParseOutout);
            }

            return outputAsset;
        }
    }
}
