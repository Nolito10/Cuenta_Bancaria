using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cuenta_Bancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cuenta> Cuentas = new List<Cuenta>();

            while (true)
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Crear nueva cuenta");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Transferir dinero");
                Console.WriteLine("5. Mostrar información de una cuenta");
                Console.WriteLine("6. Mostrar información del banco");
                Console.WriteLine("7. Salir");
                Console.Write("Por favor, selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Introduce el número de cuenta: ");
                            string numeroCuenta = Console.ReadLine();
                            Console.Write("Introduce el nombre del titular: ");
                            string titular = Console.ReadLine();
                            Console.Write("Introduce el saldo inicial: ");
                            if (double.TryParse(Console.ReadLine(), out double saldoInicial))
                            {
                                Cuentas.Add(new Cuenta(numeroCuenta, titular, saldoInicial, "Activa"));
                                Console.WriteLine("Cuenta creada exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida para saldo inicial.");
                            }
                            break;
                        case 2:
                            Console.Write("Introduce el número de cuenta: ");
                            string numeroDeposito = Console.ReadLine();
                            Cuenta cuentaDeposito = Cuentas.Find(c => c.NumeroCuenta == numeroDeposito);
                            if (cuentaDeposito != null)
                            {
                                Console.Write("Introduce la cantidad a depositar: ");
                                if (double.TryParse(Console.ReadLine(), out double montoDeposito))
                                {
                                    cuentaDeposito.Depositar(montoDeposito);
                                    Console.WriteLine($"Depósito de {montoDeposito:C} realizado con éxito en la cuenta {numeroDeposito}.");
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad inválida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontró la cuenta con ese número.");
                            }
                            break;
                            
                        case 3:
                            Console.Write("Introduce el número de cuenta: ");
                            string numeroRetiro = Console.ReadLine();
                            Cuenta cuentaRetiro = Cuentas.Find(c => c.NumeroCuenta == numeroRetiro);
                            if (cuentaRetiro != null)
                            {
                                Console.Write("Introduce la cantidad a retirar: ");
                                if (double.TryParse(Console.ReadLine(), out double montoRetiro))
                                {
                                    cuentaRetiro.Retirar(montoRetiro);
                                    Console.WriteLine($"Retiro de {montoRetiro:C} realizado con éxito en la cuenta {numeroRetiro}.");
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad inválida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontró la cuenta con ese número.");
                            }
                            break;
                        case 4:
                            Console.Write("Introduce el número de cuenta de origen: ");
                            string numeroOrigen = Console.ReadLine();
                            Console.Write("Introduce el número de cuenta de destino: ");
                            string numeroDestino = Console.ReadLine();
                            Cuenta cuentaOrigen = Cuentas.Find(c => c.NumeroCuenta == numeroOrigen);
                            Cuenta cuentaDestino = Cuentas.Find(c => c.NumeroCuenta == numeroDestino);
                            if (cuentaOrigen != null && cuentaDestino != null)
                            {
                                Console.Write("Introduce la cantidad a transferir: ");
                                if (double.TryParse(Console.ReadLine(), out double montoTransferencia))
                                {
                                    cuentaOrigen.Transferir(numeroOrigen, numeroDestino, montoTransferencia);
                                    Console.WriteLine($"Transferencia de {montoTransferencia:C} realizada de la cuenta {numeroOrigen} a la cuenta {numeroDestino}.");
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad inválida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontró alguna de las cuentas.");
                            }
                            break;
                        case 5:
                            Console.Write("Introduce el número de cuenta: ");
                            string numeroBuscado = Console.ReadLine();
                            Cuenta cuentaBuscada = Cuentas.Find(c => c.NumeroCuenta == numeroBuscado);
                            if (cuentaBuscada != null)
                            {
                                cuentaBuscada.MostrarInformacion();
                            }
                            else
                            {
                                Console.WriteLine("No se encontró la cuenta con ese número.");
                            }
                            break;
                        case 6:
                            Cuenta.MostrarInfoBanco();
                            break;
                        case 7:
                            Console.WriteLine("¡Hasta luego!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, selecciona una opción del menú.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número correspondiente a una opción del menú.");
                }

                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}