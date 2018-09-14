using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrevorBot.Dialogs.OptionConnexion.Questionnaires
{
    [Serializable]
    public class SelfMonitQuery
    {

        public enum SatisfactionOption
        {
            [Describe("Tout à fait d'accord")]
            [Terms("Tout à fait d'accord")]
            AllOKay = 1,
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
            PasDaccordDutout = 5,
        };

        
        public enum ConsumptionOption
        {
            [Describe("Compléments nutritionnels ou vitamines (ex: B12, D, probiotiques, C, A, propolis, ...)")]
            //[Terms("Tout à fait d'accord")]
            ComplementsNutrionnels = 1,
            [Describe("Médicaments de routine (ex: acide folique, aspirine cardio, ...)")]
            //[Terms("D'accord")]
            MedocRoutine = 2,
            [Describe("Médicaments en prophylaxie(ex: penicillin contre le pneumocoque, médicament anti-paludisme)")]
            [Terms("Indifférent")]
            MedocProphylaxie = 3,
            [Describe("Médecine traditionnelle ou remèdes à base de plantes")]
            [Terms("Pas d'accord")]
            MedcineTradi = 4,
            [Describe("Une douche, un bain chaud")]
            [Terms("Pas du tout d'accord")]
            DoucheOuBain = 5,
        };

        [Pattern ("^10|[0-9]$")]
        [Prompt("Sur une note de 0 à 10, 10 étant la meilleure note, comment te sens-tu maintenant ?")]
        public string Feeling { get; set; }

        /* [Prompt("Quelle quantité d'eau (ou autre) as-tu bu aujourd'hui ?")]
        public string QteEau { get; set; } 

        [Prompt("As-tu bu au moins 4 litres d'eau [hommes] ou 3 litres [de femmes] à intervalles réguliers?")] // Mettre un int seulement
        public Boolean EauSuffisante { get; set; }


        [Prompt("Est-ce que tu ressens une douleur ?")]
        public Boolean Douleur { get; set; }

        [Prompt("A quel point est-ce supportable?")]
        public int NbDouleur { get; set; }

        [Prompt("As-tu pris une des choses suivantes aujourd'hui ?")] 
       // public ConsumptionOption? ConsumedItems; 
        //Compléments nutritionnels ou vitamines (ex: B12, D, probiotiques, C, A, propolis, ...)
        //Médicaments de routine (ex: acide folique, aspirine cardio, ...)
        //Médicaments en prophylaxie(ex: penicillin contre le pneumocoque, médicament anti-paludisme)
        //Médecine traditionnelle ou remèdes à base de plantes
        //Une douche, un bain chaud

        public Boolean BoucheSeche { get; set; } */

           
    }
}   