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
        public async Task StartAsync(IDialogContext context) //ce qui démarre à l'initialisation du dialogue
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result) //attend le message
        {
            var message = await result;
            await this.ConnexionMessageAsync(context); //appelle la connexion 
        }
        private async Task ConnexionMessageAsync(IDialogContext context)
        {
            await context.PostAsync("Bonjour mon nom est Trevor. Je peux t'aider à mieux gérer ta drépanocytose ! ");
            this.ShowMenuOption(context); //appelle le choix de menu, je sais pas pourquoi, mais j'ai essayé de faire sans ces deux étapes sucessives et ca ne marchait plus.
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
                switch (optionSelected) //une fois que l'option a été selectionnée, on ouvre un nouveau dialogue 
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

        private async Task ResumeAfterQuestionnaire(IDialogContext context, IAwaitable<string> result) // obligatoire d'avoir une ResumeAfter... (sinon il sait pas quoi faire à la fin du dialogue)
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