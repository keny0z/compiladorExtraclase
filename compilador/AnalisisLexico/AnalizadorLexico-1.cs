using compilador.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compilador.AnalisisLexico
{
    class AnalizadorLexico
    {
        private int Puntero;
        private int NumeroLineaActual;
        private Linea LineaActual;
        private String CaracterActual;
        private String Lexema;
        private String ResultadoAnaLex;
        private int EstadoActual;
        private bool ContinuarAnalisis;

        public AnalizadorLexico()
        {
            CargarNuevaLinea();
        }

        private void CargarNuevaLinea()
        {
            NumeroLineaActual = NumeroLineaActual + 1;
            LineaActual = Cache.ObtenerCache().ObtenerLinea(NumeroLineaActual);
            NumeroLineaActual = LineaActual.ObtenerNumero(); //Asegura que se quede en el fin de archivo
            Puntero = 0;

        }

        private void DevolverPuntero()
        {
            if (Puntero > 1)
            {
                Puntero = Puntero - 1;
            }
        }

        private void AvanzarPuntero()
        {
            Puntero = Puntero + 1;
        }

        private void LeerSiguienteCaracter()
        {
            if (LineaActual.esFinArchivo())
            {
                CaracterActual = LineaActual.ObtenerContenido();
            }
            else if (Puntero > LineaActual.ObtenerLongitud()-1)
            {
                Puntero = LineaActual.ObtenerLongitud() + 1;
                CaracterActual = "@FL@";
            }
            else
            {
                CaracterActual = LineaActual.ObtenerContenido().Substring(Puntero, 1); //oBTIENE LA PARTE DE LA CADENA DEL PUNTERO Y OBTIENE UN CARACTER
                AvanzarPuntero();
            }
        }

        public String DevolverResultado()
        {
            return ResultadoAnaLex; 
        }

        public void Reiniciar()
        {
            Lexema = "";
            CaracterActual = "";
            EstadoActual = 0;
            ContinuarAnalisis = true;
        }

        public void ReiniciarComentario()
        {
           
            EstadoActual = 34;
            ContinuarAnalisis = true;
        }

        public String DevolverComponenteLexico()
        {
            Reiniciar();
            while (ContinuarAnalisis)
            {
                switch (EstadoActual)
                {
                    case 0:
                        ProcesarEstado0();
                        break;
                    case 1:
                        ProcesarEstado1();
                        break;
                    case 2:
                        ProcesarEstado2();
                        break;
                    case 3:
                        ProcesarEstado3();
                        break;
                    case 4:
                        ProcesarEstado4();
                        break;
                    case 5:
                        ProcesarEstado5();
                        break;
                    case 6:
                        ProcesarEstado6();
                        break;
                    case 7:
                        ProcesarEstado7();
                        break;
                    case 8:
                        ProcesarEstado8();
                        break;
                    case 9:
                        ProcesarEstado9();
                        break;
                    case 10:
                        ProcesarEstado10();
                        break;
                    case 11:
                        ProcesarEstado11();
                        break;
                    case 12:
                        ProcesarEstado12();
                        break;
                    case 13:
                        ProcesarEstado13();
                        break;
                    case 14:
                        ProcesarEstado14();
                        break;
                    case 15:
                        ProcesarEstado15();
                        break;
                    case 16:
                        ProcesarEstado16();
                        break;
                    case 17:
                        ProcesarEstado17();
                        break;
                    case 18:
                        ProcesarEstado18();
                        break;
                    case 19:
                        ProcesarEstado19();
                        break;
                    case 20:
                        ProcesarEstado20();
                        break;
                    case 21:
                        ProcesarEstado21();
                        break;
                    case 22:
                        ProcesarEstado22();
                        break;
                    case 23:
                        ProcesarEstado23();
                        break;
                    case 24:
                        ProcesarEstado24();
                        break;
                    case 25:
                        ProcesarEstado25();
                        break;
                    case 26:
                        ProcesarEstado26();
                        break;
                    case 27:
                        ProcesarEstado27();
                        break;
                    case 28:
                        ProcesarEstado28();
                        break;
                    case 29:
                        ProcesarEstado29();
                        break;
                    case 30:
                        ProcesarEstado30();
                        break;
                    case 31:
                        ProcesarEstado31();
                        break;
                    case 32:
                        ProcesarEstado32();
                        break;
                    case 33:
                        ProcesarEstado33();
                        break;
                    case 34:
                        ProcesarEstado34();
                        break;
                    case 35:
                        ProcesarEstado35();
                        break;
                    case 36:
                        ProcesarEstado36();
                        break;
                    case 37:
                        ProcesarEstado37();
                        break;
                }

            }
            return Lexema;
        }

        private void ProcesarEstado0()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();

            if (EsLetra() || EsGuionBajo() || EsSimboloPesos())
            {
                EstadoActual = 4;
                FormarLexema();
            }
            else if (EsDigito())
            {
                EstadoActual = 1;
                FormarLexema();
            }
            else if (EsSignoSuma())
            {
                EstadoActual = 5;
                FormarLexema();
            }
            else if (EsSignoResta())
            {
                EstadoActual = 6;
                FormarLexema();
            }
            else if (EsSignoMultiplicacion())
            {
                EstadoActual = 7;
                FormarLexema();
            }
            else if (EsSignoDivision())
            {
                EstadoActual = 8;
                FormarLexema();
            }
            else if (EsSignoModulo())
            {
                EstadoActual = 9;
                FormarLexema();
            }
            else if (EsParentesisAbre())
            {
                EstadoActual = 10;
                FormarLexema();
            }
            else if (EsParentesisCierra())
            {
                EstadoActual = 11;
                FormarLexema();
            }
            else if (LineaActual.esFinArchivo())
            {
                EstadoActual = 12;
                FormarLexema();
            }
            else if (EsSignoIgual())
            {
                EstadoActual = 19;
                FormarLexema();
            }
            else if (EsSignoMenor())
            {
                EstadoActual = 20;
                FormarLexema();
            }
            else if (EsSignoMayor())
            {
                EstadoActual = 21;
                FormarLexema();
            }
            else if (EsDosPuntos())
            {
                EstadoActual = 22;
                FormarLexema();
            }
            else if (EsSignoAdmiracion())
            {
                EstadoActual = 30;
                FormarLexema();
            }
            else if (EsFinLinea())
            {
                EstadoActual = 13;
            }
            else
            {
                EstadoActual = 18;
            }
        }

        private void ProcesarEstado1()
        {
            LeerSiguienteCaracter();

            if (EsDigito())
            {
                EstadoActual = 1;
                FormarLexema();
            }
            else if (EsComa())
            {
                EstadoActual = 2;
                FormarLexema();
            }
            else
            {
                EstadoActual = 14;
            }
        }

        private void ProcesarEstado2()
        {
            LeerSiguienteCaracter();

            if (EsDigito())
            {
                EstadoActual = 3;
                FormarLexema();
            }
            else
            {
                EstadoActual = 17;
            }

        }

        private void ProcesarEstado3()
        {
            LeerSiguienteCaracter();

            if (EsDigito())
            {
                EstadoActual = 3;
                FormarLexema();
            }
            else
            {
                EstadoActual = 15;
            }
        }

        private void ProcesarEstado4()
        {
            LeerSiguienteCaracter();

            if (EsLetra() || EsGuionBajo() || EsSimboloPesos() || EsDigito())
            {
                EstadoActual = 4;
                FormarLexema();
            }
            else
            {
                EstadoActual = 16;
            }
        }

        private void ProcesarEstado5()
        {
            String Categoria = "SUMA";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema +")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado6()
        {

            String Categoria = "RESTA";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

            

        private void ProcesarEstado7()
        {

            String Categoria = "MULTIPLICACION";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }
        private void ProcesarEstado8()
        {
            LeerSiguienteCaracter();
            if (EsSignoMultiplicacion())
            {
                EstadoActual = 34;
                FormarLexema();
            }
            else if (EsSignoDivision())
            {
                EstadoActual = 36;
                FormarLexema();
            }
            else
            {
                EstadoActual = 33;
            }
        }

        private void ProcesarEstado9()
        {
            String Categoria = "MODULO";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado10()
        {
            String Categoria = "PARENTESIS ABRE";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado11()
        {
            String Categoria = "PARENTESIS CIERRA";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado12()
        {
            String Categoria = "FIN DE ARCHIVO (EOF)";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado13()
        {
            CargarNuevaLinea();
            Reiniciar();
        }

        private void ProcesarEstado14()
        {
            DevolverPuntero();

            String Categoria = "NUMERO ENTERO";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado15()
        {
            DevolverPuntero();

            String Categoria = "NUMERO DECIMAL";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }



        private void ProcesarEstado16()
        {
            DevolverPuntero();

            String Categoria = "IDENTIFICADOR";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado17()
        {

            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            MessageBox.Show("Error en linea "+NumeroLinea  + ": Decimal con el caracter " + "'"+CaracterActual+"'" + " no reconocido, no es permitido");
            DevolverPuntero();
            ContinuarAnalisis = false;
            //throw new Exception("Decimal con el caracter:" + CaracterActual + ", No es permitido...");
        }

        private void ProcesarEstado18()
        {
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            MessageBox.Show("Error en linea " + NumeroLinea + ": Símbolo " +"'"+CaracterActual+"'"+ " no reconocido, no permitido");
            ContinuarAnalisis = false;
            //throw new Exception("Símbolo:" + CaracterActual + " No es permitido..."); 
        }

        private void ProcesarEstado19()
        {
            String Categoria = "IGUAL QUE";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado20()
        {
            LeerSiguienteCaracter();

            if (EsSignoMayor())
            {
                EstadoActual = 23;
                FormarLexema();
            }
            else if (EsSignoIgual())
            {
                EstadoActual = 24;
                FormarLexema();
            }
            else
            {
                EstadoActual = 25;
            }

        }

        private void ProcesarEstado21()
        {
            LeerSiguienteCaracter();

            if (EsSignoIgual())
            {
                EstadoActual = 26;
                FormarLexema();
            }
            else
            {
                EstadoActual = 27;

            }

        }

        private void ProcesarEstado22()
        {
            LeerSiguienteCaracter();

            if (EsSignoIgual())
            {
                EstadoActual = 28;
                FormarLexema();
            }
            else
            {
                EstadoActual = 29;

            }

        }

        private void ProcesarEstado23()
        {
            String Categoria = "DIFERENTE QUE";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado24()
        {
            String Categoria = "MENOR O IGUAL QUE";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado25()
        {
            DevolverPuntero();

            String Categoria = "MENOR QUE";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado26()
        {
            String Categoria = "MAYOR O IGUAL QUE";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado27()
        {
            DevolverPuntero();

            String Categoria = "MAYOR QUE";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado28()
        {
            String Categoria = "ASIGNACION";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado29()
        {
            int NumeroLinea = NumeroLineaActual;
            DevolverPuntero();
            //throw new Exception("Asignación de igualdad no válida con el caracter:" + CaracterActual + ", No es permitida.");
            MessageBox.Show("Error en linea " + NumeroLinea + ": Asignación con el caracter " + "'" + CaracterActual + "'" + " no válida");
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado30()
        {
            LeerSiguienteCaracter();

            if (EsSignoIgual())
            {
                EstadoActual = 31;
                FormarLexema();
            }
            else
            {
                EstadoActual = 32;

            }

        }

        private void ProcesarEstado31()
        {
            String Categoria = "DIFERENTE QUE";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado32()
        {
            int NumeroLinea = NumeroLineaActual;
            DevolverPuntero();
            //throw new Exception("Asignación diferencia no válida con el caracter:" + CaracterActual + ", No es permitida.");
            MessageBox.Show("Error en linea " + NumeroLinea + ": Asignación de diferencia con el caracter " + "'" + CaracterActual + "'" + " no válida");
            ContinuarAnalisis = false;

        }

        private void ProcesarEstado33()
        {
            DevolverPuntero();

            String Categoria = "DIVISION";
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            MessageBox.Show("Categoria:" + Categoria + ", Lexema:" + Lexema);
            ResultadoAnaLex = ResultadoAnaLex + "(" + Categoria + "," + Lexema + ")";
            ContinuarAnalisis = false;
        }
        private void ProcesarEstado34()
        {
            LeerSiguienteCaracter();

            if (EsSignoMultiplicacion())
            {
                EstadoActual = 35;
            }
            else if (EsFinLinea())
            {
                EstadoActual = 37;
            }
        }

        private void ProcesarEstado35()
        {
            LeerSiguienteCaracter();

            if (EsSignoMultiplicacion())
            {
                EstadoActual = 35;
            }
            else if (!EsSignoMultiplicacion() && !EsSignoDivision())
            {
                EstadoActual = 34;

            }
            else if (EsSignoDivision())
            {
                EstadoActual = 0;
            }
            else if (EsFinLinea())
            {
                EstadoActual = 37;
            }
        }

        private void ProcesarEstado36()
        {
            LeerSiguienteCaracter();

            if (!EsFinLinea())
            {
                EstadoActual = 36;
            }
            else
            {
                EstadoActual = 13;
            }
        }


        private void ProcesarEstado37()
        {
            CargarNuevaLinea();
            ReiniciarComentario();
        }

        private bool EsFinLinea()
        {
            return "@FL@".Equals(CaracterActual);
        }

        private void FormarLexema()
        {
            Lexema = Lexema + CaracterActual;
        }

        private void DevorarEspacioBlanco()
        {
            String Blanco = " ";

            while (Blanco.Equals(CaracterActual))
            {
                LeerSiguienteCaracter();
            }
        }

        private bool EsLetra()
        {
            return Char.IsLetter(CaracterActual.ToCharArray()[0]);

        }

        private bool EsGuionBajo()
        {
            return "_".Equals(CaracterActual);
        }

        private bool EsSimboloPesos()
        {
            return "$".Equals(CaracterActual);
        }

        private bool EsDigito()
        {
            return Char.IsDigit(CaracterActual.ToCharArray()[0]);

        }

        private bool EsSignoSuma()
        {
            return "+".Equals(CaracterActual);
        }

        private bool EsSignoResta()
        {
            return "-".Equals(CaracterActual);
        }

        private bool EsSignoMultiplicacion()
        {
            return "*".Equals(CaracterActual);
        }

        private bool EsSignoDivision()
        {
            return "/".Equals(CaracterActual);
        }

        private bool EsSignoModulo()
        {
            return "%".Equals(CaracterActual);
        }

        private bool EsParentesisAbre()
        {
            return "(".Equals(CaracterActual);
        }

        private bool EsParentesisCierra()
        {
            return ")".Equals(CaracterActual);
        }

        private bool EsSignoMayor()
        {
            return ">".Equals(CaracterActual);
        }

        private bool EsSignoMenor()
        {
            return "<".Equals(CaracterActual);
        }

        private bool EsSignoIgual()
        {
            return "=".Equals(CaracterActual);
        }

        private bool EsDosPuntos()
        {
            return ":".Equals(CaracterActual);
        }

        private bool EsSignoAdmiracion()
        {
            return "!".Equals(CaracterActual);
        }

        private bool EsComa()
        {
            return ",".Equals(CaracterActual);
        }

     
    }
}
