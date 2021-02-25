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

        [Fact]
        public async void TestGetUserInbox()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
       .UseInMemoryDatabase(databaseName: "p3MessageService")
       .Options;


            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());

                var userInbox = new UserInbox
                {
                   UserID = "636544",
                   MessageID = Guid.NewGuid(),
                   IsRead = false
                };

                r.UserInboxes.Add(userInbox);
                await r.CommitSave();
                var getUserInbox = await r.GetUserInbox(userInbox.UserID);
                Assert.NotNull(getUserInbox);

            }
        }

        [Fact]
        public async void TestGetMessagesBySenderById()
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
                    MessageText = "Hello, this is a test everyone!!!"
                };

                r.Messages.Add(message);
                await r.CommitSave();
                var listOfMessages = await r.GetMessagesBySenderById(message.SenderID);
                Assert.NotNull(listOfMessages);

            }
        }


        [Fact]
        public async void TestGetRecipientListById()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
       .UseInMemoryDatabase(databaseName: "p3MessageService")
       .Options;


            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());

                var recipientList = new RecipientList
                {
                   RecipientListID = Guid.NewGuid(),
                   RecipientID = "3234562"
                };

                r.RecipientLists.Add(recipientList);
                await r.CommitSave();
                var getRecipientListById = await r.GetRecipientListById(recipientList.RecipientListID);
                Assert.NotNull(getRecipientListById);

            }
        }

        [Fact]
        public async void TestGetRecipientLists()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
       .UseInMemoryDatabase(databaseName: "p3MessageService")
       .Options;


            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());

                var recipientList = new RecipientList
                {
                    RecipientListID = Guid.NewGuid(),
                    RecipientID = "3232344562"
                };

                r.RecipientLists.Add(recipientList);
                await r.CommitSave();
                var getRecipientLists = await r.GetRecipientLists();
                Assert.NotNull(getRecipientLists);

            }
        }



    }
}
