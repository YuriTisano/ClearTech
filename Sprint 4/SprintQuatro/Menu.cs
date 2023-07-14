using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SprintQuatro;

namespace SprintQuatro
{
    public class CadastroeLista
    {
        List<Produtos> lista = new List<Produtos>();
        Subcategoria subcategoria = new Subcategoria();

        public void CaminhoParaCadastro()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            MetodoCores("\nVocê gostaria de:\n(1) Cadastrar uma SUBCATEGORIA" +
                                            "\n(2) Cadastrar um PRODUTO" +
                                            "\n(3) Editar um PRODUTO" +
                                            "\n(4) Pesquisar PRODUTO(S)" +
                                            "\nDigite 1, 2, 3 ou 4.");
            string resposta = Console.ReadLine();

            if (resposta == "1")
            {
                subcategoria.CadastrodeSubcategoria();
                CaminhoParaCadastro();
            }

            else if (resposta == "2")
            {
                Produtos.CadastrarProduto(lista);
                CaminhoParaCadastro();
            }

            else if (resposta == "3")
            {
                Produtos.Edicao(lista);
                CaminhoParaCadastro();
            }

            else if (resposta == "4")
            {
                Produtos.PesquisarProduto(lista);
                CaminhoParaCadastro();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                MetodoCores("Ops! Não entendi o que você digitou.");
                CaminhoParaCadastro();
            }
        }

        #region [MetodoCores]
        private static void MetodoCores(string cores)
        {
            Console.WriteLine(cores);
            Console.ResetColor();
        }
        #endregion
    }
}