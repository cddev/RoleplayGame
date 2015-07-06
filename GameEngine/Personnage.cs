using System;

namespace GameEngine
{
    public abstract class Personnage
    {
        public event EventHandler<AttackEventArgs> Attacking;

        public event EventHandler<AdversaireKilledEventArgs> Killing;

        //public int IdPers { get; private set; }
        public string NomPers { get; set; }

        public int PvPers { get; set; }

        public Arme WpPers { get; set; }

        public bool isDead { get; set; }

        public Personnage()
        {
            //IdPers = setId();
            isDead = false;
            PvPers = 10;
            //WpPers = new Arme();
        }

        public Personnage(string _nom, int _pvPers, Arme _wp)
        {
            //IdPers = setId();
            WpPers = _wp;
            NomPers = _nom;
            PvPers = _pvPers;
        }

        public void Attaque(Personnage p)
        {
            AttackEventArgs attackArgs = new AttackEventArgs(this, p);
            OnAttacking(this, attackArgs);
        }

        protected void OnAttacking(object sender, AttackEventArgs e)
        {
            EventHandler<AttackEventArgs> att = Attacking;
            if (att != null)
            {
                att(this, e);
            }
        }

        public void Killed(Personnage p)
        {
            AdversaireKilledEventArgs killArgs = new AdversaireKilledEventArgs(p);
            OnKilling(this, killArgs);
        }

        protected void OnKilling(object sender, AdversaireKilledEventArgs e)
        {
            EventHandler<AdversaireKilledEventArgs> kill = Killing;
            if (kill != null)
            {
                kill(this, e);
            }
        }

        public int ReceiveDmg(int nbDegat)
        {
            return this.PvPers - nbDegat;
        }

        public int DoAction(int nbPvHealed)
        {
            return this.PvPers + nbPvHealed;
        }

        //public int setId()
        //{
        //    int randomN = 0;
        //    Random rnd = new Random();
        //    for (int ctr = 0; ctr <= 9; ctr++)
        //    {
        //        randomN = rnd.Next(Int32.MinValue, Int32.MaxValue);

        //    }

        //    return randomN;
        //}
        // public override bool Equals(Object obj)
        //{
        //    if (obj == null || !(obj is Personnage))
        //        return false;
        //    else
        //        return IdPers == ((Personnage)obj).IdPers;
        //}
        // public override int GetHashCode()
        //{
        //    return IdPers;
        //}
        public override string ToString()
        {
            string _ret = string.Format("--Type:{0} Nom:{1} PV:{2} {3}", base.ToString(), NomPers, PvPers.ToString(), WpPers.ToString());

            return _ret;
        }
    }
}