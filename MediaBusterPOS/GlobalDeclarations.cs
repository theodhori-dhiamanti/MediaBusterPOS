using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBusterPOS
{
   public static class GlobalDeclarations
    {
        public enum Rating { G, PG, PG13, NC17, R, None }
        public enum MovieCategory { Action_Adventure, Drama, Family_Kids, Horror, SciFi_Fantasy, Music, Sports, Romance, Comedy, Western, None }
        public enum DVDFormat { DVD, HDDVD, BLUERAY_DISC, None }
        public enum GameCategory { Action, Roleplaying, Shooting, Fighting, Racing, Sports, Strategy, Horror, Flight_Simulators, Online, Rhythm, None }
        public enum VideoGameFormat { XBox, XBox360, PS4, PS3, PS2, GameCube, Atari, DS, Wii, PC, None }

    }
}
