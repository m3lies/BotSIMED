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
    public class ConnexionDialog : IDialog<string>
    {
        private const string FacebookOption = "FaceBook";
        private const string MailOption = "Mail";

        public async Task StartAsync(IDialogContext context)
        {


            // Sign in card https://docs.microsoft.com/en-us/azure/bot-service/dotnet/bot-builder-dotnet-add-rich-card-attachments?view=azure-bot-service-3.0 
            PromptDialog.Choice(context, this.InscriptionSelected, new List<string>() { FacebookOption, MailOption }, "Ok ! Dis moi si tu veux te connecter avec FaceBook ou avec une adresse mail", "Ce n'est pas une option valide !", 3);
            // context.Wait(this.MessageReceivedAsync);

        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (message.Text.ToLower().Contains("help") || message.Text.ToLower().Contains("support") || message.Text.ToLower().Contains("problem"))
            {
                //await context.Forward(new SupportDialog(), this.ResumeAfterSupportDialog, message, CancellationToken.None);
            }
            else
            {
                this.ConnexionOptions(context);
            }
        }

        private void ConnexionOptions(IDialogContext context)
        {
            PromptDialog.Choice(context, this.InscriptionSelected, new List<string>() { FacebookOption, MailOption }, "Ok ! Dis moi si tu veux te connecter avec FaceBook ou avec une adresse mail", "Ce n'est pas une option valide !", 3);
        }

        private async Task InscriptionSelected(IDialogContext context, IAwaitable<string> result)
        {

            try
            {
                string optionSelected = await result;
                switch (optionSelected)
                {

                    case FacebookOption:
                        //context.Call(new FacebookAuthDialog(), this.ResumeAfterConnexionDialog);
                        //await context.PostAsync("OKkkkkk FACEBOOK C'est parti !");
                        break;
                    case MailOption:
                       // context.Call(new MailDialog(), this.ResumeAfterConnexionDialog);
                        break;

                }

            }
            catch (TooManyAttemptsException ex)
            {

                await context.PostAsync($"Oh oh... Trop de tentatives, je m'en occupe ! Tu peux réessayer");
                context.Wait(this.MessageReceivedAsync);

            }
        }

        private async Task ResumeAfterConnexionDialog(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var message = await result;
                await context.PostAsync("Merci de t'être connecté :)");

            }
            catch (Exception ex)
            {
                await context.PostAsync($"Failed with message: {ex.Message}");
            }
            finally
            {
                context.Wait(this.MessageReceivedAsync);
            }
        }
    }
}