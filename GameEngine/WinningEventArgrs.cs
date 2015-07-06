using System;

namespace GameEngine
{
    public class WinningEventArgrs : EventArgs
    {
        public string wTeam { get; set; }

        public WinningEventArgrs(string _wTeam)
        {
            wTeam = _wTeam;
        }
    }
}