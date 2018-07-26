using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloBot.Dialogs
{
    public enum Server
    {
        Test01, Test02, Test03, Test04
    }

    public enum Branch
    {
        Dev, Automation, Staging, Production
    }

    public enum NotifySlack
    {
        Yes, No
    }


    [Serializable]
    public class CodeBuilder
    {
        public Server? Server { get; set; }
        public Branch? Branch { get; set; }
        public NotifySlack? NotifySlack { get; set; }

        public static IForm<CodeBuilder> BuildForm()
        {
            return new FormBuilder<CodeBuilder>()
                .Message("Welcome to the Code Builder bot!")
                .Build();
        }
    }
}