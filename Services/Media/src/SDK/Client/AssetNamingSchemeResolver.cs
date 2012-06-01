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

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    internal class AssetNamingSchemeResolver<TInputAsset, TOutputAsset>
        where TInputAsset : class
        where TOutputAsset : class
    {
        private readonly List<TInputAsset> _inputAssets;
        private readonly List<TOutputAsset> _tempAssets = new List<TOutputAsset>();
        private readonly List<TOutputAsset> _outputAssets = new List<TOutputAsset>();

        public AssetNamingSchemeResolver(List<TInputAsset> inputAssets)
        {
            _inputAssets = inputAssets;
        }

        public AssetNamingSchemeResolver() : this(new List<TInputAsset>())
        {
        }

        static private int CalcIndex<T>(T obj, List<T> list)
        {
            int index = list.IndexOf(obj);
            if (index == -1)
            {
                list.Add(obj);
                index = list.Count - 1;
            }
            return index;
        }

        public string GetAssetId(object obj)
        {
            TInputAsset asset = obj as TInputAsset;
            if (asset != null)
            {
                return string.Format(CultureInfo.InvariantCulture, "JobInputAsset({0})", CalcIndex(asset, _inputAssets));
            }

            OutputAsset outputAsset = obj as OutputAsset;
            if (outputAsset != null)
            {
                TOutputAsset toutputAsset = outputAsset as TOutputAsset;
                if (outputAsset.IsTemporary)
                {
                    return string.Format(CultureInfo.InvariantCulture, "TemporaryAsset({0})", CalcIndex(toutputAsset, _tempAssets));
                }
                else
                {
                    return string.Format(CultureInfo.InvariantCulture, "JobOutputAsset({0})", CalcIndex(toutputAsset, _outputAssets));
                }
            }

            throw new InvalidCastException(StringTable.ErrorInvalidTaskInput);
        }

        public IList<TInputAsset> Inputs
        {
            get { return _inputAssets; }
        }

        public IList<TOutputAsset> Outputs
        {
            get { return _outputAssets; }
        }

        public IList<TOutputAsset> Temporaries
        {
            get { return _tempAssets; }
        }
    }
}
