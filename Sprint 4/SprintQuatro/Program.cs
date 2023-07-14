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
    public class Program
    {
        static void Main(string[] args)
        {
            Categoria categoria = new Categoria();
            Console.ForegroundColor = ConsoleColor.Magenta;
            MetodoCores("Bem Vindo ao cadastro de Produtos!");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MetodoCores("Informe o nome do que quer cadastrar");

            # region [Método de cadastro de CATEGORIA]
            categoria.CadastrodeCategoria();
            #endregion

            #region [Edição de CATEGORIA]
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                MetodoCores("Gostaria de editar a categoria cadastrada? Digite SIM ou NAO.");
                string edit = Console.ReadLine();

                if (edit.ToUpper() == "SIM")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    MetodoCores("\nPor favor, informe um novo nome para a categoria.");
                    categoria.EdicaodeCategoria();

                    //Alteração de STATUS da CATEGORIA
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nO Status da categoria " + categoria.NomeCategoria + " está " + categoria.StatusCategoria);
                        MetodoCores("Caso queira alterar o status (ativo e inativo) digite SIM ou NAO.\n");
                        string usuarioalteraStatus = Console.ReadLine();

                        if (usuarioalteraStatus.ToUpper() == "SIM")
                        {
                            categoria.MetododeStatus();

                            Console.ForegroundColor = ConsoleColor.Green;
                            MetodoCores("Categoria criada: " + categoria.NomeCategoria);

                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            MetodoCores("Status: " + categoria.StatusCategoria);

                            Console.ForegroundColor = ConsoleColor.Green;
                            MetodoCores("Edição realizada em: " + DateTime.Now + "\n");

                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\nCaso a categoria permaneça " + categoria.StatusCategoria + " não é possível cadastrar  uma subcategoria ou um produto");
                            Console.WriteLine("Gostaria de encerrar o console (1) ou ATIVAR a categoria (2)?");
                            Console.ResetColor();
                            string resposta = Console.ReadLine();

                            if (resposta == "1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                MetodoCores("Tecle enter para encerrar?");
                                return;
                            }
                            else if (resposta == "2")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                categoria.MetododeStatus();
                                Console.WriteLine("\nCategoria criada: " + categoria.NomeCategoria);
                                Console.WriteLine("Status: " + categoria.StatusCategoria);
                                Console.WriteLine("Edição realizada em: " + DateTime.Now);
                                Console.ResetColor();
                                break;
                            }
                        }
                        else if (usuarioalteraStatus.ToUpper() == "NAO")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            MetodoCores("Tudo bem. Status mantido!");
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            MetodoCores("\nOPS! Não cosegui entender o que você digitou");
                        }
                    }
                    while (true);
                }
                else if (edit.ToUpper() == "NAO")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    MetodoCores("\nTudo bem. Categoria mantida.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    MetodoCores("\nOPS! Não cosegui entender o que você digitou");
                }
            }
            while (true);
            #endregion

            #region [Método para cadastro de SUBCATEGORIA, PRODUTO e PESQUISA DE PRODDUTOS]
            do
            {
                CadastroeLista cadastroeLista = new CadastroeLista();
                cadastroeLista.CaminhoParaCadastro();
            }
            while (true);
            #endregion
        }

        #region [Metodo de cores]
        private static void MetodoCores(string cores)
        {
            Console.WriteLine(cores);
            Console.ResetColor();
        }
        #endregion
    }
}