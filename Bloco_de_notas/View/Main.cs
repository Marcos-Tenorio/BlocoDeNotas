using System;
using System.IO;
using System.Windows.Forms;

namespace Bloco_de_notas.View
{
    internal sealed partial class Main : Form
    {
        private string lastPath;

        internal Main()
        {
            InitializeComponent();
        }

        private void SetTitle(string filename)
        {
            Text = "Notepad - " + filename;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".txt";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";

            DialogResult result = openFileDialog1.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                lastPath = openFileDialog1.FileName;
                SetTitle(Data.DataController.ExtractName(lastPath));
                textBoxText.Text = Data.DataController.Read(lastPath);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(lastPath))
            {
                Data.DataController.Write(lastPath, textBoxText.Text);
            }
            else
            {
                saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
                saveFileDialog1.FilterIndex = 1;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    lastPath = saveFileDialog1.FileName;
                    Data.DataController.Write(lastPath, textBoxText.Text);
                    SetTitle(Data.DataController.ExtractName(lastPath));
                }

            }
            MessageBox.Show("Arquivo salvo!");
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                lastPath = saveFileDialog1.FileName;
                Data.DataController.Write(lastPath, textBoxText.Text);
                SetTitle(Data.DataController.ExtractName(lastPath));
            }
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bloco de notas personalizado criado para fins de estudo pessoal", "Performático", MessageBoxButtons.OK);

        }

        //TODO: Criar metodo para examinar se textbox possue conteudo
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Certeza que quer apagar todos os dados?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                textBoxText.Clear();
            }



        }
    }
}