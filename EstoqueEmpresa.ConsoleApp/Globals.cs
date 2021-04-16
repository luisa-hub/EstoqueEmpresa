using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueEmpresa.ConsoleApp
{
    public static class Globals
    {
        public const int CAPACIDADE_REGISTROS = 100;

        public static int[] numerosEquipamento = new int[CAPACIDADE_REGISTROS];
        public static string[] nomeEquipamento = new string[CAPACIDADE_REGISTROS];
        public static double[] precosEquipamento = new double[CAPACIDADE_REGISTROS];
        public static DateTime[] datasFabricacaoEquipamento = new DateTime[CAPACIDADE_REGISTROS];
        public static string[] fabricantesEquipamento = new string[CAPACIDADE_REGISTROS];

        public static string[] tituloChamado = new string[CAPACIDADE_REGISTROS];
        public static string[] descricaoChamado = new string[CAPACIDADE_REGISTROS];
        public static int[] equipamentoChamado = new int[CAPACIDADE_REGISTROS];
        public static DateTime[] dataChamado = new DateTime[CAPACIDADE_REGISTROS];

    }
}
