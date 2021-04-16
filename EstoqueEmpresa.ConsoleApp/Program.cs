using System;

using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EstoqueEmpresa.ConsoleApp
{
    using static Globals;
    #region Equipamentos
    //Deve ter um nome com no mínimo 6 caracteres;  
    //   Deve ter um preço de aquisição;  
    // Deve ter um número de série;  
    //Deve ter uma data de fabricação;  
    //Deve ter uma fabricante;
    #endregion
    class Program
    {
        
              

        static void Main(string[] args)
        {

            string opcao = "";
            int quantidadeEquipamentos = 0;
            bool confereNumeroChamado = false;
            int quantidadeChamados = 0;

            do
            {              

                MostrarMenu(ref opcao);

                switch (opcao)

                {

                    case "1":

                        Console.WriteLine("Digite o numero do equipamento:");
                        int numero = Convert.ToInt32(Console.ReadLine());

                        quantidadeEquipamentos++;
                        RegistraEquipamentos(quantidadeEquipamentos, numero);
                        
                        Console.Clear();

                        break;

                    case "2":
                        if (quantidadeEquipamentos == 0)
                        {
                            MensagemErro("Nenhum equipamento registrado");
                        }

                        else
                        {
                            VisualizarEquipamentos(quantidadeEquipamentos);
                        }

                        break;

                    case "3":

                        EditarEquipamentos(quantidadeEquipamentos);
                        Console.Clear();

                        break;

                    case "4":

                        ExcluirEquipamentos(quantidadeEquipamentos);

                        break;

                    case "5":

                        Console.WriteLine("Digite o numero do equipamento:");
                        int numeroEquipamentoChamado = Convert.ToInt32(Console.ReadLine());

                        ValidaNumeroChamado( ref confereNumeroChamado, numeroEquipamentoChamado);

                        if (confereNumeroChamado == false)
                        {
                            MensagemErro("Não existe nenhum equipamento com este número!");
                            Console.Clear();
                        }

                        else if (confereNumeroChamado == true)
                        {
                            quantidadeChamados++;
                            RegistraChamados(quantidadeChamados, numeroEquipamentoChamado);

                        }


                        break;

                    case "6":
                        if (quantidadeChamados == 0)
                        {

                            MensagemErro("Nenhum chamado registrado");
                        }

                        else
                        {
                            VisualizarChamados(quantidadeChamados);
                        }

                        break;

                    case "7":

                        EditarChamado(quantidadeChamados);
                        Console.ReadLine();
                        Console.Clear();

                        break;

                    case "8":

                        ExcluirChamado(quantidadeChamados);
                        Console.ReadLine();
                        Console.Clear();

                        break;


                    default:
                        break;
                }

            } while (!opcao.Equals("S", StringComparison.OrdinalIgnoreCase));

        }

        private static void MensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        private static void ExcluirChamado(int quantidadeChamados)
        {
            Console.WriteLine("Excluindo chamados...");

            VisualizarChamados(quantidadeChamados);

            Console.WriteLine("Digite o numero do equipamento do chamado que deseja excluir:");
            int numeroSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < CAPACIDADE_REGISTROS; i++)
            {
                if (tituloChamado[i] != null && equipamentoChamado[i] == numeroSelecionado)
                {
                    tituloChamado[i] = null;
                    descricaoChamado[i] = null;
                    dataChamado[i] = DateTime.MinValue;
                    equipamentoChamado[i] = 0;
                }
            }
        }

        private static void EditarChamado(int quantidadeChamados)
        {
            Console.WriteLine("Editando Chamado...");

            VisualizarChamados(quantidadeChamados);

            Console.WriteLine("Digite o numero do equipamento do chamado que seja editar:");

            int numeroSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= quantidadeChamados; i++)
            {
                if (tituloChamado[i] != null && equipamentoChamado[i] == numeroSelecionado)
                {
                    RegistraChamados(i, numeroSelecionado);
                }

            }

            Console.WriteLine("Chamado editado com Sucesso!");
        }

        private static void VisualizarChamados(int quantidadeChamados)
        {
            string mostrarInformacoes;

            for (int contador = 1; contador <= quantidadeChamados; contador++)
            {
                string diasAbertos = (DateTime.Now - dataChamado[contador]).Days.ToString();
                Console.WriteLine("\nChamado: " + contador);
                mostrarInformacoes = $"Titulo: {tituloChamado[contador]} \nNumero: {equipamentoChamado[contador]} " +
                  $"\nDescrição: {descricaoChamado[contador]}\nData Abertura: {dataChamado[contador]}\nDias Abertos: {diasAbertos}";
                Console.WriteLine(mostrarInformacoes);

            }

            Console.ReadLine();
            Console.Clear();
        }

        private static void RegistraChamados(int quantidadeChamados, int numeroEquipamentoChamado)
        {
            Console.WriteLine("Insira o título do chamado:");
            tituloChamado[quantidadeChamados] = (Console.ReadLine());

            Console.WriteLine("Insira a descricao do chamado:");
            descricaoChamado[quantidadeChamados] = Console.ReadLine();

            Console.WriteLine("Insira a data do chamado:");
            datasFabricacaoEquipamento[quantidadeChamados] = Convert.ToDateTime(Console.ReadLine());

            equipamentoChamado[quantidadeChamados] = numeroEquipamentoChamado;
        }

        private static bool ValidaNumeroChamado(ref bool confereNumeroChamado, int numeroEquipamentoChamado)
        {
            for (int i = 0; i < CAPACIDADE_REGISTROS; i++)
            {
                if (numeroEquipamentoChamado == numerosEquipamento[i])
                {
                    confereNumeroChamado = true;
                }
            }

            return confereNumeroChamado;
        }

        private static void ExcluirEquipamentos(int quantidadeEquipamentos)
        {
            Console.WriteLine("Excluindo equipamentos...");

            VisualizarEquipamentos(quantidadeEquipamentos);

            Console.WriteLine("Digite o numero do equipamento que deseja excluir:");
            int numeroSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < CAPACIDADE_REGISTROS; i++)
            {
                if (nomeEquipamento[i] != null && numerosEquipamento[i] == numeroSelecionado)
                {
                    numerosEquipamento[i] = 0;
                    nomeEquipamento[i] = null;
                    precosEquipamento[i] = 0;
                    datasFabricacaoEquipamento[i] = DateTime.MinValue;
                    fabricantesEquipamento[i] = null;
                }
            }
        }

        private static void EditarEquipamentos(int quantidadeEquipamentos)
        {
            Console.WriteLine("Editando Equipamentos...");

            VisualizarEquipamentos(quantidadeEquipamentos);

            Console.WriteLine("Digite o numero do equipamento que seja editar:");

            int numeroSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= quantidadeEquipamentos; i++)
            {
                if (nomeEquipamento[i] != null && numerosEquipamento[i] == numeroSelecionado)
                {
                    RegistraEquipamentos(i, numeroSelecionado);
                }

            }

            Console.WriteLine("Equipamento Registrado com Sucesso!");
        }

        private static void VisualizarEquipamentos(int quantidadeEquipamentos)
        {
            string mostrarInformacoes;
            for (int contador = 1; contador <= quantidadeEquipamentos; contador++)
            {
                Console.WriteLine("\nEquipamento: " + contador);
                mostrarInformacoes = $"Nome: {nomeEquipamento[contador]} \nNumero: {numerosEquipamento[contador]} " +
                  $"\nPreço: R${precosEquipamento[contador]}\nFabricante: {fabricantesEquipamento[contador]}\nData: {datasFabricacaoEquipamento[contador]}";
                Console.WriteLine(mostrarInformacoes);
               
                }

            Console.ReadLine();
            Console.Clear();
        }

        private static string MostrarMenu(ref string opcao)
        {
                       

            do
            {
                Console.WriteLine("Digite a opção desejada:");
                Console.WriteLine("1 - Adicionar Equipamentos");
                Console.WriteLine("2 - Visualizar Equipamentos");
                Console.WriteLine("3 - Editar Equipamentos");
                Console.WriteLine("4 - Excluir Equipamentos");
                Console.WriteLine("5 - Adicionar Chamados");
                Console.WriteLine("6 - Visualizar Chamados");
                Console.WriteLine("7 - Editar Chamados");
                Console.WriteLine("8 - Excluir Chamados");
                Console.WriteLine("Digite S para sair do programa");
                opcao = Console.ReadLine();
                if (!ValidaOpcaoMenu(opcao))
                {
                    MensagemErro("Opção Inválida. Tente Novamente!");
                    Console.Clear();

                }

            } while (!ValidaOpcaoMenu(opcao));

            return opcao;
        }

        private static bool ValidaOpcaoMenu(string opcao)
        {
            return (opcao == "1" || opcao == "2" || opcao == "3" || opcao == "4" || opcao == "5" || opcao == "6" ||
                opcao == "7" || opcao == "8" || opcao == "S" || opcao == "s");
        }

        public static void RegistraEquipamentos(int i, int numero)
        {

            bool nomeInvalido = false;

                do
                {
                     nomeInvalido = false;
                    Console.WriteLine("Insira o nome do Equipamento:");
                    nomeEquipamento[i] = (Console.ReadLine());

                    if (nomeEquipamento[i].Length < 6)
                    {
                        nomeInvalido = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O nome não pode ter menos de 6 caracteres");
                        Console.ResetColor();
                    }


                } while (nomeInvalido);

                Console.WriteLine("Insira o preco do Equipamento:");
                precosEquipamento[i] = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Insira a data do Equipamento:");
                datasFabricacaoEquipamento[i] = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Insira o fabricante do Equipamento:");
                fabricantesEquipamento[i] = (Console.ReadLine());

                numerosEquipamento[i] = numero;
            

            
        } 
    } }
