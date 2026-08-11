// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>
    /// Developer-facing client for one explicit Foundry state store, bound to a single
    /// caller-chosen store <see cref="Name"/>.
    /// </summary>
    /// <remarks>
    /// Session or conversation scoping is expressed by encoding that identity into the
    /// store name itself (for example <c>checkpoints/&lt;conversation-id&gt;</c>).
    /// Prefer <c>GetOrCreateAsync</c> over constructing directly: it resolves (or
    /// creates) the server-side store resource in one call.
    /// </remarks>
    public class FoundryStateStore
    {
        /// <summary>The default per-item TTL (30 days, in seconds) applied at store creation.</summary>
        public const int DefaultItemTtlSeconds = 30 * 24 * 60 * 60;

        private const string DelegatedUserIdHeader = "x-ms-user-id";

        private static readonly ModelReaderWriterOptions WireOptions = new("W");

        private readonly FoundryStorageClient _client = null!;
        private readonly string _name = null!;
        private readonly bool _userIsolation;
        private readonly int _itemTtlSeconds;
        private readonly string? _description;
        private readonly IReadOnlyDictionary<string, string>? _tags;
        private readonly string? _userId;

        /// <summary>Initializes a new instance of the <see cref="FoundryStateStore"/> class for mocking.</summary>
        protected FoundryStateStore()
        {
        }

        internal FoundryStateStore(
            string name,
            TokenCredential credential,
            FoundryStorageEndpoint endpoint,
            bool userIsolation,
            int itemTtlSeconds,
            string? description,
            IReadOnlyDictionary<string, string>? tags,
            string? userId,
            FoundryStorageClientOptions? options)
        {
            _client = new FoundryStorageClient(credential, endpoint, options);
            _name = name;
            _userIsolation = userIsolation;
            _itemTtlSeconds = itemTtlSeconds;
            _description = description;
            _tags = tags;
            _userId = userId;
        }

        /// <summary>Gets the logical store name bound to this client.</summary>
        public virtual string Name => _name;

        /// <summary>
        /// Returns a client bound to <paramref name="name"/>, creating the store if it does not exist.
        /// </summary>
        /// <param name="name">The logical state-store name. Encode conversation/thread identity into this name when you need that scope.</param>
        /// <param name="credential">A token credential used to authenticate to the storage service.</param>
        /// <param name="endpoint">Optional Foundry project endpoint (or full storage URL). When <see langword="null"/>, resolved from the <c>FOUNDRY_PROJECT_ENDPOINT</c> environment variable.</param>
        /// <param name="userIsolation">Whether item operations are partitioned per resolved user. Applied only when the store is created.</param>
        /// <param name="itemTtlSeconds">Store-level default TTL inherited by every item. Applied only when the store is created.</param>
        /// <param name="description">Optional store description, set at creation.</param>
        /// <param name="tags">Optional store metadata tags, set at creation.</param>
        /// <param name="userId">Delegated end-user identity for trusted callers.</param>
        /// <param name="apiVersion">Storage API version.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The bound, ready-to-use store client.</returns>
        public static Task<FoundryStateStore> GetOrCreateAsync(
            string name,
            TokenCredential credential,
            Uri? endpoint = null,
            bool userIsolation = false,
            int itemTtlSeconds = DefaultItemTtlSeconds,
            string? description = null,
            IReadOnlyDictionary<string, string>? tags = null,
            string? userId = null,
            string apiVersion = FoundryStorageEndpoint.DefaultApiVersion,
            CancellationToken cancellationToken = default)
            => GetOrCreateAsync(
                name, credential, endpoint, userIsolation, itemTtlSeconds, description, tags, userId, apiVersion, options: null, cancellationToken);

        internal static async Task<FoundryStateStore> GetOrCreateAsync(
            string name,
            TokenCredential credential,
            Uri? endpoint,
            bool userIsolation,
            int itemTtlSeconds,
            string? description,
            IReadOnlyDictionary<string, string>? tags,
            string? userId,
            string apiVersion,
            FoundryStorageClientOptions? options,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(credential, nameof(credential));

            FoundryStorageEndpoint resolved = endpoint is null
                ? FoundryStorageEndpoint.FromEnvironment(apiVersion)
                : FoundryStorageEndpoint.FromEndpoint(endpoint.AbsoluteUri, apiVersion);

            var store = new FoundryStateStore(
                name, credential, resolved, userIsolation, itemTtlSeconds, description, tags, userId, options);

            try
            {
                await store.FetchPropertiesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (FoundryStorageNotFoundException)
            {
                try
                {
                    await store.CreatePropertiesAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (FoundryStorageConflictException)
                {
                    await store.FetchPropertiesAsync(cancellationToken).ConfigureAwait(false);
                }
            }

            return store;
        }

        /// <summary>Fetches the bound store's own descriptor.</summary>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The store descriptor, or <see langword="null"/> if the store does not exist.</returns>
        public virtual async Task<StateStore?> GetAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await FetchPropertiesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (FoundryStorageNotFoundException)
            {
                return null;
            }
        }

        /// <summary>Updates the bound store's mutable metadata (<c>description</c> / <c>tags</c>).</summary>
        /// <param name="update">The metadata changes to apply.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The updated store descriptor.</returns>
        public virtual async Task<StateStore> UpdateAsync(StateStoreUpdateOptions update, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(update, nameof(update));

            BinaryData body = BuildUpdateBody(update);
            Request request = BuildRequest(RequestMethod.Patch, StorePath(), content: body);
            Response response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return Deserialize<StateStore>(response);
        }

        /// <summary>Deletes the bound store, cascading to every item under it.</summary>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The deleted-store marker.</returns>
        public virtual async Task<DeletedStateStore> DeleteAsync(CancellationToken cancellationToken = default)
        {
            Request request = BuildRequest(RequestMethod.Delete, StorePath());
            Response response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return Deserialize<DeletedStateStore>(response);
        }

        /// <summary>Creates a new item, failing on a duplicate key.</summary>
        /// <param name="key">The item key.</param>
        /// <param name="value">The item value as a JSON object.</param>
        /// <param name="tags">Optional item metadata tags.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A reference to the created item.</returns>
        public virtual async Task<StateStoreItemRef> CreateItemAsync(
            string key,
            IDictionary<string, BinaryData> value,
            IReadOnlyDictionary<string, string>? tags = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            var payload = new CreateItemRequest(key, value);
            CopyTags(tags, payload.Tags);
            BinaryData body = ModelReaderWriter.Write(payload, WireOptions, AzureAIAgentServerCoreStorageContext.Default);
            Request request = BuildRequest(RequestMethod.Post, $"{StorePath()}/items", content: body, includeUserId: true);
            Response response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return Deserialize<StateStoreItemRef>(response);
        }

        /// <summary>Creates or replaces one item by key.</summary>
        /// <param name="key">The item key.</param>
        /// <param name="value">The item value as a JSON object.</param>
        /// <param name="tags">Optional item metadata tags.</param>
        /// <param name="ifMatch">Optional optimistic-concurrency token. Mutually exclusive with <paramref name="requireExists"/>.</param>
        /// <param name="requireExists">When <see langword="true"/>, requires the item to already exist (sends <c>If-Match: *</c>). Mutually exclusive with <paramref name="ifMatch"/>.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A reference to the written item.</returns>
        public virtual async Task<StateStoreItemRef> SetItemAsync(
            string key,
            IDictionary<string, BinaryData> value,
            IReadOnlyDictionary<string, string>? tags = null,
            string? ifMatch = null,
            bool requireExists = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));
            if (ifMatch is not null && requireExists)
            {
                throw new ArgumentException($"{nameof(ifMatch)} and {nameof(requireExists)} are mutually exclusive.");
            }

            var payload = new PutItemRequest(value);
            CopyTags(tags, payload.Tags);
            BinaryData body = ModelReaderWriter.Write(payload, WireOptions, AzureAIAgentServerCoreStorageContext.Default);
            string? header = requireExists ? "*" : ifMatch;
            Request request = BuildRequest(RequestMethod.Put, ItemPath(key), content: body, includeUserId: true, ifMatch: header);
            Response response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return Deserialize<StateStoreItemRef>(response);
        }

        /// <summary>Fetches one item by key.</summary>
        /// <param name="key">The item key.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The item, or <see langword="null"/> if it does not exist.</returns>
        public virtual async Task<StateStoreItem?> GetItemAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            try
            {
                Request request = BuildRequest(RequestMethod.Get, ItemPath(key), includeUserId: true);
                Response response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
                return Deserialize<StateStoreItem>(response);
            }
            catch (FoundryStorageNotFoundException)
            {
                return null;
            }
        }

        /// <summary>Deletes one item by key.</summary>
        /// <param name="key">The item key.</param>
        /// <param name="ifMatch">Optional optimistic-concurrency token.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The deleted-item marker.</returns>
        public virtual async Task<DeletedStateStoreItem> DeleteItemAsync(
            string key,
            string? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            Request request = BuildRequest(RequestMethod.Delete, ItemPath(key), includeUserId: true, ifMatch: ifMatch);
            Response response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return Deserialize<DeletedStateStoreItem>(response);
        }

        /// <summary>Lists keys within the bound store.</summary>
        /// <param name="tags">Optional AND-combined tag-equality filters.</param>
        /// <param name="limit">Optional maximum number of results.</param>
        /// <param name="after">Optional cursor: return results after this id. Mutually exclusive with <paramref name="before"/>.</param>
        /// <param name="before">Optional cursor: return results before this id. Mutually exclusive with <paramref name="after"/>.</param>
        /// <param name="order">Sort order over creation time.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A <see cref="StateStoreItemKeyPage"/> of keys.</returns>
        public virtual async Task<StateStoreItemKeyPage> ListKeysAsync(
            IReadOnlyDictionary<string, string>? tags = null,
            int? limit = null,
            string? after = null,
            string? before = null,
            ListRequestOrder order = ListRequestOrder.Desc,
            CancellationToken cancellationToken = default)
        {
            if (after is not null && before is not null)
            {
                throw new ArgumentException($"{nameof(after)} and {nameof(before)} are mutually exclusive.");
            }

            var query = new List<KeyValuePair<string, string>>();
            if (tags is not null)
            {
                foreach (KeyValuePair<string, string> pair in tags)
                {
                    query.Add(new KeyValuePair<string, string>($"tags.{pair.Key}", pair.Value));
                }
            }

            if (limit is not null)
            {
                query.Add(new KeyValuePair<string, string>("limit", limit.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)));
            }

            if (after is not null)
            {
                query.Add(new KeyValuePair<string, string>("after", after));
            }

            if (before is not null)
            {
                query.Add(new KeyValuePair<string, string>("before", before));
            }

            query.Add(new KeyValuePair<string, string>("order", order.ToSerialString()));

            Request request = BuildRequest(RequestMethod.Get, $"{StorePath()}/items:keys", includeUserId: true, query: query);
            Response response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return new StateStoreItemKeyPage(Deserialize<ListResponseStateStoreItemKey>(response));
        }

        private async Task<StateStore> FetchPropertiesAsync(CancellationToken cancellationToken)
        {
            Request request = BuildRequest(RequestMethod.Get, StorePath());
            Response response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return Deserialize<StateStore>(response);
        }

        private async Task<StateStore> CreatePropertiesAsync(CancellationToken cancellationToken)
        {
            var payload = new CreateStateStoreRequest(_name)
            {
                UserIsolation = _userIsolation,
                ItemTtlSeconds = _itemTtlSeconds,
                Description = _description,
            };
            CopyTags(_tags, payload.Tags);
            BinaryData body = ModelReaderWriter.Write(payload, WireOptions, AzureAIAgentServerCoreStorageContext.Default);
            Request request = BuildRequest(RequestMethod.Post, "state_stores", content: body);
            Response response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return Deserialize<StateStore>(response);
        }

        private Request BuildRequest(
            RequestMethod method,
            string path,
            BinaryData? content = null,
            bool includeUserId = false,
            string? ifMatch = null,
            IEnumerable<KeyValuePair<string, string>>? query = null)
        {
            Request request = _client.CreateRequest();
            request.Method = method;
            request.Uri.Reset(_client.Endpoint.BuildUri(path, query));
            if (content is not null)
            {
                request.Headers.Add("Content-Type", FoundryStorageClient.JsonContentType);
                request.Content = RequestContent.Create(content);
            }

            if (includeUserId && _userId is not null)
            {
                request.Headers.Add(DelegatedUserIdHeader, _userId);
            }

            if (ifMatch is not null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }

            return request;
        }

        private static T Deserialize<T>(Response response) where T : class, IPersistableModel<T>
        {
            T? model = ModelReaderWriter.Read<T>(response.Content, WireOptions, AzureAIAgentServerCoreStorageContext.Default);
            if (model is null)
            {
                throw new FoundryStorageApiException(response.Status, "The storage service returned an empty or unparseable response body.");
            }

            return model;
        }

        private static void CopyTags(IReadOnlyDictionary<string, string>? source, IDictionary<string, string> destination)
        {
            if (source is null)
            {
                return;
            }

            foreach (KeyValuePair<string, string> pair in source)
            {
                destination[pair.Key] = pair.Value;
            }
        }

        private static BinaryData BuildUpdateBody(StateStoreUpdateOptions update)
        {
            var buffer = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                if (update.IsDescriptionSet)
                {
                    if (update.Description is null)
                    {
                        writer.WriteNull("description");
                    }
                    else
                    {
                        writer.WriteString("description", update.Description);
                    }
                }

                if (update.IsTagsSet)
                {
                    if (update.Tags is null)
                    {
                        writer.WriteNull("tags");
                    }
                    else
                    {
                        writer.WritePropertyName("tags");
                        writer.WriteStartObject();
                        foreach (KeyValuePair<string, string> pair in update.Tags)
                        {
                            writer.WriteString(pair.Key, pair.Value);
                        }

                        writer.WriteEndObject();
                    }
                }

                writer.WriteEndObject();
            }

            return BinaryData.FromBytes(buffer.WrittenMemory);
        }

        private string StorePath() => $"state_stores/{EncodeSegment(_name)}";

        private string ItemPath(string key) => $"{StorePath()}/items/{EncodeSegment(key)}";

        private static string EncodeSegment(string value)
        {
            string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
            return encoded.TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }
    }
}
