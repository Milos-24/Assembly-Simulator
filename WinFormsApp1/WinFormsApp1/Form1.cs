using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arh_Simulator
{
    public partial class Simulator : Form
    {
        Assembly simulator;

        public Simulator()
        {
            InitializeComponent();
            InitializeCheckList();

            ShowBtn.Enabled = false;
            ExecuteBtn.Enabled = false;
            DebugBtn.Enabled = false;
        }

        private void InitializeCheckList()
        {
            for(int i=0;i<20;i++)
            {
                string address = "ADDRESS" + i.ToString();
                AddressCheckList.Items.Add(address);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CompileBtn_Click(object sender, EventArgs e)
        {
            OutputRTB.Clear();

            simulator = new Assembly(InputRTB.Text);

            OutputRTB.Text = simulator.ReturnInvalidLines();

            if(simulator.InvalidLines()==false)
            {
                ExecuteBtn.Enabled = true;
                DebugBtn.Enabled = true;
            }
            else
            {
                ShowBtn.Enabled = false;
                ExecuteBtn.Enabled = false;
                DebugBtn.Enabled = false;
            }    

        }

        //prikazati stanje adresa i registara odabranih
        private void ShowBtn_Click(object sender, EventArgs e)
        {
            String[] str = new String[Assembly.numOfAddresses];
            int i = 0;
            foreach (var selectedAddress in AddressCheckList.CheckedItems)
            {
                str[i] = selectedAddress.ToString();
                i++;
            }
            int numOfCheckedAddresses = i;
            string output=null;

            output = "Value at RAX is " + simulator.registers.RAX.ToString() + "\n";
            output += "Value at RBX is " + simulator.registers.RBX.ToString() + "\n";
            output += "Value at RCX is " + simulator.registers.RCX.ToString() + "\n";
            output += "Value at RDX is " + simulator.registers.RDX.ToString() + "\n";
            
            i = 0;
            while (i<numOfCheckedAddresses) {
                output += "Value at " + str[i] + " is " + simulator.GetAddress(str[i]).ToString() + "\n";
                i++;
            }

            MessageBox.Show(output);
        }

        private void CodeRTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DebugBtn_Click(object sender, EventArgs e)
        {
            if (simulator.currentlyExecutedLine >= simulator.instructions.Length)
            {
                CompileBtn.Enabled = true;
                ShowBtn.Enabled = true;
                DebugBtn.Enabled = false;
                ExecuteBtn.Enabled = false;
                InputRTB.Text = null;
                foreach (Instruction i in simulator.instructions)
                {
                    InputRTB.Text += i.GetLine();
                }
                InputRTB.Text = InputRTB.Text.Substring(0, InputRTB.Text.Length - 1);//nakon debagovanja predje u novu liniju pa se ne moze odma kompajlovati pa sam odsjekao zadnji
                return;
            }

            string current = "=>" + simulator.instructions[simulator.currentlyExecutedLine].GetLine();
            InputRTB.Text = null;

            foreach(Instruction i in simulator.instructions)
            {
                if (i.Equals(simulator.instructions[simulator.currentlyExecutedLine]))
                    InputRTB.Text += current;
                else
                    InputRTB.Text += i.GetLine();
            }
            
            simulator.ExecuteNext();
            simulator.currentlyExecutedLine++;
            CompileBtn.Enabled = false;
            ShowBtn.Enabled = true;
            ExecuteBtn.Enabled = false;


        }

        private async void ExecuteBtn_Click(object sender, EventArgs e)
        {
            ExecuteBtn.Enabled = false;
            CompileBtn.Enabled = false;
            DebugBtn.Enabled = false;
            List<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() =>
            {
                while (simulator.currentlyExecutedLine < simulator.instructions.Length)
                {
                    simulator.ExecuteNext();
                    simulator.currentlyExecutedLine++;
                }
            }
            ));
            await Task.WhenAny(taskList);

          
            ExecuteBtn.Enabled = false;
            CompileBtn.Enabled = true;
            DebugBtn.Enabled = false;
            ShowBtn.Enabled = true;
        }
    }
}
