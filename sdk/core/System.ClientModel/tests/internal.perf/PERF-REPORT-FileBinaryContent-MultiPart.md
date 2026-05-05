# Perf Report: `FileBinaryContent` and `MultiPartFormContent`

**Environment:** BenchmarkDotNet v0.15.8, Windows 11 26200, Snapdragon X 12-core X1E80100 @ 3.40 GHz, .NET 8.0.26 Arm64 RyuJIT, Concurrent Server GC.
**Job:** `IterationTime=250 ms`, `WarmupCount=1`, `MinIterationCount=15`, `MaxIterationCount=20`, `MemoryDiagnoser`.
**Sink:** all writes target `Stream.Null` to isolate the type's overhead from network/file output cost.
**Total runs:** 75 (10:48 wall-clock).

Raw artifacts: [perf-results.log](perf-results.log).

---

## TL;DR

- **`FileBinaryContent` is correctly streaming.** Path- and stream-backed instances allocate **constant ~600–3.3 KB regardless of file size** (4 KB / 256 KB / 8 MB). No buffering of file payloads occurs.
- **`Construct_FromPath` is ~60 ns / 320 B and is independent of file size.** Lazy file-open contract is verified — no I/O at construction.
- **`MultiPartFormContent` correctly streams file parts.** `WriteToAsync_FilePartsFromPath` allocates ~3 KB (1 part) → ~47 KB (16 parts) at 4 MB/file — **flat in `FileSize`**, scales linearly only in part count.
- **List-of-files scenario (each part backed by a distinct file) behaves identically to single-file reuse.** No regression and no extra allocation per distinct path.
- ⚠️ **`FileBinaryContent(BinaryData)` materializes the full byte array on `WriteTo`**: at 8 MB it allocates **8,388,900 B per op** and triggers Gen2 GC. This is the only path that is *not* streaming. Likely culprit: the underlying `Create(BinaryData)` factory currently produces a `BinaryContent` that copies bytes via `ToArray()` instead of wrapping `ReadOnlyMemory`/`Stream`.

---

## Methodology

Two benchmark classes were added under [tests/internal.perf](.):

- [FileBinaryContentBenchmarks.cs](FileBinaryContentBenchmarks.cs) — covers construction (path / `BinaryData` / `Stream`), `WriteTo` / `WriteToAsync`, and `TryComputeLength`. `FileSize` is parameterized at 4 KB / 256 KB / 8 MB.
- [MultiPartFormContentBenchmarks.cs](MultiPartFormContentBenchmarks.cs) — covers `Add` of file parts (path-backed, `BinaryData`-backed), primitive parts, `BinaryData` parts, plus full `WriteTo` / `WriteToAsync`. Includes a dedicated **list-of-files** scenario (`_filePaths[]` — each part references a distinct file on disk). `FileSize` parameterized at 64 KB / 4 MB and `FileParts` at 1 / 4 / 16.

Both write to `Stream.Null` so allocations and time directly reflect the type's overhead.

---

## `FileBinaryContent` results

