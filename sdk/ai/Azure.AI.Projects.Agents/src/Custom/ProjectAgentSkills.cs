// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

[Experimental("AAIP001")]
[CodeGenType("Skills")]
public partial class ProjectAgentSkills
{
    private static BinaryData CreateAndReadZipFile(string directoryPath)
    {
        string temporaryFile = Path.GetTempFileName();
        File.Delete(temporaryFile);
        ZipFile.CreateFromDirectory(directoryPath, temporaryFile);
        return new(File.ReadAllBytes(temporaryFile));
    }

    private static void SaveAndUnzipData(string directoryPath, BinaryData content)
    {
        string temporaryFile = Path.GetTempFileName();
        File.Delete(temporaryFile);
        File.WriteAllBytes(temporaryFile, content.ToArray());
        ZipFile.ExtractToDirectory(temporaryFile, directoryPath);
    }

    /// <summary> Creates a skill from a zip package. </summary>
    /// <param name="directoryPath"> The path to the directory, containing skill description. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="directoryPath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="directoryPath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentsSkill> CreateSkillFromPackage(string directoryPath, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(directoryPath, nameof(directoryPath));

        ClientResult result = CreateSkillFromPackage(BinaryContent.Create(CreateAndReadZipFile(directoryPath)), cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((AgentsSkill)result, result.GetRawResponse());
    }

    /// <summary> Creates a skill from a zip package. </summary>
    /// <param name="directoryPath"> The path to the directory, containing skill description. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="directoryPath"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="directoryPath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentsSkill>> CreateSkillFromPackageAsync(string directoryPath, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(directoryPath, nameof(directoryPath));

        ClientResult result = await CreateSkillFromPackageAsync(BinaryContent.Create(CreateAndReadZipFile(directoryPath)), cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((AgentsSkill)result, result.GetRawResponse());
    }

    /// <summary> Returns the list of all skills. </summary>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<AgentsSkill> GetSkills(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAICollectionResultOfT<AgentsSkill>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetSkillsRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<AgentsSkill>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns the list of all skills. </summary>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<AgentsSkill> GetSkillsAsyncAsync(int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return new InternalOpenAIAsyncCollectionResultOfT<AgentsSkill>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetSkillsRequest(
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<AgentsSkill>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Downloads a skill package, save it to file and return as a Binary data. </summary>
    /// <param name="skillName"> The unique name of the skill. </param>
    /// <param name="path"> The path to save the skill content to. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="skillName"/> or <paramref name="path"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="skillName"/> or <paramref name="path"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public BinaryData DownloadSkill(string skillName, string path, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(skillName, nameof(skillName));
        Argument.AssertNotNullOrEmpty(path, nameof(path));

        BinaryData result = DownloadSkill(skillName, cancellationToken);
        SaveAndUnzipData(path, result);
        return result;
    }

    /// <summary> Downloads a skill package, save it to file and return as a Binary data. </summary>
    /// <param name="skillName"> The unique name of the skill. </param>
    /// <param name="path"> The path to save the skill content to. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="skillName"/> or <paramref name="path"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="skillName"/> or <paramref name="path"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<BinaryData> DownloadSkillAsync(string skillName, string path, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(skillName, nameof(skillName));
        Argument.AssertNotNullOrEmpty(path, nameof(path));

        BinaryData result = await DownloadSkillAsync(skillName, cancellationToken).ConfigureAwait(false);
        SaveAndUnzipData(path, result);
        return result;
    }
}
