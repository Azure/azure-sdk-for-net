// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.TestFramework.Recording;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework;

public abstract class RecordingTestBase<TEnvironment> : RecordingTestBase where TEnvironment : RecordedTestEnvironment
{
    public RecordingTestBase(bool isAsync, RecordedTestMode? mode = null, Func<TEnvironment>? createEnv = null)
        : base(isAsync, mode)
    {
        createEnv ??= Helpers.CreateWithParameterlessConstructor<TEnvironment>();
        TestEnvironment = createEnv()
            ?? throw new ArgumentNullException(nameof(TestEnvironment));

        Mode = mode ?? TestEnvironment.GlobalMode;
    }

    public TEnvironment TestEnvironment { get; }

    protected override ProxyOptions CreateProxyOptions() => new ProxyOptions()
    {
        StorageLocationDir = TestEnvironment.RepositoryRoot.FullName,
        DevCertFile = TestEnvironment.DevCertPath?.FullName,
        DevCertPassword = TestEnvironment.DevCertPassword
    };

    protected override FileInfo GetAssetsJson()
    {
        for (var dir = TestEnvironment.GetSourcePath(GetType().Assembly);
            dir != null;
            dir = dir.Parent)
        {
            if (IsGitRootFolder(dir))
            {
                break;
            }
            else if (HasAssetsFile(dir))
            {
                return new FileInfo(Path.Combine(dir.FullName, AssetsJsonFile));
            }
        }

        throw new InvalidOperationException($"Could not find the '{AssetsJsonFile}' file to use");

        static bool IsGitRootFolder(DirectoryInfo dir) => dir.GetDirectories(".git", SearchOption.TopDirectoryOnly).Length == 1;
        bool HasAssetsFile(DirectoryInfo dir) => dir.GetFiles(AssetsJsonFile, SearchOption.TopDirectoryOnly).Length == 1;
    }

    protected override string GetRecordingFileRelativePath()
    {
        DirectoryInfo? dir = TestEnvironment.GetSourcePath(GetType().Assembly);
        if (dir == null)
        {
            throw new InvalidOperationException("Could not determine the source path of the test assembly");
        }

        string relativeDir = FileExtensions.GetRelativePath(TestEnvironment.RepositoryRoot.FullName, dir.FullName);

        var builder = GetRecordedTestName();
        builder.Append(".json");

        return Path.Combine(relativeDir, builder.ToString());
    }
}
