using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Models;
using Models.DataTransfer;
using Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace Service.Tests
{
    public class ServiceTest
    {
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
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());


                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = "12345",
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.Now,
                    MessageText = "Hello this is a text!"
                };

                r.Messages.Add(message);
                await r.CommitSave();

                var getMessageById = await logic.GetMessageById(message.MessageID);
                Assert.Equal("12345", getMessageById.SenderID);
                Assert.Equal("Hello this is a text!", getMessageById.MessageText);
                
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
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());
                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = "12345",
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.Now,
                    MessageText = "Hello this is a text!!"
                };

                r.Messages.Add(message);
                await r.CommitSave();

                var getMessageById = await logic.GetMessagesBySenderById(message.SenderID);
                Assert.NotNull(getMessageById);

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
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());
                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = "12345",
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.Now,
                    MessageText = "Hello this is a text!!!"
                };

                r.Messages.Add(message);
                await r.CommitSave();

                var getMessageById = await logic.GetMessages();
                Assert.NotNull(getMessageById);

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
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());
                var recipientList = new RecipientList
                {
                    RecipientListID = Guid.NewGuid(),
                    RecipientID = "56789"
                };

                r.RecipientLists.Add(recipientList);
                await r.CommitSave();

                var getRecipientListById = await logic.GetRecipientListById(recipientList.RecipientListID);
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
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());
                var recipientList = new RecipientList
                {
                    RecipientListID = Guid.NewGuid(),
                    RecipientID = "56789"
                };

                r.RecipientLists.Add(recipientList);
                await r.CommitSave();

                var getRecipientLists = await logic.GetRecipientLists();
                Assert.NotNull(getRecipientLists);

            }
        }

        [Fact]
        public async void TestBuildRecipientLists()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());
                var recipientList = new RecipientList
                {
                    RecipientListID = Guid.NewGuid(),
                    RecipientID = "56789"
                };


                var buildRecipientLists = await logic.BuildRecipientList(recipientList.RecipientListID, recipientList.RecipientID);
                Assert.NotNull(buildRecipientLists);

            }
        }

        [Fact]
        public async void TestBuildRecipientList()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());
                var recipientList = new RecipientList
                {
                    RecipientListID = Guid.NewGuid(),
                    RecipientID = "56789"
                };

           

                var buildRecipientList = await logic.BuildRecipientList(recipientList);
                Assert.NotNull(buildRecipientList);

            }
        }

        [Fact]
        public async void TestCreateNewMessage()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());

                var newMessageDto = new NewMessageDto
                {
                    SenderID = "38675634",
                    RecipientList = new List<string>(),
                    MessageText = "Hello I am a message"
                };

                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = newMessageDto.SenderID,
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.Now,
                    MessageText = newMessageDto.MessageText
                };

                r.Messages.Add(message);
                await r.CommitSave();

                var createNewMessage = await logic.CreateNewMessage(newMessageDto);
                Assert.Equal(message.MessageText, newMessageDto.MessageText);
                Assert.Equal(message.SenderID, newMessageDto.SenderID);


            }
        }


        [Fact]
        public async void TestGetMessagePool()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());

                var newMessageDto = new NewMessageDto
                {
                    SenderID = "2345654",
                    RecipientList = new List<string>(),
                    MessageText = "Hello I am a message!"
                };

                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = newMessageDto.SenderID,
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.Now,
                    MessageText = newMessageDto.MessageText
                };

                r.Messages.Add(message);
                await r.CommitSave();

                var getMessagePool = await logic.GetMessagePool(message.RecipientListID);
                Assert.NotNull(getMessagePool);


            }
        }

        [Fact]
        public async void TestSendCarpool()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());

                var carpoolingDto = new CarpoolingDto
                {
                    SenderID = "23423435654",
                    CarpoolListID = Guid.NewGuid(),
                    MessageText = "Hello I am a message!!!!"
                };

                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = carpoolingDto.SenderID,
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.Now,
                    MessageText = carpoolingDto.MessageText
                };

                r.Messages.Add(message);
                await r.CommitSave();

                var sendCarpool = await logic.SendCarpool(carpoolingDto);
                Assert.Equal(message.SenderID, carpoolingDto.SenderID);
                Assert.Equal(message.MessageText, carpoolingDto.MessageText);   

            }
        }

        [Fact]
        public async void TestSendMessage()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());

             

                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = "123422223",
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.Now,
                    MessageText = "I am a test!!"
                };


                var sendMessage = await logic.SendMessage(message);
                Assert.NotNull(sendMessage);

            }
        }

        [Fact]
        public async void TestSendReply()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());

                var replyDto = new ReplyDto
                {
                    SenderID = "22343445654",
                    RecipientListID = Guid.NewGuid(),
                    MessageText = "Hello I am a message!!!!!"
                };

                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = replyDto.SenderID,
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.Now,
                    MessageText = replyDto.MessageText
                };

                r.Messages.Add(message);
                await r.CommitSave();

                var sendreply = await logic.SendReply(replyDto);
                Assert.Equal(message.SenderID, replyDto.SenderID);
                Assert.Equal(message.MessageText, replyDto.MessageText);

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
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());


                var userInbox = new UserInbox
                {
                    UserID = "123421",
                    MessageID = Guid.NewGuid(),
                    IsRead = false

                };

                r.UserInboxes.Add(userInbox);
                await r.CommitSave();

                var getUserInbox = await logic.GetUserInbox(userInbox.UserID);
                Assert.NotNull(getUserInbox);


            }
        }

        [Fact]
        public async void TestCreateUserInbox()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3Message2Service")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());


                var userInbox2 = new UserInbox
                {
                    UserID = "2342328666",
                    MessageID = Guid.NewGuid(),
                    IsRead = false

                };


                var createUserInbox = await logic.CreateUserInbox(userInbox2.UserID, userInbox2.MessageID);
                Assert.NotNull(createUserInbox);


            }
        }


    }
}