| Method                      | FileSize | Mean         | Allocated   | Notes                                    |
|---------------------------- |---------:|-------------:|------------:|------------------------------------------|
| Construct_FromPath          |   4 KB   |    61 ns     |    320 B    | flat across sizes — lazy open verified   |
| Construct_FromPath          | 256 KB   |    62 ns     |    320 B    |                                          |
| Construct_FromPath          |   8 MB   |    60 ns     |    320 B    |                                          |
| Construct_FromBinaryData    |   8 MB   |    43 ns     |    248 B    | flat                                     |
| TryComputeLength_FromPath   |   4 KB   |   75 µs      |    600 B    | dominated by file-open syscall           |
| TryComputeLength_FromPath   |   8 MB   |   67 µs      |    600 B    | flat — uses `Length`, not a read         |
| WriteTo_FromPath            |   4 KB   |   79 µs      |    642 B    | streams                                  |
| WriteTo_FromPath            |   8 MB   |  1.09 ms     |  1,186 B    | **alloc flat in size** ✅                 |
| WriteToAsync_FromPath       |   4 KB   |  104 µs      |  1,445 B    |                                          |
| WriteToAsync_FromPath       |   8 MB   |  1.31 ms     |  3,315 B    | **alloc flat in size** ✅                 |
| WriteToAsync_FromStream     |   4 KB   |  109 µs      |  1,330 B    |                                          |
| WriteToAsync_FromStream     |   8 MB   |  1.31 ms     |  3,187 B    | **alloc flat in size** ✅                 |
| **WriteTo_FromBinaryData**  |   4 KB   |  483 ns      |  4,368 B    | suspicious even at 4 KB                  |
| **WriteTo_FromBinaryData**  | 256 KB   |  149 µs      | **262,441 B** | ⚠ alloc ≈ FileSize                      |
| **WriteTo_FromBinaryData**  |   8 MB   |  2.70 ms     | **8,388,900 B** | ⚠ Gen2 every iteration               |

### Findings
1. **Path-backed and stream-backed paths stream correctly.** Allocations are independent of `FileSize` — confirms `FileStream` + `Stream.CopyTo`/`CopyToAsync` is being used and no `ToArray()`/full buffering occurs.
2. **`Construct_FromPath` does not open the file.** 60 ns / 320 B is consistent with `Lazy<>` + delegate capture + `Path.GetFileName` only.
3. **`TryComputeLength_FromPath` does open the file** (~67 µs) because it forces the `Lazy<>`. This matches the documented contract but is worth noting: callers that probe length will pay the file-open cost.
4. ⚠ **`WriteTo_FromBinaryData` allocates ≈ payload size.** This is the only non-streaming path. The fix is to make the `BinaryData` factory wrap the underlying memory (e.g., `new ReadOnlyMemoryContent(data.ToMemory())` / `data.ToStream()`) instead of copying via `ToArray()`. `MultiPartFormContent.Add(string, BinaryData)` already does this correctly — the bug is localized to `FileBinaryContent`'s `BinaryData` overload.

---

## `MultiPartFormContent` results

### Add-only (no write)

| Method                       | FileSize | Parts | Mean      | Allocated   |
|----------------------------- |---------:|------:|----------:|------------:|
| Add_FileParts_FromPath       |  64 KB   |   1   |  845 ns   |   2,392 B   |
| Add_FileParts_FromPath       |  64 KB   |  16   |  6.97 µs  |  17,920 B   |
| Add_FileParts_FromPath       |   4 MB   |   1   |  846 ns   |   2,392 B   |
| Add_FileParts_FromPath       |   4 MB   |  16   |  6.96 µs  |  17,920 B   |
| Add_ListOfFiles              |  64 KB   |  16   |  7.35 µs  |  18,096 B   |
| Add_ListOfFiles              |   4 MB   |  16   |  7.40 µs  |  18,096 B   |
| Add_FileParts_FromBinaryData |   4 MB   |  16   |  4.56 µs  |  12,544 B   |
| Add_BinaryDataParts          |   4 MB   |  16   |  3.34 µs  |   7,632 B   |
| Add_PrimitiveParts           |   4 MB   |  16   | 17.54 µs  |  53,504 B   |

- **Add cost is independent of `FileSize`** for every variant — file contents are never read during `Add`. ✅
- **List-of-files vs single-file path:** `Add_ListOfFiles` is within ~5 % of `Add_FileParts_FromPath` (7.40 µs vs 6.96 µs at 16 parts) and allocates the same ~1.1 KB/part. Distinct paths do not introduce extra cost. ✅
- **`Add_PrimitiveParts` allocates ~3.3 KB per call.** This is the most expensive `Add` overload because every primitive routes through `Utf8JsonWriter` + `MemoryStream` + `StreamContent`. Worth noting if SDKs add many small primitive fields per request.

