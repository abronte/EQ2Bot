using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;

namespace EQWaypoint
{
    class EQmemory
    {
        private Process[] processes;
        public Process eqproc = null;
        private int addrbase = 0x400000;

        MemoryLoc pPlayer;
        MemoryLoc pPlocation;

        public EQmemory()
        {
            processes = Process.GetProcessesByName("EverQuest2");
            eqproc = processes[0];

            pPlayer = new MemoryLoc(eqproc, addrbase + 0xFC6CC);
            pPlocation = new MemoryLoc(eqproc, addrbase + 0x165DE0);
        }

        public bool findEQ()
        {
            if (eqproc == null)
            {
                processes = Process.GetProcessesByName("EverQuest2");

                if (processes.Length > 0)
                {
                    eqproc = processes[0];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public int currentHp()
        {
            MemoryLoc cur_hp = new MemoryLoc(eqproc, pPlayer.GetInt32() + 0x88);
            return cur_hp.GetInt32();
        }

        public int maxHp()
        {
            MemoryLoc max_hp = new MemoryLoc(eqproc, pPlayer.GetInt32() + 0x8C);
            return max_hp.GetInt32();
        }

        public float getXPos()
        {
            MemoryLoc cur_xaxis = new MemoryLoc(eqproc, pPlocation.GetInt32() + 0x74);

            return cur_xaxis.GetFloat();
        }

        public float getYPos()
        {
            MemoryLoc cur_yaxis = new MemoryLoc(eqproc, pPlocation.GetInt32() + 0x7C);

            return cur_yaxis.GetFloat();
        }

        public float getZPos()
        {
            MemoryLoc cur_zaxis = new MemoryLoc(eqproc, pPlocation.GetInt32() + 0x78);

            return cur_zaxis.GetFloat();
        }

        public string getWaypointString()
        {
            return getXPos().ToString()+","+getYPos().ToString()+","+getZPos().ToString();
        }

        public float getHeading()
        {
            MemoryLoc heading = new MemoryLoc(eqproc, pPlocation.GetInt32() + 0x8);

            return heading.GetFloat();
        }

    }
}
