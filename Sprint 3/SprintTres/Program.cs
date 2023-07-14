using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SprintTres
{
    public class Program
    {
        static void Main(string[] args)
        {
            Categoria categoria = new Categoria();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Bem Vindo ao cadastro de categorias e subcategorias!");
            Console.ResetColor();

            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Informe o nome de uma CATEGORIA?");
                Console.ResetColor();

                categoria.CadastrodeCategoria();
                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nGostaria de editar a categoria cadastrada? Digite SIM ou NAO.");
                    Console.ResetColor();

                    string edit = Console.ReadLine();
                    if (edit.ToUpper() == "SIM")
                    {
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\nPor favor, informe um novo nome para a categoria.");
                            Console.ResetColor();

                            categoria.EdicaodeCategoria();


                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nA categoria " + categoria.NomeCategoria + " está " + categoria.StatusCategoria);
                            Console.WriteLine("Caso queira alterar o status (ativo e inativo) digite SIM ou NAO.\n");
                            Console.ResetColor();

                            string usuarioalteraStatus = Console.ReadLine();
                            if (usuarioalteraStatus.ToUpper() == "SIM")
                            {
                                categoria.AlteracaodeStatus();
                                Console.ForegroundColor = ConsoleColor.Green; //
                                Console.WriteLine("Categoria criada: " + categoria.NomeCategoria);
                                Console.ResetColor(); //
                                Console.ForegroundColor = ConsoleColor.DarkBlue; //
                                Console.WriteLine("Status: " + categoria.StatusCategoria);
                                Console.ResetColor(); //
                                Console.ForegroundColor = ConsoleColor.Green; //
                                Console.WriteLine("Edição realizada em: " + DateTime.Now + "\n");
                                Console.ResetColor();//
                                break;
                            }
                            else if (usuarioalteraStatus.ToUpper() == "NAO")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Tudo bem. Status mantido!");
                                Console.ResetColor();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nOPS! Não cosegui entender o que você digitou");
                                Console.ResetColor();
                            }
                        }
                        while (true);
                    }
                    else if (edit.ToUpper() == "NAO")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nTudo bem. Categoria mantida.");
                        Console.ResetColor();

                        Subcategoria subcategoria = new Subcategoria();
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nGostaria de cadastrar uma SUBCATEGORIA(1) ou encerrar o console (2)?");
                            Console.WriteLine("Pressione 1 ou 2?");
                            Console.ResetColor();
                            string respostaSubcategoria = Console.ReadLine();

                            if (respostaSubcategoria == "1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("\nInforme o nome da SUBCATEGORIA?");
                                Console.ResetColor();

                                subcategoria.CadastrodeSubcategoria();
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\nGostaria de editar a Subcategoria cadastrada? Digite SIM ou NAO.");
                                    Console.ResetColor();

                                    string editarSubcategoria = Console.ReadLine();
                                    if (editarSubcategoria.ToUpper() == "SIM")
                                    {
                                        do
                                        {
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.WriteLine("\nPor favor, informe um novo nome para a categoria.");
                                            Console.ResetColor();

                                            subcategoria.EdicaodeSubcategoria();


                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\nA subcategoria " + subcategoria.NomeSubcategoria + " está " + subcategoria.StatusSubcategoria);
                                            Console.WriteLine("Caso queira alterar o status (ativo e inativo) digite SIM ou NAO.\n");
                                            Console.ResetColor();

                                            string alteracaoStatusSubcategoria = Console.ReadLine();
                                            if (alteracaoStatusSubcategoria.ToUpper() == "SIM")
                                            {
                                                categoria.AlteracaodeStatus();
                                                Console.ForegroundColor = ConsoleColor.Green; //
                                                Console.WriteLine("Subategoria criada: " + subcategoria.NomeSubcategoria);
                                                Console.ResetColor(); //
                                                Console.ForegroundColor = ConsoleColor.DarkBlue; //
                                                Console.WriteLine("Status: " + subcategoria.StatusSubcategoria);
                                                Console.ResetColor(); //
                                                Console.ForegroundColor = ConsoleColor.Green; //
                                                Console.WriteLine("Edição realizada em: " + DateTime.Now + "\n");
                                                Console.ResetColor();//
                                                break;
                                            }
                                            else if (alteracaoStatusSubcategoria.ToUpper() == "NAO")
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.WriteLine("Tudo bem. Status mantido!");
                                                Console.ResetColor();
                                                break;
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nOPS! Não cosegui entender o que você digitou");
                                                Console.ResetColor();
                                            }
                                        }
                                        while (true);
                                    }
                                    else if (editarSubcategoria.ToUpper() == "NAO")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("\nTudo bem. Subcategoria mantida.");
                                        Console.ResetColor();
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nOPS! Não cosegui entender o que você digitou");
                                        Console.ResetColor();
                                    }

                                } while (true);
                            }
                            else if (respostaSubcategoria == "2")
                            {
                                return;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nOPS! Não cosegui entender o que você digitou");
                                Console.ResetColor();
                            }

                        } while (true);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOPS! Não cosegui entender o que você digitou");
                        Console.ResetColor();
                    }

                } while (true);

            } while (true);
        }
    }
}