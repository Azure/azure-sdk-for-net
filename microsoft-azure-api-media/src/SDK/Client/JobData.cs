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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Xml;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    [DataServiceKey("Id")]
    internal partial class JobData : IJob, ICloudMediaContextInit
    {
        private const string JobSet = "Jobs";
        private const string TaskBodyNodeName = "taskBody";
        private const string InputAssetNodeName = "inputAsset";
        private const string OutputAssetNodeName = "outputAsset";
        private const string AssetCreationOptionsAttributeName = "AssetCreationOptions";
        private CloudMediaContext _cloudMediaContext;
        private ReadOnlyCollection<IAsset> _inputMediaAssets;
        private ReadOnlyCollection<IAsset> _outputMediaAssets;
        private TaskCollection _tasks;

        public JobData()
        {
            Tasks = new List<TaskData>();
            InputMediaAssets = new List<AssetData>();
            OutputMediaAssets = new List<AssetData>();
        }

        public List<AssetData> InputMediaAssets { get; set; }
        public List<AssetData> OutputMediaAssets { get; set; }
        public List<TaskData> Tasks { get; set; }

        #region ICloudMediaContextInit Members

        public void InitCloudMediaContext(CloudMediaContext context)
        {
            _cloudMediaContext = context;
        }

        #endregion

        #region IJob Members

        ReadOnlyCollection<IAsset> IJob.InputMediaAssets
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

                    _inputMediaAssets = InputMediaAssets.ToList<IAsset>().AsReadOnly();
                }
                return _inputMediaAssets;
            }
        }

        ReadOnlyCollection<IAsset> IJob.OutputMediaAssets
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

                    _outputMediaAssets = OutputMediaAssets.ToList<IAsset>().AsReadOnly();
                }
                return _outputMediaAssets;
            }
        }

        TaskCollection IJob.Tasks
        {
            get
            {
                if (_tasks == null)
                {
                    if (_cloudMediaContext != null)
                    {
                        EntityDescriptor desc = _cloudMediaContext.DataContext.GetEntityDescriptor(this);
                        if (desc != null &&
                            (desc.State == EntityStates.Unchanged || desc.State == EntityStates.Modified))
                        {
                            _cloudMediaContext.DataContext.LoadProperty(this, "Tasks");
                        }
                    }
                    _tasks = new TaskCollection(this, Tasks);
                }
                return _tasks;
            }
        }


        /// <summary>
        ///   Sends request to cancel a job. After job has been submitted to cancelation system trys to cancel it.
        /// </summary>
        public void Cancel()
        {
            Uri uri =
                new Uri(
                    string.Format(CultureInfo.InvariantCulture, "/CancelJob?jobid='{0}'", HttpUtility.UrlEncode(Id)),
                    UriKind.Relative);
            _cloudMediaContext.DataContext.Execute<string>(uri);
            _cloudMediaContext.Jobs.Where(c => c.Id == Id).First();
            JobEntityRefresh();
        }


        /// <summary>
        ///   Deletes this instance.
        /// </summary>
        public void Delete()
        {
            _cloudMediaContext.DataContext.DeleteObject(this);
            _cloudMediaContext.DataContext.SaveChanges();
        }

        /// <summary>
        ///   Submits this instance.
        /// </summary>
        public void Submit()
        {
            X509Certificate2 certToUse = null;
            VerifyJob(this);

            _cloudMediaContext.DataContext.AddObject(JobSet, this);

            List<AssetData> inputAssets = new List<AssetData>();
            AssetNamingSchemeResolver<AssetData, OutputAsset> assetNamingSchemeResolver =
                new AssetNamingSchemeResolver<AssetData, OutputAsset>(inputAssets);

            foreach (ITask task in ((IJob) this).Tasks)
            {
                VerifyTask(task);
                TaskData taskData = (TaskData) task;

                if (task.Options.HasFlag(TaskCreationOptions.ProtectedConfiguration))
                {
                    ProtectTaskConfiguration(taskData, ref certToUse);
                }

                taskData.TaskBody = CreateTaskBody(assetNamingSchemeResolver, task.InputMediaAssets.ToArray(),
                                                   task.OutputMediaAssets.ToArray());
                taskData.InputMediaAssets.AddRange(task.InputMediaAssets.OfType<AssetData>().ToArray());
                taskData.OutputMediaAssets.AddRange(
                    task.OutputMediaAssets.OfType<OutputAsset>().Select(c => new AssetData() { Name = c.Name, Options = (int)c.Options, AlternateId =c.AlternateId}).ToArray());
                _cloudMediaContext.DataContext.AddRelatedObject(this, "Tasks", taskData);
             
                
            }
            foreach (IAsset asset in inputAssets)
            {
                _cloudMediaContext.DataContext.AddLink(this, "InputMediaAssets", asset);
            }

            _cloudMediaContext.DataContext.SaveChanges(SaveChangesOptions.Batch);

            JobEntityRefresh();
        }

        private void JobEntityRefresh()
        {
            foreach (ITask task in ((IJob) this).Tasks)
            {
                TaskData taskData = (TaskData) task;
                foreach (var asset in taskData.OutputMediaAssets)
                {
                    _cloudMediaContext.DataContext.Detach(asset);
                }
                taskData.OutputMediaAssets = null;
                taskData.InputMediaAssets = null;
                _cloudMediaContext.Detach(taskData);
            }
            _tasks = null;
            _inputMediaAssets = null;
            _outputMediaAssets = null;
            InputMediaAssets.Clear();
            OutputMediaAssets.Clear();

            _cloudMediaContext.Jobs.Where(c => c.Id == Id).First();
        }

        private static void VerifyJob(JobData jobData)
        {
            var atleastOne = false;

            var data = (IJob) jobData;
            if (data.Tasks.Count == 0)
            {
                throw new ArgumentException(StringTable.EmptyTaskArray);
            }

            foreach (ITask task in data.Tasks)
            {
                if (task.InputMediaAssets.Count == 0) { throw new ArgumentException(StringTable.EmptyInputArray); }
                if (task.OutputMediaAssets.Count == 0) { throw new ArgumentException(StringTable.EmptyOutputArray); }
                if (!atleastOne)
                {
                    var output = task.OutputMediaAssets.SingleOrDefault(c => ((OutputAsset) c).IsTemporary == false);
                    if (output != null)
                    {
                        atleastOne = true;
                    }
                }
            }


            if (!atleastOne)
            {
                throw new ArgumentException(StringTable.NoPermanentOutputs);
            }

        }

        #endregion

        private static JobState GetExposedState(int state)
        {
            return (JobState) state;
        }

        private static TimeSpan GetExposedRunningDuration(double runningDuration)
        {
            return TimeSpan.FromMilliseconds((int) runningDuration);
        }

        private void ProtectTaskConfiguration(TaskData taskData, ref X509Certificate2 certToUse)
        {
            using (ConfigurationEncryption configEncryption = new ConfigurationEncryption())
            {
                // Update the task with the required data                        
                taskData.Configuration = configEncryption.Encrypt(taskData.Configuration);
                taskData.EncryptionKeyId = configEncryption.GetKeyIdentifierAsString();
                taskData.EncryptionScheme = ConfigurationEncryption.SchemeName;
                taskData.EncryptionVersion = ConfigurationEncryption.SchemeVersion;
                taskData.InitializationVector = configEncryption.GetInitializationVectorAsString();

                if (certToUse == null)
                {
                    // Get the certificate to use to encrypt the configuration encryption key
                    certToUse =
                        BaseContentKeyCollection.GetCertificateToEncryptContentKey(_cloudMediaContext.DataContext,ContentKeyType.ConfigurationEncryption);
                }

                // Create a content key object to hold the encryption key
                ContentKeyData contentKeyData = BaseContentKeyCollection.CreateConfigurationContentKey(
                    configEncryption, certToUse);
                _cloudMediaContext.DataContext.AddObject(ContentKeyCollection.ContentKeySet, contentKeyData);
            }
        }

        private static string CreateTaskBody(
            AssetNamingSchemeResolver<AssetData, OutputAsset> assetNamingSchemeResolver,
            IEnumerable<IAsset> inputs,
            IEnumerable<IAsset> outputs)
        {
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                XmlWriterSettings outputSettings = new XmlWriterSettings();
                outputSettings.Encoding = Encoding.UTF8;
                outputSettings.Indent = true;
                XmlWriter taskBody = XmlWriter.Create(stringWriter, outputSettings);
                taskBody.WriteStartDocument();
                taskBody.WriteStartElement(TaskBodyNodeName);

                foreach (IAsset input in inputs)
                {
                    taskBody.WriteStartElement(InputAssetNodeName);
                    taskBody.WriteString(assetNamingSchemeResolver.GetAssetId(input));
                    taskBody.WriteEndElement();
                }
                foreach (IAsset output in outputs)
                {
                    taskBody.WriteStartElement(OutputAssetNodeName);

                    var outputAsset = ((OutputAsset) output);
                    if (outputAsset.Options != AssetCreationOptions.None)
                    {
                        int options = (int) outputAsset.Options;
                        taskBody.WriteAttributeString(AssetCreationOptionsAttributeName,
                                                      options.ToString(CultureInfo.InvariantCulture));
                    }

                    taskBody.WriteString(assetNamingSchemeResolver.GetAssetId(output));
                    taskBody.WriteEndElement();
                }

                taskBody.WriteEndDocument();
                taskBody.Flush();

                return stringWriter.ToString();
            }
        }

        private static void VerifyTask(ITask task)
        {
            if (task == null) throw new ArgumentNullException("task");
            if (!(task is TaskData))
            {
                throw new InvalidCastException(StringTable.ErrorInvalidTaskType);
            }
        }
    }
}
