using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TrevorBot.Dialogs.OptionConnexion.DataChart;

namespace TrevorBot.Dialogs
{
    [Serializable]
    public class SESForm : IDialog<string>
    {
        private const string allOkay = "Tout à fait d'accord";
        private const string okay = "D'accord";
        private const string quiteOkay = "Indifférent";
        private const string notOkay = "Pas d'accord";
        private const string notAllOkay = "Pas du tout  d'accord";
        private List<string> SatisfactionOpt = new List<string>() { allOkay, okay, quiteOkay, notOkay, notAllOkay };
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Bienvenue dans le SES Quizz Form");
            //this.SESFormQuery(context);
            var SesFormDialog = FormDialog.FromForm(this.BuildSESForm, FormOptions.PromptInStart);
            context.Call(SesFormDialog, this.ResumeAfterSESFormDialog);
        }
               
        
        private void SESFormQuery(IDialogContext context)
        {
            PromptDialog.Choice(context, null, SatisfactionOpt, "En matière de gestion de la drépanocytose, je pense savoir quels sont les aspects dont je suis insatisfait?", "Cecic n'est pas une option valide", 3);
           //   PromptDialog.Choice(context, null, SatisfactionOpt, "En général, je suis capable de transformer mes objectifs en matière de gestion quotidienne de la drépanocytose en un plan réalisable.", "Cecic n'est pas une option valide", 3);
        }
        
        private IForm<SESQuery> BuildSESForm()
        {
            return new FormBuilder<SESQuery>()
                .AddRemainingFields()
                .Build();
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            await context.PostAsync("Bienvenue dans le questionnaire SES");
        }

        public async Task GetChart(IDialogContext context, IAwaitable<IMessageActivity> activity)
        {
            // Some mechanism for retrieving data

            var data = RadarChart.GetData();

            // Call the chart method

            var chartDataUrl = RadarChart.GetLineChart(data, "Chart Title");

            var message = context.MakeMessage();
            var attachment = new Attachment(contentType: "image/png", contentUrl: null);
            message.Attachments.Add(attachment);

            await context.PostAsync(message);
            context.Wait(this.MessageReceivedAsync);
        }
        public async Task ResumeAfterSESFormDialog(IDialogContext context, IAwaitable<SESQuery> result)
        {
            await context.PostAsync("Merci d'avoir rempli ce questionnaire voici tes résultats");
           //                   context.Done(this.SESFormQuery);

        }



        



    }
}