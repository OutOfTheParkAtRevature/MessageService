using Xunit;

namespace Service.Tests
{
    public class ServiceTest
    {
        [Fact]
        public async void TestGetMessageById()
        {
            var options = new DbContextOptionsBuilder<LeagueContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic logic = new Logic(r, new NullLogger<Repo>());
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
            var options = new DbContextOptionsBuilder<LeagueContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic logic = new Logic(r, new NullLogger<Repo>());
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

                var getMessageById = await logic.GetMessageById(message.SenderID);
                Assert.Equal("Hello this is a text!!", getMessageById.MessageText);

            }
        }


        [Fact]
        public async void TestGetMessages()
        {
            var options = new DbContextOptionsBuilder<LeagueContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic logic = new Logic(r, new NullLogger<Repo>());
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
            var options = new DbContextOptionsBuilder<LeagueContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic logic = new Logic(r, new NullLogger<Repo>());
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
            var options = new DbContextOptionsBuilder<LeagueContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic logic = new Logic(r, new NullLogger<Repo>());
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
        public async void TestBuildRecipientList()
        {
            var options = new DbContextOptionsBuilder<LeagueContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic logic = new Logic(r, new NullLogger<Repo>());
                var recipientList = new RecipientList
                {
                    RecipientListID = Guid.NewGuid(),
                    RecipientID = "56789"
                };

                r.RecipientLists.Add(recipientList);
                await r.CommitSave();

                var buildRecipientList = await logic.BuildRecipientList(recipientList.RecipientListID, recipientList.RecipientID);
                Assert.NotNull(buildRecipientList);

            }
        }

        [Fact]
        public async void TestBuildRecipientList()
        {
            var options = new DbContextOptionsBuilder<LeagueContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic logic = new Logic(r, new NullLogger<Repo>());
                var recipientList = new RecipientList
                {
                    RecipientListID = Guid.NewGuid(),
                    RecipientID = "56789"
                };

                r.RecipientLists.Add(recipientList);
                await r.CommitSave();

                var buildRecipientList = await logic.BuildRecipientList(RecipientList);
                Assert.NotNull(buildRecipientList);

            }
        }

        [Fact]
        public async void TestCreateNewMessage()
        {
            var options = new DbContextOptionsBuilder<LeagueContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic logic = new Logic(r, new NullLogger<Repo>());

                var newMessageDto = new NewMessageDto
                {
                    SenderID = "38675634",
                    RecipientList = List<string>,
                    MessageText = "Hello I am a message"
                }

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
            var options = new DbContextOptionsBuilder<LeagueContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic logic = new Logic(r, new NullLogger<Repo>());

                var newMessageDto = new NewMessageDto
                {
                    SenderID = "2345654",
                    RecipientList = List<string>,
                    MessageText = "Hello I am a message!"
                }

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
                Logic logic = new Logic(r, new NullLogger<Repo>());

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

                var sendCarpool = await logic.SendCarpool(message.RecipientListID);
                Assert.Equal(message.SenderID, carpoolingDto.SenderID);
                Assert.Equal(message.MessageText, carpoolingDto.MessageText);   

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
                Logic logic = new Logic(r, new NullLogger<Repo>());

                var replyDto = new ReplyDto
                {
                    SenderID = "22343445654",
                    RecipientListID = Guid.NewGuid(),
                    MessageText = "Hello I am a message!!!!!"
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

                var sendreply = await logic.SendReply(message.RecipientListID);
                Assert.Equal(message.SenderID, replyDto.SenderID);
                Assert.Equal(message.MessageText, replyDto.MessageText);

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
                Logic logic = new Logic(r, new NullLogger<Repo>());


                var message = new Message
                {
                    MessageID = Guid.NewGuid(),
                    SenderID = "3478273",
                    RecipientListID = Guid.NewGuid(),
                    SentDate = DateTime.Now,
                    MessageText = "Hi I am a test message"
                };

                r.Messages.Add(message);
                await r.CommitSave();

                var sendMessage = await logic.SendMessage(message);
                Assert.NotNull(sendMessage);
               

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
                Logic logic = new Logic(r, new NullLogger<Repo>());


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
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic logic = new Logic(r, new NullLogger<Repo>());


                var userInbox = new UserInbox
                {
                    UserID = "123421",
                    MessageID = Guid.NewGuid(),
                    IsRead = false

                };

                r.UserInboxes.Add(userInbox);
                await r.CommitSave();

                var createUserInbox = await logic.CreateUserInbox(userInbox.UserID, userInbox.MessageID);
                Assert.NotNull(getUserInbox);


            }
        }

        [Fact]
        public async void TestDeleteMessageFromInbox()
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
            .UseInMemoryDatabase(databaseName: "p3MessageService")
            .Options;

            using (var context = new MessageContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic logic = new Logic(r, new NullLogger<Repo>());


                var userInbox = new UserInbox
                {
                    UserID = "123421123",
                    MessageID = Guid.NewGuid(),
                    IsRead = false

                };

                r.UserInboxes.Add(userInbox);
                await r.CommitSave();

                var deleteMessageFromInbox = await logic.DeleteMessageFromInbox(userInbox.UserID, userInbox.MessageID);
                Assert.NotNull(getUserInbox);


            }
        }



    }
}
