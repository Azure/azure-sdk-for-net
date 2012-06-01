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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Services.Client;
using System.Data.Services.Common;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    [DataServiceKey("Id")]
    internal partial class JobTemplateData : IJobTemplate, ICloudMediaContextInit
    {
        private const string TaskTemplatesPropertyName = "TaskTemplates";
        private CloudMediaContext _cloudMediaContext;
        private ReadOnlyCollection<ITaskTemplate> _taskTemplates;

        public JobTemplateData()
        {
            TaskTemplates = new List<TaskTemplateData>();
        }

        public void InitCloudMediaContext(CloudMediaContext context)
        {
            _cloudMediaContext = context;
        }

        static private TemplateType GetExposedTemplateType(int type)
        {
            return (TemplateType)type;
        }
        static private int GetInternalTemplateType(TemplateType type)
        {
            return (int)type;
        }

        public List<TaskTemplateData> TaskTemplates { get; set; }

        ReadOnlyCollection<ITaskTemplate> IJobTemplate.TaskTemplates
        {
            get
            {
                if (_taskTemplates == null)
                {
                    if (_cloudMediaContext != null)
                    {
                        EntityDescriptor desc = _cloudMediaContext.DataContext.GetEntityDescriptor(this);
                        if (desc != null && (desc.State == EntityStates.Unchanged || desc.State == EntityStates.Modified))
                        {
                            _cloudMediaContext.DataContext.LoadProperty(this, TaskTemplatesPropertyName);
                            ResolveTaskTemplateInputsAndOuputs();
                        }
                    }
                    _taskTemplates = new ReadOnlyCollection<ITaskTemplate>(new List<ITaskTemplate>(TaskTemplates));
                }
                return _taskTemplates;
            }
        }

        private void ResolveTaskTemplateInputsAndOuputs()
        {
            AssetPlaceholderToInstanceResolver assetPlaceholderToInstanceResolver = new AssetPlaceholderToInstanceResolver();

            using (StringReader stringReader = new StringReader(JobTemplateBody))
            {
                XElement root = XElement.Load(stringReader);

                foreach (XElement taskBody in root.Elements("taskBody"))
                {
                    List<IAsset> taskTemplateInputs = new List<IAsset>();
                    List<IAsset> taskTemplateOutputs = new List<IAsset>();

                    string taskTemplateId = (string)taskBody.Attribute("taskTemplateId");

                    TaskTemplateData taskTemplate = TaskTemplates.Where(t => t.Id == taskTemplateId).Single();

                    foreach (XElement input in taskBody.Elements("inputAsset"))
                    {
                        string inputName = (string)input.Value;
                        taskTemplateInputs.Add(assetPlaceholderToInstanceResolver.CreateOrGetInputAsset(inputName));
                    }

                    foreach (XElement output in taskBody.Elements("outputAsset"))
                    {
                        string outputName = (string)output.Value;
                        taskTemplateOutputs.Add(assetPlaceholderToInstanceResolver.CreateOrGetOutputAsset(outputName));
                    }

                    taskTemplate.TaskInputs = taskTemplateInputs.ToArray();
                    taskTemplate.TaskOutputs = taskTemplateOutputs.ToArray();
                }
            }
        }
    }
}
