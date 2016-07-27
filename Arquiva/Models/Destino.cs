using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arquiva.Models
{
    public class Destino
    {
        #region Fields
        private const string PATTERN = "{0};{1}";

        #endregion

        #region Propriedades

        public string Local { get; set; }

        public string Nome { get; set; }
        #endregion

        #region + RecuperarRegistro
        public string RecuperarRegistro()
        {
            return String.Format(PATTERN,
                Local,
                Nome
                );
        }

        #endregion

        #region + Criar
        public static Destino Criar(string linha)
        {

            if (String.IsNullOrWhiteSpace(linha))
                return null;

            var campos = linha.Split(';');

            if (campos.Length < 2)
                return null;

            return new Destino
            {
                Local = String.IsNullOrWhiteSpace(campos[1])? "Interno": campos[0],
                Nome = String.IsNullOrWhiteSpace(campos[1]) ? campos[0] : campos[1],
            };
        }

        #endregion

    }
}
