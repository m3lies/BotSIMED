using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrevorBot.Dialogs.OptionConnexion.Questionnaires
{
    [Serializable]
    public class SelfMonitoringQuery
    {

        private const string allOkay = "Tout à fait d'accord";
        private const string okay = "D'accord";
        private const string quiteOkay = "Indifférent";
        private const string notOkay = "Pas d'accord";
        private const string notAllOkay = "Pas du tout  d'accord";
        public enum SatisfactionOption { ToutÁFaitDAccord, DAccord, Indifférent, PasDAccord, PasDuToutDAccord };
        public enum SexeOption { Masculin, Féminin, Autre };
        public List<string> SatisfactionOpt = new List<string>() { allOkay, okay, quiteOkay, notOkay, notAllOkay };

        [Prompt("Comment te sens-tu maintenant ?")]
        public string Feeling { get; set; }

        [Prompt("Quelle quantité d'eau (ou autre) as-tu bu aujourd'hui ?")]
        public string QteEau { get; set; } 

        [Prompt("As-tu bu au moins 4 litres d'eau [hommes] ou 3 litres [de femmes] à intervalles réguliers?")]
        public Boolean EauSuffisante { get; set; }


        [Prompt("Est-ce que tu ressens une douleur ?")]
        public Boolean YeuxJaunes { get; set; }

        [Prompt("As-tu pris une des choses suivantes aujourd'hui ?")]
        //Compléments nutritionnels ou vitamines (ex: B12, D, probiotiques, C, A, propolis, ...)
        //Médicaments de routine (ex: acide folique, aspirine cardio, ...)
        //Médicaments en prophylaxie(ex: penicillin contre le pneumocoque, médicament anti-paludisme)
        //Médecine traditionnelle ou remèdes à base de plantes
        //Une douche, un bain chaud

        public Boolean BoucheSeche { get; set; }

           
    }
}   