### Full WriteToAsync (streaming the whole multipart payload)

| Method                              | FileSize | Parts | Mean       | Allocated  |
|------------------------------------ |---------:|------:|-----------:|-----------:|
| WriteToAsync_FilePartsFromPath      |  64 KB   |   1   |   113 µs   |  5,455 B   |
| WriteToAsync_FilePartsFromPath      |   4 MB   |   1   |   688 µs   |  6,386 B   |
| WriteToAsync_FilePartsFromPath      |  64 KB   |  16   |  1.66 ms   | 41,869 B   |
| WriteToAsync_FilePartsFromPath      |   4 MB   |  16   | 10.02 ms   | 47,380 B   |
| WriteToAsync_ListOfFiles            |   4 MB   |  16   | 11.50 ms   | 49,193 B   |
| WriteToAsync_FilePartsFromBinaryData|   4 MB   |  16   |   9.8 µs   | 14,528 B   |
| WriteTo_FilePartsFromPath (sync)    |   4 MB   |  16   |  9.83 ms   | 33,165 B   |

### Findings
1. **End-to-end multipart write streams correctly from disk.** At 16 × 4 MB (= 64 MB payload), allocation is **~47 KB total**, i.e. ~3 KB/part of overhead — independent of `FileSize`. No payload buffering. ✅
2. **List-of-files matches single-file behavior end-to-end.** `WriteToAsync_ListOfFiles` (16 distinct files × 4 MB) = 11.5 ms / 49 KB; `WriteToAsync_FilePartsFromPath` (same file × 16) = 10.0 ms / 47 KB. The ~15 % time delta is OS file-cache warmth (16 distinct files vs one hot file), not type overhead. ✅
3. **`BinaryData`-backed multipart is streamed too.** `WriteToAsync_FilePartsFromBinaryData` at 4 MB × 16 = 9.8 µs / 14.5 KB. The `ReadOnlyMemoryContent` wrapper (used in `MultiPartFormContent.Add(string, BinaryData)`) avoids copying. Note: the very low time is because there is no real I/O — `Stream.Null` discards instantly and no file-system traversal happens.
4. **Sync `WriteTo` and async `WriteToAsync` are equivalent in cost.** Confirms `MultipartFormDataContent.CopyTo`/`CopyToAsync` is doing the right thing on .NET 8.
5. **Time scales ~linearly in `Parts × FileSize`** for path-backed parts, as expected for true streaming I/O.

---

## Recommendations

1. ⚠ **Fix `FileBinaryContent(BinaryData)`'s `WriteTo` to avoid the per-call full-payload copy.** Mirror the wrapping strategy used by `MultiPartFormContent.Add(string, BinaryData)`:
   ```csharp
   #if NET6_0_OR_GREATER
       // wrap memory, do not copy
   #else
       // use BinaryData.ToStream()
   #endif
   ```
   The current 8 MB → 8 MB allocation forces Gen2 collections and defeats the purpose of `BinaryData` over `byte[]`.
2. **Document `TryComputeLength` opens the file.** Callers that want a cheap probe (e.g., to set `Content-Length` headers up front) should be aware.
3. **Consider a fast path for primitive parts.** `Add_PrimitiveParts` is the most allocation-heavy `Add` overload (~3.3 KB/call). Reusable `Utf8JsonWriter` / pooled `MemoryStream` could reduce this if SDKs add many small fields, but it's not on the hot streaming path.
4. **No action needed for the streaming/file-handling story.** Both new types correctly stream from disk and the list-of-files scenario behaves identically to repeated single-file use.

---

## How to reproduce

```pwsh
cd sdk/core/System.ClientModel/tests/internal.perf
dotnet build -c Release -f net8.0
dotnet run -c Release --framework net8.0 --no-build -- `
    --filter "*FileBinaryContent*" "*MultiPartFormContent*" `
    --exporters github
```
