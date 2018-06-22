namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    public class PermissionsTests : BaseTest
    {
        [Fact]
        public void ListPermissions()
        {
            UseClientFor(async client =>
            {
                var result = await client.Permissions.ListAsync(appId);

                Assert.Equal("owner.user@microsoft.com", result.Owner);
                Assert.Equal(new string[] { "guest@outlook.com", "invited.user@live.com" }, result.Emails);
            });
        }

        [Fact]
        public void AddPermission()
        {
            UseClientFor(async client =>
            {
                var userToAdd = new UserCollaborator
                {
                    Email = "guest@outlook.com"
                };

                await client.Permissions.AddAsync(appId, userToAdd);
                var result = await client.Permissions.ListAsync(appId);

                Assert.True(result.Emails.Contains(userToAdd.Email));
            });
        }

        [Fact]
        public void DeletePermission()
        {
            UseClientFor(async client =>
            {
                var userToRemove = new UserCollaborator
                {
                    Email = "guest@outlook.com"
                };

                await client.Permissions.DeleteAsync(appId, userToRemove);
                var result = await client.Permissions.ListAsync(appId);

                Assert.False(result.Emails.Contains(userToRemove.Email));
            });
        }

        [Fact]
        public void UpdatePermission()
        {
            UseClientFor(async client =>
            {
                var collaborators = new CollaboratorsArray
                {
                    Emails = new string[] 
                    {
                        "guest@outlook.com",
                        "invited.user@live.com"
                    }
                };

                await client.Permissions.UpdateAsync(appId, collaborators);
                var result = await client.Permissions.ListAsync(appId);

                Assert.Equal(collaborators.Emails, result.Emails);
            });
        }
    }
}
