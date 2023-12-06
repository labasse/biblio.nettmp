namespace FlatBiblio
{
    public record Emprunteur(string Numero, string Prenom, string Nom, string Ville)
    {
        private readonly IList<Livre> emprunts = new List<Livre>();

        public void Emprunter(Livre l) => emprunts.Add(l);
        
        public IEnumerable<Livre> Livres => emprunts;
    }
}
