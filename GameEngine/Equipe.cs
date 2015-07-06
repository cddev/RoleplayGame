using System;
using System.Collections.Generic;

namespace GameEngine
{
    public class Equipe
    {
        public event EventHandler<AdversaireMeetEventArgs> MeetAdversaire;

        public event EventHandler<WinningEventArgrs> TeamWon;

        public string NomEquipe { get; set; }

        //public int PvEquipe { get; set; }
        //public int IdEquipe { get; set; }

        public List<GameEngine.Personnage> LPersonnage { get; set; }

        public Equipe(string _nomEquipe/*, int _pvEquipe*/)
        {
            NomEquipe = _nomEquipe;
            //PvEquipe = _pvEquipe;
        }

        public Equipe()
        {
            LPersonnage = new List<GameEngine.Personnage>();
        }

        public Equipe(string _nom, List<Personnage> _lp)
        {
            NomEquipe = _nom;
            LPersonnage = _lp;
        }

        public override string ToString()
        {
            string _ret = string.Format("Equipe {0} : \n", NomEquipe);

            foreach (Personnage p in LPersonnage)
            {
                _ret += p.ToString() + "\n";
            }

            return _ret;
        }

        public void Rencontre(List<Equipe> _EquipeList, List<Personnage> _PersHeroList, List<Personnage> _PersMonstreList)
        {
            do
            {
                List<Personnage> FullList = new List<Personnage>();
                FullList.AddRange(_PersHeroList);
                FullList.AddRange(_PersMonstreList);

                Personnage p1 = getRandomPers(FullList);
                Personnage p2 = getRandomPers(FullList);

                if (_PersMonstreList.Count == 1)
                {
                    p1 = _PersMonstreList[0];
                }

                if (_PersHeroList.Count == 1)
                {
                    p2 = _PersHeroList[0];
                }

                if (p1 is Hero && p2 is Monstre || p1 is Monstre && p2 is Hero)
                {
                    AdversaireMeetEventArgs AdvMeetArgs = new AdversaireMeetEventArgs(p1, p2);
                    onAdversaireMeet(this, AdvMeetArgs);
                }
            } while (_PersHeroList.Count > 0 && _PersMonstreList.Count > 0);

            if (_PersHeroList.Count == 0)
            {
                WinningEventArgrs tWin = new WinningEventArgrs("Monstres");
                onWinning(this, tWin);
            }
            else
            {
                WinningEventArgrs tWin = new WinningEventArgrs("Héros");
                onWinning(this, tWin);
            }
        }

        public static Personnage getRandomPers(List<Personnage> _FullList)
        {
            int randomN = 0;
            Random rnd = new Random();
            for (int ctr = 0; ctr <= 9; ctr++)
            {
                randomN = rnd.Next(0, _FullList.Count);
            }
            if (randomN != 0)
            {
                return _FullList[randomN - 1];
            }
            else
            {
                return _FullList[randomN];
            }
        }

        public static Personnage chooseRandomAttacker(List<Personnage> _FullList)
        {
            int randomN = 0;
            Random rnd = new Random();
            for (int ctr = 0; ctr <= 9; ctr++)
            {
                randomN = rnd.Next(0, _FullList.Count - 1);
            }
            //if (randomN != 0)
            //{
            //    return _FullList[randomN - 1];
            //}
            //else
            //{
            return _FullList[randomN];
            //}
        }

        protected void onAdversaireMeet(Object sender, AdversaireMeetEventArgs e)
        {
            EventHandler<AdversaireMeetEventArgs> AdvMeet = MeetAdversaire;
            if (AdvMeet != null)
            {
                AdvMeet(this, e);
            }
        }

        protected void onWinning(object sender, WinningEventArgrs e)
        {
            EventHandler<WinningEventArgrs> winT = TeamWon;
            if (winT != null)
            {
                winT(this, e);
            }
        }
    }
}