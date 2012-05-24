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
using System.Collections.ObjectModel;
using System.Data.Services.Common;
using System.Globalization;
using System.Linq;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    [DataServiceKey("Id")]
    partial class TaskTemplateData : ITaskTemplate, ICloudMediaContextInit
    {
        private CloudMediaContext _cloudMediaContext;
        public IAsset[] TaskInputs { get; set; }
        public IAsset[] TaskOutputs { get; set; }

        public void InitCloudMediaContext(CloudMediaContext context)
        {
            _cloudMediaContext = context;
        }
        
        /// <summary>
        /// Decrypts an encrypted task configuration.
        /// </summary>
        /// <returns>The decrypted task configuration if it was encrypted; otherwise the <see cref="Configuration"/>.</returns>
        /// <seealso cref="ITaskTemplate.EncryptionKeyId"/>
        public string GetClearConfiguration()
        {
            TaskCreationOptions options = (TaskCreationOptions)Options;

            string returnValue = null;

            if (options.HasFlag(TaskCreationOptions.ProtectedConfiguration) && (!String.IsNullOrEmpty(EncryptionKeyId)))
            {
                if (_cloudMediaContext != null)
                {
                    returnValue = ConfigurationHelper.DecryptConfigurationString(_cloudMediaContext, EncryptionKeyId, InitializationVector, Configuration);
                }
            }
            else
            {
                return Configuration;
            }

            return returnValue;        
        }

       

        private static TaskCreationOptions GetExposedOptions(int options)
        {
            return (TaskCreationOptions)options;
        }

        ReadOnlyCollection<IAsset> ITaskTemplate.TaskInputs
        {
            get
            {
                return new ReadOnlyCollection<IAsset>(TaskInputs);
            }
        }

        ReadOnlyCollection<IAsset> ITaskTemplate.TaskOutputs
        {
            get
            {
                return new ReadOnlyCollection<IAsset>(TaskOutputs);
            }
        }
    }
}
