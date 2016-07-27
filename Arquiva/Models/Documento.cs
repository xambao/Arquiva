using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arquiva.Models
{
    public class Documento
    {

        #region Fields
        private const string PATTERN = "{0};{1};{2};{3};{4};{5};";

        #endregion

        #region Propriedades
        public int Id { get; set; }

        public string REG { get; set; }

        public string REGMasked { get; set; }

        public int NumPasta { get; set; }

        public int NumDocumento { get; set; }

        public string Assunto { get; set; }

        #endregion

        #region + RecuperarRegistro
        public string RecuperarRegistro()
        {
            return String.Format(PATTERN,
                Id,
                REG,
                REGMasked,
                NumPasta,
                NumDocumento,
                Assunto.Trim().Length > 100 ? Assunto.Trim().Substring(0, 96) + " ..." : Assunto.Trim()
                );
        }

        #endregion


        #region + Criar
        public static Documento Criar(string linha)
        {

            if (String.IsNullOrWhiteSpace(linha))
                return null;

            var campos = linha.Split(';');

            if (campos.Length < 5)
                return null;

            return new Documento
            {
                Id = TryParseInt(campos[0]),
                REG = campos[1],
                REGMasked = campos[2],
                NumPasta = TryParseInt(campos[3]),
                NumDocumento = TryParseInt(campos[4]),
                Assunto = campos.Length > 5 ? campos[5] : String.Empty
            };
        }

        #endregion

        #region - TryParseInt
        private static int TryParseInt(string str)
        {
            int value;
            if (!Int32.TryParse(str, out value))
                value = 0;
            return value;
        }
        #endregion
    }
}
