using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TrevorBot.Dialogs
{
    [Serializable]
    public class MailDialog : IDialog<object> //Connexion lorsqu'un mail est choisi
    {

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Ok ! Ecris moi donc ton adresse mail");
            //var accountForm = FormDialog.FromForm(this.);
            context.Wait(this.MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            if (message.Text != null)
            {
                await context.PostAsync("Retour au FirstDialog");
                context.Done(message.Text);
            }
        }

        public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument) 
        {
            var confirm = await argument;
            if (confirm)
            {

                await context.PostAsync("Reset count.");
            }
            else
            {
                await context.PostAsync("Did not reset count.");
            }
            context.Wait(MessageReceivedAsync);
        }

    }
}