using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SprintQuatro
{
    public class Produtos
    {
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }

        public string Status = "";
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Largura { get; set; }
        public double Comprimento { get; set; }
        public double Valor { get; set; }
        public int QuantidadeemEstoque { get; set; }
        public string CentrodeDistribuição { get; set; }
        public DateTime DataCriacao { get; set; }
        public CadastroeLista menuPrincipal { get; set; }

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

        #region [Cadastro de Produtos]
        public static void CadastrarProduto(List<Produtos> lista)
        {
            Produtos produtos = new Produtos();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MetodoCores("\nInforme o nome do produto");
            string nomeProduto = Console.ReadLine();

            if (produtos.CriteriosDeAceite(nomeProduto))
            {

            }
            else
            {
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MetodoCores("\nInforme a descrição do produto");
            string descricao = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nInforme o peso do produto");
            double pesoProduto;
            pesoProduto = produtos.Peso = double.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nInforme a altura do produto ");
            double altura;
            altura = produtos.Altura = double.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nInforme a largura do produto");
            double largura;
            largura = produtos.Largura = double.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nInforme o comprimento do produto");
            double comprimento;
            comprimento = produtos.Comprimento = double.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nInforme o valor do produto");
            double valor;
            valor = produtos.Valor = double.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nInforme a quantidade em estoque do produto");
            int quantidade;
            quantidade = produtos.QuantidadeemEstoque = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nInforme o centro de distribuição do produto");
            string centroDistribuição = Console.ReadLine();

            var DataCriacao = DateTime.Now;
            var Status = "Ativo";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Produto criado: " + (produtos.NomeProduto = nomeProduto));
            Console.WriteLine("Descrição: " + (produtos.Descricao = descricao));
            Console.WriteLine("Centro de distribuição: " + (produtos.CentrodeDistribuição = centroDistribuição));
            Console.WriteLine("Peso: " + (produtos.Peso = pesoProduto));
            Console.WriteLine("Altura: " + (produtos.Altura = altura));
            Console.WriteLine("Largura: " + (produtos.Largura = largura));
            Console.WriteLine("Comprimento: " + (produtos.Comprimento = comprimento));
            Console.WriteLine("Valor: R$" + (produtos.Valor = valor));
            Console.WriteLine("Estoque: " + (produtos.QuantidadeemEstoque = quantidade));
            Console.WriteLine("Criado em: " + DataCriacao);
            Console.WriteLine("Status: " + Status);
            lista.Add(produtos);
        }
        #endregion

        #region [Edição  de produto]
        public static void Edicao(List<Produtos> lista)
        {
            Produtos produtos = new Produtos();
            CadastroeLista menuPrincipal = new CadastroeLista();

            var DataCriacao = DateTime.Now;
            var Status = "Ativo";

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MetodoCores("\nGostaria de editar o produto. Digite SIM ou NAO?");
            string resposta = Console.ReadLine();

            if (resposta.ToUpper() == "SIM")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                MetodoCores("\nInforme o novo nome do produto");
                string novoNomeProduto = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                MetodoCores("\nInforme a nova descrição do produto");
                string novaDescricao = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                MetodoCores("\nInforme o novo peso do produto");
                double novoPesoProduto;
                novoPesoProduto = produtos.Peso = double.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                MetodoCores("\nInforme a nova altura do produto ");
                double novaAltura;
                novaAltura = produtos.Altura = double.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                MetodoCores("\nInforme a nova largura do produto");
                double novaLargura;
                novaLargura = produtos.Largura = double.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                MetodoCores("\nInforme o novo comprimento do produto");
                double novoComprimento;
                novoComprimento = produtos.Comprimento = double.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                MetodoCores("\nInforme o novo valor do produto");
                double novoValor;
                novoValor = produtos.Valor = double.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                MetodoCores("\nInforme a nova quantidade em estoque do produto");
                int novaQuantidade;
                novaQuantidade = produtos.QuantidadeemEstoque = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                MetodoCores("\nInforme o novo centro de distribuição do produto");
                string novoCentroDistribuição = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nEDIÇÃO REALIZADA");
                Console.WriteLine("Produto criado: " + (produtos.NomeProduto = novoNomeProduto));
                Console.WriteLine("Descrição: " + (produtos.Descricao = novaDescricao));
                Console.WriteLine("Centro de distribuição: " + (produtos.CentrodeDistribuição = novoCentroDistribuição));
                Console.WriteLine("Peso: " + (produtos.Peso = novoPesoProduto));
                Console.WriteLine("Altura: " + (produtos.Altura = novaAltura));
                Console.WriteLine("Largura: " + (produtos.Largura = novaLargura));
                Console.WriteLine("Comprimento: " + (produtos.Comprimento = novoComprimento));
                Console.WriteLine("Valor: R$" + (produtos.Valor = novoValor));
                Console.WriteLine("Estoque: " + (produtos.QuantidadeemEstoque = novaQuantidade));
                Console.WriteLine("Criado em: " + DataCriacao);
                Console.WriteLine("Status: " + Status);
                lista.Add(produtos);

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nO Status do produto " + produtos.NomeProduto + " está " + Status);
                    Console.WriteLine("Caso queira alterar o status (ativo e inativo) digite SIM ou NAO.\n");
                    string alteraStatus = Console.ReadLine();

                    if (alteraStatus.ToUpper() == "SIM")
                    {
                        produtos.MetododeStatus();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Produto criado: " + produtos.NomeProduto);

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Status: " + Status);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Edição realizada em: " + DateTime.Now);
                        break;
                    }
                    else if (alteraStatus.ToUpper() == "NAO")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Tudo bem. Status mantido!");
                        break;
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOPS! Não cosegui entender o que você digitou");
                    }
                }
            }
            else if (resposta.ToUpper() == "NAO")
            {
                menuPrincipal.CaminhoParaCadastro();
            }
        }
        #endregion

        #region [Pesquisa de produtos]
        public static void PesquisarProduto(List<Produtos> lista)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MetodoCores("\nO que você gostaria de pesquisar?\n1 - Nome dos produtos cadastrados" +
                                                           "\n2 - Peso dos produtos  cadastrados" +
                                                           "\n3 - Altura dos produtos cadastrados" +
                                                           "\n4 - Largura dos produtos cadastrados" +
                                                           "\n5 - Comprimento dos produtos cadastrados" +
                                                           "\n6 - Valor dos produtos cadastrados" +
                                                           "\n7 - Quantidade em estoque dos produtos cadastrados" +
                                                           "\n8 - Centro de distribuição dos produtos cadastrados" +
                                                           "\n9 - Detalhamento de produtos criados (PAGINAÇÃO)" +
                                                           "\n0 - Voltar ao cadastro de SUBCATEGORIA e PRODUTOS");

            string resposta = Console.ReadLine();

            if (resposta == "1")
            {

                lista = lista.Where(referencia => referencia.NomeProduto.Contains(referencia.NomeProduto)).ToList();
                foreach (var referencia in lista)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    MetodoCores("Nome do produto: " + referencia.NomeProduto);
                }
            }

            else if (resposta == "2")
            {
                lista = lista.Where(referencia => referencia.Peso.Equals(referencia.Peso)).ToList();
                foreach (var referencia in lista)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nome do produto: " + referencia.NomeProduto);
                    Console.WriteLine("Peso: " + referencia.Peso);
                    Console.ResetColor();
                }
            }

            else if (resposta == "3")
            {
                lista = lista.Where(referencia => referencia.Altura.Equals(referencia.Altura)).ToList();
                foreach (var referencia in lista)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nome do produto: " + referencia.NomeProduto);
                    Console.WriteLine("Altura: " + referencia.Altura);
                    Console.ResetColor();
                }
            }

            else if (resposta == "4")
            {
                lista = lista.Where(referencia => referencia.Largura.Equals(referencia.Largura)).ToList();

                foreach (var referencia in lista)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nome do produto: " + referencia.NomeProduto);
                    Console.WriteLine("Largura: " + referencia.Largura);
                    Console.ResetColor();
                }

            }

            else if (resposta == "5")
            {
                lista = lista.Where(referencia => referencia.Comprimento.Equals(referencia.Comprimento)).ToList();
                foreach (var referencia in lista)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nome do produto: " + referencia.NomeProduto);
                    Console.WriteLine("Comprimento: " + referencia.Comprimento);
                    Console.ResetColor();
                }
            }

            else if (resposta == "6")
            {
                lista = lista.Where(referencia => referencia.Valor.Equals(referencia.Valor)).ToList();
                foreach (var referencia in lista)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nome do produto: " + referencia.NomeProduto);
                    Console.WriteLine("Valor: " + referencia.Valor);
                    Console.ResetColor();
                }
            }

            else if (resposta == "7")
            {
                var pesquisaEstoque = lista.Where(referencia => referencia.QuantidadeemEstoque.Equals(referencia.QuantidadeemEstoque)).ToList();
                foreach (var referencia in lista)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nome do produto: " + referencia.NomeProduto);
                    Console.WriteLine("Estoque: " + referencia.QuantidadeemEstoque);
                    Console.ResetColor();
                }
            }

            else if (resposta == "8")
            {
                var pesquisaEstoque = lista.Where(referencia => referencia.CentrodeDistribuição.Equals(referencia.CentrodeDistribuição)).ToList();
                foreach (var referencia in lista)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nome do produto: " + referencia.NomeProduto);
                    Console.WriteLine("Centro de distribuição: " + referencia.CentrodeDistribuição);
                    Console.ResetColor();
                }
            }

            else if (resposta == "9")
            {
                foreach (var p in lista)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nProduto criado: " + p.NomeProduto);
                    Console.WriteLine("Descrição: " + p.Descricao);
                    Console.WriteLine("Centro de distribuição: " + p.CentrodeDistribuição);
                    Console.WriteLine("Peso: " + p.Peso);
                    Console.WriteLine("Altura: " + p.Altura);
                    Console.WriteLine("Largura: " + p.Largura);
                    Console.WriteLine("Comprimento: " + p.Comprimento);
                    Console.WriteLine("Valor: R$" + p.Valor);
                    Console.WriteLine("Estoque: " + p.QuantidadeemEstoque);
                    Console.WriteLine("Criado em: " + p.DataCriacao);
                    Console.WriteLine("Status: " + p.Status);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                MetodoCores("Ops! Não entendi o que você digitou.");
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

        #region [MetododeStatus]
        public void MetododeStatus()
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
        #endregion
    }
}