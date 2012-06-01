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
using System.Collections.ObjectModel;
using System.Data.Services.Client;
using System.Data.Services.Common;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    [DataServiceKey("Id")]
    internal partial class TaskData : ITask, ICloudMediaContextInit
    {
        private CloudMediaContext _cloudMediaContext;
        private InputAssetCollection<IAsset> _inputMediaAssets;
        private OutputAssetCollection _outputMediaAssets;

        public TaskData()
        {
            Id = string.Empty;
            InputMediaAssets = new List<AssetData>();
            OutputMediaAssets = new List<AssetData>();
            ErrorDetails = new List<ErrorDetail>();
        }

        public IAsset[] TaskInputs { get; set; }
        public IAsset[] TaskOutputs { get; set; }

        public List<AssetData> InputMediaAssets { get; set; }
        public List<AssetData> OutputMediaAssets { get; set; }
        public List<ErrorDetail> ErrorDetails { get; set; }

        #region ICloudMediaContextInit Members

        public void InitCloudMediaContext(CloudMediaContext context)
        {
            _cloudMediaContext = context;
        }

        #endregion

        #region ITask Members

        public double Progress { get; set; }

        ReadOnlyCollection<ErrorDetail> ITask.ErrorDetails
        {
            get { return ErrorDetails.AsReadOnly(); }
        }

        public string GetClearConfiguration()
        {
            var options = (TaskCreationOptions)Options;

            string returnValue = null;

            if (options.HasFlag(TaskCreationOptions.ProtectedConfiguration) && (!String.IsNullOrEmpty(EncryptionKeyId)))
            {
                if (_cloudMediaContext != null)
                {
                    returnValue = ConfigurationEncryptionHelper.DecryptConfigurationString(_cloudMediaContext, EncryptionKeyId,
                                                                              InitializationVector, Configuration);
                }
            }
            else
            {
                return Configuration;
            }

            return returnValue;
        }

        InputAssetCollection<IAsset> ITask.InputMediaAssets
        {
            get
            {
                if (_inputMediaAssets == null)
                {
                    if (_cloudMediaContext != null)
                    {
                        EntityDescriptor desc = _cloudMediaContext.DataContext.GetEntityDescriptor(this);
                        if (desc != null &&
                            (desc.State == EntityStates.Unchanged || desc.State == EntityStates.Modified))
                        {
                            _cloudMediaContext.DataContext.LoadProperty(this, "InputMediaAssets");
                        }
                    }

                    _inputMediaAssets = new InputAssetCollection<IAsset>(this,InputMediaAssets);
                }
                return _inputMediaAssets;
            }
        }

        OutputAssetCollection ITask.OutputMediaAssets
        {
            get
            {
                if (_outputMediaAssets == null)
                {
                    if (_cloudMediaContext != null)
                    {
                        EntityDescriptor desc = _cloudMediaContext.DataContext.GetEntityDescriptor(this);
                        if (desc != null &&
                            (desc.State == EntityStates.Unchanged || desc.State == EntityStates.Modified))
                        {
                            _cloudMediaContext.DataContext.LoadProperty(this, "OutputMediaAssets");
                        }
                    }

                    _outputMediaAssets = new OutputAssetCollection(this, OutputMediaAssets);
                }
                return _outputMediaAssets;
            }
        }

        #endregion

        private static JobState GetExposedState(int state)
        {
            return (JobState)state;
        }

        private static TimeSpan GetExposedRunningDuration(double runningDuration)
        {
            return TimeSpan.FromMilliseconds((int)runningDuration);
        }

        private static TaskCreationOptions GetExposedOptions(int options)
        {
            return (TaskCreationOptions)options;
        }
    }
}