using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SprintDois
{
    public class Program
    {
        static void Main(string[] args)
        {
            Categoria categoria = new Categoria();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Bem Vindo ao cadastro de categorias!");
            Console.ResetColor();

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nInforme o que quer cadastrar?");
                Console.ResetColor();

                categoria.CadastrodeCategoria();
                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Gostaria de editar a categoria cadastrada? Digite SIM ou NAO.");
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
                            Console.WriteLine("\nA categoria " + categoria.NomeCategoria + " está " + categoria.Status);
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
                                Console.WriteLine("Status: " + categoria.Status);
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
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOPS! Não cosegui entender o que você digitou");
                        Console.ResetColor();
                    }
                }while (true);
            }while (true);
        }
    }
}