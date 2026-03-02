using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    public abstract class Personne

    { public string Nom { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

    
    public Personne(string Nom, string Email, string Contact)
        {
            this.Nom = Nom;
            this.Email = Email;
            this.Contact = Contact;
        }
        public abstract void Afficher();
       
    }
}

