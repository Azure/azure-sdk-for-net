using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;
using System.Threading;
using System.Diagnostics;
using System.Security;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using BatchFS=Microsoft.Azure.Batch.FileStaging;

// ====================================================================================================================================
// TODO: Before we go open source, reconsider whether this file should be published or not.  This is not currently part of the product.
// ====================================================================================================================================

namespace Microsoft.Azure.Batch.FileStaging
{
    /// <summary>
    /// This class will be serialized into an xml file Microsoft.Batch.Manifest.xml 
    /// </summary>
    internal class Manifest
    {
        string taskExeName;
        public List<Record> list;

        public Manifest()
        {
        }

        public Manifest(string taskExeName)
        {
            this.taskExeName = taskExeName;
            list = new List<Record>();
        }

        public class Record
        {
            public string zipFileName;

            // this should be a relative path under working directory
            public string targetComputeNodeUnzipPath;

            public Record()
            {
            }

            public Record(string zipFileName, string targetComputeNodeUnzipPath)
            {
                this.zipFileName = zipFileName;
                this.targetComputeNodeUnzipPath = targetComputeNodeUnzipPath;
            }
        }

        public void AddPair(string zipFileName, string targetComputeNodeUnzipPath)
        {
            list.Add(new Record(zipFileName, targetComputeNodeUnzipPath));
        }
    }

