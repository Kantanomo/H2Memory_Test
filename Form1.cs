using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using H2Memory_class;
namespace H2Memory_Tests
{
    public partial class Form1 : Form
    {
        H2Memory H2 = new H2Memory(H2Type.Halo2Vista, true);
        public Form1()
        {
            InitializeComponent();
            //OpCode.PatchChecks(H2);
            //OpCode.PatchRank(H2);
            //OpCode.PatchSpeed(H2);
            //OpCode.PatchAmmo(H2);
            //OpCode.PathGrenades(H2);
            //foreach (int i in DynamicObjTable.GetAllWeapons(H2))
            //{
            //    H2.H2Mem.WriteInt(false, i + 0x22C, 2000);
            //    H2.H2Mem.WriteInt(false, i + 0x22A, 2000);
            //    H2.H2Mem.WriteFloat(false, i + 0x184, 10);
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (H2.GameStateCheck() == GameState.ingame && H2.EngineCheck() == EngineType.Multiplayer)
            {
                foreach(int i in DynamicObjTable.GetWeaponSet(H2, Weapon.flag))
                {
                    float Xtemp = H2.H2Mem.ReadFloat(false, i + 0x88);
                    float Ytemp = H2.H2Mem.ReadFloat(false, i + 0x8C);
                    if (Xtemp != Math.Abs(Xtemp))
                        H2.H2Mem.WriteFloat(false, i + 0x88, Xtemp - 1f);
                    if (Xtemp == Math.Abs(Xtemp))
                        H2.H2Mem.WriteFloat(false, i + 0x88, Xtemp + 1f);
                    if (Ytemp != Math.Abs(Ytemp))
                        H2.H2Mem.WriteFloat(false, i + 0x8C, Ytemp - 1f);
                    if (Ytemp == Math.Abs(Ytemp))
                        H2.H2Mem.WriteFloat(false, i + 0x8C, Ytemp + 1f);
                    H2.H2Mem.WriteFloat(false, i + 0x90, -20);
                }
            }
        }
    }
}
