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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (H2.GameStateCheck() == GameState.ingame)
            {
                Player P = new Player();
                WeaponBase Wb = new WeaponBase();
                for (int i = 0; i < H2.GetPlayerCount(); i++)
                {
                    P = new Player(H2, i);
                    Wb = P.WeaponOut();
                    if (Wb.WeaponClass != Weapon.None)
                    {
                        Wb.WeaponHeat = -10;
                        Wb.BatteryPower = -10;
                        Wb.AmmoLeft = 9999;
                    }
                }
            }
        }
    }
}