    /*
    /// <summary>
    /// Provides for file staging of local directory to blob storage.
    /// </summary>
    public sealed class DirectoryToStage : IFileStagingProvider
    {
        private readonly StorageCredentials _storeCredentials;  // storage credentials to used for this file
        private readonly string _localDirectory; // this is the file to copy up to blob storage
        private readonly string _targetComputeNodeUnzipPath; // this is the folder on compute node for the zip file to be unzipped
        private IEnumerable<ResourceFile> _stagedFiles; // this is RF containing the SAS of the actual blob created for the local file
        private Exception _stagingException; // holds the exception that occured while staging this file.
        //private string _namingFragment;  // to be used to construct default container name
        private ICloudTask _task;
        private string _commandLine = String.Empty;

        // A directory will actually be converted into up to two FileToStage objects: a zip file and (or) a manifest file
        // the last DirectoryToStage object will have two FileToStage objects since the manifest file will surely be added to it
        private List<IFileStagingProvider> fileSToStageContained;

        private const string ManifestName = "Microsoft.Batch.Manifest.xml";
        /// <summary>
        /// Task which will own this directoryToStage object
        /// </summary>
        public ICloudTask Task
        {
            get { return _task; }
        }

        /// <summary>
        /// The name of the local directory to stage to blob storage
        /// </summary>
        public string LocalDirectoryToStage
        {
            get { return _localDirectory; }
        }

        /// <summary>
        /// The target directory to contain the unzipped folder
        /// </summary>
        public string TargetComputeNodeUnzipRelativePath
        {
            get { return _targetComputeNodeUnzipRelativePath; }
        }

        /// <summary>
        /// The ResourcesFiles for the staged local directory.
        /// it consists of two files: 1. zip file from the directory; 2. manifest file 
        /// </summary>
        public IEnumerable<ResourceFile> StagedFiles
        {
            get { return AggregateResouceFiles(); }
            internal set { _stagedFiles = value; }
        }

        public Exception ExceptionCaughtWhileStaging
        {
            get { return _stagingException; }
            internal set { _stagingException = value; }
        }

        #region constructors

        private IEnumerable<ResourceFile> AggregateResouceFiles()
        {
            List<ResourceFile> list = new List<ResourceFile>();

            foreach (FileToStage fileToStage in fileSToStageContained)
            {
                foreach (ResourceFile file in fileToStage.StagedFiles)
                {
                    list.Add(file);
                }
            }

            return _stagedFiles = list;
        }

        private DirectoryToStage()
        {
        }

        /// <summary>
        /// Specifies that a local directory should be zipped and staged to Blob Storage.
        /// </summary>
        /// <param name="localDirectoryToStage">The name of the local directory.</param>
        /// <param name="storeCredentials">The storage credentials to be used when creating the default container.</param>
        /// <param name="targetComputeNodeUnzipDirectory">The directory used to contain all unzipped files, it has the format like "folder1\folder2\currentFolder"</param>
        public DirectoryToStage(ICloudTask task, string localDirectoryToStage, StorageCredentials storeCredentials, string targetComputeNodeUnzipRelativePath)
        {
            _task = task;
            _localDirectory = localDirectoryToStage.TrimEnd(new char[] { '\\' });
            _storeCredentials = storeCredentials;
            _targetComputeNodeUnzipRelativePath = targetComputeNodeUnzipRelativePath != null ? targetComputeNodeUnzipRelativePath.Trim(new char[] { '\\' }) : String.Empty;
            fileSToStageContained = new List<IFileStagingProvider>();
        }

        #endregion // constructors

        #region // IFileStagingProvider

        /// <summary>
        /// Starts an asynchronous call to stage the given files.
        /// Meanwhile, create a manifest file for each task
        /// </summary>
        /// <param name="filesToStage"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task StageFilesAsync(List<IFileStagingProvider> directoriesToStage, IFileStagingArtifact fileStagingArtifact)
        {
            if (directoriesToStage == null)
            {
                throw new ArgumentNullException("directoriesToStage");
            }

            if (directoriesToStage.Count <= 0)
            {
                return;
            }

            // Validate whether a task has been added two DirectoryToStage objects that has the same folder name and TargetComputeNodeUnzipRelativePath
            ValidateFolderNameAndRelativePaths(directoriesToStage);

            List<IFileStagingProvider> jobFilestoStage = new List<IFileStagingProvider>();

            // record the mapping between a task and list of DirectoryToStage belonging to this task
            Dictionary<ICloudTask, List<IFileStagingProvider>> buckets = new Dictionary<ICloudTask, List<IFileStagingProvider>>();

            // record the mapping between DirectoryToStage object to zip file name from which the DirectoryToStage object was generated
            Dictionary<IFileStagingProvider, String> dic = new Dictionary<IFileStagingProvider, String>();

            try
            {
                // for each DirectoryToStage, create a zip file for it
                foreach (DirectoryToStage directory in directoriesToStage)
                {
                    // in order to maintain the name uniqueness of the zip file, the name of the zip file would be randomly generated and has 8 charaters. 
                    // The zip file will be put in the same root directory. For example, for "c:\folderForTasks\task1", the zip file would be "c:\df23d5td.zip". 
                    string directoryName = directory._localDirectory;

                    string zipfileName = String.Format(@"{0}{1}{2}", Directory.GetDirectoryRoot(directoryName), Guid.NewGuid().ToString().Substring(0, 8), ".zip");

                    ZipFile.CreateFromDirectory(directoryName, zipfileName);

                    FileToStage fileToStage = new FileToStage(zipfileName, _storeCredentials);

                    directory.fileSToStageContained.Add(fileToStage);

                    jobFilestoStage.Add(fileToStage);

                    List<IFileStagingProvider> list;

                    // if no bucket exists, create one 
                    if (!buckets.TryGetValue(directory.Task, out list))
                    {
                        list = new List<IFileStagingProvider>();

                        // one more bucket
                        buckets.Add(directory.Task, list);
                    }

                    list.Add(directory);
                    dic.Add(directory, Path.GetFileName(zipfileName));
                }

                // create a manifest file for each task
                // in order to maintain name uniqueness of all manifest files, once the file is created locally
                // we use a random 8-bit string as it is name
                foreach (ICloudTask task in buckets.Keys)
                {
                    // By default, all manisfest files are stored under "C" drive
                    // besides, we use a 8-bit random string as folder name under C drive to contain the manifest file
                    // in order for uniqueness
                    string uniqueFolderName = Guid.NewGuid().ToString().Substring(0, 8);

                    // Store the manifest file under current working directory
                    // If the user does not have write priviledge to write here,  then he would get an IO exception 
                    string directory = Path.Combine(Directory.GetCurrentDirectory(), uniqueFolderName);

                    // if the directory does not exist, create it
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string fileName = String.Format(@"{0}\{1}", directory, ManifestName);

                    Manifest manifest = new Manifest(task.Name);

                    List<IFileStagingProvider> list;
                    DirectoryToStage lastDirectory = null;

                    if (buckets.TryGetValue(task, out list))
                    {
                        foreach (DirectoryToStage dir in list)
                        {
                            // get zip file name for this DirectoryToStage
                            string zipFileName;
                            if (dic.TryGetValue(dir, out zipFileName))
                            {
                                manifest.AddPair(zipFileName, dir.TargetComputeNodeUnzipRelativePath);
                            }

                            lastDirectory = dir;
                        }

                        // Serialize manifest into an xml file
                        XmlSerializer serializer = new XmlSerializer(typeof(Manifest));

                        using (FileStream fs = File.Create(fileName))
                        {
                            serializer.Serialize(fs, manifest);
                        }

                        FileToStage fileToStage = new FileToStage(fileName, _storeCredentials, ManifestName);

                        // the manifest file is added to the last DirectoryToStage object of a task
                        if (lastDirectory != null)
                        {
                            lastDirectory.fileSToStageContained.Add(fileToStage);
                        }
                        jobFilestoStage.Add(fileToStage);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            System.Threading.Tasks.Task taskForStaticStaging = FileToStage.StageFilesInternalAsync(jobFilestoStage, fileStagingArtifact);

            await taskForStaticStaging.ConfigureAwait(continueOnCapturedContext: false);

            return;
        }

        public IFileStagingArtifact CreateStagingArtifact()
        {
            return new SequentialFileStagingArtifact() as IFileStagingArtifact;
        }

        public void Validate()
        {
            // User cannot use a root directory so as to avoid generating too big zip file
            if (!Directory.Exists(_localDirectory))
            {
                throw new FileNotFoundException(string.Format(BatchFS.ErrorMessages.FileStagingLocalDirectoryNotFound, _localDirectory));
            }

            if (IsRootDirectory(_localDirectory))
            {
                throw new FileNotFoundException(string.Format(BatchFS.ErrorMessages.FileStagingLocalDirectoryShouldNotBeRootDirectory, _localDirectory));
            }
        }

        /// <summary>
        /// All the directories to stage belonging to a task should have different folder name and unzip relative paths so as to avoid overwrite
        /// </summary>
        /// <param name="directoriesToStage">All the directories to stage belonging to a task</param>
        private void ValidateFolderNameAndRelativePaths(List<IFileStagingProvider> directoriesToStage)
        {
            // record the mapping between a task and list of DirectoryToStage belonging to this task
            Dictionary<ICloudTask, List<IFileStagingProvider>> buckets = new Dictionary<ICloudTask, List<IFileStagingProvider>>();

            if (directoriesToStage != null)
            {
                foreach (DirectoryToStage directory in directoriesToStage)
                {
                    List<IFileStagingProvider> list;

                    // if no bucket exists, create one 
                    if (!buckets.TryGetValue(directory.Task, out list))
                    {
                        list = new List<IFileStagingProvider>();

                        // one more bucket
                        buckets.Add(directory.Task, list);
                    }

                    list.Add(directory);
                }

                // For each task, validate whether there are more than one DirectoryToStage that have the same direct folder names and relative paths
                // for example, (c:\test\abc\, folder1\currentFolder) (e:\randomName\abc\, folder1\currentFolder)
                foreach (ICloudTask task in buckets.Keys)
                {
                    List<IFileStagingProvider> list;
                    HashSet<KeyValuePair<String, String>> set = new HashSet<KeyValuePair<String, String>>();

                    if (buckets.TryGetValue(task, out list))
                    {
                        foreach (DirectoryToStage dir in list)
                        {
                            string folderName = GetFolderName(dir.LocalDirectoryToStage);
                            string relativeUnzipPath = dir.TargetComputeNodeUnzipRelativePath;

                            KeyValuePair<String, String> pair = new KeyValuePair<string, string>(folderName, relativeUnzipPath);

                            if (!set.Contains(pair))
                            {
                                set.Add(pair);
                            }
                            else
                            {
                                // Detect deplicate pair
                                throw new FileNotFoundException(string.Format(BatchFS.ErrorMessages.FileStagingDuplicateFoldersAndTargetComputeNodeUnzipRelativePath, dir.Task.Name, folderName, relativeUnzipPath));
                            }
                        }
                    }
                }
            }
        }

        #endregion // IFileStagingProvier

        private static bool IsRootDirectory(string str)
        {
            string regex = @"^[A-Za-z]:[\\]*$";

            Match match = Regex.Match(str, regex, RegexOptions.IgnoreCase);

            return match.Success;
        }

        /// <summary>
        /// Return the direct folder name of a directory
        /// for example, it returns "test" if the directory is "c:\abc\def\test"
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        private static string GetFolderName(string directory)
        {
            if (!String.IsNullOrWhiteSpace(directory))
            {
                string[] words = directory.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                if (words != null)
                {
                    return words[words.Length - 1];
                }
            }

            return String.Empty;
        }
    }

    */
}
