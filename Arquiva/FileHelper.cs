using Arquiva.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Arquiva
{
    public class FileHelper 
    {

        #region Fields
        private const string FILE_ARQUIVADO = "Arquiva.dat";
        private const string FILE_ARQUIVADO_BKP = "Arquiva.bkp";

        private const string FILE_PESSOA = "Pessoa.dat";
        private const string FILE_PESSOA_BKP = "Pessoa.bkp";

        private const string FILE_DESTINO = "Destino.dat";
        private const string FILE_DESTINO_BKP = "Destino.bkp";

        private const string FILE_TRAMITE = "Tramite.dat";
        private const string FILE_TRAMITE_BKP = "Tramite.bkp";
        #endregion


        #region RecuperarArquivados
        public static List<Documento> RecuperarArquivados()
        {
            var lista = new List<Documento>();

            if (!File.Exists(FILE_ARQUIVADO))
            {
                if (!File.Exists(FILE_ARQUIVADO_BKP))
                    return lista;

                File.Copy(FILE_ARQUIVADO_BKP, FILE_ARQUIVADO);
            }

            using (var sr = File.OpenText(FILE_ARQUIVADO))
            {
                while (sr.Peek() >= 0)
                {
                    var doc = Documento.Criar(sr.ReadLine());
                    if (doc == null)
                        continue;

                    lista.Add(doc);
                }
            }

            return lista;
        }
        
        #endregion

        #region SalvarArquivados
        public static bool SalvarArquivados(List<Documento> lista)
        {

            if (File.Exists(FILE_ARQUIVADO))
                File.Copy(FILE_ARQUIVADO, FILE_ARQUIVADO_BKP, true);

            try
            {
                if (File.Exists(FILE_ARQUIVADO))
                    File.Delete(FILE_ARQUIVADO);

                using (var sw = File.CreateText(FILE_ARQUIVADO))
                {
                    foreach (var reg in lista)
                    {
                        if (reg == null)
                            continue;

                        sw.WriteLine(reg.RecuperarRegistro());
                    }
                }
            }
            catch
            {
                if (File.Exists(FILE_ARQUIVADO_BKP))
                    File.Copy(FILE_ARQUIVADO_BKP, FILE_ARQUIVADO, true);

                return false;
            }

            return true;
        }
        
        #endregion


        #region RecuperarPessoas
        public static List<Pessoa> RecuperarPessoas()
        {
            var lista = new List<Pessoa>();

            if (!File.Exists(FILE_PESSOA))
            {
                if (!File.Exists(FILE_PESSOA_BKP))
                    return lista;

                File.Copy(FILE_PESSOA_BKP, FILE_PESSOA);
            }

            using (var sr = File.OpenText(FILE_PESSOA))
            {
                while (sr.Peek() >= 0)
                {
                    var doc = Pessoa.Criar(sr.ReadLine());
                    if (doc == null)
                        continue;

                    lista.Add(doc);
                }
            }

            return lista;
        }

        #endregion

        #region SalvarPessoas
        public static bool SalvarPessoas(List<Pessoa> lista)
        {

            if (File.Exists(FILE_PESSOA))
                File.Copy(FILE_PESSOA, FILE_PESSOA_BKP, true);

            try
            {
                if (File.Exists(FILE_PESSOA))
                    File.Delete(FILE_PESSOA);

                using (var sw = File.CreateText(FILE_PESSOA))
                {
                    foreach (var reg in lista)
                    {
                        if (reg == null)
                            continue;

                        sw.WriteLine(reg.RecuperarRegistro());
                    }
                }
            }
            catch
            {
                if (File.Exists(FILE_PESSOA_BKP))
                    File.Copy(FILE_PESSOA_BKP, FILE_PESSOA, true);

                return false;
            }

            return true;
        }

        #endregion



        #region RecuperarDestinos
        public static List<Destino> RecuperarDestinos()
        {
            var lista = new List<Destino>();

            if (!File.Exists(FILE_DESTINO))
            {
                if (!File.Exists(FILE_DESTINO_BKP))
                    return lista;

                File.Copy(FILE_DESTINO_BKP, FILE_DESTINO);
            }

            using (var sr = File.OpenText(FILE_DESTINO))
            {
                while (sr.Peek() >= 0)
                {
                    var doc = Destino.Criar(sr.ReadLine());
                    if (doc == null)
                        continue;

                    lista.Add(doc);
                }
            }

            return lista;
        }

        #endregion

        #region SalvarDestinos
        public static bool SalvarDestinos(List<Destino> lista)
        {

            if (File.Exists(FILE_DESTINO))
                File.Copy(FILE_DESTINO, FILE_DESTINO_BKP, true);

            try
            {
                if (File.Exists(FILE_DESTINO))
                    File.Delete(FILE_DESTINO);

                using (var sw = File.CreateText(FILE_DESTINO))
                {
                    foreach (var reg in lista)
                    {
                        if (reg == null)
                            continue;

                        sw.WriteLine(reg.RecuperarRegistro());
                    }
                }
            }
            catch
            {
                if (File.Exists(FILE_DESTINO_BKP))
                    File.Copy(FILE_DESTINO_BKP, FILE_DESTINO, true);

                return false;
            }

            return true;
        }

        #endregion


        #region RecuperarTramites
        public static List<Tramite> RecuperarTramites()
        {
            var lista = new List<Tramite>();

            if (!File.Exists(FILE_TRAMITE))
            {
                if (!File.Exists(FILE_TRAMITE_BKP))
                    return lista;

                File.Copy(FILE_TRAMITE_BKP, FILE_TRAMITE);
            }

            using (var sr = File.OpenText(FILE_TRAMITE))
            {
                while (sr.Peek() >= 0)
                {
                    var doc = Tramite.Criar(sr.ReadLine());
                    if (doc == null)
                        continue;

                    lista.Add(doc);
                }
            }

            return lista;
        }

        #endregion

        #region SalvarTramites
        public static bool SalvarTramites(List<Tramite> lista)
        {

            if (File.Exists(FILE_TRAMITE))
                File.Copy(FILE_TRAMITE, FILE_TRAMITE_BKP, true);

            try
            {
                if (File.Exists(FILE_TRAMITE))
                    File.Delete(FILE_TRAMITE);

                using (var sw = File.CreateText(FILE_TRAMITE))
                {
                    foreach (var reg in lista)
                    {
                        if (reg == null)
                            continue;

                        sw.WriteLine(reg.RecuperarRegistro());
                    }
                }
            }
            catch
            {
                if (File.Exists(FILE_TRAMITE_BKP))
                    File.Copy(FILE_TRAMITE_BKP, FILE_TRAMITE, true);

                return false;
            }

            return true;
        }

        #endregion

    }
}
