//-----------------------------------------------------------------------
// <copyright file="CloudTable.cs" company="Microsoft">
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
//    Contains code for the CloudTable class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Data.Services.Client;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Microsoft.WindowsAzure.StorageClient.Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Represents a Windows Azure Table.
    /// </summary>
    public class CloudTable
    {
        /// <summary>
        /// Initializes a new instance of the CloudTable class.
        /// </summary>
        /// <param name="address">The absolute URI to the table.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudTable(string address, StorageCredentials credentials)
            : this(null, address, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudTable class.
        /// </summary>
        /// <param name="address">The relative address.</param>
        /// <param name="credentials">The storage account credentials.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c>, use path style Uris.</param>
        internal CloudTable(string address, StorageCredentials credentials, bool usePathStyleUris)
            : this(usePathStyleUris, address, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CloudTable class.
        /// </summary>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <param name="address">The address.</param>
        /// <param name="credentials">The credentials.</param>
        internal CloudTable(bool? usePathStyleUris, string address, StorageCredentials credentials)
        {
            CommonUtils.AssertNotNullOrEmpty("address", address);
            CommonUtils.AssertNotNull("credentials", credentials);

            this.Uri = new Uri(address);

            string baseAddress = NavigationHelper.GetServiceClientBaseAddress(this.Uri, usePathStyleUris);

            this.ServiceClient = new CloudTableClient(baseAddress, credentials);
            this.Name = NavigationHelper.GetTableNameFromUri(this.Uri, this.ServiceClient.UsePathStyleUris);
        }

        /// <summary>
        /// Initializes a new instance of the CloudTable class.
        /// </summary>
        /// <param name="address">The queue address.</param>
        /// <param name="client">The client.</param>
        internal CloudTable(Uri address, CloudTableClient client)
        {
            CommonUtils.AssertNotNull("address", address);
            CommonUtils.AssertNotNull("client", client);

            this.Uri = address;
            this.ServiceClient = client;

            this.Name = NavigationHelper.GetTableNameFromUri(this.Uri, this.ServiceClient.UsePathStyleUris);
        }

        /// <summary>
        /// Gets the <see cref="CloudTableClient"/> object that represents the Table service.
        /// </summary>
        /// <value>A client object that specifies the Table service endpoint.</value>
        public CloudTableClient ServiceClient { get; private set; }

        /// <summary>
        /// Gets the table name.
        /// </summary>
        /// <value>The table name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the URI that identifies the table.
        /// </summary>
        /// <value>The address of the table.</value>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Begins an asynchronous operation to create a table.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreate(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(() => this.CreateImpl(null), this.ServiceClient.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create a table.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndCreate(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Creates a table.
        /// </summary>
        public void Create()
        {
            TaskImplHelper.ExecuteImplWithRetry(() => this.CreateImpl(null), this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a table if it does not already exist.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreateIfNotExist(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImpl<bool>(
                (setResult) => this.CreateIfNotExistImpl(setResult),
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create a table if it does not already exist.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if table was created; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public bool EndCreateIfNotExist(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<bool>(asyncResult);
        }

        /// <summary>
        /// Creates the table if it does not already exist.
        /// </summary>
        /// <returns><c>true</c> if table was created; otherwise, <c>false</c>.</returns>
        public bool CreateIfNotExist()
        {
            return TaskImplHelper.ExecuteImpl<bool>((setResult) => this.CreateIfNotExistImpl(setResult));
        }

        /// <summary>
        /// Begins an asynchronous operation to determine whether a table exists.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginExists(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImpl<bool>((setResult) => this.ExistsImpl(setResult), callback, state);
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
        public bool EndExists(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<bool>(asyncResult);
        }

        /// <summary>
        /// Checks whether the table exists.
        /// </summary>
        /// <returns><c>true</c> if table exists; otherwise, <c>false</c>.</returns>
        public bool Exists()
        {
            return TaskImplHelper.ExecuteImpl<bool>((setResult) => this.ExistsImpl(setResult));
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a table.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>
        /// An <see cref="IAsyncResult"/> that references the asynchronous request.
        /// </returns>
        public IAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(() => this.DeleteImpl(), this.ServiceClient.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete a table.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public void EndDelete(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Deletes the table.
        /// </summary>
        public void Delete()
        {
            TaskImplHelper.ExecuteImplWithRetry(() => this.DeleteImpl(), this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete the tables if it exists.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImpl<bool>((setResult) => this.DeleteIfExistsImpl(setResult), callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete the tables if it exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the table was deleted; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public bool EndDeleteIfExists(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<bool>(asyncResult);
        }

        /// <summary>
        /// Deletes the table if it exists.
        /// </summary>
        /// <returns><c>true</c> if the table was deleted; otherwise, <c>false</c>.</returns>
        public bool DeleteIfExists()
        {
            return TaskImplHelper.ExecuteImplWithRetry<bool>((setResult) => this.DeleteIfExistsImpl(setResult), this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Gets the permissions settings for the table.
        /// </summary>
        /// <returns>The table's permissions.</returns>
        public TablePermissions GetPermissions()
        {
            return TaskImplHelper.ExecuteImplWithRetry<TablePermissions>(
                (setResult) => this.GetPermissionsImpl(setResult),
                this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the table.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetPermissions(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<TablePermissions>(
                (setResult) => this.GetPermissionsImpl(setResult),
                this.ServiceClient.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Returns the asynchronous result of the request to get the permissions settings for the table.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>The table's permissions.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public TablePermissions EndGetPermissions(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<TablePermissions>(asyncResult);
        }

        /// <summary>
        /// Sets permissions for the table.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the table.</param>
        public void SetPermissions(TablePermissions permissions)
        {
            TaskImplHelper.ExecuteImplWithRetry(() => this.SetPermissionsImpl(permissions), this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous request to set permissions for the table.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the table.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetPermissions(TablePermissions permissions, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(
                () => this.SetPermissionsImpl(permissions),
                this.ServiceClient.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Returns the result of an asynchronous request to set permissions for the table.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndSetPermissions(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Returns a shared access signature for the table.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <param name="accessPolicyIdentifier">An access policy identifier.</param>
        /// <param name="startPartitionKey">The start partition key, or null.</param>
        /// <param name="startRowKey">The start row key, or null.</param>
        /// <param name="endPartitionKey">The end partition key, or null.</param>
        /// <param name="endRowKey">The end row key, or null.</param>
        /// <returns>A shared access signature.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the current credentials don't support creating a shared access signature.</exception>
        public string GetSharedAccessSignature(
            SharedAccessTablePolicy policy,
            string accessPolicyIdentifier,
            string startPartitionKey,
            string startRowKey,
            string endPartitionKey,
            string endRowKey)
        {
            if (!this.ServiceClient.Credentials.CanSignRequest)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.CannotCreateSASWithoutAccountKey);
                throw new InvalidOperationException(errorMessage);
            }

            string resourceName = this.GetCanonicalName();

            string signature = SharedAccessSignatureHelper.GetSharedAccessSignatureHashImpl(
                policy,
                accessPolicyIdentifier,
                startPartitionKey,
                startRowKey,
                endPartitionKey,
                endRowKey,
                resourceName,
                this.ServiceClient);

            string accountKeyName = null;

            if (this.ServiceClient.Credentials is StorageCredentialsAccountAndKey)
            {
                accountKeyName = (this.ServiceClient.Credentials as StorageCredentialsAccountAndKey).AccountKeyName;
            }

            UriQueryBuilder builder = SharedAccessSignatureHelper.GetSharedAccessSignatureImpl(
                policy,
                this.Name,
                accessPolicyIdentifier,
                startPartitionKey,
                startRowKey,
                endPartitionKey,
                endRowKey,
                signature,
                accountKeyName);

            return builder.ToString();
        }

        /// <summary>
        /// Returns the name of the table.
        /// </summary>
        /// <returns>The name of the table.</returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Gets the canonical name of the table, formatted as /&lt;account-name&gt;/&lt;table-name&gt;.
        /// </summary>
        /// <returns>The canonical name of the table.</returns>
        private string GetCanonicalName()
        {
            string accountName = this.ServiceClient.Credentials.AccountName;
            string tableNameLowerCase = this.Name.ToLower();

            return string.Format("/{0}/{1}", accountName, tableNameLowerCase);
        }

        /// <summary>
        /// Creates the table implementation.
        /// </summary>
        /// <param name="setResult">The set result.</param>
        /// <returns>A sequence of tasks to do the operation.</returns>
        private TaskSequence CreateImpl(Action<InvalidOperationException> setResult)
        {
            TableServiceContext serviceContext = this.ServiceClient.GetDataServiceContext();

            serviceContext.AddObject(Protocol.Constants.TableServiceTablesName, new TableServiceTable() { TableName = this.Name });

            Task<DataServiceResponse> saveChangesTask = serviceContext.SaveChangesAsync();

            yield return saveChangesTask;

            // wrap any exceptions
            try
            {
                DataServiceResponse result = saveChangesTask.Result;
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
        /// <param name="setResult">The set result.</param>
        /// <returns>A sequence of tasks to do the operation.</returns>
        private TaskSequence CreateIfNotExistImpl(Action<bool> setResult)
        {
            InvokeTaskSequenceTask<bool> doesTableExistTask = new InvokeTaskSequenceTask<bool>((set) => this.ExistsImpl(set));

            yield return doesTableExistTask;

            if (doesTableExistTask.Result)
            {
                setResult(false);
            }
            else
            {
                Task<InvalidOperationException> createTableTask = TaskImplHelper.GetRetryableAsyncTask<InvalidOperationException>(
                    (resultSetter) => this.CreateImpl(resultSetter),
                    this.ServiceClient.RetryPolicy);

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
        /// <param name="setResult">The set result.</param>
        /// <returns>A sequence of tasks to do the operation.</returns>
        private TaskSequence ExistsImpl(Action<bool> setResult)
        {
            TableServiceContext serviceContext = this.ServiceClient.GetDataServiceContext();

            CloudTableQuery<TableServiceTable> tableExistsQuery = (from table in serviceContext.CreateQuery<TableServiceTable>(Protocol.Constants.TableServiceTablesName)
                                    where table.TableName == this.Name
                                    select table).AsTableServiceQuery();

            ResultSegment<TableServiceTable> segment = null;

            while (true)
            {
                Task<ResultSegment<TableServiceTable>> tableExistsSegmentTask;

                if (segment == null)
                {
                    tableExistsSegmentTask = TaskImplHelper.GetRetryableAsyncTask<ResultSegment<TableServiceTable>>(
                        (setResultInner) => tableExistsQuery.ExecuteSegmentedImpl(null, setResultInner), this.ServiceClient.RetryPolicy);
                }
                else
                {
                    tableExistsSegmentTask = TaskImplHelper.GetRetryableAsyncTask<ResultSegment<TableServiceTable>>(segment.GetNextImpl, this.ServiceClient.RetryPolicy);
                }

                yield return tableExistsSegmentTask;

                if (CloudTableClient.GetResultOrDefault(tableExistsSegmentTask, out segment))
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
        /// Delete table implementation.
        /// </summary>
        /// <returns>A sequence of tasks to do the operation.</returns>
        private TaskSequence DeleteImpl()
        {
            TableServiceContext svc = this.ServiceClient.GetDataServiceContext();
            TableServiceTable table = new TableServiceTable(this.Name);

            svc.AttachTo(Protocol.Constants.TableServiceTablesName, table);
            svc.DeleteObject(table);

            Task<DataServiceResponse> saveChangesTask = svc.SaveChangesAsync();

            yield return saveChangesTask;

            // wrap any exceptions
            try
            {
                DataServiceResponse result = saveChangesTask.Result;
            }
            catch (InvalidOperationException ex)
            {
                throw Utilities.TranslateDataServiceClientException(ex);
            }
        }

        /// <summary>
        /// Deletes table if exists implementation.
        /// </summary>
        /// <param name="setResult">The set result.</param>
        /// <returns>A sequence of tasks to do the operation.</returns>
        private TaskSequence DeleteIfExistsImpl(Action<bool> setResult)
        {
            Task<bool> doesTableExistTask = TaskImplHelper.GetRetryableAsyncTask<bool>(
                (set) => this.ExistsImpl(set),
                this.ServiceClient.RetryPolicy);

            yield return doesTableExistTask;

            if (!doesTableExistTask.Result)
            {
                setResult(false);
            }
            else
            {
                Task<NullTaskReturn> deleteTableTask = TaskImplHelper.GetRetryableAsyncTask(() => this.DeleteImpl(), this.ServiceClient.RetryPolicy);

                yield return deleteTableTask;

                NullTaskReturn result = deleteTableTask.Result;

                setResult(true);
            }
        }

        /// <summary>
        /// Generate a task sequence for setting the permissions.
        /// </summary>
        /// <param name="acl">The permissions to set.</param>
        /// <returns>A <see cref="TaskSequence"/> that sets the permissions.</returns>
        private TaskSequence SetPermissionsImpl(TablePermissions acl)
        {
            return this.ServiceClient.GenerateWebTask(
                TableRequest.SetAcl(this.Uri, this.ServiceClient.Timeout.RoundUpToSeconds()),
                (stream) => TableRequest.WriteSharedAccessIdentifiers(acl.SharedAccessPolicies, stream),
                null /* no response header processing */,
                null /* no response body */);
        }

        /// <summary>
        /// Generate a task sequence for getting the permissions.
        /// </summary>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that gets the permissions.</returns>
        private TaskSequence GetPermissionsImpl(Action<TablePermissions> setResult)
        {
            return this.ServiceClient.GenerateWebTask(
                TableRequest.GetAcl(this.Uri, this.ServiceClient.Timeout.RoundUpToSeconds()),
                null /* no request body */,
                null /* no response header processing */,
                (stream) =>
                {
                    TablePermissions tableAcl = new TablePermissions();

                    // Get the policies from the web response.
                    TableResponse.ReadSharedAccessIdentifiers(stream, tableAcl);

                    setResult(tableAcl);
                });
        }
    }
}
