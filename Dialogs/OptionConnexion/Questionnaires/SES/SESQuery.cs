﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace TrevorBot
{

    [Serializable]
    public class SESQuery
    {   /*
        private const string allOkay = "Tout à fait d'accord";
        private const string okay = "D'accord";
        private const string quiteOkay = "Indifférent";
        private const string notOkay = "Pas d'accord";
        private const string notAllOkay = "Pas du tout  d'accord"; */

        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        [Prompt("1. Quel âge as-tu ?")]
        [Pattern("([1-9]|[1-8][0-9]|9[0-9]|1[01][0-9]|120)")]
        public string Age { get; set; }

        public enum SexeOption { Masculin, Féminin, Autre }
        [Prompt("2. De quel sexe es tu ? {||}")]
        public SexeOption? Sexe;

        [Prompt("3. Quel est le plus haut niveau d'éducation que tu aies achevé?")] // NE PAS OUBLIER
        public string Education { get; set; }

                              
        //Mettre Describe pour le format dans le choix, et terms pour les seules valeurs acceptées 
        public enum SatisfactionOption {
            [Describe("Tout à fait d'accord")]
            [Terms("Tout à fait d'accord")]
            AllOKay =1 ,
            [Describe("D'accord")]
            [Terms("D'accord")]
            Daccord = 2,
            [Describe("Indifférent")]
            [Terms("Indifférent")]
            Indifferent = 3,
            [Describe("Pas d'accord")]
            [Terms("Pas d'accord")]
            PasDAccord = 4,
            [Describe("Pas du tout d'accord")]
            [Terms("Pas du tout d'accord")]
            PasDaccordDutout =5,
        };

        //public List<string> SatisfactionOpt = new List<string>() { allOkay, okay, quiteOkay, notOkay, notAllOkay };
        
        /*
        private void SESFormQuery (IDialogContext context) {
            PromptDialog.Choice(context, null, SatisfactionOpt, "En matière de gestion de la drépanocytose, je pense savoir quels sont les aspects dont je suis insatisfait?", "Cecic n'est pas une option valide", 3);
        }*/


        //private async Task AskQuestionAsync(IDialogContext context) { PromptDialog.Choice(context, null, SatisfactionOpt, "Tout d'abord dis moi ce que tu veux faire", "Cecic n'est pas une option valide", 3);  }

        [Prompt("4. En matière de gestion de la drépanocytose, je pense savoir quels sont les aspects dont je suis insatisfait? {||}")]
        public  SatisfactionOption ? Dissatisfaction;

        [Prompt("5. En général, je suis capable de transformer mes objectifs en matière de gestion quotidienne de la drépanocytose en un plan réalisable. {||}")]
        public SatisfactionOption? WorkablePlan;

        [Prompt("6. En général, je pense pouvoir essayer différentes manières pour surmonter les obstacles qui entravent l'atteinte de mes objectifs en matière de gestion de la drépanocytose {||}")]
        public SatisfactionOption? BarriersOvercoming;

        [Prompt("7. En général, je pense connaître les moyens positifs que j'utilise pour faire face au stress que provoque la drépanocytose {||}")]
        public SatisfactionOption? PositiveCopingStress;

        [Prompt("8. Lorsque j'en ai besoin, je pense pouvoir demander du soutien pour vivre avec et prendre soin de ma drépanocytose {||}")]
        public SatisfactionOption? SupportCaring;
        [Prompt("9.En général, je sais ce qui m'aide à rester motiver pour prendre soin de ma drépanocytose {||}")]
        public SatisfactionOption? MotivationalMaintenance;

        [Prompt("10.En général, j'en sais suffisamment sur la drépanocytose pour choisir ce qui est bon pour moi {||}")]
        public SatisfactionOption? SelfCareKnowledgeInformedChoices;

        [Prompt("11.En général, je suis capable de comprendre si cela vaut la peine de changer ma façon de prendre soin de ma drépanocytose {||}")]
        public SatisfactionOption? ChangeCareKnowledge;
    }

}