using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using HelloBot.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

namespace HelloBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        internal static IDialog<CodeBuilder> MakeCodeBuidlerDialog()
        {
            return Chain.From(() => FormDialog.FromForm(CodeBuilder.BuildForm))
                .Do(async (context, order) =>
                {
                    try
                    {
                        var completed = await order;

                        await context.PostAsync(
                            $"Okay, thanks for the choice! I'm building '{completed.Branch}' to server '{completed.Server}' ...");

                        if (completed.NotifySlack == NotifySlack.Yes)
                        {
                            Thread.Sleep(1000);
                            await context.PostAsync("  and be patient, will NOTIFY you via Slack ...");

                            Thread.Sleep(2000);
                            await context.PostAsync("... hmmm, but I'm not sure how long it would take :(");
                        }
                    }
                    catch (FormCanceledException<CodeBuilder> e)
                    {
                        string reply;
                        if (e.InnerException == null)
                        {
                            reply = $"You quit on {e.Last} -- maybe you can finish next time!";
                        }
                        else
                        {
                            reply = "Sorry, there are some problems in my room. Please try again.";
                        }
                        await context.PostAsync(reply);
                    }
                });
        }

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.GetActivityType() == ActivityTypes.Message)
            {
                //await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
                await Conversation.SendAsync(activity, MakeCodeBuidlerDialog);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            string messageType = message.GetActivityType();
            if (messageType == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (messageType == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (messageType == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (messageType == ActivityTypes.Typing)
            {
                // Handle knowing that the user is typing
            }
            else if (messageType == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}