// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;

namespace Microsoft.Azure.Batch
{

    /// <summary>
    /// Contains information about a file staging process.  File staging is typically performed for
    /// a <see cref="CloudTask"/> (see <see cref="CloudTask.FilesToStage"/>).
    /// </summary>
    /// <remarks>
    /// <para>
    /// IFileStagingArtifact allows an application to customize and to obtain information about the process of uploading
    /// files to the cloud, for example as part of a task-related operation such as
    /// <see cref="JobOperations.AddTaskAsync(string,IEnumerable{CloudTask},BatchClientParallelOptions,ConcurrentBag{ConcurrentDictionary{Type, IFileStagingArtifact}},TimeSpan?,IEnumerable{BatchClientBehavior})">JobOperations.AddTaskAsync</see>
    /// or <see cref="CloudJob.AddTaskAsync(CloudTask, ConcurrentDictionary{Type, IFileStagingArtifact}, IEnumerable{BatchClientBehavior}, CancellationToken)">CloudJob.AddTaskAsync</see>.  Applications may use this
    /// information to, for example, find out about containers that were created in Azure Storage as
    /// part of the upload process.
    /// </para>
    /// <para>
    /// When <see cref="JobOperations.AddTaskAsync(string,IEnumerable{CloudTask},BatchClientParallelOptions,ConcurrentBag{ConcurrentDictionary{Type, IFileStagingArtifact}},TimeSpan?,IEnumerable{BatchClientBehavior})">JobOperations.AddTaskAsync</see>
    /// is called, the Batch client sends the tasks to the Batch service in collections.  As each collection is
    /// processed, the Batch client performs file staging for that collection: it examines the tasks to see if
    /// any of them specify any <see cref="CloudTask.FilesToStage"/>, and if so creates a dictionary entry for
    /// each type of <see cref="FileStaging.IFileStagingProvider"/> in the FilesToStage collection. The key of
    /// the dictionary entry is the <see cref="Type"/> of the IFileStagingProvider and the value is an instance
    /// of the corresponding implementation of IFileStagingArtifact.  For example, if FilesToStage includes one or more
    /// <see cref="FileStaging.FileToStage"/> objects, then the dictionary contains an entry whose key is
    /// typeof(FileToStage) and whose value is an instance of <see cref="FileStaging.SequentialFileStagingArtifact"/>.
    /// </para>
    /// <para>
    /// When the Add Task operation completes, or during the Add Task operation if the application is multi-threaded,
    /// you can examine the dictionary and convert each IFileStagingArtifact to the appropriate type to retrieve
    /// the type-specific information.  For example, if your Add Task operation specified one or more FileToStage objects,
    /// you can locate the dictionary entry keyed by typeof(FileToStage), cast the value to SequentialFileStagingArtifact,
    /// and examine the <see cref="FileStaging.SequentialFileStagingArtifact.BlobContainerCreated"/> property to
    /// determine if the upload process created a blob container in Azure Storage and if so the name of that container.
    /// This example could be useful for cleaning up automatically created containers.
    /// </para>
    /// <para>
    /// (Single-task Add Task operations work similarly, except that in a multi-task Add Task operation, there is
    /// a dictionary for each collection of tasks, and the dictionaries are collected in a <see cref="ConcurrentBag{T}"/>,
    /// whereas in a single-task Add Task operation there is only a single dictionary.)
    /// </para>
    /// <para>
    /// In a single-task Add Task operation, you can also use the dictionary to customize the file staging process, by pre-populating it with appropriate
    /// entries.  For example, suppose you wish to control the <see cref="NamingFragment"/> for a group of FileToStage
    /// objects.  Then you could initialize the dictionary with <c>{ typeof(FileToStage), new SequentialFileStagingArtifact { NamingFragment = "myname" } }</c>
    /// before passing it to AddTaskAsync.  The FileToStage implementation of IFileStagingProvider would then use your
    /// SequentialFileStagingArtifact instead of creating its own.  (This feature is not available in multi-task
    /// Add Task operations.)
    /// </para>
    /// <para>
    /// You may also encounter IFileStagingArtifact if you are developing a custom <see cref="FileStaging.IFileStagingProvider"/>.
    /// In this case you will typically create a custom implementation of IFileStagingArtifact to report
    /// implementation-specific information about your file staging process.
    /// </para>
    /// </remarks>
    public interface IFileStagingArtifact
    {
        /// <summary>
        /// Gets or sets a name fragment that can be used when constructing default names.
        /// </summary>
        /// <remarks>Although a caller may set this property, the <see cref="FileStaging.IFileStagingProvider"/> implementation
        /// is not required to respect it.</remarks>
        string NamingFragment { get; set;}
    }
}
