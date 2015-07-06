namespace GameEngine
{
    public class Gourdin : Arme
    {
        public int weightGourdin { get; set; }

        public Gourdin(string name, int dmg, int weight) : base(name, dmg)
        {
            base.NomArme = name;
            base.DmgPointArme = dmg;
            this.weightGourdin = weight;
        }

        public override string ToString()
        {
            return "Gourdin " + " Nom: " + NomArme + " Dmg: " + DmgPointArme.ToString();
        }
    }
}