// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Data.SQLite;
using System.IO;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {

            var name = turnContext.Activity.From.Name;
            var replyText = $"Hi, " + name;
            string[] commands = {
            "SELECT", "UPDATE", "CREATE TABLE", "INSERT INTO", "DROP TABLE"
            };

            switch(turnContext.Activity.Text)
            {
                case "/start":
                    await turnContext.SendActivityAsync(MessageFactory.Text("Glad to see you"), cancellationToken);
                    break;
                case "/hello":
                    await turnContext.SendActivityAsync(MessageFactory.Text(replyText), cancellationToken);
                    break;
                case "/theory":
                    await turnContext.SendActivityAsync(MessageFactory.Carousel(new Attachment[]
                    {
                        new HeroCard(title: "CHOOSE COMMAND YOU WANT TO FIND OUT ABOUT", buttons:
                            new CardAction[]
                            {
                                new CardAction(title: commands[0], type : ActionTypes.ImBack, value: commands[0]),
                                new CardAction(title: commands[1], type: ActionTypes.ImBack, value: commands[1]),
                                new CardAction(title: commands[2], type : ActionTypes.ImBack, value: commands[2]),
                                new CardAction(title: commands[3], type: ActionTypes.ImBack, value: commands[3]),
                            }).ToAttachment()
                    }));
                    break;    
                case "SELECT":
                    await turnContext.SendActivityAsync(MessageFactory.Text(commands[0] + " ..."), cancellationToken);
                    break;
                case "UPDATE":
                    await turnContext.SendActivityAsync(MessageFactory.Text(commands[1] + " ..."), cancellationToken);
                    break;
                case "CREATE TABLE":
                    await turnContext.SendActivityAsync(MessageFactory.Text(commands[2] + " ..."), cancellationToken);
                    break;
                case "INSERT INTO":
                    await turnContext.SendActivityAsync(MessageFactory.Text(commands[3] + " ..."), cancellationToken);
                    break;
                case "DB":
                    if (!File.Exists(@"Bots/MY_DATABASE.db"))
                    {
                        SQLiteConnection.CreateFile(@"Bots/MY_DATABASE.db");
                        await turnContext.SendActivityAsync(MessageFactory.Text("DATABASE WAS CREATED"), cancellationToken);
                    }
                    else
                    {
                        await turnContext.SendActivityAsync(MessageFactory.Text("DATABASE EXISTS"), cancellationToken);
                    }
                    break;
            }
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello and welcome!";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
