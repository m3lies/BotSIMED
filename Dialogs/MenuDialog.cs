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
    public class MenuDialog : IDialog<string>
    {
        private const string SelfMonitOption = "Remplir le questionnaire de self monitoring";
        private const string SESOption = "Bilan de compétences";
        private const string ResultsOption = "Quelles sont les meilleures pratiques d'auto gestion ?";
        public async Task StartAsync(IDialogContext context)
        {
            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() { SelfMonitOption, SESOption }, "Tout d'abord dis moi ce que tu veux faire", "Cecic n'est pas une option valide", 3);
            context.Wait(MessageReceivedAsync);

        }
        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            await this.MenuMessageAsync(context);
        }

        private async Task MenuMessageAsync(IDialogContext context)
        {
            await context.PostAsync("Bienvenue dans le menu principal! Que veux-tu faire ?");
            this.ShowMenuOption(context);
        }
        private void ShowMenuOption(IDialogContext context)
        {
            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() { SelfMonitOption, SESOption }, "Tout d'abord dis moi ce que tu veux faire", "Cecic n'est pas une option valide", 3);
        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        {

            try
            {
                string optionSelected = await result;
                switch (optionSelected)
                {

                    case SelfMonitOption:
                        context.Call(new SelfMonitForm(), this.ResumeAfterQuestionnaire);

                        //Sign-in card : https://docs.microsoft.com/en-us/azure/bot-service/dotnet/bot-builder-dotnet-add-rich-card-attachments?view=azure-bot-service-3.0
                        break;
                    case SESOption:
                        context.Call(new SESForm(), this.ResumeAfterQuestionnaire);
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
                await context.PostAsync($"Dialog just said this {resultFromNewOrder} - Retour sur Menu");
                context.Wait(this.MessageReceivedAsync);

            }
            catch (TooManyAttemptsException)
            {

                await context.PostAsync("Marche pas ce truc. Essaie autre chose");
            }

        }
    }

}