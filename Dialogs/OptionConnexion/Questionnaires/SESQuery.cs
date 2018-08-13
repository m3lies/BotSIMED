﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace TrevorBot
{

    [Serializable]
    public class SESQuery
    {
        private const string allOkay = "Tout à fait d'accord";
        private const string okay = "D'accord";
        private const string quiteOkay = "Indifférent";
        private const string notOkay = "Pas d'accord";
        private const string notAllOkay = "Pas du tout  d'accord";
        public enum SatisfactionOption { [DescriptionAttribute("Tout à fait d'accord")] ToutÁFaitDAccord, DAccord, Indifférent, PasDAccord, PasDuToutDAccord };
        public enum SexeOption { Masculin, Féminin, Autre }
        public List<string> SatisfactionOpt = new List<string>() { allOkay, okay, quiteOkay, notOkay, notAllOkay };
        
        /*
        private void SESFormQuery (IDialogContext context) {
            PromptDialog.Choice(context, null, SatisfactionOpt, "En matière de gestion de la drépanocytose, je pense savoir quels sont les aspects dont je suis insatisfait?", "Cecic n'est pas une option valide", 3);
        }*/
        [Prompt("Quel âge as-tu ?")]
        public string Age { get; set; }
        [Prompt("De quel sexe es tu ? {||}")]
        public SexeOption? Sexe;

        [Prompt("Quel est le plus haut niveau d'éducation que tu aies achevé?")]
        public string Education { get; set; }

        //private async Task AskQuestionAsync(IDialogContext context) { PromptDialog.Choice(context, null, SatisfactionOpt, "Tout d'abord dis moi ce que tu veux faire", "Cecic n'est pas une option valide", 3);  }

        

        [Prompt("En matière de gestion de la drépanocytose, je pense savoir quels sont les aspects dont je suis insatisfait? {||}")]
        public  SatisfactionOption ? Dissatisfaction;

        [Prompt("En général, je suis capable de transformer mes objectifs en matière de gestion quotidienne de la drépanocytose en un plan réalisable.")]
        public SatisfactionOption? WorkablePlan;

        [Prompt("En général, je pense pouvoir essayer différentes manières pour surmonter les obstacles qui entravent l'atteinte de mes objectifs en matière de gestion de la drépanocytose")]
        public SatisfactionOption? BarriersOvercoming;

        [Prompt("En général, je pense connaître les moyens positifs que j'utilise pour faire face au stress que provoque la drépanocytose")]
        public SatisfactionOption? PositiveCopingStress;

        [Prompt("Lorsque j'en ai besoin, je pense pouvoir demander du soutien pour vivre avec et prendre soin de ma drépanocytose")]
        public SatisfactionOption? SupportCaring;
        [Prompt("En général, je sais ce qui m'aide à rester motiver pour prendre soin de ma drépanocytose")]
        public SatisfactionOption? MotivationalMaintenance;

        [Prompt("En général, j'en sais suffisamment sur la drépanocytose pour choisir ce qui est bon pour moi")]
        public SatisfactionOption? SelfCareKnowledgeInformedChoices;

        [Prompt("En général, je suis capable de comprendre si cela vaut la peine de changer ma façon de prendre soin de ma drépanocytose")]
        public SatisfactionOption? ChangeCareKnowledge;
    }

}