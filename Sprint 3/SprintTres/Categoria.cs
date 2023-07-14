using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SprintTres
{
    public class Categoria
    {
        public string StatusCategoria = "";
        public string NomeCategoria { get; set; }
        public DateTime Horas { get; set; }
        public Subcategoria subcategoria { get; set; }

        public bool CampoNulo(string erro)
        {
            if (String.IsNullOrWhiteSpace(erro))
            {
                throw new ArgumentException("Por favor, informe uma categoria com letras e com menos de 128 caracteres");
            }
            else
            {
                int restricoes = Regex.Matches(erro, @"[a-zA-Zà-úÀ-Ú' ']").Count;
                if (erro.Length <= 128 && restricoes == erro.Length)
                {
                    return true;
                }
                return false;
            }
        }
        public void CadastrodeCategoria()
        {
            while (true)
            {
                Horas = DateTime.Now;
                StatusCategoria = "Ativo";

                try
                {
                    string cadastroCategoria = Console.ReadLine();
                    if (CampoNulo(cadastroCategoria))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nCATEGORIA CADASTRADA!");
                        Console.WriteLine("Categoria criada: " + cadastroCategoria);
                        Console.WriteLine("Criado em: " + Horas);
                        Console.WriteLine("Status: " + StatusCategoria);
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, informe uma categoria somente com letras e com menos de 128 caracteres\"");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

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
                    if (CampoNulo(edicaoCategoria))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nCATEGORIA EDITADA!");
                        Console.WriteLine("Novo nome da categoria: " + edicaoCategoria);
                        Console.WriteLine("Modificado em: " + Horas);
                        Console.WriteLine("Status: " + StatusCategoria);
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, informe uma categoria somente com letras e com menos de 128 caracteres\"");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void AlteracaodeStatus()
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
    }

}