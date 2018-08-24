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

        public Dictionary<string, int> dictionary = new Dictionary<string, int>();
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Bienvenue dans le SES Quizz Form, afin de mieux faire connaissance, voici 11 questions auxquelles il faudrait que tu répondes, ca ne te prendra que 5 minutes.");
            //this.SESFormQuery(context);
            var SesFormDialog = FormDialog.FromForm(this.BuildSESForm, FormOptions.PromptInStart);
            context.Call(SesFormDialog, this.ResumeAfterSESFormDialog);
        }
               
        
        private IForm<SESQuery> BuildSESForm()
        {
            return new FormBuilder<SESQuery>()
                .Field(nameof(SESQuery.Age))
                .Field(nameof(SESQuery.Sexe))
                .Field(nameof(SESQuery.Education))
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

            // var data = getData();
            var data = new int[] {1,15,20};

         //   var resultFromNewOrder = await activity;
         //   await context.PostAsync($"Inscription dialog just said this {resultFromNewOrder} - Retour sur Root");
            // Call the chart method

           // var chartDataUrl = RadarChart.GetLineChart(data, "Chart Title");

            var message = context.MakeMessage();
            var attachment = new Attachment(contentType: "image/png", contentUrl: null);
            message.Attachments.Add(attachment);

            await context.PostAsync(message);
            context.Wait(this.MessageReceivedAsync);
        }
        public async Task ResumeAfterSESFormDialog(IDialogContext context, IAwaitable<SESQuery> result)
        {
            var message = await result;
            await context.PostAsync("Merci d'avoir rempli ce questionnaire voici tes résultats");
           context.Done(message.Sexe);

        }


              



    }
}