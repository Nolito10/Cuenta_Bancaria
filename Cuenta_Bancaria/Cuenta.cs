using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cuenta_Bancaria
{
    internal class Cuenta
    {
        //Campos Estaticos

        public static int CantidadDeCuentas { get; set; }
        public static double TotalDinero { get; set; }

        //Propiedades

        private string _NumeroCuenta;
        private string _Titular;
        private double _Saldo;
        private string _Estado;

        //Getters y Setters
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }


        public double Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }


        public string Titular
        {
            get { return _Titular; }
            set { _Titular = value; }
        }


        public string NumeroCuenta
        {
            get { return _NumeroCuenta; }
            set { _NumeroCuenta = value; }
        }

        //Propiedad de Navegacion

        public List<Transaccion> Transacciones { get; set; }

        //Constructores

        public Cuenta()
        {

        }
        public Cuenta(string NumeroCuenta, string Titular, double Saldo, string Estado)
        {

            this._NumeroCuenta = NumeroCuenta;
            this._Titular = Titular;
            this._Saldo = Saldo;
            this._Estado = Estado;

            CantidadDeCuentas++; //incrementa cantidad de cuenta
            TotalDinero += Saldo; //Sumar saldo al total
            Transacciones = new List<Transaccion>();

        }

        //Metodos

        public void Depositar(double Monto)
        {
            Saldo += Monto;
            TotalDinero += Monto;
            Transacciones.Add(new Transaccion("Deposito", Monto));
        }

        public void Retirar(double Monto)
        {
            if (Saldo >= Monto)
            {
                Saldo -= Monto;
                TotalDinero -= Monto;
                Transacciones.Add(new Transaccion("Retiro", -Monto));
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para retirar esa cantidad");
            }
        }

        public void Inactivar()
        {
            Estado = "Inactivo";
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Numero de Cuenta:{NumeroCuenta}");
            Console.WriteLine($"Titular:{Titular}");
            Console.WriteLine($"Saldo:{Saldo}");
            Console.WriteLine($"Estado:{Estado}");

            Console.WriteLine("Transacciones");
            foreach (var transaccion in Transacciones)
            {
                Console.WriteLine(transaccion);
            }
        }
               List<Cuenta> Cuentas = new List<Cuenta>();
        public void MostrarInformacion(string numeroCuenta)
        {
           
            //Buscar Cuenta
            Cuenta cuenta = Cuentas.Find(c => c.NumeroCuenta == numeroCuenta);
            if (cuenta != null)
            {
                cuenta.MostrarInformacion();
            }
            else
            {
                Console.WriteLine("No se encontró cuenta con ese número.");
            }

        }
        public void Transferir(string numeroOrigen, string numeroDestino, double monto, string descripcion)
        {
            // Buscar cuentas
            Cuenta origen = Cuentas.Find(c => c.NumeroCuenta == numeroOrigen);
            Cuenta destino = Cuentas.Find(c => c.NumeroCuenta == numeroDestino);



            if (origen != null && destino != null)
            {
                origen.Retirar(monto);
                origen.Transacciones.Add(new Transaccion($"Transferencia a {destino.NumeroCuenta}", -monto));

                destino.Depositar(monto);
                destino.Transacciones.Add(new Transaccion($"Transferencia desde {origen.NumeroCuenta}", monto));
            }
            else
            {
                Console.WriteLine("No se encontró alguna de las cuentas.");
            }
        }

        public void Transferir(string numeroOrigen, string numeroDestino, double monto)
        {
            Transferir(numeroOrigen, numeroDestino, monto, "Transferencia entre cuentas");
        }

        public static void MostrarInfoBanco()
        {
            Console.WriteLine($"Cantidad de Cuentas: {CantidadDeCuentas}");
            Console.WriteLine($"Total Dinero: {TotalDinero}");
        }
    }

    public class Transaccion
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }


        public Transaccion(string descripcion, double monto)
        {
            Codigo = Guid.NewGuid().ToString();
            Descripcion = descripcion;
            Fecha = DateTime.Now;
            Monto = monto;
        }
        public override string ToString()
        {
            return ($"{Codigo} {Descripcion} {Fecha} {Monto}");
        }

    }



}

