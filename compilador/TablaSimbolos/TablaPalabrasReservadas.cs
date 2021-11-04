using compilador.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compilador.TablaSimbolos
{
    public class TablaPalabrasReservadas
    {
        private Dictionary<string, ComponenteLexico> TablaReservadas = new Dictionary<string, ComponenteLexico>();
        private Dictionary<string, List<ComponenteLexico>> Tabla = new Dictionary<string, List<ComponenteLexico>>();
        private static TablaPalabrasReservadas INSTANCIA = new TablaPalabrasReservadas();

        private TablaPalabrasReservadas()
        {
           
        }

        public static TablaPalabrasReservadas ObtenerInstancia()
        {
            return INSTANCIA;
        }
        private void Inicializar()
        {
            TablaReservadas.Add("IN", ComponenteLexico.Crear("IN", Categoria.IN,Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("OUT", ComponenteLexico.Crear("OUT", Categoria.OUT, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("INIT", ComponenteLexico.Crear("INIT", Categoria.INIT, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("OFF", ComponenteLexico.Crear("OFF", Categoria.OFF, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("ON", ComponenteLexico.Crear("ON", Categoria.ON, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("INCREMENTAR", ComponenteLexico.Crear("INCREMENTAR", Categoria.INCREMENTAR, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("DECREMENTAR", ComponenteLexico.Crear("DECREMENTAR", Categoria.DECREMENTAR, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("SHUTDOWN", ComponenteLexico.Crear("SHUTDOWN", Categoria.SHUTDOWN, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("GET_TEMPERATURE", ComponenteLexico.Crear("GET_TEMPERATURE", Categoria.GET_TEMPERATURE, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("K", ComponenteLexico.Crear("K", Categoria.KELVIN, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("F", ComponenteLexico.Crear("F", Categoria.FAHRENHEIT, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("C", ComponenteLexico.Crear("C", Categoria.CENTIGRADOS, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("R", ComponenteLexico.Crear("R", Categoria.RANKINE, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("-00-", ComponenteLexico.Crear("-00-", Categoria.APAGADO, Tipo.PALABRA_RESERVADA));
            TablaReservadas.Add("-11-", ComponenteLexico.Crear("-11-", Categoria.ENCENDIDO, Tipo.PALABRA_RESERVADA));

        }
        private void ValidarSiComponenteEsPalabraReservada(ComponenteLexico Componente)
        {
            if(Componente != null && TablaReservadas.ContainsKey(Componente.ObtenerLexema())){
                ComponenteLexico PalabraReservada = TablaReservadas[Componente.ObtenerLexema()];
                Componente = ComponenteLexico.Crear(PalabraReservada.ObtenerLexema(), PalabraReservada.ObtenerCategoria(), Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Tipo.PALABRA_RESERVADA);
            }
        } 

        public void Limpiar()
        {
            Tabla.Clear();
        }

        private List<ComponenteLexico> ObtenerSimbolo(string Simbolo)
        {
            if (!Tabla.ContainsKey(Simbolo))
            {
                Tabla.Add(Simbolo, new List<ComponenteLexico>());
            }
            return Tabla[Simbolo];
        }

        public void Agregar(ComponenteLexico Componente)
        {
            ValidarSiComponenteEsPalabraReservada(Componente);

            if (Componente != null && Tipo.PALABRA_RESERVADA.Equals(Componente.ObtenerTipo()))
            {
                ObtenerSimbolo(Componente.ObtenerLexema()).Add(Componente);
            }
        }

        public List<ComponenteLexico> ObtenerComponentes()
        {
            List<ComponenteLexico> Componentes = new List<ComponenteLexico>();

            foreach (List<ComponenteLexico> Lista in Tabla.Values)
            {
                Componentes.AddRange(Lista);
            }
            return Tabla.Values.SelectMany(componente => componente).ToList();
        }
    }
}
