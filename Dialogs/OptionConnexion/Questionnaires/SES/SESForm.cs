using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System;
using System.Collections;
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

        private List<int> ListeReponsesItems = new List<int>() { };
        public Dictionary<string, int> dictionary = new Dictionary<string, int>();// pour le radar chart 
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Bienvenue dans le SES Quizz Form, afin de mieux faire connaissance, voici 11 questions auxquelles il faudrait que tu répondes, ca ne te prendra que 5 minutes.");
            //this.SESFormQuery(context);
            var SesFormDialog = FormDialog.FromForm(this.BuildSESForm, FormOptions.PromptInStart);
            context.Call(SesFormDialog, this.ResumeAfterSESFormDialog);
        }
               
        
        private IForm<SESQuery> BuildSESForm()
        {
            OnCompletionAsyncDelegate<SESQuery> processResult = async (context, state) =>
                {
                    await context.PostAsync($"Merci d'avoir rempli ce questionnaire voici tes résultats : ");
                    await context.PostAsync("Sexe : "+ state.Sexe);
                    await context.PostAsync("Age : " + state.Age);
                    await context.PostAsync("BarriersOvercoming : " + (int)state.BarriersOvercoming);
                    await context.PostAsync(" MotivationalMaintenance : " + (int)state.MotivationalMaintenance);
                    for (int i = 0; i < 5; i++)
                    {
                        //ListeReponsesItems.Add((int)state.);
                    }
                    ListeReponsesItems.Add((int)state.Dissatisfaction);
                    ListeReponsesItems.Add((int)state.WorkablePlan);
                    ListeReponsesItems.Add((int)state.BarriersOvercoming);
                    ListeReponsesItems.Add((int)state.PositiveCopingStress);
                    ListeReponsesItems.Add((int)state.SupportCaring);
                    ListeReponsesItems.Add((int)state.MotivationalMaintenance);
                    ListeReponsesItems.Add((int)state.SelfCareKnowledgeInformedChoices);
                    ListeReponsesItems.Add((int)state.ChangeCareKnowledge);
                    int total = ListeReponsesItems.Sum(x => Convert.ToInt32(x));
                    await context.PostAsync("Total : "+ total+" Moyenne : " + (double)total/ListeReponsesItems.Count);
                };
            return new FormBuilder<SESQuery>() // mettre la priorité sur des questions : .Field(nameof(...))
                .Field(nameof(SESQuery.Age))
                .Field(nameof(SESQuery.Sexe))
                .Field(nameof(SESQuery.Education))
                .AddRemainingFields()
                .OnCompletion(processResult)
                .Build();
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            await context.PostAsync("Bienvenue dans le questionnaire SES");
        }

        /*public async Task GetChart(IDialogContext context, IAwaitable<IMessageActivity> activity)
        {
            // Some mechanism for retrieving data

            // var data = getData();
            var data = ListeReponsesItems;

         //   var resultFromNewOrder = await activity;
         //   await context.PostAsync($"Inscription dialog just said this {resultFromNewOrder} - Retour sur Root");
         // Call the chart method

            // var chartDataUrl = RadarChart.GetLineChart(data, "Chart Title");

            var message = context.MakeMessage();
            var attachment = new Attachment(contentType: "image/png", contentUrl: null);
            message.Attachments.Add(attachment);

            await context.PostAsync(message);
            context.Wait(this.MessageReceivedAsync);
        }*/
        public async Task ResumeAfterSESFormDialog(IDialogContext context, IAwaitable<SESQuery> result)
        {
            var message = await result;

            context.Done(message.Dissatisfaction);
            //context.Done();

        }


              



    }
}