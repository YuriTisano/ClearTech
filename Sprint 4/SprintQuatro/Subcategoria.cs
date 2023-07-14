using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SprintQuatro
{
    public class Subcategoria
    {
        public string StatusSubcategoria = "";
        public string NomeSubcategoria { get; set; }
        public DateTime Horas { get; set; }
        public Categoria categoria { get; set; }

        #region [Cadastro de Subcategoria]
        public void CadastrodeSubcategoria()
        {
            Horas = DateTime.Now;
            StatusSubcategoria = "Ativo";

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MetodoCores("\nInforme o nome da subcategoria");

            while (true)
            {
                try
                {
                    string cadastroSubcategoria = Console.ReadLine();
                    if (CriteriosDeAceite(cadastroSubcategoria))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nSUBCATEGORIA CADASTRADA!");
                        Console.WriteLine("SUBCATEGORIA criada: " + cadastroSubcategoria);
                        Console.WriteLine("Criado em: " + Horas);
                        Console.WriteLine("Status: " + StatusSubcategoria);
                        Console.ResetColor();
                        break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                MetodoCores("\nGostaria de editar a subcategoria cadastrada? Digite SIM ou NAO.");
                string edicaoSubcategoria = Console.ReadLine();

                if (edicaoSubcategoria.ToUpper() == "SIM")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    MetodoCores("\nPor favor, informe um novo nome para a subcategoria.");

                    try
                    {
                        string novoNomeSubcategoria = Console.ReadLine();
                        NomeSubcategoria = novoNomeSubcategoria;
                        if (CriteriosDeAceite(novoNomeSubcategoria))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nSUBCATEGORIA EDITADA!");
                            Console.WriteLine("Novo nome da subcategoria: " + NomeSubcategoria);
                            Console.WriteLine("Modificado em: " + Horas);
                            Console.WriteLine("Status: " + StatusSubcategoria);
                            Console.ResetColor();
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nO Status da subcategoria " + NomeSubcategoria + " está " + StatusSubcategoria);
                        MetodoCores("Caso queira alterar o status (ativo e inativo) digite SIM ou NAO.\n");
                        string alteraStatusSub = Console.ReadLine();

                        if (alteraStatusSub.ToUpper() == "SIM")
                        {
                            MetododeStatus();
                            Console.ForegroundColor = ConsoleColor.Green;
                            MetodoCores("Subcategoria criada: " + NomeSubcategoria);

                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            MetodoCores("Status: " + StatusSubcategoria);

                            Console.ForegroundColor = ConsoleColor.Green;
                            MetodoCores("Edição realizada em: " + DateTime.Now + "\n");

                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\nCaso a SUBCATEGORIA permaneça " + StatusSubcategoria + " não é possível cadastrar um produto");
                            Console.WriteLine("Gostaria de encerrar o console (1) ou ATIVAR a subcategoria (2)?");
                            Console.ResetColor();
                            string resposta = Console.ReadLine();

                            if (resposta == "1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                MetodoCores("Tecle enter para encerrar");
                                Environment.Exit(1);
                            }
                            else if (resposta == "2")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                MetododeStatus();
                                Console.WriteLine("\nSubcategoria criada: " + NomeSubcategoria);
                                Console.WriteLine("Status: " + StatusSubcategoria);
                                Console.WriteLine("Edição realizada em: " + DateTime.Now + "\n");
                                Console.ResetColor();
                                break;
                            }
                        }
                        else if (alteraStatusSub.ToUpper() == "NAO")
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

                }
                else if (edicaoSubcategoria.ToUpper() == "NAO")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    MetodoCores("\nTudo bem. Subcategoria mantida.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    MetodoCores("\nOPS! Não cosegui entender o que você digitou");
                }
            }
        }
        #endregion

        #region [Critérios de aceite]
        public bool CriteriosDeAceite(string erro)
        {
            if (String.IsNullOrWhiteSpace(erro) || String.IsNullOrEmpty(erro))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ArgumentException("Por favor, informe uma categoria com letras e com menos de 128 caracteres");
                Console.ResetColor();
            }
            else
            {
                int restricoes = Regex.Matches(erro, @"[a-zA-Zà-úÀ-Ú' ']").Count;
                if (erro.Length <= 128 && restricoes == erro.Length)
                {
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, informe uma categoria com letras e com menos de 128 caracteres");
                    Console.ResetColor();
                    return false;
                }
            }
        }
        #endregion

        #region [MetododeStatus]
        public void MetododeStatus()
        {
            if (StatusSubcategoria == "Ativo")
            {
                StatusSubcategoria = "Inativo";
            }
            else
            {
                StatusSubcategoria = "Ativo";
            }
        }
        #endregion

        #region [MetodoCores]
        private static void MetodoCores(string cores)
        {
            Console.WriteLine(cores);
            Console.ResetColor();
        }
        #endregion
    }
}
