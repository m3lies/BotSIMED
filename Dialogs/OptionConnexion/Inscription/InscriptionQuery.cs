using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrevorBot
{
    [Serializable]
    public class InscriptionQuery

    {
        [Prompt("Ok, écris moi donc ton addresse {&} :")]
        [Pattern(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Mail { get; set; }
        [Prompt("Super, maintenant choisis un {&}")]
        public string MotDePasse { get; set; }

        [Prompt("Confirme-moi ton mot de passe s'il te plaît ")]
        public string ConfirmerMotDePasse { get; set; }

        [Prompt("Choisis un pseudonyme, tu pourras toujours modifier cela plus tard")]
        public string Pseudo { get; set; }

    }
}