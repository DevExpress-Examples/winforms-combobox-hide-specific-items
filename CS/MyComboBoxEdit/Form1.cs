using System;
using System.Collections.Generic;
using System.Windows.Forms;





namespace MyComboBoxEdit
{
    public partial class FormMain : Form
    {
        private MyInvisibleIndexes invisibleIndexes;

        public FormMain()
        {
            InitializeComponent();
            invisibleIndexes = new MyInvisibleIndexes(comboBoxEdit1);
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string[] s_array =  textEdit1.Text.Split(',');
            invisibleIndexes.Clear();
            
            for (int i = 0; i < s_array.Length; i++)
            {
                try
                {
                    invisibleIndexes.Add(int.Parse(s_array[i]));
                }
                catch
                {
                }
            }
        }
    }
}