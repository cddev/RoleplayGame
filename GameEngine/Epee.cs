namespace GameEngine
{
    public class Epee : Arme
    {
        public int SizeEpee { get; set; }

        public Epee(string name, int dmgEpee, int sizeEpee) : base(name, dmgEpee)
        {
            base.NomArme = name;
            base.DmgPointArme = dmgEpee;
            this.SizeEpee = sizeEpee;
        }

        public override string ToString()
        {
            return "Epée " + " Nom: " + NomArme + " Dmg: " + DmgPointArme.ToString();
        }
    }
}