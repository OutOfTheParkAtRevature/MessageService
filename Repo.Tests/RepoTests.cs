using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Models;
using Xunit;

namespace Repository.Tests
{
    public class RepoTests
    {

        /// <summary>
        /// Tests the CommitSave() method of Repo
        /// </summary>
        /// 

        [Fact]
        public async void TestCommitSave()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
                    .UseInMemoryDatabase(databaseName: "p3MessageService")
                    .Options;


            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());

                Message message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = Guid.NewGuid().ToString(),
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.UtcNow,
                    MessageText = "Hello, this is a test"

                };

                r.Messages.Add(message);
                await r.CommitSave();
                Assert.NotEmpty(context.Messages);

            }

        }
        [Fact]
        public async void TestGetMessageById()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
                   .UseInMemoryDatabase(databaseName: "p3MessageService")
                   .Options;


            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());

                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = Guid.NewGuid().ToString(),
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.UtcNow,
                    MessageText = "Hello, this is a test!!"
                };

                r.Messages.Add(message);
                await r.CommitSave();
                var listOfMessages = await r.GetMessageById(message.MessageID);
                Assert.True(listOfMessages.Equals(message));



            }
        }

        [Fact]
        public async void TestGetMessages()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
               .UseInMemoryDatabase(databaseName: "p3MessageService")
               .Options;


            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());

                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = Guid.NewGuid().ToString(),
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.UtcNow,
                    MessageText = "Hello, this is a test2!!"
                };

                r.Messages.Add(message);
                await r.CommitSave();
                var listOfMessages = await r.GetMessages();
                Assert.NotNull(listOfMessages);



            }
        }
    }
}
