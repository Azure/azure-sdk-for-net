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
using System.Data.Services.Client;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    ///   Represents a collection of JobTemplates.
    /// </summary>
    internal class JobTemplateCollection : BaseCloudCollection<IJobTemplate>
    {
        private const string JobTemplateSet = "JobTemplates";
        private const string TaskTemplatesOdataProperty = "TaskTemplates";
        private readonly Dictionary<string, string> _mediaProcessorIds = new Dictionary<string, string>();
        private readonly CloudMediaContext _cloudMediaContext;

        internal JobTemplateCollection(CloudMediaContext cloudMediaContext)
            : base(cloudMediaContext.DataContext, cloudMediaContext.DataContext.CreateQuery<JobTemplateData>(JobTemplateSet))
        {
            _cloudMediaContext = cloudMediaContext;
        }

        /// <summary>
        ///   Creates a JobTemplate with the provided <paramref name="taskTemplates" /> .
        /// </summary>
        /// <param name="name"> A friendly name for the JobTemplate. </param>
        /// <param name="taskTemplates"> The TaskTemplates that compose a JobTemplate. </param>
        /// <returns> A new JobTemplate composed of the provided <paramref name="taskTemplates" /> . </returns>
        /// <exception cref="ArgumentNullException">If
        ///   <paramref name="taskTemplates" />
        ///   is null.</exception>
        /// <exception cref="ArgumentException">If
        ///   <paramref name="taskTemplates" />
        ///   is empty.</exception>
        public IJobTemplate Create(string name, params ITaskTemplate[] taskTemplates)
        {
            X509Certificate2 certToUse = null;

            if (taskTemplates == null)
            {
                throw new ArgumentNullException("taskTemplates");
            }

            if (taskTemplates.Length == 0)
            {
                throw new ArgumentException(StringTable.EmptyTaskArray, "taskTemplates");
            }

            JobTemplateData jobTemplateData = new JobTemplateData();
            jobTemplateData.Name = name;
            jobTemplateData.TemplateType = (int) TemplateType.AccountLevel;
            DataContext.AddObject(JobTemplateSet, jobTemplateData);

            foreach (ITaskTemplate taskTemplate in taskTemplates)
            {
                Verify(taskTemplate);
                DataContext.AddRelatedObject(jobTemplateData, TaskTemplatesOdataProperty, taskTemplate);

                if (taskTemplate.Options.HasFlag(TaskCreationOptions.ProtectedConfiguration))
                {
                    using (ConfigurationEncryption configEncryption = new ConfigurationEncryption())
                    {
                        // Update the task template with the required data
                        TaskTemplateData taskTemplateData = (TaskTemplateData) taskTemplate;
                        taskTemplateData.Configuration = configEncryption.Encrypt(taskTemplate.Configuration);
                        taskTemplateData.EncryptionKeyId = configEncryption.GetKeyIdentifierAsString();
                        taskTemplateData.EncryptionScheme = ConfigurationEncryption.SchemeName;
                        taskTemplateData.EncryptionVersion = ConfigurationEncryption.SchemeVersion;
                        taskTemplateData.InitializationVector = configEncryption.GetInitializationVectorAsString();

                        if (certToUse == null)
                        {
                            // Get the certificate to use to encrypt the configuration encryption key
                            certToUse = BaseContentKeyCollection.GetCertificateToEncryptContentKey(_cloudMediaContext.DataContext, ContentKeyType.ConfigurationEncryption);
                        }

                        // Create a content key object to hold the encryption key
                        ContentKeyData contentKeyData = BaseContentKeyCollection.CreateConfigurationContentKey(configEncryption, certToUse);
                        DataContext.AddObject(ContentKeyCollection.ContentKeySet, contentKeyData);
                    }
                }
            }

            AssetNamingSchemeResolver<JobTemplateInputAsset, OutputAsset> assetIdMap =
                new AssetNamingSchemeResolver<JobTemplateInputAsset, OutputAsset>();

            jobTemplateData.JobTemplateBody = CreateJobTemplateBody(assetIdMap, taskTemplates);

            jobTemplateData.NumberofInputAssets = assetIdMap.Inputs.Count;

            DataContext.SaveChanges(SaveChangesOptions.Batch);


            IJobTemplate jobTemplateToReturn = ((IQueryable<JobTemplateData>) Queryable).Where(c => c.Id == jobTemplateData.Id).First();
            DataContext.LoadProperty(jobTemplateData, "TaskTemplates");
            return jobTemplateToReturn;
        }

        /// <summary>
        ///   Creates a TaskTemplate using the specified encoder.
        /// </summary>
        /// <param name="name"> A friendly name for the TaskTemplate. </param>
        /// <param name="encoder"> The encoder for the TaskTemplate. </param>
        /// <param name="configuration"> The configuration for the TaskTemplate. </param>
        /// <param name="inputs"> The collection of input Asset for the TaskTemplate. </param>
        /// <param name="outputs"> The collection of output Asset for the TaskTemplate. </param>
        /// <returns> A new TaskTemplate using the provided <paramref name="encoder" /> and <paramref name="configuration" /> . </returns>
        /// <exception cref="ArgumentNullException">If
        ///   <paramref name="inputs" />
        ///   is null.</exception>
        /// <exception cref="ArgumentException">If
        ///   <paramref name="inputs" />
        ///   is empty.</exception>
        /// <exception cref="ArgumentNullException">If
        ///   <paramref name="outputs" />
        ///   is null.</exception>
        /// <exception cref="ArgumentException">If
        ///   <paramref name="outputs" />
        ///   is empty.</exception>
        public ITaskTemplate CreateTaskTemplate(string name, string encoder, string configuration, IAsset[] inputs, IAsset[] outputs)
        {
            return CreateTaskTemplate(name, encoder, configuration, TaskCreationOptions.None, inputs, outputs);
        }

        /// <summary>
        ///   Creates a TaskTemplate using the specified encoder.
        /// </summary>
        /// <param name="name"> A friendly name for the TaskTemplate. </param>
        /// <param name="encoder"> The encoder for the TaskTemplate. </param>
        /// <param name="configuration"> The configuration for the TaskTemplate. </param>
        /// <param name="options"> The TaskTemplate creation options. </param>
        /// <param name="inputs"> The collection of input Asset for the TaskTemplate. </param>
        /// <param name="outputs"> The collection of output Asset for the TaskTemplate. </param>
        /// <returns> A new TaskTemplate using the provided <paramref name="encoder" /> and <paramref name="configuration" /> . </returns>
        /// <exception cref="ArgumentNullException">If
        ///   <paramref name="inputs" />
        ///   is null.</exception>
        /// <exception cref="ArgumentException">If
        ///   <paramref name="inputs" />
        ///   is empty.</exception>
        /// <exception cref="ArgumentNullException">If
        ///   <paramref name="outputs" />
        ///   is null.</exception>
        /// <exception cref="ArgumentException">If
        ///   <paramref name="outputs" />
        ///   is empty.</exception>
        public ITaskTemplate CreateTaskTemplate(string name, string encoder, string configuration, TaskCreationOptions options, IAsset[] inputs, IAsset[] outputs)
        {
            if (inputs == null)
            {
                throw new ArgumentNullException("inputs");
            }
            if (inputs.Length == 0)
            {
                throw new ArgumentException(StringTable.EmptyInputArray, "inputs");
            }
            if (outputs == null)
            {
                throw new ArgumentNullException("outputs");
            }
            if (outputs.Length == 0)
            {
                throw new ArgumentException(StringTable.EmptyOutputArray, "outputs");
            }

            TaskTemplateData taskTemplateData =
                new TaskTemplateData
                    {
                        Name = name,
                        MediaProcessorId = GetMediaProcessorId(encoder),
                        Configuration = configuration,
                        TaskInputs = inputs,
                        TaskOutputs = outputs,
                        NumberofInputAssets = inputs.Length,
                        NumberofOutputAssets = outputs.Length,
                        Options = (int) options
                    };
            return taskTemplateData;
        }

        /// <summary>
        ///   Updates JobTemplate
        /// </summary>
        /// <param name="jobTemplate"> The JobTemplate to track as updated. </param>
        public void Update(IJobTemplate jobTemplate)
        {
            Verify(jobTemplate);
            DataContext.UpdateObject(jobTemplate);
            DataContext.SaveChanges();
        }

        /// <summary>
        ///   Delets JobTemplate
        /// </summary>
        /// <param name="jobTemplate"> The JobTemplate to delete </param>
        public void Delete(IJobTemplate jobTemplate)
        {
            Verify(jobTemplate);
            DataContext.DeleteObject(jobTemplate);
            DataContext.SaveChanges();
        }

        private static string CreateJobTemplateBody(AssetNamingSchemeResolver<JobTemplateInputAsset, OutputAsset> assetMap, ITaskTemplate[] taskTemplates)
        {
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                XmlWriterSettings outputSettings =
                    new XmlWriterSettings
                        {
                            Encoding = Encoding.UTF8,
                            Indent = true
                        };

                XmlWriter jobTemplateBody = XmlWriter.Create(stringWriter, outputSettings);
                jobTemplateBody.WriteStartDocument();

                jobTemplateBody.WriteStartElement("jobTemplate");

                foreach (ITaskTemplate taskTemplate in taskTemplates)
                {
                    TaskTemplateData taskTemplateData = (TaskTemplateData) taskTemplate;
                    taskTemplateData.NumberofInputAssets = taskTemplateData.TaskInputs.Length;
                    taskTemplateData.NumberofOutputAssets = taskTemplateData.TaskOutputs.Length;
                    taskTemplateData.Id = "nb:ttid:UUID:" + Guid.NewGuid();

                    jobTemplateBody.WriteStartElement("taskBody");
                    jobTemplateBody.WriteAttributeString("taskTemplateId", taskTemplateData.Id);

                    foreach (IAsset input in taskTemplateData.TaskInputs)
                    {
                        jobTemplateBody.WriteStartElement("inputAsset");
                        jobTemplateBody.WriteString(assetMap.GetAssetId(input));
                        jobTemplateBody.WriteEndElement();
                    }

                    foreach (IAsset output in taskTemplateData.TaskOutputs)
                    {
                        jobTemplateBody.WriteStartElement("outputAsset");

                        if (((OutputAsset) output).Options != (int) AssetCreationOptions.None)
                        {
                            int options = (int) ((OutputAsset) output).Options;
                            jobTemplateBody.WriteAttributeString("AssetCreationOptions", options.ToString(CultureInfo.InvariantCulture));
                        }

                        jobTemplateBody.WriteString(assetMap.GetAssetId(output));
                        jobTemplateBody.WriteEndElement();
                    }

                    jobTemplateBody.WriteEndElement();
                }

                jobTemplateBody.WriteEndDocument();
                jobTemplateBody.Flush();

                return stringWriter.ToString();
            }
        }

        private string GetMediaProcessorId(string mediaProcessor)
        {
            string id;
            if (_mediaProcessorIds.TryGetValue(mediaProcessor, out id))
            {
                return id;
            }

            IMediaProcessor processor = _cloudMediaContext.MediaProcessors.Where(c => c.Name == mediaProcessor).First();
            if (processor == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, StringTable.UnknownMediaProcessor, mediaProcessor));
            }

            _mediaProcessorIds.Add(mediaProcessor, processor.Id);
            return processor.Id;
        }

        private static void Verify(IJobTemplate jobTemplate)
        {
            if (jobTemplate == null) throw new ArgumentNullException("jobTemplate");
            if (!(jobTemplate is JobTemplateData))
            {
                throw new InvalidCastException(StringTable.ErrorInvalidJobType);
            }
        }

        private static void Verify(ITaskTemplate taskTemplate)
        {
            if (taskTemplate == null) throw new ArgumentNullException("taskTemplate");
            if (!(taskTemplate is TaskTemplateData))
            {
                throw new InvalidCastException(StringTable.ErrorInvalidTaskType);
            }
        }
    }
}
