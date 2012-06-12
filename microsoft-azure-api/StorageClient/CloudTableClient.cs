//-----------------------------------------------------------------------
// <copyright file="CloudTableClient.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the CloudTableClient class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services.Client;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Microsoft.WindowsAzure.StorageClient.Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Provides a client for accessing the Windows Azure Table service.
    /// </summary>
    public class CloudTableClient
    {
        /// <summary>
        /// The default server and client timeout interval.
        /// </summary>
        private TimeSpan timeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTableClient"/> class using the specified Table service endpoint
        /// and account credentials.
        /// </summary>
        /// <param name="baseAddress">The Table service endpoint to use to create the client.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudTableClient(string baseAddress, StorageCredentials credentials)
            : this(null /* usePathStyleUris */, new Uri(baseAddress), credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTableClient"/> class using the specified Table service endpoint
        /// and account credentials.
        /// </summary>
        /// <param name="baseAddressUri">The Table service endpoint to use to create the client.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudTableClient(Uri baseAddressUri, StorageCredentials credentials)
            : this(null /* usePathStyleUris */, baseAddressUri, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudTableClient"/> class using the specified Table service endpoint
        /// and account credentials.
        /// </summary>
        /// <param name="usePathStyleUris">Whether to expect path-style URIs.</param>
        /// <param name="baseAddressUri">The Table service endpoint to use to create the client.</param>
        /// <param name="credentials">The account credentials.</param>
        internal CloudTableClient(bool? usePathStyleUris, Uri baseAddressUri, StorageCredentials credentials)
        {
            if (baseAddressUri == null)
            {
                throw new ArgumentNullException("baseAddressUri");
            }

            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }

            this.BaseUri = baseAddressUri;
            this.Credentials = credentials;
            this.RetryPolicy = RetryPolicies.RetryExponential(RetryPolicies.DefaultClientRetryCount, RetryPolicies.DefaultClientBackoff);
            this.Timeout = TimeSpan.FromSeconds(90);

            if (usePathStyleUris.HasValue)
            {
                this.UsePathStyleUris = usePathStyleUris.Value;
            }
            else
            {
                // Automatically decide whether to use host style uri or path style uri
                this.UsePathStyleUris = CommonUtils.UsePathStyleAddressing(this.BaseUri);
            }
        }

        /// <summary>
        /// Occurs when a response is received from the server.
        /// </summary>
        public event EventHandler<ResponseReceivedEventArgs> ResponseReceived;

        /// <summary>
        /// Gets the minimum supported timestamp value for a table entity.
        /// </summary>
        /// <value>The minimum supported timestamp value for a table entity.</value>
        public DateTime MinSupportedDateTime
        {
            get
            {
                return DateTime.FromFileTimeUtc(0);
            }
        }

        /// <summary>
        /// Gets the base URI for the Table service client.
        /// </summary>
        /// <value>The base URI used to construct the Table service client.</value>
        public Uri BaseUri { get; private set; }

        /// <summary>
        /// Gets or sets the default retry policy for requests made via the Table service client.
        /// </summary>
        /// <value>The retry policy.</value>
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the default server timeout for requests made by the Table service client.
        /// </summary>
        /// <value>The server timeout interval.</value>
        public TimeSpan Timeout
        {
            get
            {
                return this.timeout;
            }

            set
            {
                Utilities.CheckTimeoutBounds(value);
                this.timeout = value;
            }
        }

        /// <summary>
        /// Gets the account credentials used to create the Table service client.
        /// </summary>
        /// <value>The account credentials.</value>
        public StorageCredentials Credentials { get; private set; }

        /// <summary>
        /// Gets a value indicating whether to use path-style URIs or not.
        /// </summary>
        /// <value>True if path-style URIs are used; false otherwise.</value>
        internal bool UsePathStyleUris { get; private set; }

        /// <summary>
        /// Creates the tables needed for the specified service context.
        /// </summary>
        /// <param name="serviceContextType">The type of service context.</param>
        /// <param name="baseAddress">The Table service endpoint to use to create the client.</param>
        /// <param name="credentials">The account credentials.</param>
        [Obsolete]
        public static void CreateTablesFromModel(Type serviceContextType, string baseAddress, StorageCredentials credentials)
        {
            CloudTableClient client = new CloudTableClient(baseAddress, credentials);

            foreach (string tableName in TableServiceUtilities.EnumerateEntitySetNames(serviceContextType))
            {
                CloudTable table = client.GetTableReference(tableName);
                table.CreateIfNotExist();
            }
        }

        /// <summary>
        /// Gets a reference to the table at the specified address.
        /// </summary>
        /// <param name="tableAddress">Either the name of the table, or the absolute URI to the table.</param>
        /// <returns>A reference to the table.</returns>
        public CloudTable GetTableReference(string tableAddress)
        {
            Uri tableUri = NavigationHelper.AppendPathToUri(this.BaseUri, tableAddress);

            return new CloudTable(tableUri, this);
        }

        /// <summary>
        /// Creates a new <see cref="TableServiceContext"/> object for performing operations against the Table service.
        /// </summary>
        /// <returns>A service context to use for performing operations against the Table service.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1024:UsePropertiesWhereAppropriate",
            Justification = "This method creates a new object each time.")]
        public TableServiceContext GetDataServiceContext()
        {
            return new TableServiceContext(this.BaseUri.ToString(), this.Credentials)
            {
                RetryPolicy = this.RetryPolicy,
                Timeout = (int)this.Timeout.TotalSeconds
            };
        }

        /// <summary>
        /// Attaches to the specified service context.
        /// </summary>
        /// <param name="serviceContext">The service context to attach to.</param>
        public void Attach(DataServiceContext serviceContext)
        {
            if (serviceContext is TableServiceContext)
            {
                throw new ArgumentException(SR.AttachToTableServiceContext);
            }

            // because this is an anonymous method the closure object acts as GC isolation
            serviceContext.SendingRequest += (sender, e) =>
            {
                HttpWebRequest request = e.Request as HttpWebRequest;

                // do the authentication
                Credentials.SignRequestLite(request);
            };
        }

        /// <summary>
        /// Begins an asychronous operation to create a table.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreateTable(string tableName, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(() => this.CreateTableImpl(tableName, null), RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asychronous operation to create a table.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndCreateTable(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Creates a table with specified name.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        public void CreateTable(string tableName)
        {
            TaskImplHelper.ExecuteImplWithRetry(() => this.CreateTableImpl(tableName, null), RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a table with the specified name if it does not already exist.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreateTableIfNotExist(string tableName, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImpl<bool>(
                (setResult) => this.CreateTableIfNotExistImpl(tableName, setResult),
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create a table with the specified name if it does not already exist.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if table was created; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public bool EndCreateTableIfNotExist(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<bool>(asyncResult);
        }

        /// <summary>
        /// Creates the table if it does not already exist.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <returns><c>true</c> if table was created; otherwise, <c>false</c>.</returns>
        public bool CreateTableIfNotExist(string tableName)
        {
            return TaskImplHelper.ExecuteImpl<bool>((setResult) => this.CreateTableIfNotExistImpl(tableName, setResult));
        }

        /// <summary>
        /// Begins an asynchronous operation to determine whether a table exists.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDoesTableExist(string tableName, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImpl<bool>((setResult) => this.DoesTableExistImpl(tableName, setResult), callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to determine whether a table exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if table exists; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public bool EndDoesTableExist(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<bool>(asyncResult);
        }

        /// <summary>
        /// Checks whether the table exists.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <returns><c>true</c> if table exists; otherwise, <c>false</c>.</returns>
        public bool DoesTableExist(string tableName)
        {
            return TaskImplHelper.ExecuteImpl<bool>((setResult) => this.DoesTableExistImpl(tableName, setResult));
        }

        /// <summary>
        /// Returns an enumerable collection of tables in the storage account.
        /// </summary>
        /// <returns>An enumerable collection of tables.</returns>
        public IEnumerable<CloudTable> ListTables()
        {
            return this.ListTables(String.Empty);
        }

        /// <summary>
        /// Returns an enumerable collection of tables that begin with the specified prefix and that are retrieved lazily.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <returns>An enumerable collection of tables that are retrieved lazily.</returns>
        public IEnumerable<CloudTable> ListTables(string prefix)
        {
            return CommonUtils.LazyEnumerateSegmented<CloudTable>(
                (setResult) => this.ListTablesSegmentedImpl(prefix, null, null, setResult),
                this.RetryPolicy);
        }

        /// <summary>
        /// Returns a result segment containing a collection of tables in the storage account.
        /// </summary>
        /// <returns>A result segment containing tables.</returns>
        public ResultSegment<CloudTable> ListTablesSegmented()
        {
            return this.ListTablesSegmented(0, null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of tables in the storage account.
        /// </summary>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <returns>A result segment containing tables.</returns>
        public ResultSegment<CloudTable> ListTablesSegmented(int maxResults, ResultContinuation continuationToken)
        {
            return this.ListTablesSegmented(String.Empty, maxResults, continuationToken);
        }

        /// <summary>
        /// Returns a result segment containing a collection of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <returns>A result segment containing tables.</returns>
        public ResultSegment<CloudTable> ListTablesSegmented(string prefix, int maxResults, ResultContinuation continuationToken)
        {
            return this.EndListTablesSegmented(
                this.BeginListTablesSegmented(prefix, maxResults, continuationToken, null, null));
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of tables 
        /// in the storage account.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListTablesSegmented(AsyncCallback callback, object state)
        {
            return this.BeginListTablesSegmented(String.Empty, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection 
        /// of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListTablesSegmented(string prefix, AsyncCallback callback, object state)
        {
            return this.BeginListTablesSegmented(prefix, 0, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection 
        /// of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListTablesSegmented(string prefix, int maxResults, ResultContinuation continuationToken, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<ResultSegment<CloudTable>>(
                (setResult) => this.ListTablesSegmentedImpl(
                    prefix,
                    maxResults,
                    continuationToken,
                    setResult),
                this.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to return a result segment containing a collection 
        /// of tables. 
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A result segment containing tables.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public ResultSegment<CloudTable> EndListTablesSegmented(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<ResultSegment<CloudTable>>(asyncResult);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a table.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="IAsyncResult"/> that references the asynchronous request.
        /// </returns>
        public IAsyncResult BeginDeleteTable(string tableName, AsyncCallback callback, object state)
        {
            CommonUtils.CheckStringParameter(tableName, false, "tableName", Protocol.Constants.TableServiceMaxStringPropertySizeInChars);
            TableServiceUtilities.CheckTableName(tableName, "tableName");

            return TaskImplHelper.BeginImplWithRetry(() => this.DeleteTableImpl(tableName), RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete a table.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public void EndDeleteTable(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Deletes the table.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        public void DeleteTable(string tableName)
        {
            this.EndDeleteTable(this.BeginDeleteTable(tableName, null, null));
        }

        /// <summary>
        /// Begins an asynchronous operation to delete the tables if it exists.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDeleteTableIfExist(string tableName, AsyncCallback callback, object state)
        {
            CommonUtils.CheckStringParameter(tableName, false, "tableName", Protocol.Constants.TableServiceMaxStringPropertySizeInChars);

            TableServiceUtilities.CheckTableName(tableName, "tableName");

            return TaskImplHelper.BeginImpl<bool>((setResult) => this.DeleteTableIfExistImpl(tableName, setResult), callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete the tables if it exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the table was deleted; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public bool EndDeleteTableIfExist(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<bool>(asyncResult);
        }

        /// <summary>
        /// Deletes the table if it exists.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <returns><c>true</c> if the table was deleted; otherwise, <c>false</c>.</returns>
        public bool DeleteTableIfExist(string tableName)
        {
            return this.EndDeleteTableIfExist(this.BeginDeleteTableIfExist(tableName, null, null));
        }

        /// <summary>
        /// Gets the properties of the table service.
        /// </summary>
        /// <returns>The table service properties.</returns>
        public ServiceProperties GetServiceProperties()
        {
            return TaskImplHelper.ExecuteImplWithRetry<ServiceProperties>((setResult) => this.GetServicePropertiesImpl(setResult), this.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to get the properties of the table service.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetServiceProperties(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<ServiceProperties>((setResult) => this.GetServicePropertiesImpl(setResult), this.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to get the properties of the table service.
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="BeginGetServiceProperties"/>.</param>
        /// <returns>The table service properties.</returns>
        public ServiceProperties EndGetServiceProperties(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<ServiceProperties>(asyncResult);
        }

        /// <summary>
        /// Sets the properties of the table service.
        /// </summary>
        /// <param name="properties">The table service properties.</param>
        public void SetServiceProperties(ServiceProperties properties)
        {
            TaskImplHelper.ExecuteImplWithRetry(() => this.SetServicePropertiesImpl(properties), this.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to set the properties of the table service.
        /// </summary>
        /// <param name="properties">The table service properties.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetServiceProperties(ServiceProperties properties, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(() => this.SetServicePropertiesImpl(properties), this.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to set the properties of the table service.
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="BeginSetServiceProperties"/>.</param>
        public void EndSetServiceProperties(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Gets the result or default.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="task">The task to retrieve the result from.</param>
        /// <param name="result">Receives result of the task.</param>
        /// <returns><c>true</c> if the result was returned; otherwise, <c>false</c>.</returns>
        internal static bool GetResultOrDefault<T>(Task<T> task, out T result)
        {
            try
            {
                result = task.Result;

                return true;
            }
            catch (DataServiceQueryException ex)
            {
                if ((HttpStatusCode)ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    result = default(T);

                    return false;
                }

                throw Utilities.TranslateDataServiceClientException(ex);
            }
            catch (InvalidOperationException ex)
            {
                DataServiceClientException dsce = CommonUtils.FindInnerDataServiceClientException(ex);

                if (dsce != null)
                {
                    if ((HttpStatusCode)dsce.StatusCode == HttpStatusCode.NotFound)
                    {
                        result = default(T);

                        return false;
                    }
                }

                throw Utilities.TranslateDataServiceClientException(ex);
            }
        }

        /// <summary>
        /// Ends the asynchronous GetResponse operation.
        /// </summary>
        /// <param name="asyncresult">An <see cref="IAsyncResult"/> that references the asynchronous operation.</param>
        /// <param name="req">The request to end the operation on.</param>
        /// <returns>The <see cref="WebResponse"/> from the asynchronous request.</returns>
        internal WebResponse EndGetResponse(IAsyncResult asyncresult, WebRequest req)
        {
            return EventHelper.ProcessWebResponse(req, asyncresult, this.ResponseReceived, this);
        }

        /// <summary>
        /// Generates a task sequence for accessing the table service.
        /// </summary>
        /// <param name="webRequest">A web request for accessing the table service.</param>
        /// <param name="writeRequestAction">An action for writing data to the body of a web request.</param>
        /// <param name="processResponseAction">An action for processing the response received.</param>
        /// <param name="readResponseAction">An action for reading the response stream.</param>
        /// <returns>A task sequence for the operation.</returns>
        internal TaskSequence GenerateWebTask(
            HttpWebRequest webRequest,
            Action<Stream> writeRequestAction,
            Action<HttpWebResponse> processResponseAction,
            Action<Stream> readResponseAction)
        {
            return ProtocolHelper.GenerateServiceTask(
                webRequest,
                writeRequestAction,
                (request) => this.Credentials.SignRequestLite(request),
                (request) => request.GetResponseAsyncWithTimeout(this, this.Timeout),
                processResponseAction,
                readResponseAction);
        }

        /// <summary>
        /// Creates the table implementation.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A sequence of tasks to do the operation.</returns>
        private TaskSequence CreateTableImpl(string tableName, Action<InvalidOperationException> setResult)
        {
            CommonUtils.CheckStringParameter(tableName, false, "tableName", Protocol.Constants.TableServiceMaxStringPropertySizeInChars);

            var svc = this.GetDataServiceContext();

            svc.AddObject(Protocol.Constants.TableServiceTablesName, new TableServiceTable() { TableName = tableName });

            var saveChangesTask = svc.SaveChangesAsync();

            yield return saveChangesTask;

            // wrap any exceptions
            try
            {
                var result = saveChangesTask.Result;
            }
            catch (InvalidOperationException ex)
            {
                if (setResult == null)
                {
                    throw Utilities.TranslateDataServiceClientException(ex);
                }
                else
                {
                    setResult(ex);
                }
            }
        }

        /// <summary>
        /// Creates the table if not exist implementation.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A sequence of tasks to do the operation.</returns>
        private TaskSequence CreateTableIfNotExistImpl(string tableName, Action<bool> setResult)
        {
            CommonUtils.CheckStringParameter(tableName, false, "tableName", Protocol.Constants.TableServiceMaxStringPropertySizeInChars);
            TableServiceUtilities.CheckTableName(tableName, "tableName");

            var doesTableExistTask = new InvokeTaskSequenceTask<bool>((set) => this.DoesTableExistImpl(tableName, set));

            yield return doesTableExistTask;

            if (doesTableExistTask.Result)
            {
                setResult(false);
            }
            else
            {
                var createTableTask = TaskImplHelper.GetRetryableAsyncTask<InvalidOperationException>((resultSetter) => this.CreateTableImpl(tableName, resultSetter), RetryPolicy);

                yield return createTableTask;

                // wrap any exceptions
                try
                {
                    if (createTableTask.Result == null)
                    {
                        setResult(true);
                    }
                    else
                    {
                        StorageClientException exception = Utilities.TranslateDataServiceClientException(createTableTask.Result) as StorageClientException;
                        if (exception != null
                            && exception.ErrorCode == StorageErrorCode.ResourceAlreadyExists
                            && exception.ExtendedErrorInformation != null
                            && exception.ExtendedErrorInformation.ErrorCode == TableErrorCodeStrings.TableAlreadyExists)
                        {
                            setResult(false);
                        }
                        else
                        {
                            throw createTableTask.Result;
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    throw Utilities.TranslateDataServiceClientException(ex);
                }
            }
        }

        /// <summary>
        /// Verifies whether the table exist implementation.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A sequence of tasks to do the operation.</returns>
        private TaskSequence DoesTableExistImpl(string tableName, Action<bool> setResult)
        {
            CommonUtils.CheckStringParameter(tableName, false, "tableName", Protocol.Constants.TableServiceMaxStringPropertySizeInChars);

            TableServiceUtilities.CheckTableName(tableName, "tableName");

            var svc = this.GetDataServiceContext();

            var tableExistsQuery = (from table in svc.CreateQuery<TableServiceTable>(Protocol.Constants.TableServiceTablesName)
                                    where table.TableName == tableName
                                    select table).AsTableServiceQuery();

            ResultSegment<TableServiceTable> segment = null;

            while (true)
            {
                Task<ResultSegment<TableServiceTable>> tableExistsSegmentTask;

                if (segment == null)
                {
                    tableExistsSegmentTask = TaskImplHelper.GetRetryableAsyncTask<ResultSegment<TableServiceTable>>(
                        (setResultInner) => tableExistsQuery.ExecuteSegmentedImpl(null, setResultInner), RetryPolicy);
                }
                else
                {
                    tableExistsSegmentTask = TaskImplHelper.GetRetryableAsyncTask<ResultSegment<TableServiceTable>>(segment.GetNextImpl, RetryPolicy);
                }

                yield return tableExistsSegmentTask;

                if (GetResultOrDefault(tableExistsSegmentTask, out segment))
                {
                    if (segment.Results.Any())
                    {
                        setResult(true);

                        break;
                    }
                    else
                    {
                        setResult(false);

                        break;
                    }
                }
                else
                {
                    setResult(false);

                    break;
                }
            }
        }

        /// <summary>
        /// Returns an enumerable collection of tables segmented impl.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="maxResults">The max results.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> that lists the tables.</returns>
        private TaskSequence ListTablesSegmentedImpl(
            string prefix,
            int? maxResults,
            ResultContinuation continuationToken,
            Action<ResultSegment<CloudTable>> setResult)
        {
            ResultPagination pagination = new ResultPagination(maxResults.GetValueOrDefault());

            return this.ListTablesSegmentedImplCore(prefix, continuationToken, pagination, null, setResult);
        }

        /// <summary>
        /// Returns an enumerable collection of tables segmented implementation.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="pagination">The pagination.</param>
        /// <param name="lastResult">The last result.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A sequence of tasks to do the operation.</returns>
        private TaskSequence ListTablesSegmentedImplCore(
            string prefix,
            ResultContinuation continuationToken,
            ResultPagination pagination,
            ResultSegment<TableServiceTable> lastResult,
            Action<ResultSegment<CloudTable>> setResult)
        {
            CommonUtils.AssertContinuationType(continuationToken, ResultContinuation.ContinuationType.Table);

            InvokeTaskSequenceTask<ResultSegment<TableServiceTable>> listTablesSegmentedTask;

            if (lastResult == null)
            {
                TableServiceContext serviceContext = this.GetDataServiceContext();
                IQueryable<TableServiceTable> query = from table in serviceContext.CreateQuery<TableServiceTable>(Protocol.Constants.TableServiceTablesName)
                            select table;

                if (prefix != string.Empty)
                {                       
                    // Append Max char to end  '{' is 1 + 'z' in AsciiTable
                    string uppperBound = prefix + '{';
                    
                    query = query.Where((table) => table.TableName.CompareTo(prefix) >= 0 && table.TableName.CompareTo(uppperBound) < 0);
                }

                if (pagination.IsPagingEnabled)
                {
                    query = query.Take(pagination.GetNextRequestPageSize().Value);
                }

                CloudTableQuery<TableServiceTable> listTablesQuery = query.AsTableServiceQuery();

                listTablesSegmentedTask = new InvokeTaskSequenceTask<ResultSegment<TableServiceTable>>(
                                    (setResultInner) =>
                                    listTablesQuery.ExecuteSegmentedImpl(continuationToken, setResultInner));
            }
            else
            {
                listTablesSegmentedTask = new InvokeTaskSequenceTask<ResultSegment<TableServiceTable>>(lastResult.GetNextImpl);
            }

            yield return listTablesSegmentedTask;

            if (GetResultOrDefault<ResultSegment<TableServiceTable>>(listTablesSegmentedTask, out lastResult))
            {
                setResult(new ResultSegment<CloudTable>(
                    lastResult.Results.Select((table) => this.GetTableReference(table.TableName)),
                    lastResult.HasMoreResults,
                    (setResultInner) =>
                        this.ListTablesSegmentedImplCore(prefix, lastResult.ContinuationToken, pagination, lastResult, setResultInner),
                    RetryPolicy)
                {
                    ContinuationToken = lastResult.ContinuationToken
                });
            }
            else
            {
                setResult(new ResultSegment<CloudTable>(new List<CloudTable>(), false, null, RetryPolicy));
            }
        }

        /// <summary>
        /// Delete table implementation.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <returns>A sequence of tasks to do the operation.</returns>
        private TaskSequence DeleteTableImpl(string tableName)
        {
            var svc = this.GetDataServiceContext();
            var table = new TableServiceTable(tableName);

            svc.AttachTo(Protocol.Constants.TableServiceTablesName, table);
            svc.DeleteObject(table);

            var saveChangesTask = svc.SaveChangesAsync();

            yield return saveChangesTask;

            // wrap any exceptions
            try
            {
                var result = saveChangesTask.Result;
            }
            catch (InvalidOperationException ex)
            {
                throw Utilities.TranslateDataServiceClientException(ex);
            }
        }

        /// <summary>
        /// Deletes table if exists implementation.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A sequence of tasks to do the operation.</returns>
        private TaskSequence DeleteTableIfExistImpl(string tableName, Action<bool> setResult)
        {
            var doesTableExistTask = TaskImplHelper.GetRetryableAsyncTask<bool>(
                (set) => this.DoesTableExistImpl(tableName, set),
                RetryPolicy);

            yield return doesTableExistTask;

            if (!doesTableExistTask.Result)
            {
                setResult(false);
            }
            else
            {
                var deleteTableTask = TaskImplHelper.GetRetryableAsyncTask(() => this.DeleteTableImpl(tableName), RetryPolicy);

                yield return deleteTableTask;

                var result = deleteTableTask.Result;

                setResult(true);
            }
        }

        /// <summary>
        /// Generates a task sequence for getting the properties of the table service.
        /// </summary>
        /// <param name="setResult">A delegate to receive the service properties.</param>
        /// <returns>A task sequence that gets the properties of the table service.</returns>
        private TaskSequence GetServicePropertiesImpl(Action<ServiceProperties> setResult)
        {
            return this.GenerateWebTask(
                TableRequest.GetServiceProperties(this.BaseUri, this.Timeout.RoundUpToSeconds()),
                null /* no request body */,
                null /* no response header processing */,
                (stream) => setResult(TableResponse.ReadServiceProperties(stream)));
        }

        /// <summary>
        /// Generates a task sequence for setting the properties of the table service.
        /// </summary>
        /// <param name="properties">The table service properties to set.</param>
        /// <returns>A task sequence that sets the properties of the table service.</returns>
        private TaskSequence SetServicePropertiesImpl(ServiceProperties properties)
        {
            CommonUtils.AssertNotNull("properties", properties);

            return this.GenerateWebTask(
                TableRequest.SetServiceProperties(this.BaseUri, this.Timeout.RoundUpToSeconds()),
                (stream) =>
                {
                    try
                    {
                        TableRequest.WriteServiceProperties(properties, stream);
                    }
                    catch (InvalidOperationException invalidOpException)
                    {
                        throw new ArgumentException(invalidOpException.Message, "properties");
                    }
                },
                null /* no response header processing */,
                null /* no response body */);
        }
    }
}
