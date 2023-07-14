using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SprintDois
{
    public class Categoria
    {
        public string Status = "";
        public string NomeCategoria { get; set; }
        public DateTime Horas { get; set; }
        public bool CampoNulo (string name)
        {
            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Por favor, informe uma categoria com letras e com menos de 128 caracteres");
            }
            else
            {
                int alpha = Regex.Matches(name, @"[a-zA-Zà-úÀ-Ú' ']").Count;
                if (name.Length <= 128 && alpha == name.Length)
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
                Status = "Ativo";

                try
                {
                    string cadastroCategoria = Console.ReadLine();
                    if (CampoNulo(cadastroCategoria))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nCATEGORIA CADASTRADA!");
                        Console.WriteLine("Categoria criada: " + cadastroCategoria);
                        Console.WriteLine("Criado em: " + Horas);
                        Console.WriteLine("Status: " + Status);
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
                Status = Status;

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
                        Console.WriteLine("Status: " + Status);
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("\nPor favor, informe uma categoria somente com letras e com menos de 128 caracteres\"");
                        Console.ResetColor();
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
            if (Status == "Ativo")
            {
                Status = "Inativo";
            }
            else
            {

                Status = "Ativo";
            }
        }
    }

}