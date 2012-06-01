using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    public class TaskCollection : IEnumerable<ITask>
    {
        private readonly IList<ITask> _tasks;
        private IJob _job;

        public TaskCollection()
        {
            _tasks = new List<ITask>();
        }

        internal TaskCollection(IJob job, IEnumerable<ITask> tasks)
        {
            _tasks = new List<ITask>(tasks);
            _job = job;
        }

        public ITask this[int index]
        {
            get { return _tasks[index]; }
        }

        /// <summary>
        /// Gets the count of elements in collection.
        /// </summary>
        public int Count
        {
            get { return _tasks.Count; }
        }

        #region IEnumerable<ITask> Members

        public IEnumerator<ITask> GetEnumerator()
        {
            return _tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        /// <summary>
        /// Adds the new.
        /// </summary>
        /// <param name="taskName">The task name.</param>
        /// <param name="mediaProcessor">The media processor id.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public ITask AddNew(string taskName, IMediaProcessor mediaProcessor, string configuration, TaskCreationOptions options)
        {
            CheckIfJobIsPersistedAndThrowNotSupported();
            if (mediaProcessor==null)
            {
                throw new ArgumentNullException(String.Format(CultureInfo.InvariantCulture,StringTable.ErrorArgCannotBeNull, "mediaProcessor"));
            }
            if (string.IsNullOrEmpty(taskName))
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture,StringTable.ErrorArgCannotBeNullOrEmpty, "taskName"));
            }
            
            var task = new TaskData
                           {
                               Name = taskName,
                               Configuration = configuration,
                               MediaProcessorId = mediaProcessor.Id,
                               Options = (int) options
                           };
            _tasks.Add(task);
            return task;
        }

        /// <summary>
        /// Adds the new task.
        /// </summary>
        /// <param name="taskName">The task name.</param>
        /// <param name="mediaProcessor">The media processor.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="options">The options.</param>
        /// <param name="parentTask">The parent task.</param>
        /// <returns></returns>
        public ITask AddNew(string taskName, IMediaProcessor mediaProcessor, string configuration, TaskCreationOptions options, ITask parentTask)
        {
            if(parentTask==null)
            {
                throw new ArgumentNullException("parentTask");
            }

            CheckIfJobIsPersistedAndThrowNotSupported();
            var task = AddNew(taskName, mediaProcessor, configuration, options);

            foreach (IAsset outputAsset in parentTask.OutputMediaAssets)
            {
                task.InputMediaAssets.Add(outputAsset);
            }
            return task;
        }
        public bool IsReadOnly
        {
            get { return !string.IsNullOrEmpty(_job.Id); }
        }

        /// <summary>
        /// Checks if job is persisted and throw not supported exception.
        /// </summary>
        private void CheckIfJobIsPersistedAndThrowNotSupported()
        {
            //TODO:find a better way to detect if task has been persisted
            if (IsReadOnly)
            {
                throw new NotSupportedException(String.Format(CultureInfo.InvariantCulture, StringTable.ErrorReadOnlyCollectionToSubmittedTask, "Tasks"));
            }
        }
    }
}
