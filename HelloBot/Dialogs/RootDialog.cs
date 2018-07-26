using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HelloBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        const string ImageHost = "https://raw.githubusercontent.com/nguyen190887/HelloBot/master/HelloBot/Images/";

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            var reply = context.MakeMessage();

            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            reply.Attachments = GetCardsAttachments(ImageHost);

            await context.PostAsync(reply);

            context.Wait(MessageReceivedAsync);
        }

        #region Message attachments

        private static IList<Attachment> GetCardsAttachments(string imageHost)
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "Messi",
                    "Messi",
                    "I love this guy the most!",
                    new CardImage(url: $"{imageHost}/messi.jpg"),
                    new CardAction(ActionTypes.OpenUrl, "See more", value: "https://www.google.com/search?q=messi")),
                GetThumbnailCard(
                    "Ronaldo",
                    "Ronaldo",
                    "Personally, I hate him!",
                    new CardImage(url: $"{imageHost}/ronaldo.jpg"),
                    new CardAction(ActionTypes.OpenUrl, "See what he did", value: "https://www.google.com/search?q=ronaldo")),
                GetHeroCard(
                    "Mbappe",
                    "Mbappe",
                    "Hmmm, new M10 here!",
                    new CardImage(url: $"{imageHost}/mbappe.jpg"),
                    new CardAction(ActionTypes.OpenUrl, "See him", value: "https://www.google.com/search?q=mbappe")),
                GetThumbnailCard(
                    "Neymar",
                    "Neymar",
                    "He is an actor!",
                    new CardImage(url: $"{imageHost}/neymar.jpg"),
                    new CardAction(ActionTypes.OpenUrl, "See his performance", value: "https://www.google.com/search?q=neymar+acting")),
            };
        }

        private static Attachment GetHeroCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }

        private static Attachment GetThumbnailCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new ThumbnailCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }

        #endregion
    }
}