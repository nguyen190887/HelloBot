using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HelloBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            //return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            //// Calculate something for us to return
            //int length = (activity.Text ?? string.Empty).Length;

            //// Return our reply to the user
            //await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            PromptDialog.Choice(
                context,
                AfterChoiceSelected,
                new[] { "Messi", "Ronaldo" },
                "Who is better player?",
                "I am sorry but I did not understand that"
                );

            //context.Wait(MessageReceivedAsync);
        }

        private async Task AfterChoiceSelected(IDialogContext context, IAwaitable<string> result)
        {
            await context.PostAsync("Thanks for choosing: "+(await result));
            await StartAsync(context);
        }
    }
}