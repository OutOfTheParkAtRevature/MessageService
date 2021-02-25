using MessageService.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Model.DataTransfer;
using Models;
using Models.DataTransfer;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace MessageService.Tests
{
    public class MessageControllerTest
    {
        [Fact]
        public async void TestForGetMessages()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3LeagueService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());
                MessageController messageController = new MessageController(logic, null);


                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = "12234345",
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.Now,
                    MessageText = "Hello this is a text!"
                };

                r.Messages.Add(message);
                await r.CommitSave();


                var getMessages = await messageController.GetMessages();
                Assert.NotNull(getMessages);
            }
        }

        [Fact]
        public async void TestForGetMessage()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3LeagueService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());
                MessageController messageController = new MessageController(logic, null);

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


                var getMessages = await messageController.GetMessage(message.MessageID);
                Assert.NotNull(getMessages);
            }
        }

        [Fact]
        public async void TestGetMessagesBySenderById()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3LeagueService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());
                MessageController messageController = new MessageController(logic, null);

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


                var getMessagesBySenderById = await messageController.GetMessagesBySenderById(message.SenderID);
                Assert.NotNull(getMessagesBySenderById);
            }
        }


        [Fact]
        public async void TestSendNewMessage()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3LeagueService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Mapper map = new Mapper();
                Logic logic = new Logic(r, map, new NullLogger<Repo>());
                MessageController messageController = new MessageController(logic, null);

                var newMessageDto = new NewMessageDto
                {
                    SenderID = "12343214",
                    RecipientList = new List<string>(),
                    MessageText = "Hi I am a message test!"
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


                var sendNewMessage = await messageController.SendNewMessage(newMessageDto);
                Assert.NotNull(sendNewMessage);
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
                MessageController messageController = new MessageController(logic, null);

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

                var sendCarpool = await messageController.SendCarpool(carpoolingDto);
                Assert.NotNull(sendCarpool);

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
                MessageController messageController = new MessageController(logic, null);

                var replyDto = new ReplyDto
                {
                    SenderID = "223435654",
                    RecipientListID = Guid.NewGuid(),
                    MessageText = "Hello I am a message?"
                };

                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = replyDto.SenderID,
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.Now,
                    MessageText =replyDto.MessageText
                };

                r.Messages.Add(message);
                await r.CommitSave();

                var sendReply = await messageController.SendReply(replyDto);
                Assert.NotNull(sendReply);

            }
        }

        [Fact]
        public async void TestCreateRecipientList()
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
                MessageController messageController = new MessageController(logic, null);

                var createCarpoolDto = new CreateCarpoolDto
                {
                    CarpoolID = Guid.NewGuid(),
                    UserID = "34543235"

                };

                var recipientList = new RecipientList
                {
                    RecipientListID = Guid.NewGuid(),
                    RecipientID = "342134"
                };


                r.RecipientLists.Add(recipientList);
                await r.CommitSave();

                var createRecipientList = await messageController.CreateRecipientList(createCarpoolDto);
                Assert.NotNull(createRecipientList);

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
                MessageController messageController = new MessageController(logic, null);


                var recipientList = new RecipientList
                {
                    RecipientListID = Guid.NewGuid(),
                    RecipientID = "34223134"
                };


                r.RecipientLists.Add(recipientList);
                await r.CommitSave();

                var getRecipientLists = await messageController.GetRecipientLists();
                Assert.NotNull(getRecipientLists);

            }
        }

        [Fact]
        public async void TestGetRecipientList()
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
                MessageController messageController = new MessageController(logic, null);


                var recipientList = new RecipientList
                {
                    RecipientListID = Guid.NewGuid(),
                    RecipientID = "625325433"
                };


                r.RecipientLists.Add(recipientList);
                await r.CommitSave();

                var getRecipientList = await messageController.GetRecipientList(recipientList.RecipientListID);
                Assert.NotNull(getRecipientList);

            }
        }

        [Fact]
        public async void TestGetUserInboxes()
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
                MessageController messageController = new MessageController(logic, null);


                var userInbox = new UserInbox
                {
                    UserID = "23654345",
                    MessageID = Guid.NewGuid(),
                    IsRead = false
                };


                r.UserInboxes.Add(userInbox);
                await r.CommitSave();

                var getUserInboxes = await messageController.GetUserInboxes(userInbox.UserID);
                Assert.NotNull(getUserInboxes);

            }
        }

    }
}
