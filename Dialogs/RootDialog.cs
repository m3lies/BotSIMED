using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TrevorBot.Dialogs.OptionConnexion.Questionnaires;

namespace TrevorBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {

        private const string ConnexionOption = "Me connecter";
        private const string InscriptionOption = "M'inscrire";
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            await this.ConnexionMessageAsync(context);
        }
        private async Task ConnexionMessageAsync(IDialogContext context)
        {
            await context.PostAsync("Bonjour mon nom est Trevor. Je peux t'aider à mieux gérer ta drépanocytose ! ");
            this.ShowMenuOption(context);
        }

        private void ShowMenuOption(IDialogContext context)
        {
            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() { ConnexionOption, InscriptionOption }, "Tout d'abord dis moi ce que tu veux faire", "Cecic n'est pas une option valide", 3);
        }
        private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        {

            try
            {
                string optionSelected = await result;
                switch (optionSelected)
                {

                    case ConnexionOption:
                        context.Call(new ConnexionDialog(), this.ResumeAfterQuestionnaire);

                        //Sign-in card : https://docs.microsoft.com/en-us/azure/bot-service/dotnet/bot-builder-dotnet-add-rich-card-attachments?view=azure-bot-service-3.0
                        break;
                    case InscriptionOption:
                        context.Call(new InscriptionDialog(), this.ResumeAfterQuestionnaire);
                        break;
                }

            }
            catch (TooManyAttemptsException ex)
            {

                await context.PostAsync($"Oh oh... Trop de tentatives, je m'en occupe ! Tu peux réessayer");
                context.Wait(this.MessageReceivedAsync);

            }
        }

        private async Task ResumeAfterQuestionnaire(IDialogContext context, IAwaitable<string> result)
        {

            try
            {
                var name = await result;
                var resultFromNewOrder = await result;
                await context.PostAsync($"Inscription dialog just said this {resultFromNewOrder} - Retour sur Root");
                context.Wait(this.MessageReceivedAsync);

            }
            catch (TooManyAttemptsException)
            {

                await context.PostAsync("Marche pas ce truc. Essaie autre chose");
            }

        }
    }
}