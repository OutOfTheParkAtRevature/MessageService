# MessageService
## Description
To run this Service, you must first download and start up User Service and create an account. Once the account is created then you must login if it has not done so automatically. Upon logging in you will be provided with a Bear Token. This Bear Token will be used to make sure you are authorized to use the Messages Service.

Messaging Microservice API.The Message Service API is responsible for creating, replying, and sending new messages for the teams and league. Within the Service,Each team will get a Carpool message group. This group will allow the team members and their parents to have private communication channels to arrange players getting to the games. Users of the Out of the Park application can send individual, group, or league messages to one another. 


## Functionality
    Authorization is needed in order to access messages which the user will get upon logging in.
    Users can send and receive personal messages. A recipention list is created which will hold the Ids of the people or person you want to communicate with.
    Leveraging this conversation ID would allow the application to list all conversations the user is a part of.
    Carpool members will be able to send and receive messages. Each carpool group message will have its own unique identification so no out people will be able to get into the chat.

  
## To-Do List
* This is something that will be implemented in the future

## Links
Repo link
https://github.com/OutOfTheParkAtRevature/MessageService
‘
To run:
Go to the link above.
Where it says “Code” with a little drop arrow next to it.
Press the down arrow and you will see a clipboard icon.
Press the clipboard icon to copy the link for the cloning of the repo.
Find or create a folder to clone repo in. However, before this step you should have git bash installed on your computer.
Open the folder.
Once downloaded you will right click on mouse for windows and ctrl mouse click for Mac OS.
Click the newly installed git bash.
Use the command “git clone <clipboard copy is pasted here>” to download the repo.
Either go into the newly created clone folder or use command “cd <folder name>” to go into the folder.
Open Visudio studio and press open sln. Once done migrate to the folder and click the .sln file to open the project.
Once opened at the top you will press the play button on LLS Express to run the program.

