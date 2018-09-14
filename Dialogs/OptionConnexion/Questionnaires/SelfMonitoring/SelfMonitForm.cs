using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace TrevorBot.Dialogs.OptionConnexion.Questionnaires
{
    [Serializable]
    public class SelfMonitForm : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Bienvenue dans le Self Monitoring Form");
            var SelfFormDialog = FormDialog.FromForm(this.BuildSelfForm, FormOptions.PromptInStart);
            context.Call(SelfFormDialog, this.ResumeAfterSelfFormDialog);

        }

        private IForm<SelfMonitQuery> BuildSelfForm() // là où on peut customiser le FormBuiler avec des Field, des onCompletion ou validate/confirm
        {
            OnCompletionAsyncDelegate<SelfMonitQuery> processResult = async (context, state) =>
            {
                await context.PostAsync(" HEX"+ state.Feeling.ToString());

            };
            return new FormBuilder<SelfMonitQuery>() // mettre la priorité sur des questions : .Field(nameof(...))
                .Field(nameof(SelfMonitQuery.Feeling))
                .AddRemainingFields()
                .OnCompletion(processResult)
                .Build();
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result) //pas utilisée dans ce cas, mais bon ...
        {
            await context.PostAsync("Bienvenue dans le questionnaire SelfMonitoring");
        }

        public async Task ResumeAfterSelfFormDialog(IDialogContext context, IAwaitable<SelfMonitQuery> result) // obligatoire d'avoir une ResumeAfter... (sinon il sait pas quoi faire à la fin du dialogue)
        {
            var message = await result;
            context.Done(message);

          //  context.Done();

        }
    }
}          