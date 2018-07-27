# HelloBot
A bot to demo some basic capabilities of Microsoft Bot Framework

# How to use this sample?
- To show list of [tags/bookmarks](https://github.com/nguyen190887/HelloBot/releases), run
``` bash
git tag --list
```
  
  
- To checkout to desired step, run
```bash
git checkout {tagName}
```
  
  
- Build and enjoy it with the [Bot Emulator](https://github.com/Microsoft/BotFramework-Emulator) :smile:

# To register with Skype
1. Deploy it to a host or cloud service - for example, creating an [Azure API App](https://azure.microsoft.com/en-us/services/app-service/api/)
2. Create a [Bot Channel Registration](https://docs.microsoft.com/en-us/azure/bot-service/bot-service-quickstart-registration?view=azure-bot-service-3.0)
3. [Create a new password](https://docs.microsoft.com/en-us/azure/bot-service/bot-service-quickstart-registration?view=azure-bot-service-3.0#bot-channels-registration-password) for Bot Channel Registration
4. Add `MicrosoftAppId` and `MicrosoftAppPassword` (got from step 3) keys to App Settings of the app created in step 1
5. Create a channel for [Skype](https://docs.microsoft.com/en-us/azure/bot-service/bot-service-channel-connect-skype?view=azure-bot-service-3.0)
6. Grab the URL of Skype bot (e.g. https://join.skype.com/bot/xxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx) and add friend with him :smiley:
