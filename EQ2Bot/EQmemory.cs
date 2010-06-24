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

        public EQmemory()
        {
            processes = Process.GetProcessesByName("EverQuest2");
            eqproc = processes[0];
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

        public float getXPos()
        {
            MemoryLoc Pxaxis = new MemoryLoc(eqproc, addrbase + 0x782DEC);
            MemoryLoc cur_xaxis = new MemoryLoc(eqproc, Pxaxis.GetInt32());

            return cur_xaxis.GetFloat();
        }

        public float getYPos()
        {
            MemoryLoc Pyaxis = new MemoryLoc(eqproc, addrbase + 0x789600);
            MemoryLoc cur_yaxis = new MemoryLoc(eqproc, Pyaxis.GetInt32());

            return cur_yaxis.GetFloat();
        }

        public float getZPos()
        {
            MemoryLoc Pzaxis = new MemoryLoc(eqproc, addrbase + 0x7453C8);
            MemoryLoc cur_zaxis = new MemoryLoc(eqproc, Pzaxis.GetInt32()+ 0x130);

            return cur_zaxis.GetFloat();
        }

        public string getWaypointString()
        {
            return getXPos().ToString()+","+getYPos().ToString()+","+getZPos().ToString();
        }

        public float getHeading()
        {
            MemoryLoc Pheading = new MemoryLoc(eqproc, addrbase + 0xD5DB0C);
            MemoryLoc h1 = new MemoryLoc(eqproc, Pheading.GetInt32() + 0x778);
            MemoryLoc h2 = new MemoryLoc(eqproc, h1.GetInt32() + 0xF8);
            MemoryLoc h3 = new MemoryLoc(eqproc, h2.GetInt32() + 0xF8);
            MemoryLoc h4 = new MemoryLoc(eqproc, h3.GetInt32() + 0xE4);
            MemoryLoc heading = new MemoryLoc(eqproc, h4.GetInt32() + 0x3E0);

            return heading.GetFloat();
        }

    }
}
