using System.IO;
using System.Windows.Forms;

namespace Bloco_de_notas.Data
{
    internal static class DataController
    {
        internal static void Write(string path, string text)
        {
            try
            {
                File.WriteAllText(path, text);
            }
            catch
            {
                MessageBox.Show($"Erro ao escrever arquivo {path}", "Erro", MessageBoxButtons.OK);
            }
        }

        internal static string Read(string path)
        {
            if (!File.Exists(path))
                return null;

            return File.ReadAllText(path);
        }
    }
}
