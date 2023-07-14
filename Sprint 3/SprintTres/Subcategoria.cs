using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SprintTres
{
    public class Subcategoria
    {
        public string StatusSubcategoria = "";
        public string NomeSubcategoria { get; set; }
        public DateTime Horas { get; set; }
        public Categoria categoria { get; set; }

        public bool CampoNuloSubcategoria(string erro)
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
        public void CadastrodeSubcategoria()
        {
            while (true)
            {
                Horas = DateTime.Now;
                StatusSubcategoria = "Ativo";

                try
                {
                    string cadastroSubcategoria = Console.ReadLine();
                    if (CampoNuloSubcategoria(cadastroSubcategoria))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nSUBCATEGORIA CADASTRADA!");
                        Console.WriteLine("SUBCATEGORIA criada: " + cadastroSubcategoria);
                        Console.WriteLine("Criado em: " + Horas);
                        Console.WriteLine("Status: " + StatusSubcategoria);
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, informe uma subcategoria somente com letras e com menos de 128 caracteres\"");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void EdicaodeSubcategoria()
        {
            while (true)
            {
                Horas = DateTime.Now;
                StatusSubcategoria = StatusSubcategoria;

                try
                {
                    string edicaoSubcategoria = Console.ReadLine();
                    NomeSubcategoria = edicaoSubcategoria;
                    if (CampoNuloSubcategoria(edicaoSubcategoria))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nSUBCATEGORIA EDITADA!");
                        Console.WriteLine("Novo nome da subcategoria: " + edicaoSubcategoria);
                        Console.WriteLine("Modificado em: " + Horas);
                        Console.WriteLine("Status: " + StatusSubcategoria);
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, informe uma subcategoria somente com letras e com menos de 128 caracteres\"");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void AlteracaodeStatusSubcategoria()
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
    }

}
