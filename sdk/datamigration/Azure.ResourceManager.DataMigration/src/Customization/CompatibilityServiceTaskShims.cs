// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402, SA1649, CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.DataMigration.Mocking;
using Azure.ResourceManager.DataMigration.Models;

namespace Azure.ResourceManager.DataMigration
{
    /// <summary>Backward-compatible GA alias for service-level tasks.</summary>
    public class ServiceServiceTaskResource : DataMigrationServiceTaskResource
    {
        public static new readonly Azure.Core.ResourceType ResourceType = DataMigrationServiceTaskResource.ResourceType;

        protected ServiceServiceTaskResource()
        {
        }

        internal ServiceServiceTaskResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal ServiceServiceTaskResource(ArmClient client, DataMigrationProjectTaskData data) : base(client, data)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ServiceServiceTaskResource> Get(string expand = default, CancellationToken cancellationToken = default)
        {
            Response<DataMigrationServiceTaskResource> response = base.Get(expand, cancellationToken);
            return Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<Response<ServiceServiceTaskResource>> GetAsync(string expand = default, CancellationToken cancellationToken = default)
        {
            Response<DataMigrationServiceTaskResource> response = await base.GetAsync(expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ServiceServiceTaskResource> Update(DataMigrationProjectTaskData data, CancellationToken cancellationToken = default)
        {
            Response<DataMigrationServiceTaskResource> response = base.Update(data, cancellationToken);
            return Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<Response<ServiceServiceTaskResource>> UpdateAsync(DataMigrationProjectTaskData data, CancellationToken cancellationToken = default)
        {
            Response<DataMigrationServiceTaskResource> response = await base.UpdateAsync(data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ServiceServiceTaskResource> Cancel(CancellationToken cancellationToken = default)
        {
            Response<DataMigrationServiceTaskResource> response = base.Cancel(cancellationToken);
            return Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<Response<ServiceServiceTaskResource>> CancelAsync(CancellationToken cancellationToken = default)
        {
            Response<DataMigrationServiceTaskResource> response = await base.CancelAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse());
        }
    }

    /// <summary>Backward-compatible GA alias for service-level tasks.</summary>
    public class ServiceServiceTaskCollection : DataMigrationServiceTaskCollection, IEnumerable<ServiceServiceTaskResource>, IAsyncEnumerable<ServiceServiceTaskResource>
    {
        protected ServiceServiceTaskCollection()
        {
        }

        internal ServiceServiceTaskCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual ArmOperation<ServiceServiceTaskResource> CreateOrUpdate(WaitUntil waitUntil, string taskName, DataMigrationProjectTaskData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<DataMigrationServiceTaskResource> operation = base.CreateOrUpdate(waitUntil, taskName, data, cancellationToken);
            return new DataMigrationArmOperation<ServiceServiceTaskResource>(Response.FromValue(new ServiceServiceTaskResource(Client, operation.Value.Data), operation.GetRawResponse()), operation.GetRehydrationToken());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<ArmOperation<ServiceServiceTaskResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string taskName, DataMigrationProjectTaskData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<DataMigrationServiceTaskResource> operation = await base.CreateOrUpdateAsync(waitUntil, taskName, data, cancellationToken).ConfigureAwait(false);
            return new DataMigrationArmOperation<ServiceServiceTaskResource>(Response.FromValue(new ServiceServiceTaskResource(Client, operation.Value.Data), operation.GetRawResponse()), operation.GetRehydrationToken());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ServiceServiceTaskResource> Get(string taskName, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<DataMigrationServiceTaskResource> response = base.Get(taskName, expand, cancellationToken);
            return Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<Response<ServiceServiceTaskResource>> GetAsync(string taskName, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<DataMigrationServiceTaskResource> response = await base.GetAsync(taskName, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Pageable<ServiceServiceTaskResource> GetAll(string taskType = default, CancellationToken cancellationToken = default)
            => new ServiceTaskPageable(base.GetAll(taskType, cancellationToken), Client);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual AsyncPageable<ServiceServiceTaskResource> GetAllAsync(string taskType = default, CancellationToken cancellationToken = default)
            => new ServiceTaskAsyncPageable(base.GetAllAsync(taskType, cancellationToken), Client);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual NullableResponse<ServiceServiceTaskResource> GetIfExists(string taskName, string expand = default, CancellationToken cancellationToken = default)
        {
            NullableResponse<DataMigrationServiceTaskResource> response = base.GetIfExists(taskName, expand, cancellationToken);
            return response.HasValue ? Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse()) : new NoValueResponse<ServiceServiceTaskResource>(response.GetRawResponse());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<NullableResponse<ServiceServiceTaskResource>> GetIfExistsAsync(string taskName, string expand = default, CancellationToken cancellationToken = default)
        {
            NullableResponse<DataMigrationServiceTaskResource> response = await base.GetIfExistsAsync(taskName, expand, cancellationToken).ConfigureAwait(false);
            return response.HasValue ? Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse()) : new NoValueResponse<ServiceServiceTaskResource>(response.GetRawResponse());
        }

        IEnumerator<ServiceServiceTaskResource> IEnumerable<ServiceServiceTaskResource>.GetEnumerator() => GetAll().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();
        IAsyncEnumerator<ServiceServiceTaskResource> IAsyncEnumerable<ServiceServiceTaskResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);

        private sealed class ServiceTaskPageable : Pageable<ServiceServiceTaskResource>
        {
            private readonly Pageable<DataMigrationServiceTaskResource> _pageable;
            private readonly ArmClient _client;

            public ServiceTaskPageable(Pageable<DataMigrationServiceTaskResource> pageable, ArmClient client)
            {
                _pageable = pageable;
                _client = client;
            }

            public override IEnumerable<Page<ServiceServiceTaskResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (Page<DataMigrationServiceTaskResource> page in _pageable.AsPages(continuationToken, pageSizeHint))
                {
                    List<ServiceServiceTaskResource> values = new List<ServiceServiceTaskResource>();
                    foreach (DataMigrationServiceTaskResource resource in page.Values)
                    {
                        values.Add(new ServiceServiceTaskResource(_client, resource.Data));
                    }
                    yield return Page<ServiceServiceTaskResource>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class ServiceTaskAsyncPageable : AsyncPageable<ServiceServiceTaskResource>
        {
            private readonly AsyncPageable<DataMigrationServiceTaskResource> _pageable;
            private readonly ArmClient _client;

            public ServiceTaskAsyncPageable(AsyncPageable<DataMigrationServiceTaskResource> pageable, ArmClient client)
            {
                _pageable = pageable;
                _client = client;
            }

            public override async IAsyncEnumerable<Page<ServiceServiceTaskResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (Page<DataMigrationServiceTaskResource> page in _pageable.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    List<ServiceServiceTaskResource> values = new List<ServiceServiceTaskResource>();
                    foreach (DataMigrationServiceTaskResource resource in page.Values)
                    {
                        values.Add(new ServiceServiceTaskResource(_client, resource.Data));
                    }
                    yield return Page<ServiceServiceTaskResource>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }
    }

    /// <summary>Backward-compatible project-task wrapper using the GA type name.</summary>
    internal sealed class ProjectDataMigrationServiceTaskResourceShim : DataMigrationServiceTaskResource
    {
        private readonly TaskResource _inner;

        internal ProjectDataMigrationServiceTaskResourceShim(TaskResource inner)
        {
            _inner = inner;
        }

        public override bool HasData => _inner.HasData;
        public override DataMigrationProjectTaskData Data => _inner.Data;

        public override Response<DataMigrationServiceTaskResource> Get(string expand = default, CancellationToken cancellationToken = default)
        {
            Response<TaskResource> response = _inner.Get(expand, cancellationToken);
            return Response.FromValue<DataMigrationServiceTaskResource>(new ProjectDataMigrationServiceTaskResourceShim(response.Value), response.GetRawResponse());
        }

        public override async Task<Response<DataMigrationServiceTaskResource>> GetAsync(string expand = default, CancellationToken cancellationToken = default)
        {
            Response<TaskResource> response = await _inner.GetAsync(expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue<DataMigrationServiceTaskResource>(new ProjectDataMigrationServiceTaskResourceShim(response.Value), response.GetRawResponse());
        }

        public override Response<DataMigrationServiceTaskResource> Update(DataMigrationProjectTaskData data, CancellationToken cancellationToken = default)
        {
            Response<TaskResource> response = _inner.Update(data, cancellationToken);
            return Response.FromValue<DataMigrationServiceTaskResource>(new ProjectDataMigrationServiceTaskResourceShim(response.Value), response.GetRawResponse());
        }

        public override async Task<Response<DataMigrationServiceTaskResource>> UpdateAsync(DataMigrationProjectTaskData data, CancellationToken cancellationToken = default)
        {
            Response<TaskResource> response = await _inner.UpdateAsync(data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue<DataMigrationServiceTaskResource>(new ProjectDataMigrationServiceTaskResourceShim(response.Value), response.GetRawResponse());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Response<DataMigrationCommandProperties> Command(DataMigrationCommandProperties dataMigrationCommandProperties, CancellationToken cancellationToken = default)
            => _inner.Command(dataMigrationCommandProperties, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Task<Response<DataMigrationCommandProperties>> CommandAsync(DataMigrationCommandProperties dataMigrationCommandProperties, CancellationToken cancellationToken = default)
            => _inner.CommandAsync(dataMigrationCommandProperties, cancellationToken);
    }

    /// <summary>Backward-compatible project-task collection wrapper using the GA type name.</summary>
    internal sealed class ProjectDataMigrationServiceTaskCollectionShim : DataMigrationServiceTaskCollection
    {
        private readonly TaskCollection _inner;

        internal ProjectDataMigrationServiceTaskCollectionShim(TaskCollection inner)
        {
            _inner = inner;
        }

        public override Response<DataMigrationServiceTaskResource> Get(string taskName, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<TaskResource> response = _inner.Get(taskName, expand, cancellationToken);
            return Response.FromValue<DataMigrationServiceTaskResource>(new ProjectDataMigrationServiceTaskResourceShim(response.Value), response.GetRawResponse());
        }

        public override async Task<Response<DataMigrationServiceTaskResource>> GetAsync(string taskName, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<TaskResource> response = await _inner.GetAsync(taskName, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue<DataMigrationServiceTaskResource>(new ProjectDataMigrationServiceTaskResourceShim(response.Value), response.GetRawResponse());
        }

        public override Pageable<DataMigrationServiceTaskResource> GetAll(string taskType = default, CancellationToken cancellationToken = default)
            => new ShimPageable(_inner.GetAll(taskType, cancellationToken));

        public override AsyncPageable<DataMigrationServiceTaskResource> GetAllAsync(string taskType = default, CancellationToken cancellationToken = default)
            => new ShimAsyncPageable(_inner.GetAllAsync(taskType, cancellationToken));

        private sealed class ShimPageable : Pageable<DataMigrationServiceTaskResource>
        {
            private readonly Pageable<TaskResource> _pageable;
            public ShimPageable(Pageable<TaskResource> pageable) => _pageable = pageable;
            public override IEnumerable<Page<DataMigrationServiceTaskResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (Page<TaskResource> page in _pageable.AsPages(continuationToken, pageSizeHint))
                {
                    List<DataMigrationServiceTaskResource> values = new List<DataMigrationServiceTaskResource>();
                    foreach (TaskResource resource in page.Values)
                    {
                        values.Add(new ProjectDataMigrationServiceTaskResourceShim(resource));
                    }
                    yield return Page<DataMigrationServiceTaskResource>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class ShimAsyncPageable : AsyncPageable<DataMigrationServiceTaskResource>
        {
            private readonly AsyncPageable<TaskResource> _pageable;
            public ShimAsyncPageable(AsyncPageable<TaskResource> pageable) => _pageable = pageable;
            public override async IAsyncEnumerable<Page<DataMigrationServiceTaskResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (Page<TaskResource> page in _pageable.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    List<DataMigrationServiceTaskResource> values = new List<DataMigrationServiceTaskResource>();
                    foreach (TaskResource resource in page.Values)
                    {
                        values.Add(new ProjectDataMigrationServiceTaskResourceShim(resource));
                    }
                    yield return Page<DataMigrationServiceTaskResource>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }
    }

    /// <summary>Backward-compatible service-task members for GA signatures.</summary>
    public partial class DataMigrationServiceTaskResource
    {
        // Backward-compatible project-task command API from GA.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataMigrationCommandProperties> Command(DataMigrationCommandProperties dataMigrationCommandProperties, CancellationToken cancellationToken = default)
            => throw new NotSupportedException();

        // Backward-compatible project-task command API from GA.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DataMigrationCommandProperties>> CommandAsync(DataMigrationCommandProperties dataMigrationCommandProperties, CancellationToken cancellationToken = default)
            => throw new NotSupportedException();

        // Backward-compatible project-task resource identifier shape from GA.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string serviceName, string projectName, string taskName)
            => TaskResource.CreateResourceIdentifier(subscriptionId, groupName, serviceName, projectName, taskName);
    }

    /// <summary>Backward-compatible service-task members for GA signatures.</summary>
    public partial class DataMigrationServiceTaskCollection
    {
        // Backward-compatible virtual members are overridden by project-task shims when needed.
    }

    /// <summary>Backward-compatible service-task members for GA signatures.</summary>
    public partial class DataMigrationProjectResource
    {
        // Backward-compatible GA project-task accessor.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DataMigrationServiceTaskCollection GetDataMigrationServiceTasks()
            => new ProjectDataMigrationServiceTaskCollectionShim(GetTasks());

        // Backward-compatible GA project-task accessor.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DataMigrationServiceTaskResource> GetDataMigrationServiceTask(string taskName, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<TaskResource> response = GetTasks().Get(taskName, expand, cancellationToken);
            return Response.FromValue<DataMigrationServiceTaskResource>(new ProjectDataMigrationServiceTaskResourceShim(response.Value), response.GetRawResponse());
        }

        // Backward-compatible GA project-task accessor.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<DataMigrationServiceTaskResource>> GetDataMigrationServiceTaskAsync(string taskName, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<TaskResource> response = await GetTasks().GetAsync(taskName, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue<DataMigrationServiceTaskResource>(new ProjectDataMigrationServiceTaskResourceShim(response.Value), response.GetRawResponse());
        }
    }

    /// <summary>Backward-compatible service-task members for GA signatures.</summary>
    public partial class DataMigrationServiceResource
    {
        // Backward-compatible GA alias for service-level tasks.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ServiceServiceTaskCollection GetServiceServiceTasks()
            => new ServiceServiceTaskCollection(Client, Id);

        // Backward-compatible GA alias for service-level tasks.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ServiceServiceTaskResource> GetServiceServiceTask(string taskName, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<DataMigrationServiceTaskResource> response = GetDataMigrationServiceTask(taskName, expand, cancellationToken);
            return Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse());
        }

        // Backward-compatible GA alias for service-level tasks.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ServiceServiceTaskResource>> GetServiceServiceTaskAsync(string taskName, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<DataMigrationServiceTaskResource> response = await GetDataMigrationServiceTaskAsync(taskName, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ServiceServiceTaskResource(Client, response.Value.Data), response.GetRawResponse());
        }
    }

    /// <summary>Backward-compatible extension members for GA signatures.</summary>
    public static partial class DataMigrationExtensions
    {
        // Backward-compatible GA alias for service-level tasks.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceServiceTaskResource GetServiceServiceTaskResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableDataMigrationArmClient(client).GetServiceServiceTaskResource(id);
        }
    }
}

namespace Azure.ResourceManager.DataMigration.Mocking
{
    /// <summary>Backward-compatible service-task members for GA signatures.</summary>
    public partial class MockableDataMigrationArmClient
    {
        // Backward-compatible GA alias for service-level tasks.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ServiceServiceTaskResource GetServiceServiceTaskResource(ResourceIdentifier id)
        {
            ServiceServiceTaskResource.ValidateResourceId(id);
            return new ServiceServiceTaskResource(Client, id);
        }
    }
}
