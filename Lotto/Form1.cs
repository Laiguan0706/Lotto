using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void SetLot(ref int[] choose,int min,int max,int num)
        {
            int[] lot = new int[50];
            int max_dim, choice;
            int i, j;
            max_dim = max - min + 1;
            for(i=0;i<max_dim;i++)
            {
                lot[i] = min + i;
            }
            Random rndobj = new Random();
            for(i=0;i<num;i++)
            {
                choice = rndobj.Next(0, max_dim);
                choose[i] = lot[choice];
                for(j=choice;j<max_dim;j++)
                {
                    lot[j] = lot[j + i];
                }
                max_dim--;

            }
        }
        int [] pcLot= new int[6];

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
            checkedListBox1.MultiColumn = true;
            checkedListBox1.ColumnWidth = 45;
            for(int i =1;i<=49;i++)
            {
                checkedListBox1.Items.Add(i.ToString());
            }
            textBox1.Text = "本期未開獎...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            for(int i=0;i<checkedListBox1.Items.Count;i++)
            {
                if(checkedListBox1.GetItemChecked(i))
                {
                    count++;
                }
            }
            if(count!=6)
            {
                MessageBox.Show("請選擇6個號碼!");
                return;
            }
            SetLot(ref pcLot, 1, 49, pcLot.Length);
            Array.Sort(pcLot);
            string myNumStr = "", pcNumStr = " ";
            for(int i=0;i<=pcLot.GetUpperBound(0);i++)
            {
                pcNumStr += pcLot[i].ToString() + ",";

            }
            for(int i =0;i<checkedListBox1.Items.Count;i++)
            {
                if(checkedListBox1.GetItemChecked(i))
                {
                    myNumStr += checkedListBox1.Items[i].ToString() + ",";
                }    
            }
            textBox1.Text = "本期大樂透號碼如下 : \n" + pcNumStr + "\n";
            if(pcNumStr == myNumStr)
            {
                textBox1.Text += "恭喜你中大獎了!...";
            }
            else
            {
                textBox1.Text += "沒中，請再接再厲!...";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            textBox1.Text = "";


            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
