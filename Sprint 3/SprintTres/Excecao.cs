using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTres
{
    public class Excecao
    {
        public string URL { get; }

        public Excecao(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (url == "")
            {
                throw new ArgumentException("O argumento url não pode ser uma string vazia.", nameof(url));
            }

            URL = url;
        }
    }
}
