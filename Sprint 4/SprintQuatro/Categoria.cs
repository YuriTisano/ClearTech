using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SprintQuatro
{
    public class Categoria
    {
        public string StatusCategoria = "";
        public string NomeCategoria { get; set; }
        public DateTime Horas { get; set; }
        public Subcategoria subcategoria { get; set; }

        #region [Critérios de aceite]
        public bool CriteriosDeAceite(string erro)
        {
            if (String.IsNullOrWhiteSpace(erro))
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

        #region [Cadastro de Categoria]
        public void CadastrodeCategoria()
        {
            while (true)
            {
                Horas = DateTime.Now;
                StatusCategoria = "Ativo";
                try
                {
                    string cadastroCategoria = Console.ReadLine();
                    NomeCategoria = cadastroCategoria;
                    if (CriteriosDeAceite(cadastroCategoria))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nCATEGORIA CADASTRADA!");
                        Console.WriteLine("Categoria criada: " + cadastroCategoria);
                        Console.WriteLine("Criado em: " + Horas);
                        Console.WriteLine("Status: " + StatusCategoria);
                        Console.ResetColor();
                        break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region [Edicão de Categoria]
        public void EdicaodeCategoria()
        {
            while (true)
            {
                Horas = DateTime.Now;
                StatusCategoria = StatusCategoria;

                try
                {
                    string edicaoCategoria = Console.ReadLine();
                    NomeCategoria = edicaoCategoria;
                    if (CriteriosDeAceite(edicaoCategoria))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nCATEGORIA EDITADA!");
                        Console.WriteLine("Novo nome da categoria: " + NomeCategoria);
                        Console.WriteLine("Modificado em: " + Horas);
                        Console.WriteLine("Status: " + StatusCategoria);
                        Console.ResetColor();
                        break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region [MetodoStatus]
        public void MetododeStatus()
        {
            if (StatusCategoria == "Ativo")
            {
                StatusCategoria = "Inativo";
            }
            else
            {

                StatusCategoria = "Ativo";
            }
        }
        #endregion
    }
}
