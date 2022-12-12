using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Common
{

    public class Program
    {
        //METODO SUMA
        static int Suma(int num1, int num2)
        {
            return num1 + num2;
        }
        //METODO RESTA
        static int Resta(int num1, int num2)
        {
            return num1 - num2;
        }
        //METODO PRODUCTO
        static int Producto(int num1, int num2)
        {
            return num1 * num2;
        }
        //METODO DIVISION
        static decimal Division(decimal num1, decimal num2)
        {
            return num1 / num2;
        }
        public static void Main()
        {


            Console.WriteLine("Ingrese la operación que desee realizar, expresado en letra minúscula");
            string operacion = Console.ReadLine();
            if (operacion == "Suma")
            {
                Console.WriteLine("1º Número, 2º Número");
                int resultSuma = Suma(Convert.ToInt32(Console.ReadLine()), (Convert.ToInt32(Console.ReadLine())));
                Console.WriteLine("El resultado es: {0}", resultSuma);
            }
            else if (operacion == "Resta")
            {
                //Console.WriteLine("ERROR");
                Console.WriteLine("1º Número, 2º Número");
                int resultResta = Resta(Convert.ToInt32(Console.ReadLine()), (Convert.ToInt32(Console.ReadLine())));
                Console.WriteLine("El resultado es: {0}", resultResta);
            }
            else if (operacion == "Producto")
            {
                Console.WriteLine("1º Número, 2º Número");
                int resultProducto = Producto(Convert.ToInt32(Console.ReadLine()), (Convert.ToInt32(Console.ReadLine())));
                Console.WriteLine("El resultado es: {0}", resultProducto);

            }
            else if (operacion == "Division")
            {
                Console.WriteLine("1º Número, 2º Número");
                decimal resultDivision = Division(Convert.ToInt32(Console.ReadLine()), (Convert.ToInt32(Console.ReadLine())));
                Console.WriteLine("El resultado es: {0}", resultDivision);

            }
            else
            {
                Console.WriteLine("Ingresaste una operación no válida para esta calculadora");
            }

        }
    }
    }