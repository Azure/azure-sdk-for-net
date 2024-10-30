import "@typespec/http";
import "@typespec/rest";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";

@service({
    title: "SimplePost",
  })
   
namespace SimplePost;
   
using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ClientGenerator.Core;
using Azure.Core;

@client
interface SimplePostClient {
    @post @route("add") IncrementCount(@path addend: int32) : int32;
}